using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DermaDesigner {
	class ResizeGrip {
		private static Image grip = Derma.LoadImage("resources/resizegrip.png");
		private static int twoThirdsSize = (grip.Width / 3) * 2;
		private static bool resizing = false;
		private static Point mouseOrigin = new Point(0, 0);
		public static Panel host;

		public static bool IsResizing() { return resizing; }

		public static void Paint(object sender, PaintEventArgs e) {
			if (host != null && Derma.GetSelected() == host && host.sizable) {
				// set the clip so we can actually see ourself...
				e.Graphics.Clip = new Region(new Rectangle(host.x + host.width - twoThirdsSize, host.y + host.height - twoThirdsSize, 16, 16));
				
				// draw us
				e.Graphics.DrawImage(grip, host.x + host.width - twoThirdsSize, host.y + host.height - twoThirdsSize, 16, 16);
			}
		}

		public static bool Resize_MouseDown(object sender, MouseEventArgs e) {
			if (host != null && Derma.GetSelected() == host && !host.locked && host.sizable && Derma.IsMouseOverArea(host.x + host.width - twoThirdsSize, host.y + host.height - twoThirdsSize, 16, 16)) {
				resizing = true;
				mouseOrigin.X = e.X;
				mouseOrigin.Y = e.Y;
				return true;
			}
			return false;
		}

		public static void Resize_MouseUp(object sender, MouseEventArgs e) {
			if (resizing)
				resizing = false;
		}

		public static void Resize_MouseMove(object sender, MouseEventArgs e) {
			if (resizing) {
				Point newsize;
				if (host.centered) newsize = new Point((e.X - mouseOrigin.X) * 2, (e.Y - mouseOrigin.Y) * 2);
				else newsize = new Point(e.X - mouseOrigin.X, e.Y - mouseOrigin.Y);
				if (host.PreResize(host.width + newsize.X, host.height + newsize.Y) && host.width + newsize.X > 10 && host.height + newsize.Y > 10) {
					host.ModifySize(newsize.X, newsize.Y);
					mouseOrigin.X = e.X;
					mouseOrigin.Y = e.Y;
					host.PostResize();
					Derma.RefreshProperties();
					Derma.Repaint();
				}
			}
		}
	}
}
