using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;
using System.IO;

namespace DermaDesigner {
    static class Program {
		static void CreateControl(object sender, EventArgs e) {
			TreeView t = (TreeView)sender;
			Derma.New(t.SelectedNode.Text.ToString());
			Derma.Repaint();
		}

		static Assembly LoadPlugin(string fullpath, string relpath) {
			try {
				Assembly asm = Assembly.LoadFile(fullpath);
				return asm;
			} catch (BadImageFormatException e) {
				MessageBox.Show("Failed to load " + relpath + ": " + e.Message + ".", "Failed to load plugin");
				return null;
			}
		}

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			// Set this before making any derma controls
			Derma.Init(new Form1(), new PropertiesWindow(), new Toolbox());
			Derma.GetWorkspace().Show();

			Derma.toolbox.Location = new System.Drawing.Point(Derma.GetWorkspace().Location.X - Derma.toolbox.ClientSize.Width - 20, Derma.GetWorkspace().Location.Y);
			Derma.toolbox.Show();

			Derma.prop.Location = new System.Drawing.Point(Derma.GetWorkspace().Location.X + Derma.GetWorkspace().ClientSize.Width + 24, Derma.GetWorkspace().Location.Y);
			Derma.prop.Show();

			Derma.GetWorkspace().Focus();

			/* here we will register all the classes derived from Panel */
				Assembly DD = Assembly.GetExecutingAssembly();

				foreach (Type type in DD.GetTypes()) {
					if (type.IsSubclassOf(typeof(Panel))) {
						MethodInfo r = type.GetMethod("Register");
						if (r == null)
							MessageBox.Show("Derma control \"" + type.ToString() + "\" failed to register: Register class method not found.", "Control registration error");
						else
							r.Invoke(type, new object[] { });
					}
				}
			/* end panel registration */

			/* here we will load all the extension modules and register the panels in them */
			string[] files = Directory.GetFiles("plugins", "*.dll");

			foreach (string dll in files) {
				Assembly fe = LoadPlugin(Path.GetFullPath(dll), dll);
				if (fe != null) {
					foreach (Type type in fe.GetTypes()) {
						if (type.IsSubclassOf(typeof(Panel))) {
							MethodInfo r = type.GetMethod("Register");
							if (r == null)
								MessageBox.Show("Derma control \"" + type.ToString() + "\" from plugin " + dll + " failed register: Register class method not found.", "Control registration error");
							else
								r.Invoke(type, new object[] { });
						}
					}
				}
			}
			/* end module registration */

            Application.Run(Derma.GetWorkspace());
        }
    }
}
