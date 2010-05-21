using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DermaDesigner {
	public partial class SaveLuaFile : Form {
		public SaveLuaFile() {
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void SaveBtn_Click(object sender, EventArgs e) {
			string path = pathText.Text;

			if (path.Length < 1 || path.Trim().Length < 1) {
				MessageBox.Show("Invalid path name.", "Invalid path");
				return;
			}

			foreach (char c in System.IO.Path.GetInvalidFileNameChars()) {
				if (path.Contains(c)) {
					MessageBox.Show("Invalid character '" + c + "' in file path.", "Invalid path");
					return;
				}
			}

			if (!System.IO.Path.HasExtension(path))
				path += ".lua";

			if (!overwriteCheckBox.Checked && System.IO.File.Exists(path)) {
				MessageBox.Show("File '" + path + "' already exists.", "File already exists");
				return;
			}
			
			string lua = Derma.GenerateLua();

			System.IO.TextWriter file = new System.IO.StreamWriter(path);
			file.Write(lua);
			file.Close();

			MessageBox.Show("Lua generated to file '" + path + "'.", "Success");

			this.Close();
		}
	}
}
