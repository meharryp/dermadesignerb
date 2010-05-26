using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;

namespace DermaDesigner {
	class DPanel : Panel {
		private static string respath = "resources/DPanel/";
		private static Color wndColor = Color.FromArgb(255, 154, 154, 154);
		private static SolidBrush bgBrush = new SolidBrush(wndColor);
		private static Pen bgBrushPen = new Pen(bgBrush);
		public static new Image thumbnail = Derma.LoadImage(respath + "dpanel_32.png");
		public static int numOfThisType = 0;
		public override string type { get { return "DPanel"; } }
		public override bool canBeChild { get { return true; } }

		// Lua variables
		public bool luaDisabled = false;
		public bool luaPaintBackground = true;
		#region Properties
		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets if the panel should start disabled")]
		public bool Disabled {
			get { return luaDisabled; }
			set { luaDisabled = value; }
		}
		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets if the panel should show a default background")]
		public bool PaintBackground {
			get { return luaPaintBackground; }
			set { luaPaintBackground = value; }
		}
		#endregion Properties

		public DPanel(int xpos, int ypos)
			: base(xpos, ypos, 120, 60) {
			numOfThisType++;

			if (!this.SetVarName(type + numOfThisType.ToString()))
				while (!this.SetVarName(type + numOfThisType.ToString() + Derma.RandomString(4, false)))
					continue;
		}

		// all controls should implement the following methods

		public override void PopulateProperties() {
			Derma.prop.propertyGrid.SelectedObject = this;
		}

		public override void ControlPaint(object sender, PaintEventArgs p) {
			if (this.parent) {
				int a, b, c, d;
				Point relpos = this.GetPosRelativeToParent();
				a = (this.x >= parent.x) ? this.x : parent.x;
				b = (this.y >= parent.y) ? this.y : parent.y;
				c = (this.x + this.width > parent.x + parent.width) ? parent.width - relpos.X : this.width;
				d = (this.y + this.height > parent.y + parent.height) ? parent.height - relpos.Y : this.height;
				p.Graphics.Clip = new Region(new Rectangle(a, b, c, d));
			} else
				p.Graphics.Clip = new Region(new Rectangle(this.x, this.y, this.width, this.height));

			// Draw the solid grey bg
			//p.Graphics.FillRectangle(bgBrush, this.x, this.y, this.width, this.height);
			Derma.DrawRoundedRectangle(p.Graphics, bgBrushPen, this.x, this.y, this.width, this.height, 4);
		}

		public override string GenerateLua() {
			StringBuilder code = new StringBuilder("\n");
			code.AppendFormat("local {0} = vgui.Create('DPanel')\n", this.varname);
			if (this.parent != null)
				code.AppendFormat("{0}:SetParent({1})\n", this.varname, parent.varname);

			code.AppendFormat("{0}:SetSize({1})\n", this.varname, this.GetSizeCode());

			if (this.ShouldCenter())
				code.AppendFormat("{0}:Center()\n", this.varname);
			else
				code.AppendFormat("{0}:SetPos({1})\n", this.varname, this.GetPosCode());

			if (this.luaDisabled)
				code.AppendFormat("{0}:SetDisabled(true)\n", this.varname);

			if (!this.luaPaintBackground)
				code.AppendFormat("{0}:SetPaintBackground(false)\n", this.varname);

			return code.ToString();
		}

		public static void Register() {
			Derma.RegisterPanel("DPanel", typeof(DPanel), thumbnail);
		}
	}
}
