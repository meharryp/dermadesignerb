namespace DermaDesigner
{
    partial class Toolbox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Toolbox));
            this.controlPanel = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.AllowDrop = true;
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.MultiSelect = false;
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(313, 316);
            this.controlPanel.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.controlPanel.TabIndex = 2;
            this.controlPanel.UseCompatibleStateImageBehavior = false;
            this.controlPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.controlPanel_MouseMove);
            // 
            // Toolbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(313, 316);
            this.Controls.Add(this.controlPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Toolbox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Toolbox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HideToolbox);
            this.Move += new System.EventHandler(this.Toolbox_Move);
            this.ResumeLayout(false);

        }

        #endregion


		public bool snapToWorkspace = false;
		public System.Windows.Forms.ListView controlPanel;
		public bool dragging = false;
	}
}