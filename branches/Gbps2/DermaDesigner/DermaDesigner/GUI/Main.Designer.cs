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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
			this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
			this._DebugLabelMain = new System.Windows.Forms.Label();
			this._DebugResetLabelMain = new System.Windows.Forms.Label();
			this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem43 = new System.Windows.Forms.MenuItem();
			this.menuItem44 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.menuItem21 = new System.Windows.Forms.MenuItem();
			this.menuItem22 = new System.Windows.Forms.MenuItem();
			this.menuItem23 = new System.Windows.Forms.MenuItem();
			this.menuItem24 = new System.Windows.Forms.MenuItem();
			this.menuItem25 = new System.Windows.Forms.MenuItem();
			this.menuItem26 = new System.Windows.Forms.MenuItem();
			this.menuItem28 = new System.Windows.Forms.MenuItem();
			this.menuItem29 = new System.Windows.Forms.MenuItem();
			this.menuItem27 = new System.Windows.Forms.MenuItem();
			this.menuItem30 = new System.Windows.Forms.MenuItem();
			this.menuItem31 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem32 = new System.Windows.Forms.MenuItem();
			this.menuItem33 = new System.Windows.Forms.MenuItem();
			this.menuItem34 = new System.Windows.Forms.MenuItem();
			this.menuItem35 = new System.Windows.Forms.MenuItem();
			this.menuItem36 = new System.Windows.Forms.MenuItem();
			this.menuItem37 = new System.Windows.Forms.MenuItem();
			this.menuItem38 = new System.Windows.Forms.MenuItem();
			this.menuItem39 = new System.Windows.Forms.MenuItem();
			this.menuItem40 = new System.Windows.Forms.MenuItem();
			this.menuItem41 = new System.Windows.Forms.MenuItem();
			this.menuItem42 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
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
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4,
            this.menuItem5,
            this.menuItem6,
            this.menuItem7,
            this.menuItem8,
            this.menuItem9,
            this.menuItem10,
            this.menuItem11,
            this.menuItem12});
			this.menuItem1.Text = "File";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 0;
			this.menuItem4.Text = "New";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 1;
			this.menuItem5.Text = "Open";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 2;
			this.menuItem6.Text = "-";
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 3;
			this.menuItem7.Text = "Save";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 4;
			this.menuItem8.Text = "Save As";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 5;
			this.menuItem9.Text = "-";
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 6;
			this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem43,
            this.menuItem44});
			this.menuItem10.Text = "Lua";
			// 
			// menuItem43
			// 
			this.menuItem43.Index = 0;
			this.menuItem43.Text = "Generate to File";
			this.menuItem43.Click += new System.EventHandler(this.menuItem43_Click);
			// 
			// menuItem44
			// 
			this.menuItem44.Index = 1;
			this.menuItem44.Text = "Generate to Text Box";
			this.menuItem44.Click += new System.EventHandler(this.menuItem44_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 7;
			this.menuItem11.Text = "-";
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 8;
			this.menuItem12.Text = "Exit";
			this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem13,
            this.menuItem26,
            this.menuItem27});
			this.menuItem2.Text = "View";
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 0;
			this.menuItem13.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem14,
            this.menuItem20});
			this.menuItem13.Text = "Size";
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 0;
			this.menuItem14.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem15,
            this.menuItem16,
            this.menuItem17,
            this.menuItem18,
            this.menuItem19});
			this.menuItem14.Text = "Normal";
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 0;
			this.menuItem15.Text = "640 x 480";
			this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 1;
			this.menuItem16.Text = "800 x 600";
			this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 2;
			this.menuItem17.Text = "1024 x 768";
			this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 3;
			this.menuItem18.Text = "1280 x 960";
			this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 4;
			this.menuItem19.Text = "1280 x 1024";
			this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 1;
			this.menuItem20.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem21,
            this.menuItem22,
            this.menuItem23,
            this.menuItem24,
            this.menuItem25});
			this.menuItem20.Text = "Widescreen";
			// 
			// menuItem21
			// 
			this.menuItem21.Index = 0;
			this.menuItem21.Text = "1280 x 720";
			this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
			// 
			// menuItem22
			// 
			this.menuItem22.Index = 1;
			this.menuItem22.Text = "1280 x 768";
			this.menuItem22.Click += new System.EventHandler(this.menuItem22_Click);
			// 
			// menuItem23
			// 
			this.menuItem23.Index = 2;
			this.menuItem23.Text = "1440 x 900";
			this.menuItem23.Click += new System.EventHandler(this.menuItem23_Click);
			// 
			// menuItem24
			// 
			this.menuItem24.Index = 3;
			this.menuItem24.Text = "1680 x 1050";
			this.menuItem24.Click += new System.EventHandler(this.menuItem24_Click);
			// 
			// menuItem25
			// 
			this.menuItem25.Index = 4;
			this.menuItem25.Text = "1920 x 1080";
			this.menuItem25.Click += new System.EventHandler(this.menuItem25_Click);
			// 
			// menuItem26
			// 
			this.menuItem26.Index = 1;
			this.menuItem26.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem28,
            this.menuItem29});
			this.menuItem26.Text = "Toolbox";
			// 
			// menuItem28
			// 
			this.menuItem28.Index = 0;
			this.menuItem28.Text = "Show";
			this.menuItem28.Click += new System.EventHandler(this.menuItem28_Click);
			// 
			// menuItem29
			// 
			this.menuItem29.Index = 1;
			this.menuItem29.Text = "Snap to left corner";
			this.menuItem29.Click += new System.EventHandler(this.menuItem29_Click);
			// 
			// menuItem27
			// 
			this.menuItem27.Index = 2;
			this.menuItem27.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem30,
            this.menuItem31});
			this.menuItem27.Text = "Properties";
			// 
			// menuItem30
			// 
			this.menuItem30.Index = 0;
			this.menuItem30.Text = "Show";
			this.menuItem30.Click += new System.EventHandler(this.menuItem30_Click);
			// 
			// menuItem31
			// 
			this.menuItem31.Index = 1;
			this.menuItem31.Text = "Snap to right corner";
			this.menuItem31.Click += new System.EventHandler(this.menuItem31_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem32,
            this.menuItem39,
            this.menuItem40,
            this.menuItem41,
            this.menuItem42});
			this.menuItem3.Text = "Tools";
			// 
			// menuItem32
			// 
			this.menuItem32.Index = 0;
			this.menuItem32.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem33,
            this.menuItem34,
            this.menuItem35,
            this.menuItem36,
            this.menuItem37,
            this.menuItem38});
			this.menuItem32.Text = "Grid";
			// 
			// menuItem33
			// 
			this.menuItem33.Index = 0;
			this.menuItem33.Text = "None";
			this.menuItem33.Click += new System.EventHandler(this.menuItem33_Click);
			// 
			// menuItem34
			// 
			this.menuItem34.Index = 1;
			this.menuItem34.Text = "5 x 5";
			this.menuItem34.Click += new System.EventHandler(this.menuItem34_Click);
			// 
			// menuItem35
			// 
			this.menuItem35.Index = 2;
			this.menuItem35.Text = "10 x 10";
			this.menuItem35.Click += new System.EventHandler(this.menuItem35_Click);
			// 
			// menuItem36
			// 
			this.menuItem36.Index = 3;
			this.menuItem36.Text = "25 x 25";
			this.menuItem36.Click += new System.EventHandler(this.menuItem36_Click);
			// 
			// menuItem37
			// 
			this.menuItem37.Index = 4;
			this.menuItem37.Text = "50 x 50";
			this.menuItem37.Click += new System.EventHandler(this.menuItem37_Click);
			// 
			// menuItem38
			// 
			this.menuItem38.Index = 5;
			this.menuItem38.Text = "100 x 100";
			this.menuItem38.Click += new System.EventHandler(this.menuItem38_Click);
			// 
			// menuItem39
			// 
			this.menuItem39.Index = 1;
			this.menuItem39.Text = "Find Panel";
			this.menuItem39.Click += new System.EventHandler(this.menuItem39_Click);
			// 
			// menuItem40
			// 
			this.menuItem40.Index = 2;
			this.menuItem40.Text = "Unparent Panel";
			this.menuItem40.Click += new System.EventHandler(this.menuItem40_Click);
			// 
			// menuItem41
			// 
			this.menuItem41.Index = 3;
			this.menuItem41.Text = "-";
			// 
			// menuItem42
			// 
			this.menuItem42.Index = 4;
			this.menuItem42.Text = "Update";
			this.menuItem42.Click += new System.EventHandler(this.menuItem42_Click);
			// 
			// Main
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(630, 448);
			this.Controls.Add(this._DebugResetLabelMain);
			this.Controls.Add(this._DebugLabelMain);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DermaDesigner";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
			this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.Move += new System.EventHandler(this.Form1_Move);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        void _DebugLabelMain_TextChanged(object sender, System.EventArgs e)
        {
            this._DebugResetLabelMain.Location = new Point(this._DebugLabelMain.Size.Width + this._DebugLabelMain.Location.X, this._DebugLabelMain.Location.Y+1);
        }

        #endregion

		public System.Windows.Forms.SaveFileDialog SaveDialog;
        public System.Windows.Forms.OpenFileDialog OpenDialog;
        public System.Windows.Forms.Label _DebugLabelMain;
		public System.Windows.Forms.Label _DebugResetLabelMain;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.MenuItem menuItem24;
		private System.Windows.Forms.MenuItem menuItem25;
		private System.Windows.Forms.MenuItem menuItem26;
		private System.Windows.Forms.MenuItem menuItem28;
		private System.Windows.Forms.MenuItem menuItem29;
		private System.Windows.Forms.MenuItem menuItem27;
		private System.Windows.Forms.MenuItem menuItem30;
		private System.Windows.Forms.MenuItem menuItem31;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem32;
		private System.Windows.Forms.MenuItem menuItem33;
		private System.Windows.Forms.MenuItem menuItem34;
		private System.Windows.Forms.MenuItem menuItem35;
		private System.Windows.Forms.MenuItem menuItem36;
		private System.Windows.Forms.MenuItem menuItem37;
		private System.Windows.Forms.MenuItem menuItem38;
		private System.Windows.Forms.MenuItem menuItem39;
		private System.Windows.Forms.MenuItem menuItem40;
		private System.Windows.Forms.MenuItem menuItem41;
		private System.Windows.Forms.MenuItem menuItem42;
		private System.Windows.Forms.MenuItem menuItem43;
		private System.Windows.Forms.MenuItem menuItem44;
    }
}

