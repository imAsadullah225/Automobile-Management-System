namespace AutomobileManagementSys
{
    partial class splashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(splashScreen));
            this.bordersRound = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Logo_PicBox = new System.Windows.Forms.PictureBox();
            this.Logo2_LBL = new System.Windows.Forms.Label();
            this.Logo_LBL = new System.Windows.Forms.Label();
            this.ProgressBar = new Bunifu.Framework.UI.BunifuProgressBar();
            this.ProgressTimer = new System.Windows.Forms.Timer(this.components);
            this.Loading_Label = new System.Windows.Forms.Label();
            this.CircleProgressbar = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_PicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // bordersRound
            // 
            this.bordersRound.ElipseRadius = 12;
            this.bordersRound.TargetControl = this;
            // 
            // Logo_PicBox
            // 
            this.Logo_PicBox.BackgroundImage = global::AutomobileManagementSys.Properties.Resources.Garage_150px;
            this.Logo_PicBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Logo_PicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Logo_PicBox.Location = new System.Drawing.Point(96, 48);
            this.Logo_PicBox.Name = "Logo_PicBox";
            this.Logo_PicBox.Size = new System.Drawing.Size(73, 71);
            this.Logo_PicBox.TabIndex = 3;
            this.Logo_PicBox.TabStop = false;
            // 
            // Logo2_LBL
            // 
            this.Logo2_LBL.AutoSize = true;
            this.Logo2_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logo2_LBL.ForeColor = System.Drawing.Color.White;
            this.Logo2_LBL.Location = new System.Drawing.Point(171, 77);
            this.Logo2_LBL.Name = "Logo2_LBL";
            this.Logo2_LBL.Size = new System.Drawing.Size(105, 40);
            this.Logo2_LBL.TabIndex = 5;
            this.Logo2_LBL.Text = "Management\r\nSystem\r\n";
            // 
            // Logo_LBL
            // 
            this.Logo_LBL.AutoSize = true;
            this.Logo_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logo_LBL.ForeColor = System.Drawing.Color.White;
            this.Logo_LBL.Location = new System.Drawing.Point(169, 48);
            this.Logo_LBL.Name = "Logo_LBL";
            this.Logo_LBL.Size = new System.Drawing.Size(158, 29);
            this.Logo_LBL.TabIndex = 4;
            this.Logo_LBL.Text = "Automobiles\r\n";
            // 
            // ProgressBar
            // 
            this.ProgressBar.BackColor = System.Drawing.Color.Gainsboro;
            this.ProgressBar.BorderRadius = 2;
            this.ProgressBar.Location = new System.Drawing.Point(2, 166);
            this.ProgressBar.MaximumValue = 100;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.ProgressColor = System.Drawing.Color.White;
            this.ProgressBar.Size = new System.Drawing.Size(419, 12);
            this.ProgressBar.TabIndex = 7;
            this.ProgressBar.Value = 0;
            // 
            // ProgressTimer
            // 
            this.ProgressTimer.Enabled = true;
            this.ProgressTimer.Tick += new System.EventHandler(this.ProgressTimer_Tick);
            // 
            // Loading_Label
            // 
            this.Loading_Label.AutoSize = true;
            this.Loading_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loading_Label.ForeColor = System.Drawing.Color.White;
            this.Loading_Label.Location = new System.Drawing.Point(177, 186);
            this.Loading_Label.Name = "Loading_Label";
            this.Loading_Label.Size = new System.Drawing.Size(68, 20);
            this.Loading_Label.TabIndex = 8;
            this.Loading_Label.Text = "Loading";
            // 
            // CircleProgressbar
            // 
            this.CircleProgressbar.animated = false;
            this.CircleProgressbar.animationIterval = 5;
            this.CircleProgressbar.animationSpeed = 300;
            this.CircleProgressbar.BackColor = System.Drawing.Color.Transparent;
            this.CircleProgressbar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CircleProgressbar.BackgroundImage")));
            this.CircleProgressbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.CircleProgressbar.ForeColor = System.Drawing.Color.White;
            this.CircleProgressbar.LabelVisible = false;
            this.CircleProgressbar.LineProgressThickness = 2;
            this.CircleProgressbar.LineThickness = 1;
            this.CircleProgressbar.Location = new System.Drawing.Point(236, 180);
            this.CircleProgressbar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CircleProgressbar.MaxValue = 100;
            this.CircleProgressbar.Name = "CircleProgressbar";
            this.CircleProgressbar.ProgressBackColor = System.Drawing.Color.Transparent;
            this.CircleProgressbar.ProgressColor = System.Drawing.Color.White;
            this.CircleProgressbar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CircleProgressbar.Size = new System.Drawing.Size(34, 34);
            this.CircleProgressbar.TabIndex = 9;
            this.CircleProgressbar.Value = 0;
            // 
            // splashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(179)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(423, 221);
            this.Controls.Add(this.Loading_Label);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.Logo_PicBox);
            this.Controls.Add(this.Logo2_LBL);
            this.Controls.Add(this.Logo_LBL);
            this.Controls.Add(this.CircleProgressbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "splashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "splashScreen";
            ((System.ComponentModel.ISupportInitialize)(this.Logo_PicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bordersRound;
        private System.Windows.Forms.PictureBox Logo_PicBox;
        private System.Windows.Forms.Label Logo2_LBL;
        private System.Windows.Forms.Label Logo_LBL;
        private Bunifu.Framework.UI.BunifuProgressBar ProgressBar;
        private System.Windows.Forms.Timer ProgressTimer;
        private System.Windows.Forms.Label Loading_Label;
        private Bunifu.Framework.UI.BunifuCircleProgressbar CircleProgressbar;
    }
}