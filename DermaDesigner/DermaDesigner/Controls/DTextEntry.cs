using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace DermaDesigner {
	class DTextEntry : Panel {
		private static string respath = "resources/DTextEntry/";

		// painting resources
		public static new Image thumbnail = Derma.LoadImage(respath + "dtextentry_32.png");
		private static Color whitecolor = Color.FromArgb(255, 241, 241, 241);
		private static SolidBrush blackBrush = new SolidBrush(Color.Black);
		private static SolidBrush insideBrush = new SolidBrush(whitecolor);
		private static Pen outlinePen = new Pen(blackBrush);

		// class vars
		public static int numOfThisType = 0;
		public override string type { get { return "DTextEntry"; } }

		private SizeF textSize = Derma.GetTextSize("");

		// Lua variables
		public string text = "";
		public string onEnterFunc = "function() end";

		#region Properties
		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets the text initially displayed in the DTextEntry")]
		public string Text {
			get { return text; }
			set {
				this.text = value;
				this.textSize = Derma.GetTextSize(this.text);
				Derma.Repaint();
			}
		}

        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), CategoryAttribute("Lua Attributes"), DescriptionAttribute("The function to be run when the enter button is pressed")]
		public string OnEnter {
			get { return onEnterFunc; }
			set { onEnterFunc = value; }
		}
		#endregion Properties

		public DTextEntry(int x, int y)	: base(x, y, 50, 20) {
			numOfThisType++;

			if (!this.SetVarName(type + numOfThisType.ToString()))
				while (!this.SetVarName(type + numOfThisType.ToString() + Derma.RandomString(4, false)))
					continue;
		}

		public override void PopulateProperties() {
			Derma.prop.propertyGrid.SelectedObject = this;
		}

		public override void ControlPaint(object sender, System.Windows.Forms.PaintEventArgs p) {
			if (this.parent)
				p.Graphics.Clip = new Region(new Rectangle(parent.x, parent.y, parent.width, parent.height));
			else
				p.Graphics.Clip = new Region(new Rectangle(this.x, this.y, this.width, this.height));

			p.Graphics.FillRectangle(insideBrush, this.x, this.y, this.width, this.height);
			p.Graphics.DrawRectangle(outlinePen, this.x, this.y, this.width - 1, this.height - 1);

			if (parent) {
				int a, b, c, d;
				Point relpos = this.GetPosRelativeToParentNonRecursive();
				a = (this.x >= parent.x) ? this.x : parent.x;
				b = (this.y >= parent.y) ? this.y : parent.y;
				c = (this.x + this.width > parent.x + parent.width) ? parent.width - relpos.X : this.width;
				d = (this.y + this.height > parent.y + parent.height) ? parent.height - relpos.Y : this.height;
				p.Graphics.Clip = new Region(new Rectangle(a, b, c, d));
			}

			p.Graphics.DrawString(this.text, Derma.DefaultFont, blackBrush, this.x + 3, (this.y + (this.height / 2)) - (this.textSize.Height / 2));
		}

		public override string GenerateLua() {
			StringBuilder code = new StringBuilder("\n");
			code.AppendFormat("{0} = vgui.Create('DTextEntry')\n", this.varname);

			if (this.parent != null)
				code.AppendFormat("{0}:SetParent({1})\n", this.varname, parent.varname);

			code.AppendFormat("{0}:SetSize({1})\n", this.varname, this.GetSizeCode());

			if (this.ShouldCenter())
				code.AppendFormat("{0}:Center()\n", this.varname);
			else
				code.AppendFormat("{0}:SetPos({1})\n", this.varname, this.GetPosCode());

			code.AppendFormat("{0}:SetText('{1}')\n", this.varname, this.text);

			if (!this.visible)
				code.AppendFormat("{0}:SetVisible(false)\n", this.varname);

			if (this.onEnterFunc.Trim() != "")
				code.AppendFormat("{0}.OnEnter = {1}\n", this.varname, this.onEnterFunc);

			return code.ToString();
		}

		public static void Register() {
			Derma.RegisterPanel("DTextEntry", typeof(DTextEntry), thumbnail);
		}
	}
}
