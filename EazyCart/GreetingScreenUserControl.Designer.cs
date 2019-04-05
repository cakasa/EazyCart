namespace EazyCart
{
    partial class GreetingScreenUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GreetingScreenUserControl));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.informationLabel = new System.Windows.Forms.Label();
            this.tutorialLabel = new System.Windows.Forms.Label();
            this.tabsExplanationLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EazyCart.Properties.Resources.eazyCartIcon;
            this.pictureBox1.Location = new System.Drawing.Point(3, 151);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(698, 531);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.welcomeLabel.Location = new System.Drawing.Point(237, 61);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(339, 45);
            this.welcomeLabel.TabIndex = 10;
            this.welcomeLabel.Text = "Welcome to EazyCart! ";
            // 
            // informationLabel
            // 
            this.informationLabel.AutoSize = true;
            this.informationLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.informationLabel.Location = new System.Drawing.Point(859, 5);
            this.informationLabel.Name = "informationLabel";
            this.informationLabel.Size = new System.Drawing.Size(672, 128);
            this.informationLabel.TabIndex = 11;
            this.informationLabel.Text = "This is a Point Of Sale (POS) program, which is best-suited\r\nfor retail managers " +
    "and clerks. It is simple to use, yet provides\r\nbasic functionalities for shopkee" +
    "pers. \r\n ";
            // 
            // tutorialLabel
            // 
            this.tutorialLabel.AutoSize = true;
            this.tutorialLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tutorialLabel.Location = new System.Drawing.Point(860, 119);
            this.tutorialLabel.Name = "tutorialLabel";
            this.tutorialLabel.Size = new System.Drawing.Size(442, 90);
            this.tutorialLabel.TabIndex = 12;
            this.tutorialLabel.Text = "If you do not know from where to start, please\r\ntake your time to read the simple" +
    " tutorial, \r\nwhich explains how the tabs function.\r\n";
            // 
            // tabsExplanationLabel
            // 
            this.tabsExplanationLabel.AutoSize = true;
            this.tabsExplanationLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabsExplanationLabel.Location = new System.Drawing.Point(860, 223);
            this.tabsExplanationLabel.Name = "tabsExplanationLabel";
            this.tabsExplanationLabel.Size = new System.Drawing.Size(533, 600);
            this.tabsExplanationLabel.TabIndex = 13;
            this.tabsExplanationLabel.Text = resources.GetString("tabsExplanationLabel.Text");
            // 
            // GreetingScreenUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabsExplanationLabel);
            this.Controls.Add(this.tutorialLabel);
            this.Controls.Add(this.informationLabel);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "GreetingScreenUserControl";
            this.Size = new System.Drawing.Size(1600, 840);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label informationLabel;
        private System.Windows.Forms.Label tutorialLabel;
        private System.Windows.Forms.Label tabsExplanationLabel;
    }
}
