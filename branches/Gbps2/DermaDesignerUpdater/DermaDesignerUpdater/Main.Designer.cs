namespace DermaDesignerUpdater
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
			this._ProgressBar = new System.Windows.Forms.ProgressBar();
			this._StatusLabel = new System.Windows.Forms.Label();
			this._UpdateButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// _ProgressBar
			// 
			this._ProgressBar.Location = new System.Drawing.Point(12, 99);
			this._ProgressBar.Name = "_ProgressBar";
			this._ProgressBar.Size = new System.Drawing.Size(236, 23);
			this._ProgressBar.TabIndex = 0;
			// 
			// _StatusLabel
			// 
			this._StatusLabel.AutoSize = true;
			this._StatusLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._StatusLabel.Location = new System.Drawing.Point(12, 83);
			this._StatusLabel.Name = "_StatusLabel";
			this._StatusLabel.Size = new System.Drawing.Size(198, 13);
			this._StatusLabel.TabIndex = 1;
			this._StatusLabel.Text = "Press \"Update Now\" to begin the update.";
			this._StatusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _UpdateButton
			// 
			this._UpdateButton.Location = new System.Drawing.Point(12, 12);
			this._UpdateButton.Name = "_UpdateButton";
			this._UpdateButton.Size = new System.Drawing.Size(236, 54);
			this._UpdateButton.TabIndex = 2;
			this._UpdateButton.Text = "Update Now";
			this._UpdateButton.UseVisualStyleBackColor = true;
			this._UpdateButton.Click += new System.EventHandler(this._UpdateButton_Click);
			// 
			// Main
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(260, 134);
			this.Controls.Add(this._UpdateButton);
			this.Controls.Add(this._StatusLabel);
			this.Controls.Add(this._ProgressBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Derma Designer Updater";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar _ProgressBar;
        private System.Windows.Forms.Label _StatusLabel;
        private System.Windows.Forms.Button _UpdateButton;
    }
}

