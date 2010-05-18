using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DermaDesigner {
	public partial class PropertiesWindow : Form {
		public PropertiesWindow() {
			InitializeComponent();
		}

		private void PropertiesWindow_FormClosing(object sender, FormClosingEventArgs e) {
			this.Hide();
			e.Cancel = true;
		}

		private void PropertiesWindow_Move(object sender, EventArgs e) {
			if (this.snapToWorkspace)
				this.Location = new System.Drawing.Point(Derma.GetWorkspace().Location.X + Derma.GetWorkspace().ClientSize.Width + 24, Derma.GetWorkspace().Location.Y);
		}
	}
}
