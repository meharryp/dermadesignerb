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
    class DCheckBox : Panel {
        private static string respath = "resources/DCheckBox/";

        private static Image backgroundimg = Derma.LoadImage(respath + "dcheckbox_bg.png");
        private static Image tickimg = Derma.LoadImage(respath + "dcheckbox_tick.png");

        private static SolidBrush blackBrush = new SolidBrush(Color.Black);

        public static new Image thumbnail = Derma.LoadImage(respath + "dcheckbox_32.png");

        public static int numOfThisType = 0;
        public override string type { get { return "DCheckBox"; } }
        public override bool sizable { get { return false; } }
		private SizeF labelSize = Derma.GetTextSize("DCheckBox");

        // Lua variables
        string text = "CheckBox Label";
        string ConFunc = "";
		string ClickFunc = "function() end";
        bool ticked = false;

        #region Properties
        [CategoryAttribute("Lua Attributes"), DescriptionAttribute("Set the label of the checkbox")]
        public string Text {
            get { return text; }
            set {
                this.text = value;
				this.labelSize = Derma.GetTextSize(this.text);
				this.SetSize((int)this.labelSize.Width + 18, (int)this.labelSize.Height + 3);
				Derma.RefreshProperties();
                Derma.Repaint();
            }
        }

        [CategoryAttribute("Lua Attributes"), DescriptionAttribute("Set the initial state of the checkbox")]
        public bool Checked {
            get { return ticked; }
            set {
                this.ticked = value;
                Derma.Repaint();
            }
        }

        [CategoryAttribute("Lua Attributes"), DescriptionAttribute("The console command to toggle with the checkbox")]
        public string ConCommand {
            get { return ConFunc; }
            set { ConFunc = value; }
        }

		[Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor)), CategoryAttribute("Lua Attributes"), DescriptionAttribute("The function to be run when the checkbox is clicked")]
		public string OnClick {
			get { return ClickFunc; }
			set { ClickFunc = value; }
		}
        #endregion Properties

        public DCheckBox(int xpos, int ypos) : base(xpos, ypos, 100, 15) {
            numOfThisType++;

            if (!this.SetVarName(type + numOfThisType.ToString()))
                while (!this.SetVarName(type + numOfThisType.ToString() + Derma.RandomString(4, false)))
                    continue;
        }

        public override void PopulateProperties() {
            Derma.prop.propertyGrid.SelectedObject = this;
        }

        public override void ControlPaint(object sender, PaintEventArgs p) {
            // if we have a parent, we don't want to draw outside them
            if (this.parent)
                p.Graphics.Clip = new Region(new Rectangle(parent.x, parent.y, parent.width, parent.height));
            else
                p.Graphics.Clip = new Region(new Rectangle(this.x, this.y, this.width, this.height));

			float ypos = (this.height / 2) - (labelSize.Height / 2);

            p.Graphics.DrawImage(backgroundimg, this.x, this.y + ypos, 14, 14);

			if (hasParent && parent) {
				int a, b, c, d;
				Point relpos = this.GetPosRelativeToParentNonRecursive();
				a = (this.x >= parent.x) ? this.x : parent.x;
				b = (this.y >= parent.y) ? this.y : parent.y;
				c = (this.x + this.width > parent.x + parent.width) ? parent.width - relpos.X : this.width;
				d = (this.y + this.height > parent.y + parent.height) ? parent.height - relpos.Y : this.height;
				p.Graphics.Clip = new Region(new Rectangle(a, b, c, d));
			}

            p.Graphics.DrawString(this.text, Derma.DefaultFont, Derma.fontBrush, this.x + 18, this.y + ypos + 1);

            // draw tick
			if (ticked == true) {
				p.Graphics.DrawImage(tickimg, this.x, this.y, 14, 14);
			}
        }

        public override string GenerateLua() {
            StringBuilder code = new StringBuilder("\n");
            code.AppendFormat("local {0} = vgui.Create('DCheckBoxLabel')\n", this.varname);

            if (this.parent != null)
                code.AppendFormat("{0}:SetParent({1})\n", this.varname, parent.varname);

            if (this.ShouldCenter())
                code.AppendFormat("{0}:Center()\n", this.varname);
            else
				code.AppendFormat("{0}:SetPos({1})\n", this.varname, this.GetPosCode());

            code.AppendFormat("{0}:SetText('{1}')\n", this.varname, this.text);

			if (this.ticked)
				code.AppendFormat("{0}:SetValue(true)\n", this.varname);

            if (this.ConFunc.Trim() != "")
                code.AppendFormat("{0}:SetConVar({1})\n", this.varname, this.ConFunc);

			if (this.ClickFunc.Trim() != "")
				code.AppendFormat("{0}.DoClick = {1}\n", this.varname, this.ClickFunc);

            if (!this.visible)
                code.AppendFormat("{0}:SetVisible(false)\n", this.varname);

            code.AppendFormat("{0}:SizeToContents()\n", this.varname);

            return code.ToString();
        }

        public static void Register() {
            Derma.RegisterPanel("DCheckBox", typeof(DCheckBox), thumbnail);
        }
    }
}
