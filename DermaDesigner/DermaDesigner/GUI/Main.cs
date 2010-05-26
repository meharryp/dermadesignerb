using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DermaDesigner {
	public partial class Main : Form {
		public Main() {
			InitializeComponent();
		}

		private void x480ToolStripMenuItem_Click(object sender, EventArgs e) {
			Main.ActiveForm.Size = new Size(640, 480);
			Derma.Repaint();
		}

		private void x600ToolStripMenuItem_Click(object sender, EventArgs e) {
			Main.ActiveForm.Size = new Size(800, 600);
			Derma.Repaint();
		}

		private void x768ToolStripMenuItem_Click(object sender, EventArgs e) {
			Main.ActiveForm.Size = new Size(1024, 768);
			Derma.Repaint();
		}

		private void x960ToolStripMenuItem_Click(object sender, EventArgs e) {
			Main.ActiveForm.Size = new Size(1280, 960);
			Derma.Repaint();
		}

		private void x1064ToolStripMenuItem_Click(object sender, EventArgs e) {
			Main.ActiveForm.Size = new Size(1280, 1024);
			Derma.Repaint();
		}

		private void xToolStripMenuItem_Click(object sender, EventArgs e) {
			Main.ActiveForm.Size = new Size(1280, 768);
			Derma.Repaint();
		}

		private void x900ToolStripMenuItem_Click(object sender, EventArgs e) {
			Main.ActiveForm.Size = new Size(1440, 900);
			Derma.Repaint();
		}

		private void x1050ToolStripMenuItem_Click(object sender, EventArgs e) {
			Main.ActiveForm.Size = new Size(1680, 1050);
			Derma.Repaint();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Derma.GetWorkspace().Close();
			Application.Exit();
		}

		private void toolboxToolStripMenuItem_Click(object sender, EventArgs e) {
			Derma.toolbox.Show();
		}

		private void snapToCornerToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
			ToolStripMenuItem t = (ToolStripMenuItem)sender;
			Derma.toolbox.snapToWorkspace = t.Checked;
			if (t.Checked)
				Derma.toolbox.Location = new System.Drawing.Point(Derma.GetWorkspace().Location.X - Derma.toolbox.ClientSize.Width - 20, Derma.GetWorkspace().Location.Y);
		}

		private void Form1_Move(object sender, EventArgs e) {
			if (Derma.toolbox != null && Derma.toolbox.snapToWorkspace)
				Derma.toolbox.Location = new System.Drawing.Point(Derma.GetWorkspace().Location.X - Derma.toolbox.ClientSize.Width - 20, Derma.GetWorkspace().Location.Y);

			if (Derma.prop != null && Derma.prop.snapToWorkspace)
				Derma.prop.Location = new System.Drawing.Point(Derma.GetWorkspace().Location.X + Derma.GetWorkspace().ClientSize.Width + 24, Derma.GetWorkspace().Location.Y);
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			if (Derma.GetSelected() == null) return;

			if (e.KeyValue == (int)Keys.Delete) {
				Derma.GetSelected().Remove();
				Derma.prop.propertyGrid.SelectedObject = null;
				return;
			}

			int dist;
			if ((e.Modifiers & Keys.Shift) == Keys.Shift)
				dist = 10;
			else
				dist = 1;

			switch (e.KeyValue) {
				case (int)Keys.Up:
					if (GUI.Grid.DrawGrid && !VirtualKeys.IsKeyPressed(VirtualKeyStates.VK_TAB)) {
						dist = Derma.GetSelected().y % GUI.Grid.GridSize;
						if (dist == 0) dist = GUI.Grid.GridSize;
						if (VirtualKeys.IsKeyPressed(VirtualKeyStates.VK_SHIFT)) dist += GUI.Grid.GridSize;
					}
					Derma.GetSelected().ModifyPos(0, -dist);
					break;
				case (int)Keys.Left:
					if (GUI.Grid.DrawGrid && !VirtualKeys.IsKeyPressed(VirtualKeyStates.VK_TAB)) {
						dist = Derma.GetSelected().x % GUI.Grid.GridSize;
						if (dist == 0) dist = GUI.Grid.GridSize;
						if (VirtualKeys.IsKeyPressed(VirtualKeyStates.VK_SHIFT)) dist += GUI.Grid.GridSize;
					}
					Derma.GetSelected().ModifyPos(-dist, 0);
					break;
				case (int)Keys.Right:
					if (GUI.Grid.DrawGrid && !VirtualKeys.IsKeyPressed(VirtualKeyStates.VK_TAB)) {
						dist = Derma.GetSelected().x % GUI.Grid.GridSize;
						if (dist == 0) dist = GUI.Grid.GridSize;
						if (VirtualKeys.IsKeyPressed(VirtualKeyStates.VK_SHIFT)) dist += GUI.Grid.GridSize;
					}
					Derma.GetSelected().ModifyPos(dist, 0);
					break;
				case (int)Keys.Down:
					if (GUI.Grid.DrawGrid && !VirtualKeys.IsKeyPressed(VirtualKeyStates.VK_TAB)) {
						dist = Derma.GetSelected().y % GUI.Grid.GridSize;
						if (dist == 0) dist = GUI.Grid.GridSize;
						if (VirtualKeys.IsKeyPressed(VirtualKeyStates.VK_SHIFT)) dist += GUI.Grid.GridSize;
					}
					Derma.GetSelected().ModifyPos(0, dist);
					break;
			}

			Derma.RefreshProperties();
		}

		private void Form1_ResizeEnd(object sender, EventArgs e) {
			Derma.Repaint();
		}

		private void showToolStripMenuItem1_Click(object sender, EventArgs e) {
			Derma.prop.Show();
		}

		private void snapToRightCornerToolStripMenuItem_CheckStateChanged(object sender, EventArgs e) {
			ToolStripMenuItem t = (ToolStripMenuItem)sender;
			Derma.prop.snapToWorkspace = t.Checked;
			if (t.Checked)
				Derma.prop.Location = new System.Drawing.Point(Derma.GetWorkspace().Location.X + Derma.GetWorkspace().ClientSize.Width + 20, Derma.GetWorkspace().Location.Y);
		}

		private void Form1_DragDrop(object sender, DragEventArgs e) {
			string pName = (string)e.Data.GetData(typeof(string));
			Point newPos = Derma.GetRelativeMousePos(e.X, e.Y);
			Derma.New(pName, newPos.X, newPos.Y);
			Derma.Repaint();
		}

		private void Form1_DragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.Text)) {
				e.Effect = DragDropEffects.Move;
			}
		}

		private void generateToFileToolStripMenuItem_Click(object sender, EventArgs e) {
			SaveLuaFile s = new SaveLuaFile();
			s.ShowDialog(this);
		}

		private void generateToTextBoxToolStripMenuItem_Click(object sender, EventArgs e) {
			LargeTextBox l = new LargeTextBox();

			l.luaOutput.Text = Derma.GenerateLua();

			l.ShowDialog(this);
		}

		private void x720ToolStripMenuItem_Click(object sender, EventArgs e) {
			Main.ActiveForm.Size = new Size(1280, 720);
			Derma.Repaint();
		}

		private void x1080ToolStripMenuItem_Click(object sender, EventArgs e) {
			Main.ActiveForm.Size = new Size(1920, 1080);
			Derma.Repaint();
		}

		private void findPanelByVariableToolStripMenuItem_Click(object sender, EventArgs e) {
			if (Derma.findpanelwindow == null) {
				Derma.findpanelwindow = new FindPanelByVar();
				Derma.findpanelwindow.Show();
			} else {
				Derma.findpanelwindow.Show();
			}
		}

		private void updateToolStripMenuItem_Click(object sender, EventArgs e) {
			DialogResult reply = MessageBox.Show("Are you sure you want to update?\nAny unsaved data will be lost.",
			"Update?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			if (reply == DialogResult.Yes) {
				System.Diagnostics.Process.Start("DermaDesignerUpdater.exe");
				Environment.Exit(0);
			}
		}

		private void Main_Load(object sender, EventArgs e) {

		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e) {
			if (Derma.GetPanels().Count > 0) {
				DialogResult reply = MessageBox.Show("Are you sure you want to start a new project?\nAny unsaved data will be lost.",
				"Really create a new project?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
				if (reply == DialogResult.Yes) {
					DSave.ClearAll();
					Derma.prop.propertyGrid.SelectedObject = null;
					Derma.Repaint();
				}
			} else {
				DSave.ClearAll();
				Derma.prop.propertyGrid.SelectedObject = null;
				Derma.Repaint();
			}
		}

		private void SaveDialog_FileOk(object sender, CancelEventArgs e) {
			DSave.SaveAs(SaveDialog.FileName);
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
			if (DSave.GetEnvironment() == "Untitled.ddproj") {
				SaveDialog.ShowDialog();
			} else {
				DSave.Save();
			}
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
			DSave.SetDialogDefaults();
			SaveDialog.ShowDialog();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			if (Derma.GetPanels().Count > 0) {
				DialogResult reply = MessageBox.Show("Are you sure you want to open a saved project?\nAny unsaved data in the current project will be lost.",
				"Open project", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
				if (reply != DialogResult.Yes) {
					return;
				}
			}
			DSave.SetDialogDefaults();
			Derma.prop.propertyGrid.SelectedObject = null;
			OpenDialog.ShowDialog();
		}

		private void OpenDialog_FileOk(object sender, CancelEventArgs e) {
			DSave.ClearAll();
			DSave.Load(OpenDialog.FileName);
		}

		private void _DebugResetLabelMain_Click(object sender, EventArgs e) {
			Derma.Profiler.Reset();
		}

		private void noneToolStripMenuItem_Click(object sender, EventArgs e) {
			GUI.Grid.DrawGrid = false;
			Derma.Repaint();
		}

		private void x5ToolStripMenuItem_Click(object sender, EventArgs e) {
			GUI.Grid.DrawGrid = true;
			GUI.Grid.GridSize = 5;
			Derma.Repaint();
		}

		private void x10ToolStripMenuItem_Click(object sender, EventArgs e) {
			GUI.Grid.DrawGrid = true;
			GUI.Grid.GridSize = 10;
			Derma.Repaint();
		}

		private void x20ToolStripMenuItem_Click(object sender, EventArgs e) {
			GUI.Grid.DrawGrid = true;
			GUI.Grid.GridSize = 25;
			Derma.Repaint();
		}

		private void x50ToolStripMenuItem_Click(object sender, EventArgs e) {
			GUI.Grid.DrawGrid = true;
			GUI.Grid.GridSize = 50;
			Derma.Repaint();
		}

		private void x100ToolStripMenuItem_Click(object sender, EventArgs e) {
			GUI.Grid.DrawGrid = true;
			GUI.Grid.GridSize = 100;
			Derma.Repaint();
		}

		private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e) {
			if (e.KeyChar == (char)VirtualKeyStates.VK_RETURN) {
				int newv;
				bool success = Int32.TryParse(toolStripTextBox1.Text, out newv);
				if (success) {
					toolsToolStripMenuItem.HideDropDown();
					GUI.Grid.DrawGrid = true;
					GUI.Grid.GridSize = newv;
					e.Handled = true;
					Derma.Repaint();
				} else {
					MessageBox.Show("Invalid grid size", "Invalid value");
				}
			}
		}

		private void unparentPanelToolStripMenuItem_Click(object sender, EventArgs e) {
			Derma.GetSelected().UnParent();

			Derma.Repaint();
		}
	}
}
