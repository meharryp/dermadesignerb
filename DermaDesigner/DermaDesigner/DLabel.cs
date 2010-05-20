using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace DermaDesigner {
	class DLabel : Panel {
		private static string respath = "resources/DLabel/";

		public static new Image thumbnail = Derma.LoadImage(respath + "dlabel_32.png");

		public static int numOfThisType = 0;
		public override string type { get { return "DLabel"; } }
		public override bool sizable { get { return false; } }
		private SizeF labelSize = Derma.GetTextSize("DLabel");

		public Color color = Color.LightGray;
		public SolidBrush textBrush = new SolidBrush(Color.LightGray);

		// Lua variables
		string text = "DLabel";
		public bool sizetocontents = true;

		#region Properties
		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("The text to display in the DLabel"), Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public string Text {
			get { return text; }
			set {
				this.text = value;
				this.labelSize = Derma.GetTextSize(this.text);
				if (this.sizetocontents)
					this.SetSize((int)this.labelSize.Width, (int)this.labelSize.Height);
				Derma.Repaint();
			}
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("When true, sizes the DLabel to fit it's text")]
		public bool SizeToContents {
			get { return sizetocontents; }
			set { this.sizetocontents = value; }
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("The color of the DLabel's text")]
		public Color Color {
			get { return color; }
			set {
				color = value;
				textBrush = new SolidBrush(color);
				Derma.Repaint();
			}
		}
		#endregion Properties

		public DLabel(int xpos, int ypos) : base(xpos, ypos, 60, 20) {
			numOfThisType++;

			if (!this.SetVarName(type + numOfThisType.ToString()))
				while (!this.SetVarName(type + numOfThisType.ToString() + Derma.RandomString(4, false)))
					continue;

			this.width = (int)labelSize.Width;
			this.height = (int)labelSize.Height;
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

			float ypos = (this.height / 2) - (labelSize.Height / 2);

			// draw label
			p.Graphics.DrawString(this.text, Derma.DefaultFont, textBrush, this.x, this.y + ypos);
		}

		public override void PopulateProperties() {
			Derma.prop.propertyGrid.SelectedObject = this;
		}

		public override string GenerateLua() {
			StringBuilder code = new StringBuilder("\n");
			code.AppendFormat("local {0} = vgui.Create('DLabel')\n", this.varname);

			if (this.parent != null)
				code.AppendFormat("{0}:SetParent({1})\n", this.varname, parent.varname);

			code.AppendFormat("{0}:SetPos({1}, {2})\n", this.varname, this.GetPosRelativeToParentNonRecursive().X, this.GetPosRelativeToParentNonRecursive().Y);
			code.AppendFormat("{0}:SetText('{1}')\n", this.varname, this.text);

			if (this.sizetocontents)
				code.AppendFormat("{0}:SizeToContents()\n", this.varname);
			else
				code.AppendFormat("{0}:SetSize({1}, {2})\n", this.varname, this.width, this.height);

			if (!this.visible)
				code.AppendFormat("{0}:SetVisible(false)\n", this.varname);

			if (this.color != Color.LightGray)
				code.AppendFormat("{0}:SetTextColor(Color({1}, {2}, {3}, {4}))", new object[] {this.varname, this.color.R, this.color.G, this.color.B, this.color.A});

			return code.ToString();
		}

		public static void Register() {
			Derma.RegisterPanel("DLabel", typeof(DLabel), thumbnail);
		}
	}
}
