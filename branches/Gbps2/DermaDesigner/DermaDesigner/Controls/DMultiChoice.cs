using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace DermaDesigner.Controls {
	class DMultiChoice : Panel {
		private static string respath = "resources/DMultiChoice/";

		public static int numOfThisType = 0;
		public override string type { get { return "DMultiChoice"; } }

		private static Image arrow = Derma.LoadImage(respath + "arrow.png");
		private static Color whitecolor = Color.FromArgb(255, 241, 241, 241);
		private static SolidBrush blackBrush = new SolidBrush(Color.Black);
		private static SolidBrush insideBrush = new SolidBrush(whitecolor);
		private static Pen outlinePen = new Pen(blackBrush);

		public static new Image thumbnail = Derma.LoadImage(respath + "dmultichoice_32.png");

		bool initialselection;
		int initialselectnum;

		// lua vars
		List<string> items = new List<string>();
		string onMousePressedFunc = "function() end";
		string onSelectFunc = ":OnSelect(Index, Value, Data) end";
		bool editable = true;
		
		#region Properties
		[Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor)), CategoryAttribute("Lua Attributes"), DescriptionAttribute("The items the DComboBox will show")]
		public List<string> Items {
			get { return items; }   
			set { items = value; Derma.Repaint(); }
		}

		[Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor)), CategoryAttribute("Lua Attributes"), DescriptionAttribute("The function to be run when the mouse is pressed on this control")]
		public string OnMousePressed {
			get { return onMousePressedFunc; }
			set { onMousePressedFunc = value; }
		}

		[Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor)), CategoryAttribute("Lua Attributes"), DescriptionAttribute("The function to be run when a new option is selected")]
		public string OnSelectOption {
			get { return onSelectFunc; }
			set { onSelectFunc = value; }
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("When true, the user can edit the text in this control")]
		public bool Editable {
			get { return editable; }
			set { editable = value; }
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("When true, the DMultiChoice will have an initial value of the index InitialSelectionIndex")]
		public bool InitialValue {
			get { return initialselection; }
			set { initialselection = value; }
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("When InitialValue is true, the initial value of this control will be the option with this index")]
		public int InitialSelectionIndex {
			get { return initialselectnum; }
			set {
				    initialselectnum = Derma.Clamp(value,1,items.Count);
				    Derma.Repaint();
				}
		}
		
		#endregion Properties

		public DMultiChoice(int xpos, int ypos) : base(xpos, ypos, 50, 21) {
			numOfThisType++;

			this.initialselectnum = 1;

			if (!this.SetVarName(type + numOfThisType.ToString()))
				while (!this.SetVarName(type + numOfThisType.ToString() + Derma.RandomString(4, false)))
					continue;
		}

		public override void PopulateProperties() {
			Derma.prop.propertyGrid.SelectedObject = this;
		}

		public static void Register() {
			Derma.RegisterPanel("DMultiChoice", typeof(DMultiChoice), thumbnail);
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

			p.Graphics.FillRectangle(insideBrush, this.x + 1, this.y + 1, this.width - 2, this.height - 2);
			p.Graphics.DrawRectangle(outlinePen, this.x, this.y, this.width - 1, this.height - 1);

			int ypos = (this.height / 2) - (arrow.Height / 2);

			p.Graphics.DrawImage(arrow, this.x + this.width - 7 - 6, this.y + ypos, 7, 4);

			if (this.initialselection && this.initialselectnum > 0 && this.initialselectnum < this.items.Count + 1)
				p.Graphics.DrawString(this.items[initialselectnum - 1], Derma.DefaultFont, blackBrush, this.x + 5, this.y + (this.height / 2) - 6);
		}

		public override string GenerateLua() {
			StringBuilder code = new StringBuilder("\n");
			code.AppendFormat("{0} = vgui.Create('DMultiChoice')\n", this.varname);

			if (this.parent != null)
				code.AppendFormat("{0}:SetParent({1})\n", this.varname, parent.varname);

			if (this.ShouldCenter())
				code.AppendFormat("{0}:Center()\n", this.varname);
			else
				code.AppendFormat("{0}:SetPos({1})\n", this.varname, this.GetPosCode());

			if (this.onMousePressedFunc.Trim() != "")
				code.AppendFormat("{0}.OnMousePressed = {1}\n", this.varname, this.onMousePressedFunc);

			if (this.onSelectFunc.Trim() != "")
				code.AppendFormat("function {0}{1}\n", this.varname, this.onSelectFunc);

			if (items.Count > 0) {
				code.Append("\n");

				foreach (string item in items)
					code.AppendFormat("{0}:AddChoice('{1}')\n", this.varname, item);

				code.Append("\n");
			}

			if (this.initialselection && this.initialselectnum > 0 && this.initialselectnum < this.items.Count + 1)
				code.AppendFormat("{0}:ChooseOptionID({1})\n", this.varname, this.initialselectnum);

			return code.ToString();
		}
	}
}
