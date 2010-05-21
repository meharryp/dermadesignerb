namespace DermaDesigner
{
    partial class Main
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.FormMenu = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.luaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.generateToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.generateToTextBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x480ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x600ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x768ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x960ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x1064ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.widescreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x720ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x900ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x1050ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x1080ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.snapToCornerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.snapToRightCornerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.findPanelByVariableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.FormMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// FormMenu
			// 
			this.FormMenu.BackColor = System.Drawing.Color.YellowGreen;
			this.FormMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem});
			this.FormMenu.Location = new System.Drawing.Point(0, 0);
			this.FormMenu.Name = "FormMenu";
			this.FormMenu.Size = new System.Drawing.Size(630, 24);
			this.FormMenu.TabIndex = 0;
			this.FormMenu.Text = "Menu";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.luaToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// luaToolStripMenuItem
			// 
			this.luaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToFileToolStripMenuItem,
            this.generateToTextBoxToolStripMenuItem});
			this.luaToolStripMenuItem.Name = "luaToolStripMenuItem";
			this.luaToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
			this.luaToolStripMenuItem.Text = "Lua";
			// 
			// generateToFileToolStripMenuItem
			// 
			this.generateToFileToolStripMenuItem.Name = "generateToFileToolStripMenuItem";
			this.generateToFileToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.generateToFileToolStripMenuItem.Text = "Generate to File";
			this.generateToFileToolStripMenuItem.Click += new System.EventHandler(this.generateToFileToolStripMenuItem_Click);
			// 
			// generateToTextBoxToolStripMenuItem
			// 
			this.generateToTextBoxToolStripMenuItem.Name = "generateToTextBoxToolStripMenuItem";
			this.generateToTextBoxToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.generateToTextBoxToolStripMenuItem.Text = "Generate to Text Box";
			this.generateToTextBoxToolStripMenuItem.Click += new System.EventHandler(this.generateToTextBoxToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(90, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.ToolTipText = "Exits the program";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeToolStripMenuItem,
            this.toolboxToolStripMenuItem,
            this.propertiesToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// sizeToolStripMenuItem
			// 
			this.sizeToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
			this.sizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.widescreenToolStripMenuItem});
			this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
			this.sizeToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.sizeToolStripMenuItem.Text = "Size";
			// 
			// normalToolStripMenuItem
			// 
			this.normalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x480ToolStripMenuItem,
            this.x600ToolStripMenuItem,
            this.x768ToolStripMenuItem,
            this.x960ToolStripMenuItem,
            this.x1064ToolStripMenuItem});
			this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
			this.normalToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.normalToolStripMenuItem.Text = "Normal";
			// 
			// x480ToolStripMenuItem
			// 
			this.x480ToolStripMenuItem.Name = "x480ToolStripMenuItem";
			this.x480ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.x480ToolStripMenuItem.Text = "640 x 480";
			this.x480ToolStripMenuItem.Click += new System.EventHandler(this.x480ToolStripMenuItem_Click);
			// 
			// x600ToolStripMenuItem
			// 
			this.x600ToolStripMenuItem.Name = "x600ToolStripMenuItem";
			this.x600ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.x600ToolStripMenuItem.Text = "800 x 600";
			this.x600ToolStripMenuItem.Click += new System.EventHandler(this.x600ToolStripMenuItem_Click);
			// 
			// x768ToolStripMenuItem
			// 
			this.x768ToolStripMenuItem.Name = "x768ToolStripMenuItem";
			this.x768ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.x768ToolStripMenuItem.Text = "1024 x 768";
			this.x768ToolStripMenuItem.Click += new System.EventHandler(this.x768ToolStripMenuItem_Click);
			// 
			// x960ToolStripMenuItem
			// 
			this.x960ToolStripMenuItem.Name = "x960ToolStripMenuItem";
			this.x960ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.x960ToolStripMenuItem.Text = "1280 x 960";
			this.x960ToolStripMenuItem.Click += new System.EventHandler(this.x960ToolStripMenuItem_Click);
			// 
			// x1064ToolStripMenuItem
			// 
			this.x1064ToolStripMenuItem.Name = "x1064ToolStripMenuItem";
			this.x1064ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.x1064ToolStripMenuItem.Text = "1280 x 1024";
			this.x1064ToolStripMenuItem.Click += new System.EventHandler(this.x1064ToolStripMenuItem_Click);
			// 
			// widescreenToolStripMenuItem
			// 
			this.widescreenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x720ToolStripMenuItem,
            this.xToolStripMenuItem,
            this.x900ToolStripMenuItem,
            this.x1050ToolStripMenuItem,
            this.x1080ToolStripMenuItem});
			this.widescreenToolStripMenuItem.Name = "widescreenToolStripMenuItem";
			this.widescreenToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.widescreenToolStripMenuItem.Text = "Widescreen";
			// 
			// x720ToolStripMenuItem
			// 
			this.x720ToolStripMenuItem.Name = "x720ToolStripMenuItem";
			this.x720ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.x720ToolStripMenuItem.Text = "1280 x 720";
			this.x720ToolStripMenuItem.Click += new System.EventHandler(this.x720ToolStripMenuItem_Click);
			// 
			// xToolStripMenuItem
			// 
			this.xToolStripMenuItem.Name = "xToolStripMenuItem";
			this.xToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.xToolStripMenuItem.Text = "1280 x 768";
			this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
			// 
			// x900ToolStripMenuItem
			// 
			this.x900ToolStripMenuItem.Name = "x900ToolStripMenuItem";
			this.x900ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.x900ToolStripMenuItem.Text = "1440 x 900";
			this.x900ToolStripMenuItem.Click += new System.EventHandler(this.x900ToolStripMenuItem_Click);
			// 
			// x1050ToolStripMenuItem
			// 
			this.x1050ToolStripMenuItem.Name = "x1050ToolStripMenuItem";
			this.x1050ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.x1050ToolStripMenuItem.Text = "1680 x 1050";
			this.x1050ToolStripMenuItem.Click += new System.EventHandler(this.x1050ToolStripMenuItem_Click);
			// 
			// x1080ToolStripMenuItem
			// 
			this.x1080ToolStripMenuItem.Name = "x1080ToolStripMenuItem";
			this.x1080ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.x1080ToolStripMenuItem.Text = "1920 x 1080";
			this.x1080ToolStripMenuItem.Click += new System.EventHandler(this.x1080ToolStripMenuItem_Click);
			// 
			// toolboxToolStripMenuItem
			// 
			this.toolboxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.snapToCornerToolStripMenuItem});
			this.toolboxToolStripMenuItem.Name = "toolboxToolStripMenuItem";
			this.toolboxToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.toolboxToolStripMenuItem.Text = "Toolbox";
			// 
			// showToolStripMenuItem
			// 
			this.showToolStripMenuItem.Name = "showToolStripMenuItem";
			this.showToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.showToolStripMenuItem.Text = "Show";
			this.showToolStripMenuItem.ToolTipText = "Show the toolbox if it\'s hidden";
			this.showToolStripMenuItem.Click += new System.EventHandler(this.toolboxToolStripMenuItem_Click);
			// 
			// snapToCornerToolStripMenuItem
			// 
			this.snapToCornerToolStripMenuItem.CheckOnClick = true;
			this.snapToCornerToolStripMenuItem.Name = "snapToCornerToolStripMenuItem";
			this.snapToCornerToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.snapToCornerToolStripMenuItem.Text = "Snap to left corner";
			this.snapToCornerToolStripMenuItem.ToolTipText = "Toggle the toolbox snappng to the top left corner of the workspace";
			this.snapToCornerToolStripMenuItem.CheckedChanged += new System.EventHandler(this.snapToCornerToolStripMenuItem_CheckedChanged);
			// 
			// propertiesToolStripMenuItem
			// 
			this.propertiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem1,
            this.snapToRightCornerToolStripMenuItem});
			this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
			this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.propertiesToolStripMenuItem.Text = "Properties Window";
			// 
			// showToolStripMenuItem1
			// 
			this.showToolStripMenuItem1.Name = "showToolStripMenuItem1";
			this.showToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
			this.showToolStripMenuItem1.Text = "Show";
			this.showToolStripMenuItem1.Click += new System.EventHandler(this.showToolStripMenuItem1_Click);
			// 
			// snapToRightCornerToolStripMenuItem
			// 
			this.snapToRightCornerToolStripMenuItem.CheckOnClick = true;
			this.snapToRightCornerToolStripMenuItem.Name = "snapToRightCornerToolStripMenuItem";
			this.snapToRightCornerToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.snapToRightCornerToolStripMenuItem.Text = "Snap to right corner";
			this.snapToRightCornerToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.snapToRightCornerToolStripMenuItem_CheckStateChanged);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findPanelByVariableToolStripMenuItem,
            this.toolStripSeparator2,
            this.updateToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// findPanelByVariableToolStripMenuItem
			// 
			this.findPanelByVariableToolStripMenuItem.Name = "findPanelByVariableToolStripMenuItem";
			this.findPanelByVariableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.findPanelByVariableToolStripMenuItem.Text = "Find Panel";
			this.findPanelByVariableToolStripMenuItem.Click += new System.EventHandler(this.findPanelByVariableToolStripMenuItem_Click);
			// 
			// updateToolStripMenuItem
			// 
			this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
			this.updateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.updateToolStripMenuItem.Text = "Update";
			this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
			// 
			// Main
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(630, 448);
			this.Controls.Add(this.FormMenu);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.FormMenu;
			this.MaximizeBox = false;
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DermaDesigner - Workspace";
			this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.Move += new System.EventHandler(this.Form1_Move);
			this.FormMenu.ResumeLayout(false);
			this.FormMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		public System.Windows.Forms.MenuStrip FormMenu;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x480ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x600ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x768ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x960ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x1064ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem widescreenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x900ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x1050ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolboxToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem snapToCornerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem snapToRightCornerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem luaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem generateToFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem generateToTextBoxToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem x720ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x1080ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem findPanelByVariableToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
    }
}

