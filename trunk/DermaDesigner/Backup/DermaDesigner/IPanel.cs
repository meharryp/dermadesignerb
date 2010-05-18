using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DermaDesigner {
	public interface IPanel {
		int x {get; set;}
		int y {get; set;}
        int height {get; set;}
		int width {get; set;}
		int dragOffsetX {get; set;}
		int dragOffsetY {get; set;}
		float z {get; set;}
		bool hidden {get; set;}
        List<IPanel> children {get; set;}
        MouseEventHandler MouseClickHandler {get; set;}
        MouseEventHandler MouseDoubleClickHandler {get; set;}
        MouseEventHandler MouseDownHandler {get; set;}
        MouseEventHandler MouseUpHandler {get; set;}
        MouseEventHandler MouseMoveHandler {get; set;}
        MouseEventHandler MouseWheelHandler {get; set;}

        IPanel parent {get; set;}
		bool canBeParent { get; set; }
		bool canBeChild { get; set; }
		bool hasParent { get; set; }
		bool hasChildren { get; set; }
		bool isDragging { get; set; }
		bool isLocked { get; set; }
		bool isHidden { get; set; }
		bool centered { get; set; }
		string type { get; set; }
		string varname { get; set; }

		TextBox XBox { get; set; }
		TextBox YBox { get; set; }
		TextBox WidthBox { get; set; }
		TextBox HeightBox { get; set; }

		bool ShouldCenter();

		bool IsCentered();

		IPanel GetParent();

		void SetPos(int x, int y);

		void ModifyPos(int addx, int addy);

		void SetSize(int w, int h);

		void ModifySize(int w, int h);

		void Center();

		void SetParent(IPanel p);

		void UnParent();

		bool SetVarName(string name);

		void Remove();

		void ControlPaint(object sender, PaintEventArgs p);
		void OnSelect();

		// ---
		// overridable methods
		// ---

		// We can cancel a move by returning false on PreDrag
		bool PreDrag(int newx, int newy);
		void PostDrag();
		List<Control> PopulateProperties();
		// We can cancel a resize by returning false on PreResize
		bool PreResize(int newwidth, int newheight);
		void PostResize();
		string GenerateLua();
	}
}
