namespace L298N_Control
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
            this.panelProgressbarContainer = new System.Windows.Forms.Panel();
            this.panelProgressBar = new System.Windows.Forms.Panel();
            this.timerProgressbar = new System.Windows.Forms.Timer(this.components);
            this.labelLoading = new System.Windows.Forms.Label();
            this.iconButtonExitProgress = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).BeginInit();
            this.panelProgressbarContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxBackground
            // 
            this.pictureBoxBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxBackground.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxBackground.Image")));
            this.pictureBoxBackground.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBackground.Name = "pictureBoxBackground";
            this.pictureBoxBackground.Size = new System.Drawing.Size(700, 400);
            this.pictureBoxBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBackground.TabIndex = 0;
            this.pictureBoxBackground.TabStop = false;
            // 
            // panelProgressbarContainer
            // 
            this.panelProgressbarContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(245)))));
            this.panelProgressbarContainer.Controls.Add(this.panelProgressBar);
            this.panelProgressbarContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelProgressbarContainer.Location = new System.Drawing.Point(0, 378);
            this.panelProgressbarContainer.Name = "panelProgressbarContainer";
            this.panelProgressbarContainer.Size = new System.Drawing.Size(700, 22);
            this.panelProgressbarContainer.TabIndex = 1;
            // 
            // panelProgressBar
            // 
            this.panelProgressBar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelProgressBar.Location = new System.Drawing.Point(0, 0);
            this.panelProgressBar.Name = "panelProgressBar";
            this.panelProgressBar.Size = new System.Drawing.Size(30, 22);
            this.panelProgressBar.TabIndex = 2;
            // 
            // timerProgressbar
            // 
            this.timerProgressbar.Enabled = true;
            this.timerProgressbar.Interval = 12;
            this.timerProgressbar.Tick += new System.EventHandler(this.timerProgressbar_Tick);
            // 
            // labelLoading
            // 
            this.labelLoading.AutoSize = true;
            this.labelLoading.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLoading.ForeColor = System.Drawing.Color.White;
            this.labelLoading.Location = new System.Drawing.Point(7, 357);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(67, 19);
            this.labelLoading.TabIndex = 2;
            this.labelLoading.Text = "Loading...";
            // 
            // iconButtonExitProgress
            // 
            this.iconButtonExitProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButtonExitProgress.BackColor = System.Drawing.Color.Transparent;
            this.iconButtonExitProgress.FlatAppearance.BorderSize = 0;
            this.iconButtonExitProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonExitProgress.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.iconButtonExitProgress.IconColor = System.Drawing.SystemColors.ActiveCaption;
            this.iconButtonExitProgress.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonExitProgress.IconSize = 20;
            this.iconButtonExitProgress.Location = new System.Drawing.Point(675, 0);
            this.iconButtonExitProgress.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.iconButtonExitProgress.Name = "iconButtonExitProgress";
            this.iconButtonExitProgress.Size = new System.Drawing.Size(25, 29);
            this.iconButtonExitProgress.TabIndex = 73;
            this.iconButtonExitProgress.UseVisualStyleBackColor = false;
            this.iconButtonExitProgress.Click += new System.EventHandler(this.iconButtonExitProgress_Click);
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.iconButtonExitProgress);
            this.Controls.Add(this.labelLoading);
            this.Controls.Add(this.panelProgressbarContainer);
            this.Controls.Add(this.pictureBoxBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).EndInit();
            this.panelProgressbarContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBackground;
        private System.Windows.Forms.Panel panelProgressbarContainer;
        private System.Windows.Forms.Panel panelProgressBar;
        private System.Windows.Forms.Timer timerProgressbar;
        private System.Windows.Forms.Label labelLoading;
        private FontAwesome.Sharp.IconButton iconButtonExitProgress;
    }
}