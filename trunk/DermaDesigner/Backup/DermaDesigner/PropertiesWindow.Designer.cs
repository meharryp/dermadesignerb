namespace DermaDesigner {
	partial class PropertiesWindow {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertiesWindow));
			this.SuspendLayout();
			// 
			// PropertiesWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(234, 316);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "PropertiesWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "DermaDesigner - Properties";
			this.Move += new System.EventHandler(this.PropertiesWindow_Move);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PropertiesWindow_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		public bool snapToWorkspace = false;
	}
}