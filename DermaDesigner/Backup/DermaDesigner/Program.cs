using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace DermaDesigner {
    static class Program {
		static List<string> panelTypes = new List<string>();
		
		static void CreateControl(object sender, EventArgs e) {
			TreeView t = (TreeView)sender;
			if (panelTypes.Contains(t.SelectedNode.Text)) {
				Derma.New(t.SelectedNode.Text.ToString());
				Derma.GetWorkspace().Invalidate();
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
            Derma.Init(new Form1(), new PropertiesWindow());
			Derma.GetWorkspace().Show();

			panelTypes.AddRange(new List<string>() {
				"DFrame",
			});

			Toolbox t = new Toolbox();
			Derma.toolbox = t;
			t.Location = new System.Drawing.Point(Derma.GetWorkspace().Location.X - t.ClientSize.Width - 20, Derma.GetWorkspace().Location.Y);
			t.Show();

			Derma.prop.Location = new System.Drawing.Point(Derma.GetWorkspace().Location.X + Derma.GetWorkspace().ClientSize.Width + 24, Derma.GetWorkspace().Location.Y);
			Derma.prop.Show();

			Derma.GetWorkspace().Focus();

			TreeNode parent = new TreeNode("Panel", new TreeNode[] {
				new TreeNode("DFrame"),
			});

			t.treeView1.Nodes.Add(parent);
			t.treeView1.Nodes[0].Expand();
			t.treeView1.NodeMouseDoubleClick += CreateControl;

            Application.Run(Derma.GetWorkspace());
        }
    }
}
