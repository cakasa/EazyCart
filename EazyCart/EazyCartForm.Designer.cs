﻿namespace EazyCart
{
    partial class EazyCartForm
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
            this.menuPanel = new System.Windows.Forms.Panel();
            this.mainMenuPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.closeButton = new System.Windows.Forms.Button();
            this.statisticsButton = new System.Windows.Forms.Button();
            this.warehouseButton = new System.Windows.Forms.Button();
            this.shoppingCartPIctureBox = new System.Windows.Forms.PictureBox();
            this.cashRegisterButton = new System.Windows.Forms.Button();
            this.logisticsButton = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shoppingCartPIctureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.menuPanel.Controls.Add(this.mainMenuPanel);
            this.menuPanel.Controls.Add(this.statisticsButton);
            this.menuPanel.Controls.Add(this.warehouseButton);
            this.menuPanel.Controls.Add(this.titleLabel);
            this.menuPanel.Controls.Add(this.shoppingCartPIctureBox);
            this.menuPanel.Controls.Add(this.cashRegisterButton);
            this.menuPanel.Controls.Add(this.logisticsButton);
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(1600, 60);
            this.menuPanel.TabIndex = 0;
            this.menuPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuPanel_MouseDown);
            this.menuPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuPanel_MouseMove);
            this.menuPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MenuPanel_MouseUp);
            // 
            // mainMenuPanel
            // 
            this.mainMenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(153)))));
            this.mainMenuPanel.Location = new System.Drawing.Point(342, 57);
            this.mainMenuPanel.Name = "mainMenuPanel";
            this.mainMenuPanel.Size = new System.Drawing.Size(253, 3);
            this.mainMenuPanel.TabIndex = 6;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.titleLabel.Location = new System.Drawing.Point(59, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(97, 30);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "EazyCart";
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.closeButton.Image = global::EazyCart.Properties.Resources.closeCancelIcon;
            this.closeButton.Location = new System.Drawing.Point(1540, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(60, 60);
            this.closeButton.TabIndex = 5;
            this.closeButton.TabStop = false;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // statisticsButton
            // 
            this.statisticsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.statisticsButton.BackgroundImage = global::EazyCart.Properties.Resources.statisticsButtonImage;
            this.statisticsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.statisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statisticsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.statisticsButton.Location = new System.Drawing.Point(1108, 0);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(256, 60);
            this.statisticsButton.TabIndex = 4;
            this.statisticsButton.TabStop = false;
            this.statisticsButton.UseVisualStyleBackColor = false;
            this.statisticsButton.Click += new System.EventHandler(this.StatisticsButton_Click);
            // 
            // warehouseButton
            // 
            this.warehouseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.warehouseButton.BackgroundImage = global::EazyCart.Properties.Resources.warehouseButtonImage;
            this.warehouseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.warehouseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.warehouseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.warehouseButton.Location = new System.Drawing.Point(596, 0);
            this.warehouseButton.Name = "warehouseButton";
            this.warehouseButton.Size = new System.Drawing.Size(256, 60);
            this.warehouseButton.TabIndex = 3;
            this.warehouseButton.TabStop = false;
            this.warehouseButton.UseVisualStyleBackColor = false;
            this.warehouseButton.Click += new System.EventHandler(this.WarehouseButton_Click);
            // 
            // shoppingCartPIctureBox
            // 
            this.shoppingCartPIctureBox.Image = global::EazyCart.Properties.Resources.eazyCartIcon;
            this.shoppingCartPIctureBox.Location = new System.Drawing.Point(0, 0);
            this.shoppingCartPIctureBox.Name = "shoppingCartPIctureBox";
            this.shoppingCartPIctureBox.Size = new System.Drawing.Size(60, 60);
            this.shoppingCartPIctureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.shoppingCartPIctureBox.TabIndex = 0;
            this.shoppingCartPIctureBox.TabStop = false;
            // 
            // cashRegisterButton
            // 
            this.cashRegisterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.cashRegisterButton.BackgroundImage = global::EazyCart.Properties.Resources.cashRegisterButtonImage;
            this.cashRegisterButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cashRegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cashRegisterButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.cashRegisterButton.Location = new System.Drawing.Point(340, 0);
            this.cashRegisterButton.Name = "cashRegisterButton";
            this.cashRegisterButton.Size = new System.Drawing.Size(256, 60);
            this.cashRegisterButton.TabIndex = 1;
            this.cashRegisterButton.TabStop = false;
            this.cashRegisterButton.UseVisualStyleBackColor = false;
            this.cashRegisterButton.Click += new System.EventHandler(this.CashRegisterButton_Click);
            // 
            // logisticsButton
            // 
            this.logisticsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.logisticsButton.BackgroundImage = global::EazyCart.Properties.Resources.logisticsButtonPicture;
            this.logisticsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logisticsButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logisticsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.logisticsButton.Location = new System.Drawing.Point(852, 0);
            this.logisticsButton.Name = "logisticsButton";
            this.logisticsButton.Size = new System.Drawing.Size(256, 60);
            this.logisticsButton.TabIndex = 7;
            this.logisticsButton.TabStop = false;
            this.logisticsButton.UseVisualStyleBackColor = false;
            this.logisticsButton.Click += new System.EventHandler(this.ManagementButton_Click);
            // 
            // EazyCartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.menuPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EazyCartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EazyCart";
            this.Load += new System.EventHandler(this.EazyCartForm_Load);
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shoppingCartPIctureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.PictureBox shoppingCartPIctureBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button cashRegisterButton;
        private System.Windows.Forms.Button warehouseButton;
        private System.Windows.Forms.Button statisticsButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel mainMenuPanel;
        private System.Windows.Forms.Button logisticsButton;
    }
}

