//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;
//using System.Drawing;

//namespace DermaDesigner {
//    class ResizeGrip {
//        private static Image grip = Derma.LoadImage("resources/resizegrip.png");
//        private static int twoThirdsSize = (grip.Width / 3) * 2;
//        private static bool resizing = false;
//        private static Point mouseOrigin = new Point(0, 0);
//        public static Panel host;

//        public static bool IsResizing() { return resizing; }

//        public static void Paint(object sender, PaintEventArgs e) {
//            if (host != null && Derma.GetSelected() == host && host.sizable) {
//                // set the clip so we can actually see ourself...
//                e.Graphics.Clip = new Region(new Rectangle(host.x + host.width - twoThirdsSize, host.y + host.height - twoThirdsSize, 16, 16));
				
//                // draw us
//                e.Graphics.DrawImage(grip, host.x + host.width - twoThirdsSize, host.y + host.height - twoThirdsSize, 16, 16);
//            }
//        }

//        public static bool Resize_MouseDown(object sender, MouseEventArgs e) {
//            if (host != null && Derma.GetSelected() == host && !host.locked && host.sizable && Derma.IsMouseOverArea(host.x + host.width - twoThirdsSize, host.y + host.height - twoThirdsSize, 16, 16)) {
//                resizing = true;
//                mouseOrigin.X = e.X;
//                mouseOrigin.Y = e.Y;
//                return true;
//            }
//            return false;
//        }

//        public static void Resize_MouseUp(object sender, MouseEventArgs e) {
//            if (resizing)
//                resizing = false;
//        }

//        public static void Resize_MouseMove(object sender, MouseEventArgs e) {
//            if (resizing) {
//                Point newsize;
//                if (host.centered) newsize = new Point((e.X - mouseOrigin.X) * 2, (e.Y - mouseOrigin.Y) * 2);
//                else newsize = new Point(e.X - mouseOrigin.X, e.Y - mouseOrigin.Y);
//                if (host.PreResize(host.width + newsize.X, host.height + newsize.Y) && host.width + newsize.X > 10 && host.height + newsize.Y > 10) {
//                    host.ModifySize(newsize.X, newsize.Y);
//                    mouseOrigin.X = e.X;
//                    mouseOrigin.Y = e.Y;
//                    host.PostResize();
//                    Derma.RefreshProperties();
//                    Derma.Repaint();
//                }
//            }
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DermaDesigner {
	class ResizeGrip {
		private static Image grip = Derma.LoadImage("resources/resizegrip_noround.png");
		private static Image gripb = Derma.LoadImage("resources/resizegripb.png");
		private static Image gripr = Derma.LoadImage("resources/resizegripr.png");
		private static int twoThirdsSize = (grip.Width / 3) * 2;
		private static int halfSize = (grip.Width / 2);
		private static bool resizing = false;
		private static bool resizinga = false;
		private static bool resizingx = false;
		private static bool resizingy = false;
		private static Point mouseOrigin = new Point(0, 0);
		public static Panel host;

		public static bool IsResizing() { return resizing; }

		public static void Paint(object sender, PaintEventArgs e) {
			if (host != null && Derma.GetSelected() == host && host.sizable) {
				// set the clip so we can actually see ourself...
				if (host.sizable && host.sizablex && host.sizabley) {
					e.Graphics.Clip = new Region(new Rectangle(host.x + host.width - twoThirdsSize, host.y + host.height - twoThirdsSize, 16, 16));
					e.Graphics.DrawImage(grip, host.x + host.width - twoThirdsSize, host.y + host.height - twoThirdsSize, 16, 16);
				}

				if (host.sizabley) {
					e.Graphics.Clip = new Region(new Rectangle(host.x + host.width / 2 - halfSize, host.y + host.height - halfSize - 2, 16, 16));
					e.Graphics.DrawImage(gripb, host.x + host.width / 2 - halfSize, host.y + host.height - halfSize - 2, 16, 16);
				}

				if (host.sizablex) {
					e.Graphics.Clip = new Region(new Rectangle(host.x + host.width - halfSize - 2, host.y + host.height / 2 - halfSize, 16, 16));
					e.Graphics.DrawImage(gripr, host.x + host.width - halfSize - 2, host.y + host.height / 2 - halfSize, 16, 16);
				}
			}
		}

		public static bool Resize_MouseDown(object sender, MouseEventArgs e) {
			if (host != null && Derma.GetSelected() == host && !host.locked && host.sizable && host.sizablex && Derma.IsMouseOverArea(host.x + host.width - halfSize - 2, host.y + host.height / 2 - halfSize, 16, 16)) {
				resizing = true;
				resizingx = true;
				mouseOrigin.X = e.X;
				mouseOrigin.Y = e.Y;
				return true;
			} else if (host != null && Derma.GetSelected() == host && !host.locked && host.sizable && host.sizabley && Derma.IsMouseOverArea(host.x + host.width / 2 - halfSize, host.y + host.height - halfSize - 2, 16, 16)) {
				resizing = true;
				resizingy = true;
				mouseOrigin.X = e.X;
				mouseOrigin.Y = e.Y;
				return true;
			} else if (host != null && Derma.GetSelected() == host && !host.locked && host.sizable && host.sizablex && host.sizabley && Derma.IsMouseOverArea(host.x + host.width - twoThirdsSize, host.y + host.height - twoThirdsSize, 16, 16)) {
				resizing = true;
				resizinga = true;
				mouseOrigin.X = e.X;
				mouseOrigin.Y = e.Y;
				return true;
			}

			return false;
		}

		public static void Resize_MouseUp(object sender, MouseEventArgs e) {
			resizing = false;
			resizinga = false;
			resizingx = false;
			resizingy = false;
		}

		public static void Resize_MouseMove(object sender, MouseEventArgs e) {
			if (resizing && resizinga) {
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
			} else if (resizing && resizingx) {
				Point newsize;
				if (host.centered) newsize = new Point((e.X - mouseOrigin.X) * 2, (mouseOrigin.Y) * 2);
				else newsize = new Point(e.X - mouseOrigin.X, mouseOrigin.Y);
				if (host.PreResize(host.width + newsize.X, host.height + newsize.Y) && host.width + newsize.X > 10 && host.height + newsize.Y > 10) {
					host.ModifySize(newsize.X, 0);
					mouseOrigin.X = e.X;
					host.PostResize();
					Derma.RefreshProperties();
					Derma.Repaint();
				}
			} else if (resizing && resizingy) {
				Point newsize;
				if (host.centered) newsize = new Point((mouseOrigin.X) * 2, (e.Y - mouseOrigin.Y) * 2);
				else newsize = new Point(mouseOrigin.X, e.Y - mouseOrigin.Y);
				if (host.PreResize(host.width + newsize.X, host.height + newsize.Y) && host.width + newsize.X > 10 && host.height + newsize.Y > 10) {
					host.ModifySize(0, newsize.Y);
					mouseOrigin.Y = e.Y;
					host.PostResize();
					Derma.RefreshProperties();
					Derma.Repaint();
				}
			}
		}
	}
}
