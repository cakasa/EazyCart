namespace EazyCart.UserControls
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
            this.cashRegisterAndWareHouseTutorialLabel = new System.Windows.Forms.Label();
            this.informationLabel = new System.Windows.Forms.Label();
            this.tabsExplanationLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.logisticsAndStatisticsTutorialLabel = new System.Windows.Forms.Label();
            this.ornamentalPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EazyCart.Properties.Resources.eazyCartIcon;
            this.pictureBox1.Location = new System.Drawing.Point(-33, 106);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(477, 451);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // cashRegisterAndWareHouseTutorialLabel
            // 
            this.cashRegisterAndWareHouseTutorialLabel.AutoSize = true;
            this.cashRegisterAndWareHouseTutorialLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cashRegisterAndWareHouseTutorialLabel.Location = new System.Drawing.Point(753, 17);
            this.cashRegisterAndWareHouseTutorialLabel.Name = "cashRegisterAndWareHouseTutorialLabel";
            this.cashRegisterAndWareHouseTutorialLabel.Size = new System.Drawing.Size(345, 45);
            this.cashRegisterAndWareHouseTutorialLabel.TabIndex = 10;
            this.cashRegisterAndWareHouseTutorialLabel.Text = "Welcome to EazyCart! ";
            // 
            // informationLabel
            // 
            this.informationLabel.AutoSize = true;
            this.informationLabel.Font = new System.Drawing.Font("Segoe UI", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.informationLabel.Location = new System.Drawing.Point(499, 79);
            this.informationLabel.MaximumSize = new System.Drawing.Size(816, 160);
            this.informationLabel.MinimumSize = new System.Drawing.Size(816, 85);
            this.informationLabel.Name = "informationLabel";
            this.informationLabel.Size = new System.Drawing.Size(816, 160);
            this.informationLabel.TabIndex = 11;
            this.informationLabel.Text = resources.GetString("informationLabel.Text");
            // 
            // tabsExplanationLabel
            // 
            this.tabsExplanationLabel.AutoSize = true;
            this.tabsExplanationLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabsExplanationLabel.Location = new System.Drawing.Point(659, 280);
            this.tabsExplanationLabel.MaximumSize = new System.Drawing.Size(1000, 100);
            this.tabsExplanationLabel.Name = "tabsExplanationLabel";
            this.tabsExplanationLabel.Size = new System.Drawing.Size(517, 63);
            this.tabsExplanationLabel.TabIndex = 13;
            this.tabsExplanationLabel.Text = "There are four tabs, all of which are responsible for managing your store: \r\nCash" +
    " Register, Warehouse, Logistics and Statistics:\r\n\r\n";
            this.tabsExplanationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(500, 357);
            this.label1.MaximumSize = new System.Drawing.Size(382, 425);
            this.label1.MinimumSize = new System.Drawing.Size(340, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 315);
            this.label1.TabIndex = 14;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // logisticsAndStatisticsTutorialLabel
            // 
            this.logisticsAndStatisticsTutorialLabel.AutoSize = true;
            this.logisticsAndStatisticsTutorialLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logisticsAndStatisticsTutorialLabel.Location = new System.Drawing.Point(938, 357);
            this.logisticsAndStatisticsTutorialLabel.MaximumSize = new System.Drawing.Size(382, 425);
            this.logisticsAndStatisticsTutorialLabel.Name = "logisticsAndStatisticsTutorialLabel";
            this.logisticsAndStatisticsTutorialLabel.Size = new System.Drawing.Size(382, 315);
            this.logisticsAndStatisticsTutorialLabel.TabIndex = 15;
            this.logisticsAndStatisticsTutorialLabel.Text = resources.GetString("logisticsAndStatisticsTutorialLabel.Text");
            // 
            // ornamentalPanel
            // 
            this.ornamentalPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ornamentalPanel.Location = new System.Drawing.Point(504, 264);
            this.ornamentalPanel.Name = "ornamentalPanel";
            this.ornamentalPanel.Size = new System.Drawing.Size(816, 5);
            this.ornamentalPanel.TabIndex = 21;
            // 
            // GreetingScreenUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ornamentalPanel);
            this.Controls.Add(this.logisticsAndStatisticsTutorialLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabsExplanationLabel);
            this.Controls.Add(this.informationLabel);
            this.Controls.Add(this.cashRegisterAndWareHouseTutorialLabel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "GreetingScreenUserControl";
            this.Size = new System.Drawing.Size(1366, 717);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label cashRegisterAndWareHouseTutorialLabel;
        private System.Windows.Forms.Label informationLabel;
        private System.Windows.Forms.Label tabsExplanationLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label logisticsAndStatisticsTutorialLabel;
        private System.Windows.Forms.Panel ornamentalPanel;
    }
}
