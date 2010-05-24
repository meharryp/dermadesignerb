using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace DermaDesigner.Controls
{
    
    class DNumPad : Panel
    {
        public string OnButtonPress = "function() end";

        public static Color BlueBG = Color.FromArgb(150, 0, 128, 255);
        int value = -1;
        private static SolidBrush bgBrush = new SolidBrush(BlueBG);
        [CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets the Keypad Value. Max of 15.")]
        public int Value
        {
            get { return this.value;  }
            set
            {
                this.value = Derma.Clamp(value, 0, 15);
                Derma.Repaint();
            }
        }
        [Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor)), CategoryAttribute("Lua Attributes"), DescriptionAttribute("Called when a number is selected.")]
        public string OnButtonPressAction{
            get { return this.OnButtonPress; }
            set{this.OnButtonPress=value;}
        }
        
        private static string respath = "resources/DNumPad/";
        public static new Image thumbnail = Derma.LoadImage(respath + "DNumPad32.PNG");
        public static Image Keypad = Derma.LoadImage(respath + "DNumPad.PNG");
        public static int numOfThisType = 0;
        public override bool sizable
        {
            get
            {
                return false;
            }
        }
        public DNumPad(int xpos, int ypos) : base(xpos, ypos, 76, 92) {
           
			numOfThisType++;
            //this.sizeable = false;

            if (!this.SetVarName("Dnumpad" + numOfThisType.ToString()))
				while (!this.SetVarName("Dnumpad" + numOfThisType.ToString() + Derma.RandomString(4, false)))
					continue;
		}
        public override void PopulateProperties() {
            Derma.prop.propertyGrid.SelectedObject = this;
        }
        public override void ControlPaint(object sender, PaintEventArgs p)
        {
            if (this.parent)
                p.Graphics.Clip = new Region(new Rectangle(parent.x, parent.y, parent.width, parent.height));
            else
                p.Graphics.Clip = new Region(new Rectangle(this.x, this.y, 76, 92));

            p.Graphics.DrawImage(Keypad, this.x, this.y, 76, 92);
            if (value != -1)
            {
                switch (value)
                {
                    case 15:// /
                        p.Graphics.FillRectangle(bgBrush, this.x + 22, this.y + 4, 14, 14);
                        break;
                    case 14://*
                        p.Graphics.FillRectangle(bgBrush, this.x + 39, this.y + 4, 14, 14);
                        break;
                    case 13://-
                        p.Graphics.FillRectangle(bgBrush, this.x + 56, this.y + 4, 14, 14);
                        break;
                    case 7://7
                        p.Graphics.FillRectangle(bgBrush, this.x + 5, this.y + 21, 14, 14);
                        break;
                    case 8://8
                        p.Graphics.FillRectangle(bgBrush, this.x + 22, this.y + 21, 14, 14);
                        break;
                    case 9://9
                        p.Graphics.FillRectangle(bgBrush, this.x + 39, this.y + 21, 14, 14);
                        break;
                    case 12://+
                        p.Graphics.FillRectangle(bgBrush, this.x + 56, this.y + 21, 14, 32);
                        break;
                    case 11://Enter
                        p.Graphics.FillRectangle(bgBrush, this.x + 56, this.y + 55, 14, 32);
                        break;
                    case 4:
                        p.Graphics.FillRectangle(bgBrush, this.x + 5, this.y + 38, 14, 14);
                        break;
                    case 5:
                        p.Graphics.FillRectangle(bgBrush, this.x + 22, this.y + 38, 14, 14);
                        break;
                    case 6:
                        p.Graphics.FillRectangle(bgBrush, this.x + 39, this.y + 38, 14, 14);
                        break;
                    case 1:
                        p.Graphics.FillRectangle(bgBrush, this.x + 5, this.y + 55, 14, 14);
                        break;
                    case 2:
                        p.Graphics.FillRectangle(bgBrush, this.x + 22, this.y + 55, 14, 14);
                        break;
                    case 3:
                        p.Graphics.FillRectangle(bgBrush, this.x + 39, this.y + 55, 14, 14);
                        break;
                    case 0:
                        p.Graphics.FillRectangle(bgBrush, this.x + 5, this.y + 72, 31, 14);
                        break;
                    case 10:
                        p.Graphics.FillRectangle(bgBrush, this.x + 40, this.y + 72, 14, 14);
                        break;
                }
            }
            //float xpos = (76 / 2) - (labelSize.Width / 2);
            //float ypos = (92 / 2) - (labelSize.Height / 2);

            // We only want to draw the text inside the bounds of ourselves
            // but this is only needful when we have set it to something else because we have a parent

            if (hasParent && parent)
            {
                int a, b, c, d;
                Point relpos = this.GetPosRelativeToParentNonRecursive();
                a = (this.x >= parent.x) ? this.x : parent.x;
                b = (this.y >= parent.y) ? this.y : parent.y;
                c = (this.x + 76 > parent.x + parent.width) ? parent.width - relpos.X : 76;
                d = (this.y + 92 > parent.y + parent.height) ? parent.height - relpos.Y : 92;
                p.Graphics.Clip = new Region(new Rectangle(a, b, c, d));
            }

            // draw label
            //p.Graphics.DrawString(this.text, Derma.DefaultFont, Derma.fontBrush, this.x + xpos, this.y + ypos);
        }
        public override string GenerateLua() {
            StringBuilder code = new StringBuilder("\n");
            code.AppendFormat("local {0} = vgui.Create('DNumPad')\n", this.varname);

            if (this.parent != null)
                code.AppendFormat("{0}:SetParent({1})\n", this.varname, parent.varname);

            //code.AppendFormat("{0}:SetSize({1}, {2})\n", this.varname, 76, 92);

            if (this.ShouldCenter())
                code.AppendFormat("{0}:Center()\n", this.varname);
            else
                code.AppendFormat("{0}:SetPos({1}, {2})\n", this.varname, this.GetPosRelativeToParentNonRecursive().X, this.GetPosRelativeToParentNonRecursive().Y);

            
            if (value != -1)
                code.AppendFormat("{0}:SetValue({1})\n", this.varname, this.value);

            if(this.OnButtonPress!="")
                code.AppendFormat("{0}:OnButtonPress=function() {1} end",this.varname,this.OnButtonPress);
            //if (!this.visible)
                //code.AppendFormat("{0}:SetVisible(false)\n", this.varname);

            //if (this.DoClickFunc.Trim() != "")
                //code.AppendFormat("{0}.ButtonPressed = {1}\n", this.varname, this.DoClickFunc);

            return code.ToString();
        }
        public static void Register() {
            Derma.RegisterPanel("DNumPad", typeof(DNumPad), thumbnail);
        }
    }
}
