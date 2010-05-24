using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DermaDesigner {
	class DNumSlider : Panel {
		private static string respath = "resources/DNumSlider/";

		// painting resources
		public static new Image thumbnail = Derma.LoadImage(respath + "dnumslider_32.png");
		private static Image sideimg = Derma.LoadImage(respath + "dnumslider_side.png");
		private static Image slideleft = Derma.LoadImage(respath + "dnumslider_left.png");
		private static Image slideright = Derma.LoadImage(respath + "dnumslider_right.png");
		private static Image slider = Derma.LoadImage(respath + "dnumslider_slider.png");

		private static Color whitecolor = Color.FromArgb(255, 241, 241, 241);
		private static Color slidecolor = Color.FromArgb(255, 122, 122, 122);
		private static Color linecolor = Color.FromArgb(255, 58, 58, 58);
		private static SolidBrush lineBrush = new SolidBrush(linecolor);
		private static SolidBrush blackBrush = new SolidBrush(Color.Black);
		private static SolidBrush slideBrush = new SolidBrush(slidecolor);
		private static SolidBrush insideBrush = new SolidBrush(whitecolor);
		private static Pen outlinePen = new Pen(blackBrush);
		private static Pen linePen = new Pen(lineBrush);
		public SolidBrush textBrush = new SolidBrush(Color.LightGray);
		private static Point lineStart = new Point();
		private static Point lineEnd = new Point();


		// class vars
		public static int numOfThisType = 0;
		public override string type { get { return "DNumSlider"; } }
		public override bool sizabley { get { return false; } }

		private SizeF textSize = Derma.GetTextSize("0");

		// Lua variables
        [PackerAttrib()]
        public float val = 0;
		public float min = 0;
		public float max = 1;
		public int decimals = 0;
		public int floatvalue = 0;
		public int fraction = 0;
		public string text = "";
		public string Convar = "";
		public string MouseReleasedFunc = "function() end";
		public string OnValueChangedFunc = "function() end";

		#region Properties
        [PackerAttrib(true)]
        [CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets the initial value of the DNumSlider")]
		public float InitialValue {
			get { return val; }
			set {
				if (value < this.min || value > this.max)
					MessageBox.Show("Property Value is not valid", "Properties Window");
				else if (value >= this.min && value <= this.max)
					this.val = (float)Math.Round(value, this.decimals);

				this.textSize = Derma.GetTextSize(this.val.ToString());
				Derma.Repaint();

			}
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets the number of decimal places the DNumSlider will use")]
		public string Text {
			get { return this.text; }
			set { this.text = value; Derma.Repaint(); }
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets the number of decimal places the DNumSlider will use")]
		public int Decimals {
			get { return decimals; }
			set { decimals = value; }
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets FloatValue of elements")]
		public int FloatValue {
			get { return floatvalue; }
			set { floatvalue = value; }
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets Fraction of elements")]
		public int Fraction {
			get { return fraction; }
			set { fraction = value; }
		}

		[Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor)), CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets Fraction of elements")]
		public string OnMouseReleased {
			get { return MouseReleasedFunc; }
			set { MouseReleasedFunc = value; }
		}

		[Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor)), CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets Fraction of elements")]
		public string OnValueChanged {
			get { return OnValueChangedFunc; }
			set { OnValueChangedFunc = value; }
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets the initial value of the DNumSlider")]
		public float Minimum {
			get { return min; }
			set {
				if (value < this.max)
					this.min = value;
			}
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets the initial value of the DNumSlider")]
		public float Maximum {
			get { return max; }
			set {
				if (value > this.min)
					this.max = value;
			}
		}

		[Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor)), CategoryAttribute("Lua Attributes"), DescriptionAttribute("The console variable controlled by the number wang")]
		public string ConVar {
			get { return Convar; }
			set { Convar = value; }
		}
		#endregion Properties

		public DNumSlider(int x, int y)	: base(x, y, 154, 40) {
			numOfThisType++;

			this.text = "DNumSlider";

			if (!this.SetVarName(type + numOfThisType.ToString()))
				while (!this.SetVarName(type + numOfThisType.ToString() + Derma.RandomString(4, false)))
					continue;
		}

		public override void PopulateProperties() {
			Derma.prop.propertyGrid.SelectedObject = this;
		}

		public override void ControlPaint(object sender, System.Windows.Forms.PaintEventArgs p) {
			if (this.parent) {
				int a, b, c, d;
				Point relpos = this.GetPosRelativeToParentNonRecursive();
				a = (this.x >= parent.x) ? this.x - 5 : parent.x - 5;
				b = (this.y >= parent.y) ? this.y : parent.y;
				c = (this.x + this.width > parent.x + parent.width) ? parent.width - relpos.X + 5 : this.width + 5;
				d = (this.y + this.height > parent.y + parent.height) ? parent.height - relpos.Y : this.height;
				p.Graphics.Clip = new Region(new Rectangle(a, b, c, d));
			} else
				p.Graphics.Clip = new Region(new Rectangle(this.x, this.y, this.width + 5, this.height));

			p.Graphics.FillRectangle(insideBrush, this.x + this.width - 35, this.y + 2, 22, 18);
			p.Graphics.DrawRectangle(outlinePen, this.x + this.width - 36, this.y + 1, 23, 19);
			p.Graphics.DrawString(this.val.ToString(), Derma.DefaultFont, blackBrush, this.x + this.width - 34, (this.y + 12 - (this.textSize.Height / 2)));
			p.Graphics.DrawImage(sideimg, this.x + this.width - 12, this.y + 1, 11, 20);

			lineStart = new Point(this.x + 5, this.y + 30);
			lineEnd = new Point(this.x + this.width - 3, this.y + 30);

			p.Graphics.DrawImage(slideright, this.x + this.width - 3, this.y + 24, 3, 13);
			p.Graphics.DrawImage(slideleft, this.x + 2, this.y + 24, 3, 13);
			p.Graphics.FillRectangle(slideBrush, this.x + 5, this.y + 24, this.width - 8, 13);
			p.Graphics.DrawLine(linePen, lineStart, lineEnd);

			float amount = this.max - this.min;
			float percent = (this.val / amount) * 100;
			int xtodraw;

			if (percent == 0)
				xtodraw = 0;
			else
				xtodraw = (int)((lineEnd.X - lineStart.X - 5) * percent) / 100;

			p.Graphics.DrawImage(slider, this.x + xtodraw, ((this.y + 30) - slider.Height / 2));

			p.Graphics.DrawString(this.text, Derma.DefaultFont, textBrush, this.x + 3, this.y + 8);
		}

		public override string GenerateLua() {
			StringBuilder code = new StringBuilder("\n");
			code.AppendFormat("local {0} = vgui.Create('DNumSlider')\n", this.varname);

			if (this.parent != null)
				code.AppendFormat("{0}:SetParent({1})\n", this.varname, parent.varname);

			if (this.ShouldCenter())
				code.AppendFormat("{0}:Center()\n", this.varname);
			else
				code.AppendFormat("{0}:SetPos({1}, {2})\n", this.varname, this.GetPosRelativeToParentNonRecursive().X, this.GetPosRelativeToParentNonRecursive().Y);

			code.AppendFormat("{0}:SetDecimals({1})\n", this.varname, this.decimals);
			code.AppendFormat("{0}:SetFloatValue({1})\n", this.varname, this.floatvalue);
			code.AppendFormat("{0}:SetFraction({1})\n", this.varname, this.fraction);

			if (this.MouseReleasedFunc.Trim() != "")
				code.AppendFormat("{0}.OnMouseReleased = {1}\n", this.varname, this.MouseReleasedFunc);

			if (this.OnValueChangedFunc.Trim() != "")
				code.AppendFormat("{0}.OnValueChanged = {1}\n", this.varname, this.OnValueChangedFunc);

			code.AppendFormat("{0}:SetValue({1})\n", this.varname, this.val);

			code.AppendFormat("{0}:SetMinMax( {1}, {2})\n", this.varname, this.min, this.max);

			if (!this.visible)
				code.AppendFormat("{0}:SetVisible(false)\n", this.varname);

			return code.ToString();
		}

		public static void Register() {
			Derma.RegisterPanel("DNumSlider", typeof(DNumSlider), thumbnail);
		}
	}
}
