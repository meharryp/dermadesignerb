﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;

namespace DermaDesigner {
    public abstract class Panel {
		public int x;
		public int y;
		public int height;
		public int width;
		public int dragOffsetX;
		public int dragOffsetY;
		public float z;
		public bool highlighted;
		// this is for the designer to know whether to treat this control like it exists or not
		public bool hidden;
		public List<Panel> children;
		public MouseEventHandler MouseClickHandler;
		public MouseEventHandler MouseDoubleClickHandler;
		public MouseEventHandler MouseDownHandler;
		public MouseEventHandler MouseUpHandler;
		public MouseEventHandler MouseMoveHandler;
		public MouseEventHandler MouseWheelHandler;

		public Panel parent;
		[BrowsableAttribute(false)]
		public virtual bool canBeParent { get { return true; } }
		[BrowsableAttribute(false)]
		public virtual bool canBeChild { get { return true; } }
		public bool hasParent;
		public bool hasChildren;
		public bool dragging;
		public bool locked;
		public bool centered;
		// this is to let is know whether to do SetVisible(false) on this control for lua
		public bool visible;
		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("The controls type")]
		public virtual string type { get { return "Panel"; } }
		public string varname;

		public Image thumbnail;

		// This is just for the properties box
		#region Properties
		[CategoryAttribute("Position and Size"), DescriptionAttribute("X Position")]
		public int X {
			get { return GetPosRelativeToParent().X; }
			set { SetPosRelativeToParent(value, true); Derma.Repaint(); }
		}

		[CategoryAttribute("Position and Size"), DescriptionAttribute("Y Position")]
		public int Y {
			get { return GetPosRelativeToParent().Y; }
			set { SetPosRelativeToParent(value, false); Derma.Repaint(); }
		}

		[CategoryAttribute("Position and Size"), DescriptionAttribute("Sets the height of this control")]
		public int Height {
			get { return height; }
			set { height = value; Derma.Repaint(); }
		}

		[CategoryAttribute("Position and Size"), DescriptionAttribute("Sets the width of this control")]
		public int Width {
			get { return width; }
			set { width = value; Derma.Repaint(); }
		}

		[CategoryAttribute("Position and Size"), DescriptionAttribute("Sets the depth at which to draw this control")]
		public float Z {
			get { return z; }
			set { z = value; Derma.ResortPanelsByZ(); Derma.Repaint(); }
		}

		[CategoryAttribute("Designer Attributes"), DescriptionAttribute("Toggles the ability to move and resize this control with the mouse")]
		public bool Locked {
			get { return locked; }
			set { locked = value; }
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Toggles the initial visibility of this control")]
		public bool Visible {
			get { return visible; }
			set { visible = value; }
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Centers this control in its parent")]
		public bool Centered {
			get { return centered; }
			set {
				if (value) {
					centered = true;
					this.Center();
					Derma.Repaint();
				} else {
					centered = false;
					Derma.Repaint();
				}
			}
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("Sets the name used to identify this control in lua")]
		public string VariableName {
			get { return varname; }
			set { this.SetVarName(value); }
		}

		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("The variable name of the parent panel")]
		public string Parent {
			get { 
				if (!parent)
					return "[Not set]";
				else
					return parent.varname;
			}
		}
		#endregion Properties

		public Panel(int xpos, int ypos, int w, int h) {
			this.x = xpos;
			this.y = ypos;
			this.width = w;
			this.height = h;

			this.children = new List<Panel>();

			this.hasParent = false;
			this.hasChildren = false;
			this.dragging = false;
			this.locked = false;
			this.hidden = false;
			this.centered = false;
			this.visible = true;
			this.varname = "";
		}

		~Panel() {
			children = null;
			MouseClickHandler = null;
			MouseDoubleClickHandler = null;
			MouseDownHandler = null;
			MouseUpHandler = null;
			MouseMoveHandler = null;
			MouseWheelHandler = null;
		}

		public bool ShouldCenter() { return centered; }

		public bool IsCentered() {
			if (this.x == (Derma.GetWorkspace().Width / 2) - (this.width / 2) && this.y == (Derma.GetWorkspace().Width / 2) - (this.height / 2))
				return true;
			return false;
		}

		public static implicit operator bool(Panel p) {
			return (p != null);
		}

        public Panel GetParent() { return parent; }

		public void SetPos(int x, int y) {
			foreach (Panel p in children) {
				p.x += x - this.x;
				p.y += y - this.y;
			}
			this.x = x;
			this.y = y;
			Derma.Repaint();
		}

		public Point GetPosRelativeToParent() {
			if (this.hasParent && this.GetParent() != null)
				return new Point(this.x - this.GetParent().GetPosRelativeToParent().X, this.y - this.GetParent().GetPosRelativeToParent().Y);
			else
				return new Point(this.x, this.y);
		}

		public void SetPosRelativeToParent(int newx, int newy) {
			if (this.hasParent && this.parent) {
				this.x = parent.x + newx;
				this.y = parent.y + newy;
			} else {
				this.x = newx;
				this.y = newy;
			}
		}

		public void SetPosRelativeToParent(int newv, bool x) {
			if (this.hasParent && this.parent) {
				if (x)
					this.x = parent.x + newv;
				else
					this.y = parent.y + newv;
			} else {
				if (x)
					this.x = newv;
				else
					this.y = newv;
			}
		}

		public void ModifyPos(int addx, int addy) {
			this.SetPos(this.x + addx, this.y + addy);
		}

		public void SetSize(int w, int h) {
			this.width = w;
			this.height = h;
		}

		public void ModifySize(int w, int h) {
			this.width += w;
			this.height += h;
		}

		public void Center() {
			if (this.hasParent)
				this.SetPos((parent.width / 2) - (this.width / 2), (parent.height / 2) - (this.height / 2));
			else
				this.SetPos((Derma.GetWorkspace().Width / 2) - (this.width / 2), (Derma.GetWorkspace().Height / 2) - (this.height / 2));
		}

        public void SetParent(Panel p) {
            if (p.canBeParent) {
                this.parent = p;
                p.children.Add(this);
                this.hasParent = true;
                p.hasChildren = true;
            }
        }

        public void UnParent() {
            if (this.hasParent) {
                Panel p = this.GetParent();
                p.children.Remove(this);

                if (p.children.Count < 1)
                    p.hasChildren = false;

                this.hasParent = false;
				this.parent = null;
            }
        }

		public bool SetVarName(string name) {
			System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^\\w]");
			if (reg.IsMatch(name)) return false;

			foreach (Panel p in Derma.GetPanels())
				if (p.varname == name) return false;

			varname = name;
			return true;
		}

		public void Remove() {
			foreach (Panel p in children)
				p.Remove();
			if (ResizeGrip.host == this)
				ResizeGrip.host = null;
			Derma.GetPanels().Remove(this);
			Derma.Repaint();
		}

		public virtual void ControlPaint(object sender, PaintEventArgs p) { }
		public virtual void OnSelect() { }

		// ---
		// overridable methods
		// ---

		// We can cancel a move by returning false on PreDrag
		public virtual bool PreDrag(int newx, int newy) { return true; }
		public virtual void PostDrag() { }
		public virtual void PopulateProperties() { }
		// We can cancel a resize by returning false on PreResize
		public virtual bool PreResize(int newwidth, int newheight) { return true; }
		public virtual void PostResize() { }
		public virtual string GenerateLua() { return ""; }
    }
}
