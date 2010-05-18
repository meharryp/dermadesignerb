using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DermaDesigner {
	public partial class Toolbox : Form {
        public Toolbox() {
            InitializeComponent();
		}

		private void HideToolbox(object sender, FormClosingEventArgs e) {
			this.Hide();
			e.Cancel = true;
		}

		private void Toolbox_Move(object sender, EventArgs e) {
			if (this.snapToWorkspace)
				this.Location = new System.Drawing.Point(Derma.GetWorkspace().Location.X - Derma.toolbox.ClientSize.Width - 20, Derma.GetWorkspace().Location.Y);
		}
    }
}
