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

		private void controlPanel_MouseMove(object sender, MouseEventArgs e) {
			if (this.controlPanel.SelectedItems.Count > 0 && e.Button == MouseButtons.Left && !this.dragging) {
				this.DoDragDrop(this.controlPanel.SelectedItems[0].Text, DragDropEffects.Copy | DragDropEffects.Move);
				this.dragging = true;
			} else if (e.Button != MouseButtons.Left && this.dragging)
				this.dragging = false;
		}
    }
}
