using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DermaDesigner {
	class DNumberWang : Panel {
		private static string respath = "resources/DNumberWang/";

		// painting resources
		public static new Image thumbnail = Derma.LoadImage(respath + "dnumberwang_32.png");
		private static Image sideimg = Derma.LoadImage(respath + "dnumberwang_side.png");
		private static Color whitecolor = Color.FromArgb(255, 241, 241, 241);
		private static SolidBrush blackBrush = new SolidBrush(Color.Black);
		private static SolidBrush insideBrush = new SolidBrush(whitecolor);
		private static Pen outlinePen = new Pen(blackBrush);

		// class vars
		public static int numOfThisType = 0;
		public override string type { get { return "DNumberWang"; } }
		public override bool sizabley { get { return false; } }

		private SizeF textSize = Derma.GetTextSize("0");

		// Lua variables
		public int val = 0;
		public int min = 0;
		public int max = 0;
		public int decimals = 0;
		public int floatvalue = 0;
		public int fraction = 0;
		public string Convar = "";
		public string MouseReleasedFunc = "function() end";
		public string OnValueChangedFunc = "function() end";

		#region Properties
		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets the initial value of the DNumberWang")]
		public int InitialValue {
			get { return val; }
			set {
				if (value < this.min || value > this.max)
					MessageBox.Show("Property Value is not valid", "Properties Window");
				else if (value >= this.min && value <= this.max)
					this.val = value;

				this.textSize = Derma.GetTextSize(this.val.ToString());
				Derma.Repaint();

			}
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets the number of decimal places the DNumberWang will use")]
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

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets the initial value of the DNumberWang")]
		public int Minimum {
			get { return min; }
			set {
				this.min = value;
			}
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets the initial value of the DNumberWang")]
		public int Maximum {
			get { return max; }
			set {
				this.max = value;
			}
		}

		[Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor)), CategoryAttribute("Lua Attributes"), DescriptionAttribute("The console variable controlled by the number wang")]
		public string ConVar {
			get { return Convar; }
			set { Convar = value; }
		}
		#endregion Properties

		public DNumberWang(int x, int y) : base(x, y, 64, 20) {
			numOfThisType++;

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
				a = (this.x >= parent.x) ? this.x : parent.x;
				b = (this.y >= parent.y) ? this.y : parent.y;
				c = (this.x + this.width > parent.x + parent.width) ? parent.width - relpos.X : this.width;
				d = (this.y + this.height > parent.y + parent.height) ? parent.height - relpos.Y : this.height;
				p.Graphics.Clip = new Region(new Rectangle(a, b, c, d));
			} else
				p.Graphics.Clip = new Region(new Rectangle(this.x, this.y, this.width, this.height));

			p.Graphics.FillRectangle(insideBrush, this.x + 1, this.y + 1, this.width - 2, this.height - 2);
			p.Graphics.DrawRectangle(outlinePen, this.x, this.y, this.width - 1, this.height - 1);
			p.Graphics.DrawString(this.val.ToString(), Derma.DefaultFont, blackBrush, this.x + 3, (this.y + (this.height / 2)) - (this.textSize.Height / 2));
			p.Graphics.DrawImage(sideimg, this.x + this.width - 11, this.y, 11, 20);			
		}

		public override string GenerateLua() {
			StringBuilder code = new StringBuilder("\n");
			code.AppendFormat("local {0} = vgui.Create('DNumberWang')\n", this.varname);

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

			code.AppendFormat("{0}:SetValue('{1}')\n", this.varname, this.val);

			code.AppendFormat("{0}:SetMinMax( {1}, {2})\n", this.varname, this.min, this.max);

			if (!this.visible)
				code.AppendFormat("{0}:SetVisible(false)\n", this.varname);

			return code.ToString();
		}

		public static void Register() {
			Derma.RegisterPanel("DNumberWang", typeof(DNumberWang), thumbnail);
		}
	}
}
