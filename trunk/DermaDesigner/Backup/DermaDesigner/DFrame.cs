using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DermaDesigner {
    class DFrame : Panel {
		private static Image topLeftCorner = Derma.LoadImage("resources/dframe_upperleft.png");
		private static Image topRightCorner = Derma.LoadImage("resources/dframe_upperright.png");
		private static Image bottomLeftCorner = Derma.LoadImage("resources/dframe_lowerleft.png");
		private static Image bottomRightCorner = Derma.LoadImage("resources/dframe_lowerright.png");
		private static Image topFiller = Derma.LoadImage("resources/dframe_topfiller.png");
		private static Color wndColor = Color.FromArgb(255, 100, 100, 100);
		private static SolidBrush bgBrush = new SolidBrush(wndColor);

		public static int numOfThisType = 0;
		public new string type = "DFrame";
		public new bool canBeChild = false;

		// Lua variables
		string title = "Untitled DFrame";

        public DFrame(int xpos, int ypos) : base(xpos, ypos, 50, 50) {
			numOfThisType++;

			this.MouseDoubleClickHandler = blah;

			if (!this.SetVarName("DFrame" + numOfThisType.ToString()))
				while (!this.SetVarName("DFrame" + numOfThisType.ToString() + Derma.RandomString(4, false)))
					continue;
		}

		// all controls should implement the PopulateProperties method
		public override List<Control> PopulateProperties() {
			Derma.ClearProperties();

			List<Control> ctrlList = new List<Control>();

			Label ttlLabel = PropertiesBuilder.CreateLabel("Title:", 15, 15);
			Derma.prop.Controls.Add(ttlLabel);
			ctrlList.Add(ttlLabel);

			TextBox ttlTextBox = PropertiesBuilder.CreateTextBox(this.title, ttlLabel.Location.X + ttlLabel.Size.Width, ttlLabel.Location.Y - 3);
			ttlTextBox.KeyDown += titleText_EnterKeyDown;
			Derma.prop.Controls.Add(ttlTextBox);
			ctrlList.Add(ttlTextBox);
			
			Point endPoint;
			ctrlList.AddRange(PropertiesBuilder.BuildGenericProperties(this, 
 																	   ttlLabel.Location.X + 9,
 																	   out endPoint, 
 																	   varText_EnterKeyDown, 
 																	   XTextBox_EnterKeyDown, 
																	   YTextBox_EnterKeyDown, 
																	   WidthTextBox_EnterKeyDown, 
																	   HeightTextBox_EnterKeyDown));

			CheckBox centerCheckBox = PropertiesBuilder.CreateCheckBox("Center", this.centered, 15, endPoint.Y + 15);
			centerCheckBox.CheckedChanged += centerCheckBox_CheckChanged;
			Derma.prop.Controls.Add(centerCheckBox);
			ctrlList.Add(centerCheckBox);

			return ctrlList;
		}

		public override void ControlPaint(object sender, PaintEventArgs p) {
			// every control should set the clip region it wants to draw itself
			// if it doesn't, it'll be the region that was set by the last control that was drawn
			p.Graphics.Clip = new Region(new Rectangle(this.x, this.y, this.width, this.height));

			// Draw the solid grey bg
			p.Graphics.FillRectangle(bgBrush, this.x, this.y + topLeftCorner.Height, this.width, this.height - bottomLeftCorner.Height - topLeftCorner.Height);
			p.Graphics.FillRectangle(bgBrush, this.x + bottomLeftCorner.Width, this.y + this.height - bottomLeftCorner.Height, this.width - (bottomLeftCorner.Width * 2), bottomLeftCorner.Height);
			
			// draw the top left and right corners first
			p.Graphics.DrawImage(topLeftCorner, this.x, this.y);
			p.Graphics.DrawImage(topRightCorner, this.x + this.width - topRightCorner.Width, this.y);

			// draw the bar all the way cross the top
			for (int i = 0; i < this.width / topFiller.Width; i++) {
				if ((this.x + topLeftCorner.Width + (i * topFiller.Width)) + topFiller.Width + 1 > this.x + this.width)
					break;
				p.Graphics.DrawImage(topFiller, this.x + topLeftCorner.Width + (i * topFiller.Width), this.y);
			}

			// draw the bottom two corners
			p.Graphics.DrawImage(bottomLeftCorner, this.x, this.y + this.height - bottomLeftCorner.Height);
			p.Graphics.DrawImage(bottomRightCorner, this.x + this.width - bottomRightCorner.Width, this.y + this.height - bottomRightCorner.Height);

			// Draw the window title
			p.Graphics.DrawString(this.title, Derma.DefaultFont, Derma.fontBrush, this.x + 5, this.y + 6);
		}

		public void blah(object sender, MouseEventArgs e) {
			this.isLocked = !this.isLocked;
			MessageBox.Show(this.isLocked.ToString());
		}

		//////////////////////////////////////////////////////
		// Events for property setters in the properties panel

		private void varText_EnterKeyDown(object sender, KeyEventArgs e) {
			if (e.KeyValue == 13) {
				TextBox t = (TextBox)sender;
				if (this.SetVarName(t.Text))
					Derma.Repaint();
				else {
					MessageBox.Show("Invalid variable name", "Invalid value");
					t.Text = this.varname;
				}
				e.SuppressKeyPress = true;
			}
		}

		private void titleText_EnterKeyDown(object sender, KeyEventArgs e) {
			if (e.KeyValue == 13) {
				TextBox t = (TextBox)sender;
				this.title = t.Text;
				Derma.Repaint();
				e.SuppressKeyPress = true;
			}
		}

		private void XTextBox_EnterKeyDown(object sender, KeyEventArgs e) {
			if (e.KeyValue == 13) {
				TextBox t = (TextBox)sender;
				int newx;
				bool success = Int32.TryParse(t.Text, out newx);
				if (success) {
					this.x = newx;
					Derma.Repaint();
				} else {
					MessageBox.Show("Invalid X value", "Invalid value");
					t.Text = this.x.ToString();
				}
				e.SuppressKeyPress = true;
			}
		}

		private void YTextBox_EnterKeyDown(object sender, KeyEventArgs e) {
			if (e.KeyValue == 13) {
				TextBox t = (TextBox)sender;
				int newy;
				bool success = Int32.TryParse(t.Text, out newy);
				if (success) {
					this.y = newy;
					Derma.Repaint();
				} else {
					MessageBox.Show("Invalid Y value", "Invalid value");
					t.Text = this.y.ToString();
				}
				e.SuppressKeyPress = true;
			}
		}

		private void WidthTextBox_EnterKeyDown(object sender, KeyEventArgs e) {
			if (e.KeyValue == 13) {
				TextBox t = (TextBox)sender;
				int newwidth;
				bool success = Int32.TryParse(t.Text, out newwidth);
				if (success) {
					this.width = newwidth;
					Derma.Repaint();
				} else {
					MessageBox.Show("Invalid width", "Invalid value");
					t.Text = this.width.ToString();
				}
				e.SuppressKeyPress = true;
			}
		}

		private void HeightTextBox_EnterKeyDown(object sender, KeyEventArgs e) {
			if (e.KeyValue == 13) {
				TextBox t = (TextBox)sender;
				int newheight;
				bool success = Int32.TryParse(t.Text, out newheight);
				if (success) {
					this.height = newheight;
					Derma.Repaint();
				} else {
					MessageBox.Show("Invalid height", "Invalid value");
					t.Text = this.height.ToString();
				}
				e.SuppressKeyPress = true;
			}
		}

		private void centerCheckBox_CheckChanged(object sender, EventArgs e) {
			CheckBox c = (CheckBox)sender;
			if (c.Checked) {
				this.centered = true;
				this.Center();
				Derma.Repaint();
			} else {
				this.centered = false;
				Derma.Repaint();
			}
		}
    }
}
