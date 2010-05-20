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
    class DFrame : Panel {
		private static string respath = "resources/DFrame/";

		private static Image topLeftCorner = Derma.LoadImage(respath + "dframe_upperleft.png");
		private static Image topRightCorner = Derma.LoadImage(respath + "dframe_upperright.png");
		private static Image bottomLeftCorner = Derma.LoadImage(respath + "dframe_lowerleft.png");
		private static Image bottomRightCorner = Derma.LoadImage(respath + "dframe_lowerright.png");
		private static Image topFiller = Derma.LoadImage(respath + "dframe_topfiller.png");
		private static Image XBtn = Derma.LoadImage(respath + "dframe_x.png");
		private static Color wndColor = Color.FromArgb(255, 100, 100, 100);
		private static SolidBrush bgBrush = new SolidBrush(wndColor);

		public static new Image thumbnail = Derma.LoadImage(respath + "dframe_32.png");

		public static int numOfThisType = 0;
		public override string type { get { return "DFrame"; } }
		public override bool canBeChild { get { return false; } }

		// Lua variables
		public string title = "Untitled DFrame";
		public bool luaSizable = true;
		public bool deleteOnClose = false;
		public bool closeButton = true;
		public bool makePopup = true;

		#region Properties
		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets the window title")]
		public string Title {
			get { return title; }
			set { title = value; Derma.Repaint(); }
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Toggles the resizability of the window")]
		public bool Sizable {
			get { return luaSizable; }
			set { luaSizable = value; }
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets if the window should be deleted on close")]
		public bool DeleteOnClose {
			get { return deleteOnClose; }
			set { deleteOnClose = value; }
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets the visibility of the close button")]
		public bool CloseButton {
			get { return closeButton; }
			set { closeButton = value; Derma.Repaint(); }
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets if the window should be MakePopup()'ed when created")]
		public bool MakePopup {
			get { return makePopup; }
			set { makePopup = value; }
		}
		#endregion Properties

		public DFrame(int xpos, int ypos) : base(xpos, ypos, 120, 60) {
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
			// every control should set the clip region it wants to draw itself
			// if it doesn't, it'll be the region that was set by the last control that was drawn
			p.Graphics.Clip = new Region(new Rectangle(this.x, this.y, this.width, this.height));

			// Draw the solid grey bg
			p.Graphics.FillRectangle(bgBrush, this.x, this.y + topLeftCorner.Height, this.width, this.height - bottomLeftCorner.Height - topLeftCorner.Height);
			p.Graphics.FillRectangle(bgBrush, this.x + bottomLeftCorner.Width, this.y + this.height - bottomLeftCorner.Height, this.width - (bottomLeftCorner.Width * 2), bottomLeftCorner.Height);
			
			// draw the top left and right corners first
			p.Graphics.DrawImage(topLeftCorner, this.x, this.y);
			p.Graphics.DrawImage(topRightCorner, this.x + this.width - topRightCorner.Width, this.y);

			// draw the bar all the way cross the top
			for (int i = 0; i < this.width / topFiller.Width; i++) {
				if ((this.x + topLeftCorner.Width + (i * topFiller.Width)) + topFiller.Width + 1 > this.x + this.width)
					break;
				p.Graphics.DrawImage(topFiller, this.x + topLeftCorner.Width + (i * topFiller.Width), this.y);
			}

			// draw the bottom two corners
			p.Graphics.DrawImage(bottomLeftCorner, this.x, this.y + this.height - bottomLeftCorner.Height);
			p.Graphics.DrawImage(bottomRightCorner, this.x + this.width - bottomRightCorner.Width, this.y + this.height - bottomRightCorner.Height);

			// Draw the window title
			p.Graphics.DrawString(this.title, Derma.DefaultFont, Derma.fontBrush, this.x + 5, this.y + 6);

			// Draw the X if the closeButton is true
			if (closeButton)
				p.Graphics.DrawImage(XBtn, this.x + this.width - 17, this.y + 6, 11, 11); // Sorry for the magic numbers, but numbers are faster than properties
		}

		public override string GenerateLua() {
			StringBuilder code = new StringBuilder("\n");
			code.AppendFormat("local {0} = vgui.Create('DFrame')\n", this.varname);
			code.AppendFormat("{0}:SetSize({1}, {2})\n", this.varname, this.width, this.height);

			if (this.ShouldCenter())
				code.AppendFormat("{0}:Center()\n", this.varname);
			else
				code.AppendFormat("{0}:SetPos({1}, {2})\n", this.varname, this.GetPosRelativeToParent().X, this.GetPosRelativeToParent().Y);

			code.AppendFormat("{0}:SizeTitle('{1}')\n", this.varname, this.title);

			if (!this.luaSizable)
				code.AppendFormat("{0}:SetSizable(false)\n", this.varname);

			if (!this.deleteOnClose)
				code.AppendFormat("{0}:SetDeleteOnClose(false)\n", this.varname);

			if (!this.closeButton)
				code.AppendFormat("{0}:ShowCloseButton(false)\n", this.varname);

			if (!this.visible)
				code.AppendFormat("{0}:SetVisible(false)\n", this.varname);

			if (this.makePopup)
				code.AppendFormat("{0}:MakePopup()\n", this.varname);

			return code.ToString();
		}

		public static void Register() {
			Derma.RegisterPanel("DFrame", typeof(DFrame), thumbnail);
		}
    }
}
