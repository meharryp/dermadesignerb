using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace DermaDesigner.Controls {
	class DComboBox : Panel {
		private static string respath = "resources/DComboBox/";

		public static int numOfThisType = 0;
		public override string type { get { return "DComboBox"; } }

		private static Color whitecolor = Color.FromArgb(255, 241, 241, 241);
		private static SolidBrush blackBrush = new SolidBrush(Color.Black);
		private static SolidBrush insideBrush = new SolidBrush(whitecolor);
		private static Pen outlinePen = new Pen(blackBrush);

		public static new Image thumbnail = Derma.LoadImage(respath + "dcombobox_32.png");

		// lua vars
		List<string> items = new List<string>();
		public bool enableHorizontal = false;
		public bool enableVerticalScrollbar = true;
		public string onMousePressedFunc = "function() end";
		public bool selectMultiple = false;

		#region Properties
		// long freaking editor name
		[Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor)), CategoryAttribute("Lua Attributes"), DescriptionAttribute("The items the DComboBox will show")]
		public List<string> Items {
			get { return items; }
			set { items = value; Derma.Repaint(); }
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("When true, enables a horizontal scrollbar")]
		public bool EnableHorizontal {
			get { return enableHorizontal; }
			set { enableHorizontal = value; }
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("When true, enables a vertical scrollbar")]
		public bool EnableVerticalScrollbar {
			get { return enableVerticalScrollbar; }
			set { enableVerticalScrollbar = value; }
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("When true, the user can select multiple items in this control")]
		public bool SelectMultiple {
			get { return selectMultiple; }
			set { selectMultiple = value; }
		}

		[Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor)), CategoryAttribute("Lua Attributes"), DescriptionAttribute("The function to be run when the mouse is pressed on this control")]
		public string OnMousePressed {
			get { return onMousePressedFunc; }
			set { onMousePressedFunc = value; }
		}
		#endregion Properties

		public DComboBox(int xpos, int ypos) : base(xpos, ypos, 60, 70) {
			numOfThisType++;

			if (!this.SetVarName(type + numOfThisType.ToString()))
				while (!this.SetVarName(type + numOfThisType.ToString() + Derma.RandomString(4, false)))
					continue;
		}

		public override void PopulateProperties() {
			Derma.prop.propertyGrid.SelectedObject = this;
		}

		public static void Register() {
			Derma.RegisterPanel("DComboBox", typeof(DComboBox), thumbnail);
		}

		public override void ControlPaint(object sender, System.Windows.Forms.PaintEventArgs p) {
			// if we have a parent, we don't want to draw outside them
			if (this.parent) {
				int a, b, c, d;
				Point relpos = this.GetPosRelativeToParentNonRecursive();
				a = (this.x >= parent.x) ? this.x : parent.x;
				b = (this.y >= parent.y) ? this.y : parent.y;
				c = (this.x + this.width > parent.x + parent.width) ? parent.width - relpos.X : this.width;
				d = (this.y + this.height > parent.y + parent.height) ? parent.height - relpos.Y : this.height;
				p.Graphics.Clip = new Region(new Rectangle(a, b, c, d));
			} else
				p.Graphics.Clip = new Region(new Rectangle(this.x, this.y, this.width, this.height));

			p.Graphics.FillRectangle(insideBrush, this.x + 1, this.y + 1, this.width - 2, this.height - 2);
			p.Graphics.DrawRectangle(outlinePen, this.x, this.y, this.width - 1, this.height - 1);

			int offset = 6;
			foreach (string item in items) {
				p.Graphics.DrawString(item, Derma.DefaultFont, blackBrush, this.x + 5, this.y + offset);
				offset += 20;
			}
		}

		public override string GenerateLua() {
			StringBuilder code = new StringBuilder("\n");
			code.AppendFormat("{0} = vgui.Create('DComboBox')\n", this.varname);

			if (this.parent != null)
				code.AppendFormat("{0}:SetParent({1})\n", this.varname, parent.varname);

			code.AppendFormat("{0}:SetSize({1})\n", this.varname, this.GetSizeCode());

			if (this.ShouldCenter())
				code.AppendFormat("{0}:Center()\n", this.varname);
			else
				code.AppendFormat("{0}:SetPos({1})\n", this.varname, this.GetPosCode());

			if (this.enableHorizontal)
				code.AppendFormat("{0}:EnableHorizontal(true)\n", this.varname);
			else
				code.AppendFormat("{0}:EnableHorizontal(false)\n", this.varname);

			if (this.enableVerticalScrollbar)
				code.AppendFormat("{0}:EnableVerticalScrollbar(true)\n", this.varname);
			else
				code.AppendFormat("{0}:EnableVerticalScrollbar(false)\n", this.varname);

			if (this.onMousePressedFunc.Trim() != "")
				code.AppendFormat("{0}.OnMousePressed = {1}\n", this.varname, this.onMousePressedFunc);

			if (items.Count > 0)
				code.Append("\n");

			foreach(string item in items)
				code.AppendFormat("{0}:AddItem('{1}')\n", this.varname, item);

			if (items.Count > 0)
				code.Append("\n");

			if (!this.selectMultiple)
				code.AppendFormat("{0}:SetMultiple(false)\n", this.varname);

			return code.ToString();
		}
	}
}
