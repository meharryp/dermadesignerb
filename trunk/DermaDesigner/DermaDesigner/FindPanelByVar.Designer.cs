namespace DermaDesigner {
	partial class FindPanelByVar {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindPanelByVar));
			this.SelectBtn = new System.Windows.Forms.Button();
			this.PanelList = new System.Windows.Forms.ListBox();
			this.TEntry = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// SelectBtn
			// 
			this.SelectBtn.Location = new System.Drawing.Point(139, 11);
			this.SelectBtn.Name = "SelectBtn";
			this.SelectBtn.Size = new System.Drawing.Size(75, 23);
			this.SelectBtn.TabIndex = 2;
			this.SelectBtn.Text = "Select";
			this.SelectBtn.UseVisualStyleBackColor = true;
			this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
			// 
			// PanelList
			// 
			this.PanelList.FormattingEnabled = true;
			this.PanelList.Location = new System.Drawing.Point(12, 40);
			this.PanelList.Name = "PanelList";
			this.PanelList.Size = new System.Drawing.Size(202, 95);
			this.PanelList.Sorted = true;
			this.PanelList.TabIndex = 3;
			this.PanelList.Click += new System.EventHandler(this.PanelList_Click);
			this.PanelList.DoubleClick += new System.EventHandler(this.PanelList_DoubleClick);
			// 
			// TEntry
			// 
			this.TEntry.Location = new System.Drawing.Point(12, 13);
			this.TEntry.Name = "TEntry";
			this.TEntry.Size = new System.Drawing.Size(121, 20);
			this.TEntry.TabIndex = 4;
			this.TEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEntry_KeyPress);
			this.TEntry.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
			// 
			// FindPanelByVar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(227, 146);
			this.Controls.Add(this.TEntry);
			this.Controls.Add(this.PanelList);
			this.Controls.Add(this.SelectBtn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FindPanelByVar";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Find Panel";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindPanelByVar_FormClosing);
			this.Load += new System.EventHandler(this.FindPanelByVar_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button SelectBtn;
		private System.Windows.Forms.ListBox PanelList;
		private System.Windows.Forms.TextBox TEntry;

	}
}