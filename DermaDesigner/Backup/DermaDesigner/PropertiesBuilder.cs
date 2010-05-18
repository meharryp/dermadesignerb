using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DermaDesigner {
	class PropertiesBuilder {
		public static Button CreateButton(string text, int x, int y, int height, int width, EventHandler clickAction) {
			Button b = new Button();
			b.Size = new Size(width, height);
			b.Location = new Point(x, y);
			b.Click += clickAction;
			return b;
		}

		public static Label CreateLabel(string text, int x, int y) {
			Label l = new Label();
			l.Text = text;
			l.AutoSize = true;
			l.Location = new Point(x, y);
			return l;
		}

		public static TextBox CreateTextBox(string text, int x, int y) {
			TextBox t = new TextBox();
			t.Text = text;
			t.Location = new Point(x, y);
			return t;
		}

		public static TextBox CreateTextBox(string text, int x, int y, int width, int height) {
			TextBox t = new TextBox();
			t.Text = text;
			t.Size = new Size(width, height);
			t.Location = new Point(x, y);
			return t;
		}

		public static GroupBox CreateGroupBox(string text, int x, int y, int width, int height) {
			GroupBox g = new GroupBox();
			g.Text = text;
			g.Size = new Size(width, height);
			g.Location = new Point(x, y);
			return g;
		}

		public static CheckBox CreateCheckBox(string text, bool value, int x, int y) {
			CheckBox c = new CheckBox();
			c.Text = text;
			c.Checked = value;
			c.Location = new Point(x, y);
			c.AutoSize = true;
			return c;
		}

		public static List<Control> BuildGenericProperties(Panel p, int y, out Point endPoint, KeyEventHandler varText_EnterKeyDown, KeyEventHandler xText_EnterKeyDown, KeyEventHandler yText_EnterKeyDown, KeyEventHandler widthText_EnterKeyDown, KeyEventHandler heightText_EnterKeyDown) {
			List<Control> plist = new List<Control>();

			Label titleTextLabel = PropertiesBuilder.CreateLabel("Variable name:", 15, 25 + y);
			Derma.prop.Controls.Add(titleTextLabel);
			plist.Add(titleTextLabel);

			TextBox varText = PropertiesBuilder.CreateTextBox(p.varname, titleTextLabel.Location.X + titleTextLabel.Width, titleTextLabel.Location.Y - 3);
			Derma.prop.Controls.Add(varText);
			varText.KeyDown += varText_EnterKeyDown;
			plist.Add(varText);

			GroupBox PosGroupBox = PropertiesBuilder.CreateGroupBox("Position", 15, titleTextLabel.Location.Y + 25, 130, 50);
			Derma.prop.Controls.Add(PosGroupBox);
			plist.Add(PosGroupBox);

			Label xtext = PropertiesBuilder.CreateLabel("X:", 15, 20);
			PosGroupBox.Controls.Add(xtext);

			TextBox xPosBox = PropertiesBuilder.CreateTextBox(p.x.ToString(), 30, 17, 35, 25);
			PosGroupBox.Controls.Add(xPosBox);
			xPosBox.KeyDown += xText_EnterKeyDown;
			xPosBox.BringToFront();

			Label ytext = PropertiesBuilder.CreateLabel("Y:", 70, 20);
			PosGroupBox.Controls.Add(ytext);

			TextBox yPosBox = PropertiesBuilder.CreateTextBox(p.y.ToString(), 85, 17, 35, 25);
			PosGroupBox.Controls.Add(yPosBox);
			yPosBox.KeyDown += yText_EnterKeyDown;
			yPosBox.BringToFront();

			GroupBox SizeGroupBox = PropertiesBuilder.CreateGroupBox("Size", 15, titleTextLabel.Location.Y + 85, 154, 50);
			Derma.prop.Controls.Add(SizeGroupBox);
			plist.Add(SizeGroupBox);

			Label widthLabel = PropertiesBuilder.CreateLabel("Width:", 15, 20);
			SizeGroupBox.Controls.Add(widthLabel);

			TextBox widthTextBox = PropertiesBuilder.CreateTextBox(p.width.ToString(), 51, 17, 25, 35);
			SizeGroupBox.Controls.Add(widthTextBox);
			widthTextBox.KeyDown += widthText_EnterKeyDown;
			widthTextBox.BringToFront();

			Label heightLabel = PropertiesBuilder.CreateLabel("Height:", 80, 20);
			SizeGroupBox.Controls.Add(heightLabel);

			TextBox heightTextBox = PropertiesBuilder.CreateTextBox(p.height.ToString(), 119, 17, 25, 35);
			SizeGroupBox.Controls.Add(heightTextBox);
			heightTextBox.KeyDown += heightText_EnterKeyDown;
			heightTextBox.BringToFront();

			p.XBox = xPosBox;
			p.YBox = yPosBox;
			p.WidthBox = widthTextBox;
			p.HeightBox = heightTextBox;

			endPoint = new Point(SizeGroupBox.Location.X + SizeGroupBox.Width, SizeGroupBox.Location.Y + SizeGroupBox.Height);

			return plist;
		}
	}
}
