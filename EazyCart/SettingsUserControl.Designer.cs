namespace EazyCart
{
    partial class SettingsUserControl
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
            this.unitTypesGroupBox = new System.Windows.Forms.GroupBox();
            this.britishUnitsRadioButton = new System.Windows.Forms.RadioButton();
            this.europeanUnitsUserControl = new System.Windows.Forms.RadioButton();
            this.totalLinePanel = new System.Windows.Forms.Panel();
            this.currencyGroupBox = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dollarRadioButton = new System.Windows.Forms.RadioButton();
            this.poundRadioButton = new System.Windows.Forms.RadioButton();
            this.euroRadioButton = new System.Windows.Forms.RadioButton();
            this.levRadioButton = new System.Windows.Forms.RadioButton();
            this.rubleRadioButton = new System.Windows.Forms.RadioButton();
            this.otherCurrencyRadioButton = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.themeGroupBox = new System.Windows.Forms.GroupBox();
            this.blueThemeRadioButton = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lightThemeRadioButton = new System.Windows.Forms.RadioButton();
            this.darkThemeRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.revertChangesButton = new System.Windows.Forms.Button();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.addProductButton = new System.Windows.Forms.Button();
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            this.unitTypesGroupBox.SuspendLayout();
            this.currencyGroupBox.SuspendLayout();
            this.themeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // unitTypesGroupBox
            // 
            this.unitTypesGroupBox.Controls.Add(this.totalLinePanel);
            this.unitTypesGroupBox.Controls.Add(this.europeanUnitsUserControl);
            this.unitTypesGroupBox.Controls.Add(this.britishUnitsRadioButton);
            this.unitTypesGroupBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.unitTypesGroupBox.Location = new System.Drawing.Point(66, 66);
            this.unitTypesGroupBox.Name = "unitTypesGroupBox";
            this.unitTypesGroupBox.Size = new System.Drawing.Size(281, 122);
            this.unitTypesGroupBox.TabIndex = 3;
            this.unitTypesGroupBox.TabStop = false;
            this.unitTypesGroupBox.Text = "Unit Types";
            // 
            // britishUnitsRadioButton
            // 
            this.britishUnitsRadioButton.AutoSize = true;
            this.britishUnitsRadioButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.britishUnitsRadioButton.Location = new System.Drawing.Point(12, 72);
            this.britishUnitsRadioButton.Name = "britishUnitsRadioButton";
            this.britishUnitsRadioButton.Size = new System.Drawing.Size(220, 25);
            this.britishUnitsRadioButton.TabIndex = 0;
            this.britishUnitsRadioButton.TabStop = true;
            this.britishUnitsRadioButton.Text = "British/American (LBS, GAL)";
            this.britishUnitsRadioButton.UseVisualStyleBackColor = true;
            // 
            // europeanUnitsUserControl
            // 
            this.europeanUnitsUserControl.AutoSize = true;
            this.europeanUnitsUserControl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.europeanUnitsUserControl.Location = new System.Drawing.Point(12, 41);
            this.europeanUnitsUserControl.Name = "europeanUnitsUserControl";
            this.europeanUnitsUserControl.Size = new System.Drawing.Size(142, 25);
            this.europeanUnitsUserControl.TabIndex = 1;
            this.europeanUnitsUserControl.TabStop = true;
            this.europeanUnitsUserControl.Text = "European (KG, L)";
            this.europeanUnitsUserControl.UseVisualStyleBackColor = true;
            // 
            // totalLinePanel
            // 
            this.totalLinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.totalLinePanel.Location = new System.Drawing.Point(8, 30);
            this.totalLinePanel.Name = "totalLinePanel";
            this.totalLinePanel.Size = new System.Drawing.Size(250, 5);
            this.totalLinePanel.TabIndex = 10;
            // 
            // currencyGroupBox
            // 
            this.currencyGroupBox.Controls.Add(this.textBox1);
            this.currencyGroupBox.Controls.Add(this.otherCurrencyRadioButton);
            this.currencyGroupBox.Controls.Add(this.rubleRadioButton);
            this.currencyGroupBox.Controls.Add(this.levRadioButton);
            this.currencyGroupBox.Controls.Add(this.euroRadioButton);
            this.currencyGroupBox.Controls.Add(this.panel1);
            this.currencyGroupBox.Controls.Add(this.dollarRadioButton);
            this.currencyGroupBox.Controls.Add(this.poundRadioButton);
            this.currencyGroupBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currencyGroupBox.Location = new System.Drawing.Point(66, 209);
            this.currencyGroupBox.Name = "currencyGroupBox";
            this.currencyGroupBox.Size = new System.Drawing.Size(281, 244);
            this.currencyGroupBox.TabIndex = 11;
            this.currencyGroupBox.TabStop = false;
            this.currencyGroupBox.Text = "Currency";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel1.Location = new System.Drawing.Point(8, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 5);
            this.panel1.TabIndex = 10;
            // 
            // dollarRadioButton
            // 
            this.dollarRadioButton.AutoSize = true;
            this.dollarRadioButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dollarRadioButton.Location = new System.Drawing.Point(12, 41);
            this.dollarRadioButton.Name = "dollarRadioButton";
            this.dollarRadioButton.Size = new System.Drawing.Size(163, 25);
            this.dollarRadioButton.TabIndex = 1;
            this.dollarRadioButton.TabStop = true;
            this.dollarRadioButton.Text = "American Dollar ($)";
            this.dollarRadioButton.UseVisualStyleBackColor = true;
            // 
            // poundRadioButton
            // 
            this.poundRadioButton.AutoSize = true;
            this.poundRadioButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.poundRadioButton.Location = new System.Drawing.Point(12, 72);
            this.poundRadioButton.Name = "poundRadioButton";
            this.poundRadioButton.Size = new System.Drawing.Size(143, 25);
            this.poundRadioButton.TabIndex = 0;
            this.poundRadioButton.TabStop = true;
            this.poundRadioButton.Text = "British Pound (£)";
            this.poundRadioButton.UseVisualStyleBackColor = true;
            // 
            // euroRadioButton
            // 
            this.euroRadioButton.AutoSize = true;
            this.euroRadioButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.euroRadioButton.Location = new System.Drawing.Point(12, 103);
            this.euroRadioButton.Name = "euroRadioButton";
            this.euroRadioButton.Size = new System.Drawing.Size(83, 25);
            this.euroRadioButton.TabIndex = 11;
            this.euroRadioButton.TabStop = true;
            this.euroRadioButton.Text = "Euro (€)";
            this.euroRadioButton.UseVisualStyleBackColor = true;
            // 
            // levRadioButton
            // 
            this.levRadioButton.AutoSize = true;
            this.levRadioButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.levRadioButton.Location = new System.Drawing.Point(12, 134);
            this.levRadioButton.Name = "levRadioButton";
            this.levRadioButton.Size = new System.Drawing.Size(155, 25);
            this.levRadioButton.TabIndex = 12;
            this.levRadioButton.TabStop = true;
            this.levRadioButton.Text = "Bulgarian Lev (лв.)";
            this.levRadioButton.UseVisualStyleBackColor = true;
            // 
            // rubleRadioButton
            // 
            this.rubleRadioButton.AutoSize = true;
            this.rubleRadioButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rubleRadioButton.Location = new System.Drawing.Point(12, 165);
            this.rubleRadioButton.Name = "rubleRadioButton";
            this.rubleRadioButton.Size = new System.Drawing.Size(149, 25);
            this.rubleRadioButton.TabIndex = 13;
            this.rubleRadioButton.TabStop = true;
            this.rubleRadioButton.Text = "Russian Ruble (₽)";
            this.rubleRadioButton.UseVisualStyleBackColor = true;
            // 
            // otherCurrencyRadioButton
            // 
            this.otherCurrencyRadioButton.AutoSize = true;
            this.otherCurrencyRadioButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.otherCurrencyRadioButton.Location = new System.Drawing.Point(12, 203);
            this.otherCurrencyRadioButton.Name = "otherCurrencyRadioButton";
            this.otherCurrencyRadioButton.Size = new System.Drawing.Size(14, 13);
            this.otherCurrencyRadioButton.TabIndex = 14;
            this.otherCurrencyRadioButton.TabStop = true;
            this.otherCurrencyRadioButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(32, 196);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 29);
            this.textBox1.TabIndex = 15;
            this.textBox1.Text = "Other (Please specify)";
            // 
            // themeGroupBox
            // 
            this.themeGroupBox.Controls.Add(this.blueThemeRadioButton);
            this.themeGroupBox.Controls.Add(this.panel2);
            this.themeGroupBox.Controls.Add(this.lightThemeRadioButton);
            this.themeGroupBox.Controls.Add(this.darkThemeRadioButton);
            this.themeGroupBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.themeGroupBox.Location = new System.Drawing.Point(66, 474);
            this.themeGroupBox.Name = "themeGroupBox";
            this.themeGroupBox.Size = new System.Drawing.Size(281, 140);
            this.themeGroupBox.TabIndex = 16;
            this.themeGroupBox.TabStop = false;
            this.themeGroupBox.Text = "EazyCart Theme";
            // 
            // blueThemeRadioButton
            // 
            this.blueThemeRadioButton.AutoSize = true;
            this.blueThemeRadioButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.blueThemeRadioButton.Location = new System.Drawing.Point(12, 103);
            this.blueThemeRadioButton.Name = "blueThemeRadioButton";
            this.blueThemeRadioButton.Size = new System.Drawing.Size(109, 25);
            this.blueThemeRadioButton.TabIndex = 11;
            this.blueThemeRadioButton.TabStop = true;
            this.blueThemeRadioButton.Text = "Blue Theme";
            this.blueThemeRadioButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel2.Location = new System.Drawing.Point(8, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 5);
            this.panel2.TabIndex = 10;
            // 
            // lightThemeRadioButton
            // 
            this.lightThemeRadioButton.AutoSize = true;
            this.lightThemeRadioButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lightThemeRadioButton.Location = new System.Drawing.Point(12, 41);
            this.lightThemeRadioButton.Name = "lightThemeRadioButton";
            this.lightThemeRadioButton.Size = new System.Drawing.Size(114, 25);
            this.lightThemeRadioButton.TabIndex = 1;
            this.lightThemeRadioButton.TabStop = true;
            this.lightThemeRadioButton.Text = "Light Theme";
            this.lightThemeRadioButton.UseVisualStyleBackColor = true;
            // 
            // darkThemeRadioButton
            // 
            this.darkThemeRadioButton.AutoSize = true;
            this.darkThemeRadioButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.darkThemeRadioButton.Location = new System.Drawing.Point(12, 72);
            this.darkThemeRadioButton.Name = "darkThemeRadioButton";
            this.darkThemeRadioButton.Size = new System.Drawing.Size(112, 25);
            this.darkThemeRadioButton.TabIndex = 0;
            this.darkThemeRadioButton.TabStop = true;
            this.darkThemeRadioButton.Text = "Dark Theme";
            this.darkThemeRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(21, 805);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "*All changes will be reflected in the preview window";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel3.Location = new System.Drawing.Point(437, 68);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1106, 5);
            this.panel3.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(440, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Preview Window";
            // 
            // revertChangesButton
            // 
            this.revertChangesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.revertChangesButton.BackgroundImage = global::EazyCart.Properties.Resources.revertChangesImage;
            this.revertChangesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.revertChangesButton.FlatAppearance.BorderSize = 0;
            this.revertChangesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.revertChangesButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.revertChangesButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.revertChangesButton.Location = new System.Drawing.Point(1077, 741);
            this.revertChangesButton.Name = "revertChangesButton";
            this.revertChangesButton.Size = new System.Drawing.Size(192, 65);
            this.revertChangesButton.TabIndex = 31;
            this.revertChangesButton.UseVisualStyleBackColor = false;
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.saveChangesButton.BackgroundImage = global::EazyCart.Properties.Resources.saveProductPlaceholder;
            this.saveChangesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveChangesButton.FlatAppearance.BorderSize = 0;
            this.saveChangesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveChangesButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveChangesButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveChangesButton.Location = new System.Drawing.Point(1289, 740);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(254, 65);
            this.saveChangesButton.TabIndex = 30;
            this.saveChangesButton.UseVisualStyleBackColor = false;
            // 
            // addProductButton
            // 
            this.addProductButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.addProductButton.BackgroundImage = global::EazyCart.Properties.Resources.AddProductPlaceHolder;
            this.addProductButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addProductButton.FlatAppearance.BorderSize = 0;
            this.addProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addProductButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addProductButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addProductButton.Location = new System.Drawing.Point(66, 636);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(281, 58);
            this.addProductButton.TabIndex = 26;
            this.addProductButton.UseVisualStyleBackColor = false;
            // 
            // previewPictureBox
            // 
            this.previewPictureBox.Image = global::EazyCart.Properties.Resources.currentThemePlaceholder;
            this.previewPictureBox.Location = new System.Drawing.Point(437, 79);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(1106, 638);
            this.previewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewPictureBox.TabIndex = 2;
            this.previewPictureBox.TabStop = false;
            // 
            // SettingsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.revertChangesButton);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.addProductButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.themeGroupBox);
            this.Controls.Add(this.currencyGroupBox);
            this.Controls.Add(this.unitTypesGroupBox);
            this.Controls.Add(this.previewPictureBox);
            this.Name = "SettingsUserControl";
            this.Size = new System.Drawing.Size(1600, 840);
            this.unitTypesGroupBox.ResumeLayout(false);
            this.unitTypesGroupBox.PerformLayout();
            this.currencyGroupBox.ResumeLayout(false);
            this.currencyGroupBox.PerformLayout();
            this.themeGroupBox.ResumeLayout(false);
            this.themeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox previewPictureBox;
        private System.Windows.Forms.GroupBox unitTypesGroupBox;
        private System.Windows.Forms.RadioButton europeanUnitsUserControl;
        private System.Windows.Forms.RadioButton britishUnitsRadioButton;
        private System.Windows.Forms.Panel totalLinePanel;
        private System.Windows.Forms.GroupBox currencyGroupBox;
        private System.Windows.Forms.RadioButton otherCurrencyRadioButton;
        private System.Windows.Forms.RadioButton rubleRadioButton;
        private System.Windows.Forms.RadioButton levRadioButton;
        private System.Windows.Forms.RadioButton euroRadioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton dollarRadioButton;
        private System.Windows.Forms.RadioButton poundRadioButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox themeGroupBox;
        private System.Windows.Forms.RadioButton blueThemeRadioButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton lightThemeRadioButton;
        private System.Windows.Forms.RadioButton darkThemeRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.Button revertChangesButton;
        private System.Windows.Forms.Button saveChangesButton;
    }
}
