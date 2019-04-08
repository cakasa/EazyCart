namespace EazyCart.InteractionForms
{
    partial class MessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageForm));
            this.logoLabel = new System.Windows.Forms.Label();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.eazyCartLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.signPictureBox = new System.Windows.Forms.PictureBox();
            this.ornamentalPanel = new System.Windows.Forms.Panel();
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eazyCartLogoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // logoLabel
            // 
            this.logoLabel.AutoSize = true;
            this.logoLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logoLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.logoLabel.Location = new System.Drawing.Point(53, 9);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(97, 30);
            this.logoLabel.TabIndex = 5;
            this.logoLabel.Text = "EazyCart";
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.menuPanel.Controls.Add(this.titleLabel);
            this.menuPanel.Controls.Add(this.logoLabel);
            this.menuPanel.Controls.Add(this.eazyCartLogoPictureBox);
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(430, 50);
            this.menuPanel.TabIndex = 4;
            this.menuPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuPanel_MouseDown);
            this.menuPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuPanel_MouseMove);
            this.menuPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MenuPanel_MouseUp);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.titleLabel.Location = new System.Drawing.Point(242, 13);
            this.titleLabel.MaximumSize = new System.Drawing.Size(106, 25);
            this.titleLabel.MinimumSize = new System.Drawing.Size(106, 25);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(106, 25);
            this.titleLabel.TabIndex = 6;
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // eazyCartLogoPictureBox
            // 
            this.eazyCartLogoPictureBox.Image = global::EazyCart.Properties.Resources.eazyCartIcon;
            this.eazyCartLogoPictureBox.Location = new System.Drawing.Point(0, 0);
            this.eazyCartLogoPictureBox.Name = "eazyCartLogoPictureBox";
            this.eazyCartLogoPictureBox.Size = new System.Drawing.Size(50, 50);
            this.eazyCartLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.eazyCartLogoPictureBox.TabIndex = 4;
            this.eazyCartLogoPictureBox.TabStop = false;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messageLabel.Location = new System.Drawing.Point(78, 53);
            this.messageLabel.MaximumSize = new System.Drawing.Size(264, 94);
            this.messageLabel.MinimumSize = new System.Drawing.Size(264, 94);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(264, 94);
            this.messageLabel.TabIndex = 6;
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.messageLabel.UseCompatibleTextRendering = true;
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.okButton.BackgroundImage = global::EazyCart.Properties.Resources.okButtonPicture;
            this.okButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.okButton.FlatAppearance.BorderSize = 0;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.okButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.okButton.Location = new System.Drawing.Point(230, 164);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(111, 38);
            this.okButton.TabIndex = 19;
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // signPictureBox
            // 
            this.signPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.signPictureBox.Location = new System.Drawing.Point(12, 68);
            this.signPictureBox.Name = "signPictureBox";
            this.signPictureBox.Size = new System.Drawing.Size(60, 120);
            this.signPictureBox.TabIndex = 5;
            this.signPictureBox.TabStop = false;
            // 
            // ornamentalPanel
            // 
            this.ornamentalPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ornamentalPanel.Location = new System.Drawing.Point(78, 153);
            this.ornamentalPanel.Name = "ornamentalPanel";
            this.ornamentalPanel.Size = new System.Drawing.Size(264, 5);
            this.ornamentalPanel.TabIndex = 20;
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(353, 208);
            this.Controls.Add(this.ornamentalPanel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.signPictureBox);
            this.Controls.Add(this.menuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageForm";
            this.TopMost = true;
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eazyCartLogoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.PictureBox eazyCartLogoPictureBox;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.PictureBox signPictureBox;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Panel ornamentalPanel;
    }
}