using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.IO;

namespace DermaDesigner {
    public class Derma {
        public static DProf Profiler;
        private static Form workspace;							// the form in which new panels will appear
		public static PropertiesWindow prop;					// the form that will display the selected control's properties
		public static Toolbox toolbox;							// the global variable to store the toobox form in
		public static List<string> panelTypes = new List<string>(); // A list of valid panel types
        private static Panel Selected;							// The currently selected panel
        private static List<Panel> panels = new List<Panel>();// A list of all the panels
		private static List<EventHandler> TickEvents = new List<EventHandler>(); // The container for custom Tick events
		private static Timer Tick = new Timer();				// Tick timer
		private static SolidBrush greenhighlighter = new SolidBrush(Color.LimeGreen);
		private static SolidBrush pinkhighlighter = new SolidBrush(Color.HotPink);
		private static float nextz = 0;
		private static Dictionary<string, Type> typeDict = new Dictionary<string, Type>();
		public static FindPanelByVar findpanelwindow;
		private static List<Panel> alreadyGenerated = new List<Panel>();

		// For the big logo
		static Image logo_256 = Derma.LoadImage("resources/logo_256.png");
		static Graphics g = Graphics.FromImage(logo_256);
		static ColorMatrix colMatrix = new ColorMatrix();
		static ImageAttributes imAttr = new ImageAttributes();

		public static Panel GetSelected() { return Selected; }
		public static void SetSelected(Panel p) {
			if (Selected != p) {
				p.PopulateProperties();
				Selected = p;
				ResizeGrip.host = p;
				p.OnSelect();
			}
		}
		public static List<Panel> GetPanels() { return panels; }
		public static Form GetWorkspace() { return workspace; }

		// font variables
		public static System.Drawing.Text.PrivateFontCollection fontCollection = new System.Drawing.Text.PrivateFontCollection();
		public static FontFamily DefaultFontFamily;
		public static Font DefaultFont;
		public static SolidBrush fontBrush = new SolidBrush(Color.LightGray);
        public static DateTime lastPaint = DateTime.Now;
		// TODO: Make all mouse handlers check if the control is hidden via p.hidden

        public static bool NeedsRefresh = false;

		#region Init
		public static void Init(Form mainform, PropertiesWindow prp, Toolbox tb) {
            workspace = mainform;
			prop = prp;
			toolbox = tb;

			toolbox.controlPanel.LargeImageList = new ImageList();
			toolbox.controlPanel.LargeImageList.ImageSize = new Size(32, 32);

			Tick.Interval = 20;
			Tick.Tick += TickEvent;
            Tick.Tick += new EventHandler(RepaintTick);
			Tick.Start();

			// for big logo
			colMatrix.Matrix33 = .2F;
			imAttr.SetColorMatrix(colMatrix);

			// For panel dragging
			workspace.MouseMove += PanelDrag;

			// Draw all the panels
			workspace.Paint += Paint;

			// Draw the resizer thing on the active panel
			workspace.Paint += ResizeGrip.Paint;

			// Resizer mouse events
			workspace.MouseUp += ResizeGrip.Resize_MouseUp;
			workspace.MouseMove += ResizeGrip.Resize_MouseMove;

            // Create our mouse event handlers for derma controls
            workspace.MouseClick += MouseClick;
            workspace.MouseDoubleClick += MouseDoubleClick;
            workspace.MouseDown += MouseDown;
            workspace.MouseMove += MouseMove;
            workspace.MouseUp += MouseUp;
            workspace.MouseWheel += MouseWheel;

			// Set up the "Default" font
			fontCollection.AddFontFile("resources/defaultFont.ttf");
			DefaultFontFamily = fontCollection.Families[0];
			DefaultFont = new Font(DefaultFontFamily, 6);
            DSave.SetEnvironment("Untitled.ddproj");
		}
		#endregion Init

		#region New
		// Like vgui.Create in lua
		public static Panel New(string name) { return New(name, 50, 50); } // No default arguments in C#, so we have to make this overload
		public static Panel New(string name, int x, int y) {
			if (workspace == null) {
				MessageBox.Show("Error: Derma not initialized or the active derma window has closed.\n\nExiting.", "Fatal error");
				Application.Exit();
				return null;
			}

			if (!panelTypes.Contains(name)) {
				MessageBox.Show("Derma control \"" + name + "\" not found.", "Invalid panel type");
				return null;
			}

			Type t = typeDict[name];

			ConstructorInfo constructor = t.GetConstructor(new Type[] { typeof(int), typeof(int) });

			if (constructor == null) {
				MessageBox.Show("Derma control \"" + name + "\" not created. No appropriate constructor existed.", "Invalid panel constructor");
				return null;
			}

			Panel p = (Panel)constructor.Invoke(new object[] { x, y });
			p.z = nextz;
			nextz++;
			panels.Insert(0, p);
			return p;
		}
		#endregion New

		#region ToScreenPercent
		public static float ToScreenPercent(bool x, float num) {
			if (x)
				return (float)Math.Round(((num / workspace.ClientSize.Width) * 100), 1);
			else {
				return (float)Math.Round(((num / workspace.ClientSize.Height) * 100), 1);
			}
		}
		#endregion ToScreenPercent

		#region FromScreenPercent
		public static float FromScreenPercent(bool x, float num) {
			if (x)
				return ((num / 100) * workspace.ClientSize.Width);
			else
				return ((num / 100) * workspace.ClientSize.Height);
		}
		#endregion FromScreenPercent

		#region RegisterPanel
		public static void RegisterPanel(string name, Type t, Image thumbnail) {
			panelTypes.Add(name);
			typeDict[name] = t;

			ListViewItem l = new ListViewItem(name);
			toolbox.controlPanel.LargeImageList.Images.Add(thumbnail);
			l.ImageIndex = toolbox.controlPanel.LargeImageList.Images.Count - 1;

			toolbox.controlPanel.Items.Add(l);
		}
		#endregion RegisterPanel

		#region GenerateLua
		public static string GenerateLuaSinglePanel(Panel p) {
			StringBuilder s = new StringBuilder();

			if (!alreadyGenerated.Contains(p)) {
				s.Append(p.GenerateLua());
				alreadyGenerated.Add(p);
			}

			foreach (Panel pan in p.children)
				if (!alreadyGenerated.Contains(pan))
					s.Append(GenerateLuaSinglePanel(pan));

			return s.ToString();
		}

		public static string GenerateLua() {
			StringBuilder s = new StringBuilder("\n");

			foreach (Panel p in panels)
				if (!p.global)
					s.Append("local " + p.varname + "\n");

			foreach (Panel p in panels)
				if (!p.hasParent && !p.parent)
					s.Append(GenerateLuaSinglePanel(p));

			foreach (Panel p in panels)
				s.Append(GenerateLuaSinglePanel(p));

			alreadyGenerated.Clear();

			return s.ToString();
		}
		#endregion GenerateLua

		#region LoadImage
		public static Image LoadImage(string filename) {
			return LoadImage(filename, false);
		}

		public static Image LoadImage(string filename, bool abspath) {
			Image img;
			if (!abspath)
				filename = Application.StartupPath + "\\" + filename;

			try {
				img = Image.FromFile(filename);
				return img;
			} catch (Exception e) {
				MessageBox.Show("Error loading image from file \"" + filename + "\" : " + e.ToString() + ".\n\nExiting.", "Fatal error");
				Derma.GetWorkspace().Close();
				Application.Exit();
			}

			return null;
		}
		#endregion LoadImage

		#region GetRelativeMousePos
		public static Point GetRelativeMousePos() {
			return workspace.PointToClient(Control.MousePosition);
		}

		public static Point GetRelativeMousePos(int x, int y) {
			return workspace.PointToClient(new Point(x, y));
		}
		#endregion GetRelativeMousePos

		#region IsMouseOverArea
		public static bool IsMouseOverArea(int x, int y, int w, int h) {
			Point pos = GetRelativeMousePos();
			if (pos.X >= x && pos.X <= x + w && pos.Y >= y && pos.Y <= y + h)
				return true;

			return false;
		}
		#endregion IsMouseOverArea

		#region MouseIsOverAnyPanel
		public static bool MouseIsOverAnyPanel() {
			foreach (Panel p in panels) {
				if (MouseIsOverPanel(p))
					return true;
			}
			return false;
		}
		#endregion MouseIsOverAnyPanel

		#region MouseIsOverPanel
		public static bool MouseIsOverPanel(Panel p) {
			Point pos = GetRelativeMousePos();
			if (pos.X >= p.x && pos.X <= p.x + p.width && pos.Y >= p.y && pos.Y <= p.y + p.height)
				return true;

			return false;
		}
		#endregion MouseIsOverPanel

		#region GetPanelsMouseIsOver
		public static List<Panel> GetPanelsMouseIsOver() {
			List<Panel> panellist = new List<Panel>();
			foreach (Panel p in panels) {
				if (MouseIsOverPanel(p))
					panellist.Add(p);
			}
			return panellist;
		}
		#endregion GetPanelsMouseIsOver

		#region GetHighlightedPanel
		public static Panel GetHighlightedPanel() {
			foreach (Panel p in panels)
				if (p.highlighted)
					return p;

			return null;
		}
		#endregion GetHighlightedPanel

		#region Repaint

        public static bool CanRepaint()
        {
            double millisecs = (DateTime.Now - lastPaint).TotalMilliseconds;
            if (millisecs >= 1000/120) // This levels out to about 60fps. Interval = 1000/(FPS*2)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public static void Repaint() {
			if(Profiler == null){Profiler=new DProf("Derma.Repaint");}
            if (CanRepaint())
            {
                Profiler.Start();
                workspace.Refresh();
                Profiler.End();
                ((Main)workspace)._DebugLabelMain.Text = Profiler.GetSpew();
                lastPaint = DateTime.Now;
                NeedsRefresh = false;
            }else
            {
                NeedsRefresh = true;
            }
            
		}
        public static void RepaintTick(object s, EventArgs e)
        {
            if (CanRepaint() && NeedsRefresh)
            {
                Repaint();
            }
        }
		#endregion Repaint

		#region ResortPanelsByZ
		public static void ResortPanelsByZ() {
			var sorted = from p in panels orderby p.z descending select p;
			List<Panel> newlist = sorted.ToList<Panel>();
			panels = newlist;
		}
		#endregion ResortPanelsByZ

		#region Paint
		static private void Paint(object sender, PaintEventArgs e) {
			// Paint the large logo
			e.Graphics.DrawImage(logo_256, new Rectangle(workspace.Width - logo_256.Width - 24, 16 + 24, logo_256.Width, logo_256.Height), 0, 0, logo_256.Width, logo_256.Height, GraphicsUnit.Pixel, imAttr);

			// Draw the grid
			GUI.Grid.Paint(sender, e);

			// Do the panels in reverse order to draw the one with the highest z index first
			// because we add new panels as index 0 of the panels list, because they should get the mouse click events first
			for (int i = panels.Count - 1; i >= 0; i--) {
				Panel p = panels[i];
				if (!p.hidden) {
					if (Selected == p) {
						Rectangle region = new Rectangle(p.x - 1, p.y - 1, p.width + 2, p.height + 2);
						e.Graphics.Clip = new Region(region);
						e.Graphics.FillRectangle(greenhighlighter, region);
					}

					if (p.highlighted) {
						Rectangle region = new Rectangle(p.x - 1, p.y - 1, p.width + 2, p.height + 2);
						e.Graphics.Clip = new Region(region);
						e.Graphics.FillRectangle(pinkhighlighter, region);
					}
					p.ControlPaint(sender, e);
				}
			}
		}
		#endregion Paint

		#region Tick event
		private static void TickEvent(object sender, EventArgs e) {
			foreach (EventHandler ev in TickEvents)
				ev(sender, e);
		}

		public static bool AddTickEvent(EventHandler ev) {
			if (TickEvents.Contains(ev))
				return false;

			TickEvents.Add(ev);
			return true;
		}

		public static bool RemoveTickEvent(EventHandler ev) {
			if (!TickEvents.Contains(ev))
				return false;

			TickEvents.Remove(ev);
			return true;
		}
		#endregion Tick event

		#region RefreshProperties
		public static void RefreshProperties() {
			if (prop.propertyGrid != null && Selected != null)
				prop.propertyGrid.Refresh();
		}
		#endregion RefreshProperties

		#region MouseHandlers
		private static void MouseClick(object sender, MouseEventArgs e) {
            foreach (Panel p in panels) {
                if (Derma.MouseIsOverPanel(p) && p.MouseClickHandler != null && !p.hidden) {
                    p.MouseClickHandler(p, e);
                    break;
                }
            }
        }

        private static void MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e) {
            foreach (Panel p in panels) {
				if (Derma.MouseIsOverPanel(p) && p.MouseDoubleClickHandler != null) {
                    p.MouseDoubleClickHandler(p, e);
                    break;
                }
            }
        }

        private static void MouseDown(object sender, MouseEventArgs e) {
            foreach (Panel p in panels) {
				if (ResizeGrip.Resize_MouseDown(sender, e)) break;
				SelectedItem_MouseHandler(sender, e);
				if (!p.locked && p == GetSelected() && e.Button == MouseButtons.Left && MouseIsOverPanel(p)) {
					p.dragOffsetX = e.X - p.x;
					p.dragOffsetY = e.Y - p.y;
					p.dragging = true;
				}
				if (Derma.MouseIsOverPanel(p) && p.MouseDownHandler != null) {
                    p.MouseDownHandler(p, e);
                    break;
                }
            }
        }

        private static void MouseUp(object sender, MouseEventArgs e) { 
			bool doneAlready = false;
            foreach (Panel p in panels) {
				if (Derma.MouseIsOverPanel(p) && !doneAlready && p.MouseUpHandler != null) {
                    p.MouseUpHandler(p, e);
					doneAlready = true;
                }

				if (p.dragging) {
					p.dragging = false;
					Panel h = GetHighlightedPanel();

					if (h) {
						p.SetParent(h);
						p.z = nextz;
						nextz++;
						ResortPanelsByZ();
						RefreshProperties();
						h.highlighted = false;
					}
				}
            }
        }

        private static void MouseMove(object sender, MouseEventArgs e) {
			bool alreadyCalled = false;
			foreach (Panel p in panels) {
				if (Derma.MouseIsOverPanel(p)) {
					if (!alreadyCalled && p.MouseMoveHandler != null) {
						p.MouseMoveHandler(p, e);
						alreadyCalled = true;
					}
                } else
					p.highlighted = false;
            }
        }

        private static void MouseWheel(object sender, MouseEventArgs e) {
			foreach (Panel p in panels) {
				if (Derma.MouseIsOverPanel(p) && p.MouseWheelHandler != null) {
                    p.MouseWheelHandler(p, e);
                    break;
                }
            }
		}

		// to set the selected panel
		static void SelectedItem_MouseHandler(object sender, MouseEventArgs e) {
			if (e.Button != MouseButtons.Left) return;
			foreach (Panel p in panels) {
				if (Derma.MouseIsOverPanel(p)) {
					SetSelected(p);
					Repaint();
					break;
				}
			}
		}

		// To handle the dragging of panels
		private static void PanelDrag(object sender, MouseEventArgs e) {
			foreach (Panel p in panels) {
				if (p.centered)
					p.Center();

				if (!ResizeGrip.IsResizing() && p.dragging && !p.centered) {
					// if predrag returns true, move the panel
					if (p.PreDrag(e.X - p.dragOffsetX, e.Y - p.dragOffsetY)) {
						p.SetPos(e.X - p.dragOffsetX, e.Y - p.dragOffsetY, !VirtualKeys.IsKeyPressed(VirtualKeyStates.VK_TAB));
						p.PostDrag();
						RefreshProperties();
						
						if (!VirtualKeys.IsKeyPressed(VirtualKeyStates.VK_CONTROL))
							continue;

						List<Panel> panelsOver = GetPanelsMouseIsOver();
						foreach (Panel pan in panelsOver) {
							if (pan != p && pan.canBeParent == true && p.parent != pan && p.canBeChild == true && (!p.parent || p.parent.z < pan.z)) {
								if (p.hasParent && p.parent) {
									if (p.parent.z < pan.z && pan.parent != p) {
										pan.highlighted = true;
										break;
									}
								} else {
									pan.highlighted = true;
									break;
								}
							}
						}
					}
				}
			}
		}
		#endregion MouseHandlers

		#region RandomString
		public static string RandomString(int size, bool lowerCase) {
			StringBuilder builder = new StringBuilder();
			Random random = new Random();
			char ch;
			for(int i=0; i<size; i++) {
				ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))) ;
				builder.Append(ch);
			}
			if(lowerCase)
				return builder.ToString().ToLower();

			return builder.ToString();
		}
		#endregion RandomString

		#region GetTextSize
		public static SizeF GetTextSize(string text) {
			SizeF size = workspace.CreateGraphics().MeasureString(text, DefaultFont);

			return size;
		}
		#endregion GetTextSize

		#region DrawRoundedRectangleOutlined
		public static void DrawRoundedRectangleOutlined(Graphics gfxObj, Pen penObj, float X, float Y, float RectWidth, float RectHeight, float CornerRadius) {
			RectWidth--;
			RectHeight--;
			System.Drawing.Drawing2D.GraphicsPath gfxPath = new System.Drawing.Drawing2D.GraphicsPath();
			gfxPath.AddLine(X + CornerRadius, Y, X + RectWidth - (CornerRadius * 2), Y);
			gfxPath.AddArc(X + RectWidth - (CornerRadius * 2), Y, CornerRadius * 2, CornerRadius * 2, 270, 90);
			gfxPath.AddLine(X + RectWidth, Y + CornerRadius, X + RectWidth, Y + RectHeight - (CornerRadius * 2));
			gfxPath.AddArc(X + RectWidth - (CornerRadius * 2), Y + RectHeight - (CornerRadius * 2), CornerRadius * 2, CornerRadius * 2, 0, 90);
			gfxPath.AddLine(X + RectWidth - (CornerRadius * 2), Y + RectHeight, X + CornerRadius, Y + RectHeight);
			gfxPath.AddArc(X, Y + RectHeight - (CornerRadius * 2), CornerRadius * 2, CornerRadius * 2, 90, 90);
			gfxPath.AddLine(X, Y + RectHeight - (CornerRadius * 2), X, Y + CornerRadius);
			gfxPath.AddArc(X, Y, CornerRadius * 2, CornerRadius * 2, 180, 90);
			gfxPath.CloseFigure();
			gfxObj.DrawPath(penObj, gfxPath);
			gfxPath.Dispose();
		}
		#endregion DrawRoundedRectangleOutlined

		#region DrawRoundedRectangle
		public static void DrawRoundedRectangle(Graphics gfxObj, Pen penObj, float X, float Y, float RectWidth, float RectHeight, float CornerRadius) {
			RectWidth--;
			RectHeight--;
			System.Drawing.Drawing2D.GraphicsPath gfxPath = new System.Drawing.Drawing2D.GraphicsPath();
			gfxPath.AddLine(X + CornerRadius, Y, X + RectWidth - (CornerRadius * 2), Y);
			gfxPath.AddArc(X + RectWidth - (CornerRadius * 2), Y, CornerRadius * 2, CornerRadius * 2, 270, 90);
			gfxPath.AddLine(X + RectWidth, Y + CornerRadius, X + RectWidth, Y + RectHeight - (CornerRadius * 2));
			gfxPath.AddArc(X + RectWidth - (CornerRadius * 2), Y + RectHeight - (CornerRadius * 2), CornerRadius * 2, CornerRadius * 2, 0, 90);
			gfxPath.AddLine(X + RectWidth - (CornerRadius * 2), Y + RectHeight, X + CornerRadius, Y + RectHeight);
			gfxPath.AddArc(X, Y + RectHeight - (CornerRadius * 2), CornerRadius * 2, CornerRadius * 2, 90, 90);
			gfxPath.AddLine(X, Y + RectHeight - (CornerRadius * 2), X, Y + CornerRadius);
			gfxPath.AddArc(X, Y, CornerRadius * 2, CornerRadius * 2, 180, 90);
			gfxPath.FillMode = System.Drawing.Drawing2D.FillMode.Winding;
			gfxPath.CloseFigure();
			gfxObj.DrawPath(penObj, gfxPath);
			gfxObj.FillPath(penObj.Brush, gfxPath);
			gfxPath.Dispose();
		}
		#endregion DrawRoundedRectangle

        #region Clamp
        public static int Clamp(int Val, int Min, int Max)
        {
            if (Val < Min)
            {
                return Min;
            }
            else if (Val > Max)
            {
                return Max;
            }
            return Val;
        }
        public static float Clamp(float Val, float Min, float Max)
        {
            if (Val < Min)
            {
                return Min;
            }
            else if (Val > Max)
            {
                return Max;
            }
            return Val;
        }
        #endregion Clamp
    }
}
