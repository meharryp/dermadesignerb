using System.Drawing;

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
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
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
			this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x20ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x50ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
			this.findPanelByVariableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
			this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
			this._DebugLabelMain = new System.Windows.Forms.Label();
			this._DebugResetLabelMain = new System.Windows.Forms.Label();
			this.unparentPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator4,
            this.luaToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(120, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.saveAsToolStripMenuItem.Text = "Save As...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(120, 6);
			// 
			// luaToolStripMenuItem
			// 
			this.luaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToFileToolStripMenuItem,
            this.generateToTextBoxToolStripMenuItem});
			this.luaToolStripMenuItem.Name = "luaToolStripMenuItem";
			this.luaToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
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
			this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
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
            this.gridToolStripMenuItem,
            this.findPanelByVariableToolStripMenuItem,
            this.unparentPanelToolStripMenuItem,
            this.toolStripSeparator2,
            this.updateToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// gridToolStripMenuItem
			// 
			this.gridToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noneToolStripMenuItem,
            this.x5ToolStripMenuItem,
            this.x10ToolStripMenuItem,
            this.x20ToolStripMenuItem,
            this.x50ToolStripMenuItem,
            this.x100ToolStripMenuItem,
            this.customToolStripMenuItem});
			this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
			this.gridToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.gridToolStripMenuItem.Text = "Grid";
			// 
			// noneToolStripMenuItem
			// 
			this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
			this.noneToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.noneToolStripMenuItem.Text = "None";
			this.noneToolStripMenuItem.Click += new System.EventHandler(this.noneToolStripMenuItem_Click);
			// 
			// x5ToolStripMenuItem
			// 
			this.x5ToolStripMenuItem.Name = "x5ToolStripMenuItem";
			this.x5ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.x5ToolStripMenuItem.Text = "5 x 5";
			this.x5ToolStripMenuItem.Click += new System.EventHandler(this.x5ToolStripMenuItem_Click);
			// 
			// x10ToolStripMenuItem
			// 
			this.x10ToolStripMenuItem.Name = "x10ToolStripMenuItem";
			this.x10ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.x10ToolStripMenuItem.Text = "10 x 10";
			this.x10ToolStripMenuItem.Click += new System.EventHandler(this.x10ToolStripMenuItem_Click);
			// 
			// x20ToolStripMenuItem
			// 
			this.x20ToolStripMenuItem.Name = "x20ToolStripMenuItem";
			this.x20ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.x20ToolStripMenuItem.Text = "25 x 25";
			this.x20ToolStripMenuItem.Click += new System.EventHandler(this.x20ToolStripMenuItem_Click);
			// 
			// x50ToolStripMenuItem
			// 
			this.x50ToolStripMenuItem.Name = "x50ToolStripMenuItem";
			this.x50ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.x50ToolStripMenuItem.Text = "50 x 50";
			this.x50ToolStripMenuItem.Click += new System.EventHandler(this.x50ToolStripMenuItem_Click);
			// 
			// x100ToolStripMenuItem
			// 
			this.x100ToolStripMenuItem.Name = "x100ToolStripMenuItem";
			this.x100ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.x100ToolStripMenuItem.Text = "100 x 100";
			this.x100ToolStripMenuItem.Click += new System.EventHandler(this.x100ToolStripMenuItem_Click);
			// 
			// customToolStripMenuItem
			// 
			this.customToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
			this.customToolStripMenuItem.Name = "customToolStripMenuItem";
			this.customToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.customToolStripMenuItem.Text = "Custom";
			// 
			// toolStripTextBox1
			// 
			this.toolStripTextBox1.Name = "toolStripTextBox1";
			this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
			this.toolStripTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBox1_KeyPress);
			// 
			// findPanelByVariableToolStripMenuItem
			// 
			this.findPanelByVariableToolStripMenuItem.Name = "findPanelByVariableToolStripMenuItem";
			this.findPanelByVariableToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.findPanelByVariableToolStripMenuItem.Text = "Find Panel";
			this.findPanelByVariableToolStripMenuItem.Click += new System.EventHandler(this.findPanelByVariableToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
			// 
			// updateToolStripMenuItem
			// 
			this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
			this.updateToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.updateToolStripMenuItem.Text = "Update";
			this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
			// 
			// SaveDialog
			// 
			this.SaveDialog.DefaultExt = "ddproj";
			this.SaveDialog.Filter = "Derma Designer Files|*.ddproj|All files|*.*";
			this.SaveDialog.Title = "Choose a Derma Designer Project File";
			this.SaveDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveDialog_FileOk);
			// 
			// OpenDialog
			// 
			this.OpenDialog.DefaultExt = "ddproj";
			this.OpenDialog.Filter = "Derma Designer Files|*.ddproj|All files|*.*";
			this.OpenDialog.ReadOnlyChecked = true;
			this.OpenDialog.Title = "Choose a Derma Designer Project File to Load";
			this.OpenDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenDialog_FileOk);
			// 
			// _DebugLabelMain
			// 
			this._DebugLabelMain.AutoSize = true;
			this._DebugLabelMain.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._DebugLabelMain.ForeColor = System.Drawing.Color.Green;
			this._DebugLabelMain.Location = new System.Drawing.Point(0, 24);
			this._DebugLabelMain.Name = "_DebugLabelMain";
			this._DebugLabelMain.Size = new System.Drawing.Size(112, 15);
			this._DebugLabelMain.TabIndex = 1;
			this._DebugLabelMain.Text = "_DebugLabelMain";
			this._DebugLabelMain.UseMnemonic = false;
			this._DebugLabelMain.Visible = false;
			this._DebugLabelMain.SizeChanged += new System.EventHandler(this._DebugLabelMain_TextChanged);
			// 
			// _DebugResetLabelMain
			// 
			this._DebugResetLabelMain.AutoSize = true;
			this._DebugResetLabelMain.Font = new System.Drawing.Font("DejaVu Serif Condensed", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._DebugResetLabelMain.ForeColor = System.Drawing.Color.DarkGreen;
			this._DebugResetLabelMain.Location = new System.Drawing.Point(118, 25);
			this._DebugResetLabelMain.Name = "_DebugResetLabelMain";
			this._DebugResetLabelMain.Size = new System.Drawing.Size(41, 14);
			this._DebugResetLabelMain.TabIndex = 2;
			this._DebugResetLabelMain.Text = "Reset";
			this._DebugResetLabelMain.Visible = false;
			this._DebugResetLabelMain.Click += new System.EventHandler(this._DebugResetLabelMain_Click);
			// 
			// unparentPanelToolStripMenuItem
			// 
			this.unparentPanelToolStripMenuItem.Name = "unparentPanelToolStripMenuItem";
			this.unparentPanelToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.unparentPanelToolStripMenuItem.Text = "Unparent Panel";
			this.unparentPanelToolStripMenuItem.Click += new System.EventHandler(this.unparentPanelToolStripMenuItem_Click);
			// 
			// Main
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(630, 448);
			this.Controls.Add(this._DebugResetLabelMain);
			this.Controls.Add(this._DebugLabelMain);
			this.Controls.Add(this.FormMenu);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.FormMenu;
			this.MaximizeBox = false;
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DermaDesigner";
			this.Load += new System.EventHandler(this.Main_Load);
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

        void _DebugLabelMain_TextChanged(object sender, System.EventArgs e)
        {
            this._DebugResetLabelMain.Location = new Point(this._DebugLabelMain.Size.Width + this._DebugLabelMain.Location.X, this._DebugLabelMain.Location.Y+1);
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
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.SaveFileDialog SaveDialog;
        public System.Windows.Forms.OpenFileDialog OpenDialog;
        public System.Windows.Forms.Label _DebugLabelMain;
        public System.Windows.Forms.Label _DebugResetLabelMain;
		private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x10ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x5ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x20ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x50ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x100ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
		private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
		private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem unparentPanelToolStripMenuItem;
    }
}

