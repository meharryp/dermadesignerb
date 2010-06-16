using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;

namespace DermaDesigner.Controls {
	public class ListTypeConverter : TypeConverter {
		public ListTypeConverter() {
			m_list.Add("up");
			m_list.Add("down");
			m_list.Add("left");
			m_list.Add("right");
			m_list.Add("updown");
			m_list.Add("close");
			m_list.Add("grip");
			m_list.Add("tick");
			m_list.Add("question");
			m_list.Add("none");
		}
		
		private List<string> m_list = new List<string>();
		
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context) {
			return true;
		}

		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) {
			return true;
		}

		protected void SetList(List<string> list) {
			m_list = list;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) {
			return new StandardValuesCollection(m_list);
		}
	}

	class DSysButton : Panel {		
		private static string respath = "resources/DSysButton/";

		private static Image topLeftCorner = Derma.LoadImage(respath + "dsysbutton_upperleft.png");
		private static Image topRightCorner = Derma.LoadImage(respath + "dsysbutton_upperright.png");
		private static Image bottomLeftCorner = Derma.LoadImage(respath + "dsysbutton_lowerleft.png");
		private static Image bottomRightCorner = Derma.LoadImage(respath + "dsysbutton_lowerright.png");

		private static Image topFiller = Derma.LoadImage(respath + "dsysbutton_topfiller.png");
		private static Image bottomFiller = Derma.LoadImage(respath + "dsysbutton_bottomfiller.png");
		private static Image leftFiller = Derma.LoadImage(respath + "dsysbutton_leftfiller.png");
		private static Image rightFiller = Derma.LoadImage(respath + "dsysbutton_rightfiller.png");

		private static Color wndColor = Color.FromArgb(255, 100, 100, 100);
		private static SolidBrush bgBrush = new SolidBrush(wndColor);

		public static new Image thumbnail = Derma.LoadImage(respath + "dsysbutton_32.png");

		public static int numOfThisType = 0;
		public override string type { get { return "DSysButton"; } }
		private SizeF labelSize = Derma.GetTextSize("r", Derma.MarlettFont);

		public string text = "r";
		public string DoClickFunc = "function() end";
		public bool useDisplayType = true;
		public string displayType = "close";

		private Dictionary<string, string> displayTypes = new Dictionary<string,string>() { {"up", "5"}, {"down", "u"}, {"left", "3"}, {"right", "4"}, {"updown", "v"}, {"close", "r"}, {"grip", "p"}, {"tick", "a"}, {"question", "s"}, {"none", ""} };
		//private Dictionary<string, string> reverseDisplayTypes = new Dictionary<string, string>() { { "t", "up" }, { "u", "down" }, { "3", "left" }, { "4", "right" }, { "v", "updown" }, { "r", "close" }, { "p", "grip" }, { "a", "tick" }, { "s", "question" }, { "", "none" } };

		#region Properties
		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("When true, this DSysButton will use the value in DisplayType; when false, it will use the value in DisplayChar")]
		public bool UseDisplayType {
			get { return this.useDisplayType; }
			set {
				this.useDisplayType = value;
				if (value) {
					text = displayTypes[displayType];
					this.labelSize = Derma.GetTextSize(this.text, Derma.MarlettFont);
				}
				Derma.Repaint();
			}
		}

		[CategoryAttribute("Lua Attributes"), TypeConverter(typeof(ListTypeConverter)), DescriptionAttribute("The type of icon to show in this control; this will take effect only when UseDisplayType is true")]
		public string DisplayType {
			get { return displayType; }
			set { 
				this.displayType = value;
				this.text = displayTypes[displayType];
				this.labelSize = Derma.GetTextSize(this.text, Derma.MarlettFont);
				
				Derma.Repaint();
			}
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets the text displayed on the DSysButton")]
		public string Text {
			get { return this.text; }
			set {
				if (!this.useDisplayType) {
					this.text = value;
					this.labelSize = Derma.GetTextSize(this.text, Derma.MarlettFont);
					Derma.Repaint();
				}
			}
		}

		[Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor)), CategoryAttribute("Lua Attributes"), DescriptionAttribute("The function to be run when the button is clicked")]
		public string DoClick {
			get { return DoClickFunc; }
			set { DoClickFunc = value; }
		}
		#endregion Properties

		public DSysButton(int xpos, int ypos) : base(xpos, ypos, 25, 25) {
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

			p.Graphics.FillRectangle(bgBrush, this.x, this.y, this.width, this.height);

			// Draw the top and bottom filler bars
			for (int i = 0; i * 2 < this.width; i++) {
				p.Graphics.DrawImage(topFiller, this.x + (i * 2), this.y, 2, 2);
				p.Graphics.DrawImage(bottomFiller, this.x + (i * 2), this.y + this.height - 2, 2, 2);
			}

			// Draw the left and right filler bars
			for (int i = 0; i * 2 < this.height; i++) {
				p.Graphics.DrawImage(leftFiller, this.x, this.y + (i * 2), 2, 2);
				p.Graphics.DrawImage(rightFiller, this.x + this.width - 2, this.y + (i * 2), 2, 2);
			}

			// top left and right corners
			p.Graphics.DrawImage(topLeftCorner, this.x, this.y, 3, 3);
			p.Graphics.DrawImage(topRightCorner, this.x + this.width - 3, this.y, 3, 3);

			// bottom left and right corners
			p.Graphics.DrawImage(bottomLeftCorner, this.x, this.y + this.height - 3, 3, 3);
			p.Graphics.DrawImage(bottomRightCorner, this.x + this.width - 3, this.y + this.height - 3, 3, 3);

			float xpos = (this.width / 2) - (this.labelSize.Width / 2);
			float ypos = (this.height / 2) - (this.labelSize.Height / 2);

			// We only want to draw the text inside the bounds of ourselves
			// but this is only needful when we have set it to something else because we have a parent

			if (this.hasParent && this.parent) {
				int a, b, c, d;
				Point relpos = this.GetPosRelativeToParentNonRecursive();
				a = (this.x >= parent.x) ? this.x : parent.x;
				b = (this.y >= parent.y) ? this.y : parent.y;
				c = (this.x + this.width > parent.x + parent.width) ? parent.width - relpos.X : this.width;
				d = (this.y + this.height > parent.y + parent.height) ? parent.height - relpos.Y : this.height;
				p.Graphics.Clip = new Region(new Rectangle(a, b, c, d));
			}

			// draw label
			p.Graphics.DrawString(this.text, Derma.MarlettFont, Derma.fontBrush, this.x + xpos, this.y + ypos);
		}

		public override string GenerateLua() {
			StringBuilder code = new StringBuilder("\n");
			code.AppendFormat("{0} = vgui.Create('DSysButton')\n", this.varname);

			if (this.hasParent && this.parent != null)
				code.AppendFormat("{0}:SetParent({1})\n", this.varname, parent.varname);

			code.AppendFormat("{0}:SetSize({1})\n", this.varname, this.GetSizeCode());

			if (this.ShouldCenter())
				code.AppendFormat("{0}:Center()\n", this.varname);
			else
				code.AppendFormat("{0}:SetPos({1})\n", this.varname, this.GetPosCode());

			if (this.useDisplayType)
				code.AppendFormat("{0}:SetType('{1}')\n", this.varname, this.displayType);
			else
				code.AppendFormat("{0}:SetChar('{1}')\n", this.varname, this.text);

			if (!this.visible)
				code.AppendFormat("{0}:SetVisible(false)\n", this.varname);

			if (this.DoClickFunc.Trim() != "")
				code.AppendFormat("{0}.DoClick = {1}\n", this.varname, this.DoClickFunc);

			return code.ToString();
		}

		public static void Register() {
			Derma.RegisterPanel("DSysButton", typeof(DSysButton), thumbnail);
		}
	}
}
