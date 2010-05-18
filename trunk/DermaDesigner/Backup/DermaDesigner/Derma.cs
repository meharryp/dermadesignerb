using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace DermaDesigner {
    public class Derma {
        private static Form workspace;							// the form in which new panels will appear
		public static PropertiesWindow prop;					// the form that will display the selected control's properties
		public static Toolbox toolbox;							// the global variable to store the toobox form in
        private static IPanel Selected;							// The currently selected panel
        private static List<IPanel> panels = new List<IPanel>();	// A list of all the panels
		private static List<EventHandler> TickEvents = new List<EventHandler>(); // The container for custom Tick events
		private static Timer Tick = new Timer();				// Tick timer
		private static SolidBrush highlighter = new SolidBrush(Color.LimeGreen);
		private static float nextz = 0;
		private static List<Control> currentControls;

		// For the big logo
		static Image logo_256 = Derma.LoadImage("resources/logo_256.png");
		static Graphics g = Graphics.FromImage(logo_256);
		static ColorMatrix colMatrix = new ColorMatrix();
		static ImageAttributes imAttr = new ImageAttributes();

		public static IPanel GetSelected() { return Selected; }
		public static void SetSelected(IPanel p) {
			if (Selected != p) {
				currentControls = p.PopulateProperties();
				Selected = p;
				ResizeGrip.host = p;
				p.OnSelect();
			}
		}
		public static List<IPanel> GetPanels() { return panels; }
		public static Form GetWorkspace() { return workspace; }

		// font variables
		public static System.Drawing.Text.PrivateFontCollection fontCollection = new System.Drawing.Text.PrivateFontCollection();
		public static FontFamily DefaultFontFamily;
		public static Font DefaultFont;
		public static SolidBrush fontBrush = new SolidBrush(Color.LightGray);

		// TODO: Make all mouse handlers check if the control is hidden via p.hidden

		#region Init
		public static void Init(Form mainform, PropertiesWindow prp) {
            workspace = mainform;
			prop = prp;

			Tick.Interval = 20;
			Tick.Tick += TickEvent;
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
		}
		#endregion Init

		#region New
		// Like vgui.Create in lua
		public static object New(string name) { return New(name, 50, 50); } // No default arguments, so we have to make this overload
		public static object New(string name, int x, int y) {
			if (workspace == null) {
				MessageBox.Show("Error: Derma not initialized or the active derma window has closed.\n\nExiting.", "Fatal error");
				Application.Exit();
				return false;
			}

			switch (name) {
				case "DFrame":
					DFrame p = new DFrame(x, y);
					p.z = nextz;
					nextz++;
					panels.Insert(0, p);
					return p;
				default:
					MessageBox.Show("Derma control \"" + name + "\" not found.\n\nExiting.", "Fatal error");
					Application.Exit();
					return false;
			}
		}
		#endregion New

		#region LoadImage
		public static Image LoadImage(string filename) {
			Image img;
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
			foreach (IPanel p in panels) {
				if (MouseIsOverPanel(p))
					return true;
			}
			return false;
		}
		#endregion MouseIsOverAnyPanel

		#region MouseIsOverPanel
		public static bool MouseIsOverPanel(IPanel p) {
			Point pos = GetRelativeMousePos();
			if (pos.X >= p.x && pos.X <= p.x + p.width && pos.Y >= p.y && pos.Y <= p.y + p.height)
				return true;

			return false;
		}
		#endregion MouseIsOverPanel

		#region GetPanelsMouseIsOver
		public static List<IPanel> GetPanelsMouseIsOver() {
			List<IPanel> panellist = new List<IPanel>();
			foreach (IPanel p in panels) {
				if (MouseIsOverPanel(p))
					panellist.Add(p);
			}
			return panellist;
		}
		#endregion GetPanelsMouseIsOver

		#region Repaint
		public static void Repaint() {
			// which one is better?
			//workspace.Invalidate();
			workspace.Refresh();
		}
		#endregion Repaint

		#region ResortPanelsByZ
		public static void ResortPanelsByZ() {
			var sorted = from p in panels orderby p.z descending select p;
			List<IPanel> newlist = sorted.ToList<IPanel>();
			panels = newlist;
		}
		#endregion ResortPanelsByZ

		#region Paint
		static private void Paint(object sender, PaintEventArgs e) {
			// Paint the large logo
			e.Graphics.DrawImage(logo_256, new Rectangle(workspace.Width - logo_256.Width - 24, 16 + 24, logo_256.Width, logo_256.Height), 0, 0, logo_256.Width, logo_256.Height, GraphicsUnit.Pixel, imAttr);

			// Do the panels in reverse order to draw the one with the highest z index first
			// because we add new panels as index 0 of the panels list, so they get the mouse click events first
			for (int i = panels.Count - 1; i >= 0; i--) {
				IPanel p = panels[i];
				if (!p.hidden) {
					if (Selected == p) {
						Rectangle region = new Rectangle(p.x - 1, p.y - 1, p.width + 2, p.height + 2);
						e.Graphics.Clip = new Region(region);
						e.Graphics.FillRectangle(highlighter, region);
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

		#region MouseHandlers
		private static void MouseClick(object sender, MouseEventArgs e) {
            foreach (IPanel p in panels) {
                if (e.X >= p.x && e.X <= p.x + p.width && e.Y >= p.y && e.Y <= p.y + p.height && p.MouseClickHandler != null) {
                    p.MouseClickHandler(p, e);
                    break;
                }
            }
        }

        private static void MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e) {
            foreach (IPanel p in panels) {
                if (e.X >= p.x && e.X <= p.x + p.width && e.Y >= p.y && e.Y <= p.y + p.height && p.MouseDoubleClickHandler != null) {
                    p.MouseDoubleClickHandler(p, e);
                    break;
                }
            }
        }

        private static void MouseDown(object sender, MouseEventArgs e) {
            foreach (IPanel p in panels) {
				if (ResizeGrip.Resize_MouseDown(sender, e)) break;
				SelectedItem_MouseHandler(sender, e);
				if (!p.isLocked && p == GetSelected() && e.Button == MouseButtons.Left && MouseIsOverPanel(p)) {
					p.dragOffsetX = e.X - p.x;
					p.dragOffsetY = e.Y - p.y;
					p.isDragging = true;
				}
                if (e.X >= p.x && e.X <= p.x + p.width && e.Y >= p.y && e.Y <= p.y + p.height && p.MouseDownHandler != null) {
                    p.MouseDownHandler(p, e);
                    break;
                }
            }
        }

        private static void MouseUp(object sender, MouseEventArgs e) {
			foreach (IPanel p in panels) p.isDragging = false;
            foreach (IPanel p in panels) {
                if (e.X >= p.x && e.X <= p.x + p.width && e.Y >= p.y && e.Y <= p.y + p.height && p.MouseUpHandler != null) {
                    p.MouseUpHandler(p, e);
                    break;
                }
            }
        }

        private static void MouseMove(object sender, MouseEventArgs e) {
			foreach (IPanel p in panels) {
                if (e.X >= p.x && e.X <= p.x + p.width && e.Y >= p.y && e.Y <= p.y + p.height && p.MouseMoveHandler != null) {
                    p.MouseMoveHandler(p, e);
                    break;
                }
            }
        }

        private static void MouseWheel(object sender, MouseEventArgs e) {
			foreach (IPanel p in panels) {
                if (e.X >= p.x && e.X <= p.x + p.width && e.Y >= p.y && e.Y <= p.y + p.height && p.MouseWheelHandler != null) {
                    p.MouseWheelHandler(p, e);
                    break;
                }
            }
		}

		// to set the selected panel
		static void SelectedItem_MouseHandler(object sender, MouseEventArgs e) {
			if (e.Button != MouseButtons.Left) return;
			foreach (IPanel p in panels) {
				if (e.X >= p.x && e.X <= p.x + p.width && e.Y >= p.y && e.Y <= p.y + p.height) {
					SetSelected(p);
					Repaint();
					break;
				}
			}
		}

		// To handle the dragging of panels
		private static void PanelDrag(object sender, MouseEventArgs e) {
			foreach (IPanel p in panels) {
				if (p.centered)
					p.Center();
				if (!ResizeGrip.IsResizing() && p.isDragging && !p.centered) {
					// if predrag returns true, move the panel
					if (p.PreDrag(e.X - p.dragOffsetX, e.Y - p.dragOffsetY)) {
						p.SetPos(e.X - p.dragOffsetX, e.Y - p.dragOffsetY);
						if (p.XBox != null) p.XBox.Text = p.x.ToString();
						if (p.YBox != null) p.YBox.Text = p.y.ToString();
						p.PostDrag();
						Repaint();
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

		#region ClearProperties
		public static void ClearProperties() {
			if (currentControls == null) return;
			foreach (Control c in currentControls) {
				prop.Controls.Remove(c);
			}
		}
		#endregion ClearProperties
	}
}
