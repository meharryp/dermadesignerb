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

namespace DermaDesigner {
	class SpawnIcon : Panel {
		private static string respath = "resources/SpawnIcon/";
		public static Image Placeholder = Derma.LoadImage(respath + "spawnicon.png");
		public static new Image thumbnail = Derma.LoadImage(respath + "spawnicon_32.png");
		public override string type { get { return "SpawnIcon"; } }
		public override bool sizable { get { return false; } }
		private int numOfThisType = 0;
		//public int scale = 0; WIP, unknown what it does.

		public string doclick = "";
		public string oncursorentered = "function() end";
		public string oncursorexited = "function() end";
		public string onmousereleased = "function() end";
		public string onmousepressed = "function() end";

		public string tooltip = "";
		public string model = "";

		#region Properties
		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("The model name of this SpawnIcon")]
		public string Model {
			get { return model;	}
			set { model = value; }
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets the tooltip; if blank, this will be the model name (Note: as of 5/30/10, this has no effect)")]
		public string Tooltip {
			get { return tooltip; }
			set { tooltip = value; }
		}

		[Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor)), CategoryAttribute("Lua Attributes"), DescriptionAttribute("The function to be called when the cursor enters the SpawnIcon")]
		public string OnCursorEntered {
			get { return oncursorentered; }
			set { oncursorentered = value; }
		}

		[Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor)), CategoryAttribute("Lua Attributes"), DescriptionAttribute("The function to be called when the cursor exits the SpawnIcon")]
		public string OnCursorExited {
			get { return oncursorexited; }
			set { oncursorexited = value; }
		}
		[Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor)), CategoryAttribute("Lua Attributes"), DescriptionAttribute("The function to be called when the mouse is pressed over the SpawnIcon")]
		public string OnMousePressed {
			get { return onmousepressed; }
			set { onmousepressed = value; }
		}

		[Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor)), CategoryAttribute("Lua Attributes"), DescriptionAttribute("The function to be called when the mouse is released over the SpawnIcon")]
		public string OnMouseReleased {
			get { return onmousereleased; }
			set { onmousereleased = value; }
		}
		#endregion Properties

		public SpawnIcon(int x, int y) : base(x, y, 61, 61) {
			numOfThisType++;

			if (!this.SetVarName(type + numOfThisType.ToString()))
				while (!this.SetVarName(type + numOfThisType.ToString() + Derma.RandomString(4, false)))
					continue;
		}

		public override void PopulateProperties() {
			Derma.prop.propertyGrid.SelectedObject = this;
		}

		public override string GenerateLua() {
			StringBuilder code = new StringBuilder("\n");
			code.AppendFormat("{0} = vgui.Create('SpawnIcon')\n", this.varname);

			if (this.parent != null)
				code.AppendFormat("{0}:SetParent({1})\n", this.varname, parent.varname);

			if (this.ShouldCenter())
				code.AppendFormat("{0}:Center()\n", this.varname);
			else
				code.AppendFormat("{0}:SetPos({1})\n", this.varname, this.GetPosCode());

			if (this.tooltip.Trim() != "")
				code.AppendFormat("{0}:SetToolTip('{1}')\n", this.varname, this.tooltip);

			if (this.oncursorentered.Trim() != "function() end")
				code.AppendFormat("{0}.OnCursorEntered = {1}\n", this.varname, this.oncursorentered);

			if (this.oncursorexited.Trim() != "function() end")
				code.AppendFormat("{0}.OnCursorExited = {1}\n", this.varname, this.oncursorexited);

			if (this.onmousepressed.Trim() != "function() end")
				code.AppendFormat("{0}.OnMousePressed = {1}\n", this.varname, this.onmousepressed);

			if (this.onmousereleased.Trim() != "function() end")
				code.AppendFormat("{0}.OnMouseReleased = {1}\n", this.varname, this.onmousereleased);

			if (this.model.Trim() != "")
				code.AppendFormat("{0}:SetModel('{1}')\n", this.varname, this.model);

			return code.ToString();
		}

		public override void ControlPaint(object sender, PaintEventArgs p) {
			// if we have a parent, we don't want to draw outside them
			if (this.parent)
				p.Graphics.Clip = new Region(new Rectangle(parent.x, parent.y, parent.width, parent.height));
			else
				p.Graphics.Clip = new Region(new Rectangle(this.x, this.y, this.width, this.height));

			p.Graphics.DrawImage(Placeholder, this.x, this.y, this.width, this.height);
		}

		public static void Register() {
			Derma.RegisterPanel("SpawnIcon", typeof(SpawnIcon), thumbnail);
		}
	}
}
