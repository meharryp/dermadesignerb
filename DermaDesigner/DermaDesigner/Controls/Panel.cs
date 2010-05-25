using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;

namespace DermaDesigner {
    public abstract class Panel {
        [PackerAttrib()]
        public int x;
        [PackerAttrib()]
		public int y;
        [PackerAttrib()]
		public int height;
        [PackerAttrib()]
		public int width;
		public int dragOffsetX;
		public int dragOffsetY;
        [PackerAttrib()]
		public float z;

        private bool _highlighted;
        public bool highlighted
        {
            get
            {
                return _highlighted;
            }
            set
            {
                if (value != _highlighted)
                {
                    _highlighted = value;
                    Derma.Repaint();
                }
            }
        }

		// this is for the designer to know whether to treat this control like it exists or not
        [PackerAttrib()]
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
        [PackerAttrib()]
		public bool centered;
		// this is to let is know whether to do SetVisible(false) on this control for lua
        [PackerAttrib()]
		public bool visible;
		[CategoryAttribute("Lua Attributes"), DescriptionAttribute("The controls type")]
		public virtual string Type { get { return type; } }
		[BrowsableAttribute(false)]
		public virtual string type { get { return "Panel"; } }
        [PackerAttrib()]
		public string varname;
		// This makes it able to size or not in the editor, for instance in DLabel we don't need to resize
		// this doesn't correlate to lua's SetSizable
		[BrowsableAttribute(false)]
		public virtual bool sizable { get { return true; } }
		[BrowsableAttribute(false)]
		public virtual bool sizablex { get { return true; } }
		[BrowsableAttribute(false)]
		public virtual bool sizabley { get { return true; } }

        private int LastX = 0;
        private int LastY = 0;
        /// <summary>
        /// Used by DPacker to assign the varname of the parent that the packer should match later on.
        /// </summary>
        public string parentIdentifier;
		public Image thumbnail;

		// This is just for the properties box
		#region Properties
		[CategoryAttribute("Position and Size"), DescriptionAttribute("X Position")]
		public int X {
			get { return GetPosRelativeToParentNonRecursive().X; }
			set { SetPosRelativeToParent(value, true); Derma.Repaint(); }
		}

		[CategoryAttribute("Position and Size"), DescriptionAttribute("Y Position")]
		public int Y {
			get { return GetPosRelativeToParentNonRecursive().Y; }
			set { SetPosRelativeToParent(value, false); Derma.Repaint(); }
		}

		[CategoryAttribute("Position and Size"), DescriptionAttribute("Sets the height of this control")]
		public int Height {
			get { return height; }
            set { 
                    if (sizable && sizabley)
                    {
                      height = value; Derma.Repaint();
                    }
                }
		}

		[CategoryAttribute("Position and Size"), DescriptionAttribute("Sets the width of this control")]
		public int Width {
			get { return width; }
			set
			{
                if (sizable && sizablex)
                {
                    width = value;
                    Derma.Repaint();
                }
			}
		}

		[CategoryAttribute("Position and Size"), DescriptionAttribute("Sets the depth at which to draw this control")]
        [PackerAttrib(true)]
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

		public void SetPos(int newx, int newy) {
			SetPos(newx, newy, false);
		}

		public void SetPos(int newx, int newy, bool snap) {
			if (GUI.Grid.DrawGrid && snap) {
				newx = (int)Math.Round((double)newx / GUI.Grid.GridSize, 1) * GUI.Grid.GridSize;
				newy = (int)Math.Round((double)newy / GUI.Grid.GridSize, 1) * GUI.Grid.GridSize;
			}

			foreach (Panel p in children) {
				p.ModifyPos(newx - this.x, newy - this.y);
			}
			this.x = newx;
			this.y = newy;
            if (LastX != newx || LastY != newy) {
                Derma.Repaint();
            }
		    LastX = newx;
		    LastY = newy;
		}

		public Point GetPosRelativeToParent() {
			if (this.hasParent && this.parent)
				return new Point(this.x - this.parent.GetPosRelativeToParent().X, this.y - this.parent.GetPosRelativeToParent().Y);
			else
				return new Point(this.x, this.y);
		}

		public Point GetPosRelativeToParentNonRecursive() {
			if (this.hasParent && this.parent)
				return new Point(this.x - this.parent.x, this.y - this.parent.y);
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
			SetSize(w, h, false);
		}

		public void SetSize(int w, int h, bool snap) {
			if (GUI.Grid.DrawGrid && snap) {
				int totalw = this.x + w;
				int totalh = this.y + h;

				int neww = (int)Math.Round((double)totalw / GUI.Grid.GridSize) * GUI.Grid.GridSize;
				int newh = (int)Math.Round((double)totalh / GUI.Grid.GridSize) * GUI.Grid.GridSize;

				w = neww - this.x;
				h = newh - this.y;
			}

			this.width = w;
			this.height = h;
		}

		public void ModifySize(int w, int h) {
			SetSize(this.width + w, this.height + h, false);
		}

		public void ModifySize(int w, int h, bool snap) {
			SetSize(this.width + w, this.height + h, snap);
		}

		public void Center() {
			if (this.hasParent && this.parent)
				this.SetPos(parent.x + (parent.width / 2) - (this.width / 2), parent.y + (parent.height / 2) - (this.height / 2));
			else
				this.SetPos((Derma.GetWorkspace().Width / 2) - (this.width / 2), (Derma.GetWorkspace().Height / 2) - (this.height / 2));
		}

        public void SetParent(Panel p) {
            if (p.canBeParent && this.canBeChild) {
				if (this.hasParent && this.parent) {
					this.parent.children.Remove(this);
					if (this.parent.children.Count < 1)
						this.parent.hasChildren = false;
				}
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
