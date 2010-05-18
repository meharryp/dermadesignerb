using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace DermaDesigner {
    public class Panel : IPanel {
		public int x { get; set; }
		public int y { get; set; }
		public int height { get; set; }
		public int width { get; set; }
		public int dragOffsetX { get; set; }
		public int dragOffsetY { get; set; }
		public float z { get; set; }
		public bool hidden { get; set; }
		public List<IPanel> children { get; set; }
		public MouseEventHandler MouseClickHandler { get; set; }
		public MouseEventHandler MouseDoubleClickHandler { get; set; }
		public MouseEventHandler MouseDownHandler { get; set; }
		public MouseEventHandler MouseUpHandler { get; set; }
		public MouseEventHandler MouseMoveHandler { get; set; }
		public MouseEventHandler MouseWheelHandler { get; set; }

		public IPanel parent { get; set; }
		public bool canBeParent { get; set; }
		public bool canBeChild { get; set; }
		public bool hasParent { get; set; }
		public bool hasChildren { get; set; }
		public bool isDragging { get; set; }
		public bool isLocked { get; set; }
		public bool isHidden { get; set; }
		public bool centered { get; set; }
		public string type { get; set; }
		public string varname { get; set; }

		public TextBox XBox { get; set; }
		public TextBox YBox { get; set; }
		public TextBox WidthBox { get; set; }
		public TextBox HeightBox { get; set; }

		public Panel(int xpos, int ypos, int w, int h) {
			this.x = xpos;
			this.y = ypos;
			this.width = w;
			this.height = h;

			this.children = new List<IPanel>();

			this.canBeChild = true;
			this.canBeParent = true;
			this.hasParent = false;
			this.hasChildren = false;
			this.isDragging = false;
			this.isLocked = false;
			this.isHidden = false;
			this.centered = false;
			this.type = "Panel";
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

        public IPanel GetParent() { return parent; }

		public void SetPos(int x, int y) {
			foreach (IPanel p in children) {
				p.x += x - this.x;
				p.y += y - this.y;
			}
			this.x = x;
			this.y = y;
			Derma.Repaint();
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

        public void SetParent(IPanel p) {
            if (p.canBeParent) {
                this.parent = p;
                p.children.Add(this);
                this.hasParent = true;
                p.hasChildren = true;
            }
        }

        public void UnParent() {
            if (this.hasParent) {
                IPanel p = this.GetParent();
                p.children.Remove(this);

                if (p.children.Count < 1)
                    p.hasChildren = false;

                this.hasParent = false;
            }
        }

		public bool SetVarName(string name) {
			System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^\\w]");
			if (reg.IsMatch(name)) return false;

			foreach (IPanel p in Derma.GetPanels())
				if (p.varname == name) return false;

			varname = name;
			return true;
		}

		public void Remove() {
			foreach (IPanel p in children)
				p.Remove();
			if (ResizeGrip.host == this)
				ResizeGrip.host = null;
			Derma.GetPanels().Remove(this);
			Derma.Repaint();
		}

		public virtual void ControlPaint(object sender, PaintEventArgs p) {}
		public virtual void OnSelect() {}

		// ---
		// overridable methods
		// ---

		// We can cancel a move by returning false on PreDrag
		public virtual bool PreDrag(int newx, int newy) { return true; }
		public virtual void PostDrag() {}
		public virtual List<Control> PopulateProperties() { return new List<Control>(); }
		// We can cancel a resize by returning false on PreResize
		public virtual bool PreResize(int newwidth, int newheight) { return true; }
		public virtual void PostResize() {}
		public virtual string GenerateLua() { return ""; }
    }
}
