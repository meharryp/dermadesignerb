using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DermaDesigner.GUI {
	public class Grid {
		public static bool DrawGrid = false;
		public static int GridSize = 20;
		private static Pen blackPen = new Pen(Color.LightGreen, 1);

		public static void Paint(object sender, PaintEventArgs e) {
			if (!DrawGrid)
				return;

			Form main = Derma.GetWorkspace();

			e.Graphics.SetClip(new Rectangle(0, 0, main.Size.Width, main.Size.Height));

			for (int i = GridSize; i < Derma.GetWorkspace().Size.Width; i += GridSize) {
				e.Graphics.DrawLine(blackPen, i, 0, i, Derma.GetWorkspace().Size.Height);
				e.Graphics.DrawLine(blackPen, 0, i, Derma.GetWorkspace().Size.Width, i);
			}

			return;
		}
	}
}
