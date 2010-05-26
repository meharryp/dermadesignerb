using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;

// Thanks to SnakeFace for this control

namespace DermaDesigner {
	class DImage : Panel {
		private static string respath = "resources/DImage/";

		// painting resources
        private static Image paletteimg = Derma.LoadImage(respath + "dimage_palette.png");

		public static new Image thumbnail = Derma.LoadImage(respath + "dimage_32.png");

		private static Color whitecolor = Color.FromArgb(255, 241, 241, 241);
		private static SolidBrush squareimgBrush = new SolidBrush(whitecolor);
        private static Color blackcolor = Color.FromArgb(255, 0, 0, 0);
        private static SolidBrush blackBrush = new SolidBrush(blackcolor);

		// class vars
		public static int numOfThisType = 0;
		public override string type { get { return "DImage"; } }

        private SizeF textSize = Derma.GetTextSize("");

		// Lua variables
		public string imagepath = "";

		#region Properties
		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("The path to the texture file to use in-game (relative to 'materials/')")]
		public string Filepath {
			get { return imagepath; }
			set {
				this.imagepath = value;
                this.textSize = Derma.GetTextSize(this.imagepath);
				Derma.Repaint();
			}
		}
		#endregion Properties

		public DImage(int x, int y)	: base(x, y, 50, 50) {
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

			p.Graphics.FillRectangle(squareimgBrush, this.x, this.y, this.width, this.height);

			if (parent) {
				int a, b, c, d;
				Point relpos = this.GetPosRelativeToParent();
				a = (this.x >= parent.x) ? this.x : parent.x;
				b = (this.y >= parent.y) ? this.y : parent.y;
				c = (this.x + this.width > parent.x + parent.width) ? parent.width - relpos.X : this.width;
				d = (this.y + this.height > parent.y + parent.height) ? parent.height - relpos.Y : this.height;
				p.Graphics.Clip = new Region(new Rectangle(a, b, c, d));
			}

            p.Graphics.DrawImage(paletteimg, this.x + this.width / 2 - 32, this.y + this.height / 2 - 32, 64, 64);
			p.Graphics.DrawString(this.imagepath, Derma.DefaultFont, blackBrush, (this.x + (this.width / 2) - (this.textSize.Width / 2)), (this.y + this.height - (this.height / 4 ) + 12));
		}

		public override string GenerateLua() {
			StringBuilder code = new StringBuilder("\n");
			code.AppendFormat("local {0} = vgui.Create('DImage')\n", this.varname);

			if (this.parent != null)
				code.AppendFormat("{0}:SetParent({1})\n", this.varname, parent.varname);

			code.AppendFormat("{0}:SetSize({1})\n", this.varname, this.GetSizeCode());

			if (this.ShouldCenter())
				code.AppendFormat("{0}:Center()\n", this.varname);
			else
				code.AppendFormat("{0}:SetPos({1})\n", this.varname, this.GetPosCode());

			code.AppendFormat("{0}:SetImage('{1}')\n", this.varname, this.imagepath);

            code.AppendFormat("{0}:SizeToContents()\n", this.varname);

			if (!this.visible)
				code.AppendFormat("{0}:SetVisible(false)\n", this.varname);

			return code.ToString();
		}

		public static void Register() {
			Derma.RegisterPanel("DImage", typeof(DImage), thumbnail);
		}
	}
}
