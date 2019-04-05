namespace EazyCart.InteractionForms
{
    partial class PayForm
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
        //payform
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayForm));
            this.menuPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.makePaymentLabel = new System.Windows.Forms.Label();
            this.logoLabel = new System.Windows.Forms.Label();
            this.eazyCartLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.grandTotalCashLabel = new System.Windows.Forms.Label();
            this.grandTotalLabel = new System.Windows.Forms.Label();
            this.ornamentalPanel = new System.Windows.Forms.Panel();
            this.payingAmountTextBox = new System.Windows.Forms.TextBox();
            this.warningLabel = new System.Windows.Forms.Label();
            this.makePaymentButton = new System.Windows.Forms.Button();
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eazyCartLogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.menuPanel.Controls.Add(this.closeButton);
            this.menuPanel.Controls.Add(this.makePaymentLabel);
            this.menuPanel.Controls.Add(this.logoLabel);
            this.menuPanel.Controls.Add(this.eazyCartLogoPictureBox);
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(495, 50);
            this.menuPanel.TabIndex = 3;
            this.menuPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuPanel_MouseDown);
            this.menuPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuPanel_MouseMove);
            this.menuPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MenuPanel_MouseUp);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.closeButton.BackgroundImage = global::EazyCart.Properties.Resources.closeCancelIcon;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.closeButton.Location = new System.Drawing.Point(445, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(50, 50);
            this.closeButton.TabIndex = 7;
            this.closeButton.TabStop = false;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // makePaymentLabel
            // 
            this.makePaymentLabel.AutoSize = true;
            this.makePaymentLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.makePaymentLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.makePaymentLabel.Location = new System.Drawing.Point(227, 9);
            this.makePaymentLabel.Name = "makePaymentLabel";
            this.makePaymentLabel.Size = new System.Drawing.Size(150, 30);
            this.makePaymentLabel.TabIndex = 6;
            this.makePaymentLabel.Text = "Make Payment";
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
            // grandTotalCashLabel
            // 
            this.grandTotalCashLabel.AutoSize = true;
            this.grandTotalCashLabel.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grandTotalCashLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.grandTotalCashLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.grandTotalCashLabel.Location = new System.Drawing.Point(236, 58);
            this.grandTotalCashLabel.MinimumSize = new System.Drawing.Size(250, 40);
            this.grandTotalCashLabel.Name = "grandTotalCashLabel";
            this.grandTotalCashLabel.Size = new System.Drawing.Size(250, 47);
            this.grandTotalCashLabel.TabIndex = 15;
            this.grandTotalCashLabel.Text = " $ 0.00";
            this.grandTotalCashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grandTotalLabel
            // 
            this.grandTotalLabel.AutoSize = true;
            this.grandTotalLabel.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grandTotalLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.grandTotalLabel.Location = new System.Drawing.Point(12, 62);
            this.grandTotalLabel.Name = "grandTotalLabel";
            this.grandTotalLabel.Size = new System.Drawing.Size(170, 40);
            this.grandTotalLabel.TabIndex = 13;
            this.grandTotalLabel.Text = "Grand Total:";
            // 
            // ornamentalPanel
            // 
            this.ornamentalPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ornamentalPanel.Location = new System.Drawing.Point(19, 111);
            this.ornamentalPanel.Name = "ornamentalPanel";
            this.ornamentalPanel.Size = new System.Drawing.Size(455, 5);
            this.ornamentalPanel.TabIndex = 16;
            // 
            // payingAmountTextBox
            // 
            this.payingAmountTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.payingAmountTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.payingAmountTextBox.Location = new System.Drawing.Point(19, 136);
            this.payingAmountTextBox.Name = "payingAmountTextBox";
            this.payingAmountTextBox.Size = new System.Drawing.Size(455, 33);
            this.payingAmountTextBox.TabIndex = 17;
            this.payingAmountTextBox.Text = "Enter cash amount";
            this.payingAmountTextBox.Enter += new System.EventHandler(this.PayingAmountTextBox_Enter);
            this.payingAmountTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PayingAmountTextBox_KeyDown);
            this.payingAmountTextBox.Leave += new System.EventHandler(this.PayingAmountTextBox_Leave);
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.warningLabel.Location = new System.Drawing.Point(15, 250);
            this.warningLabel.MinimumSize = new System.Drawing.Size(455, 21);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(455, 21);
            this.warningLabel.TabIndex = 19;
            this.warningLabel.Text = "Be wary that payment cannot be edited afterwards";
            this.warningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // makePaymentButton
            // 
            this.makePaymentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.makePaymentButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.makePaymentButton.FlatAppearance.BorderSize = 0;
            this.makePaymentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.makePaymentButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.makePaymentButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.makePaymentButton.Image = global::EazyCart.Properties.Resources.confirmPaymentButtonImage;
            this.makePaymentButton.Location = new System.Drawing.Point(102, 181);
            this.makePaymentButton.Name = "makePaymentButton";
            this.makePaymentButton.Size = new System.Drawing.Size(275, 66);
            this.makePaymentButton.TabIndex = 18;
            this.makePaymentButton.UseVisualStyleBackColor = false;
            this.makePaymentButton.Click += new System.EventHandler(this.MakePaymentButton_Click);
            // 
            // PayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(495, 281);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.makePaymentButton);
            this.Controls.Add(this.payingAmountTextBox);
            this.Controls.Add(this.ornamentalPanel);
            this.Controls.Add(this.grandTotalCashLabel);
            this.Controls.Add(this.grandTotalLabel);
            this.Controls.Add(this.menuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PayForm";
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eazyCartLogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.PictureBox eazyCartLogoPictureBox;
        private System.Windows.Forms.Label makePaymentLabel;
        private System.Windows.Forms.Label grandTotalCashLabel;
        private System.Windows.Forms.Label grandTotalLabel;
        private System.Windows.Forms.Panel ornamentalPanel;
        private System.Windows.Forms.TextBox payingAmountTextBox;
        private System.Windows.Forms.Button makePaymentButton;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Button closeButton;
    }
}