using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DermaDesigner {
	public partial class FindPanelByVar : Form {
		public FindPanelByVar() {
			InitializeComponent();
			this.Leave += FindPanelByVar_LostFocus;
			this.Enter += FindPanelByVar_GotFocus;
		}

		private void FindPanelByVar_Load(object sender, EventArgs e) {
			foreach (Panel p in Derma.GetPanels()) {
				this.PanelList.Items.Add(p.varname);
			}
		}

		private void RefreshListing() {
			this.PanelList.Items.Clear();

			foreach (Panel p in Derma.GetPanels()) {
				if (p.varname.ToLower().Contains(this.TEntry.Text.ToLower()))
					this.PanelList.Items.Add(p.varname);
			}
		}

		private void SelectBtn_Click(object sender, EventArgs e) {
			foreach (Panel p in Derma.GetPanels()) {
				if (p.varname == this.TEntry.Text) {
					Derma.SetSelected(p);
					Derma.Repaint();
					return;
				}
			}

			MessageBox.Show("No panel exists with the variable name '" + this.TEntry.Text + "'.", "Panel not found");
		}

		private void textBox1_TextChanged(object sender, EventArgs e) {
			RefreshListing();
		}

		private void PanelList_DoubleClick(object sender, EventArgs e) {
			if (this.PanelList.SelectedItem == null) return;

			foreach (Panel p in Derma.GetPanels()) {
				if (p.varname == this.PanelList.SelectedItem.ToString()) {
					Derma.SetSelected(p);
					Derma.Repaint();
					return;
				}
			}

			MessageBox.Show("No panel exists with the variable name '" + this.TEntry.Text + "'.", "Panel not found");
		}

		private void FindPanelByVar_GotFocus(object sender, EventArgs e) {
			this.Opacity = 1;
		}

		private void FindPanelByVar_LostFocus(object sender, EventArgs e) {
			this.Opacity = .55;
		}

		private void FindPanelByVar_FormClosing(object sender, FormClosingEventArgs e) {
			this.Hide();
			e.Cancel = true;
		}

		private void PanelList_Click(object sender, EventArgs e) {
			if (this.PanelList.SelectedItem != null)
				this.TEntry.Text = this.PanelList.SelectedItem.ToString();
		}

		private void textBox1_KeyUp(object sender, KeyEventArgs e) {
			RefreshListing();
		}

		private void TEntry_KeyPress(object sender, KeyPressEventArgs e) {
			if ((int)e.KeyChar == 13) {
				foreach (Panel p in Derma.GetPanels()) {
					if (p.varname == this.TEntry.Text) {
						Derma.SetSelected(p);
						Derma.Repaint();
						e.Handled = true;
						return;
					}
				}

				MessageBox.Show("No panel exists with the variable name '" + this.TEntry.Text + "'.", "Panel not found");
				return;
			}
		}
	}
}
