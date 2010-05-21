/* @Gbps -- This is a small library for getting some C++ functions we need to make sure the
 * the main windows correctly focus when the main window focuses.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace DermaDesigner {
	public class ShowWindowInterop {
		private const int SW_SHOWNOACTIVATE = 4;
		private const int HWND_TOPMOST = -1;
		private const uint SWP_NOACTIVATE = 0x0010;
		private const int SW_HIDEWINDOW = 0;
		[DllImport("user32.dll", EntryPoint = "SetWindowPos")]
		static extern bool SetWindowPos(
			 int hWnd,           // window handle
			 int hWndInsertAfter,    // placement-order handle
			 int X,          // horizontal position
			 int Y,          // vertical position
			 int cx,         // width
			 int cy,         // height
			 uint uFlags);       // window positioning flags

		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		[DllImport("user32.dll")]
		static extern IntPtr GetForegroundWindow();

		public static void ShowInactiveTopmost(Form frm) {
			ShowWindow(frm.Handle, SW_SHOWNOACTIVATE);
			SetWindowPos(frm.Handle.ToInt32(), HWND_TOPMOST,
			frm.Left, frm.Top, frm.Width, frm.Height,
			SWP_NOACTIVATE);
		}
		public static void HideTarget(Form frm) {
			ShowWindow(frm.Handle, SW_HIDEWINDOW);
		}

		public static IntPtr GetForegroundWindowPtr() {
			IntPtr Active = GetForegroundWindow();
			return Active;
		}
	}
}
