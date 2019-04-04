namespace EazyCart
{
    partial class StatisticsUserContol
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
            this.exportReportButton = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.reportChart = new LiveCharts.Wpf.CartesianChart();
            this.reportCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.reportPeriodComboBox = new System.Windows.Forms.ComboBox();
            this.reportTypeComboBox = new System.Windows.Forms.ComboBox();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.totalLinePanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.generateReportButton = new System.Windows.Forms.Button();
            this.exportInformationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exportReportButton
            // 
            this.exportReportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.exportReportButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.exportReportButton.FlatAppearance.BorderSize = 0;
            this.exportReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportReportButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exportReportButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exportReportButton.Image = global::EazyCart.Properties.Resources.exportReportButtonImage;
            this.exportReportButton.Location = new System.Drawing.Point(1297, 424);
            this.exportReportButton.Name = "exportReportButton";
            this.exportReportButton.Size = new System.Drawing.Size(282, 65);
            this.exportReportButton.TabIndex = 36;
            this.exportReportButton.UseVisualStyleBackColor = false;
            this.exportReportButton.Click += new System.EventHandler(this.ExportReportButton_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(51, 102);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(1216, 698);
            this.elementHost1.TabIndex = 37;
            this.elementHost1.Text = "reportChart";
            this.elementHost1.Child = this.reportChart;
            // 
            // reportCategoryComboBox
            // 
            this.reportCategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reportCategoryComboBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reportCategoryComboBox.FormattingEnabled = true;
            this.reportCategoryComboBox.Items.AddRange(new object[] {
            "Select Report Type",
            "Sales Report",
            "Inventory Report",
            "Order Report"});
            this.reportCategoryComboBox.Location = new System.Drawing.Point(38, 31);
            this.reportCategoryComboBox.Name = "reportCategoryComboBox";
            this.reportCategoryComboBox.Size = new System.Drawing.Size(393, 33);
            this.reportCategoryComboBox.TabIndex = 38;
            this.reportCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.ReportCategoryComboBox_SelectedIndexChanged);
            // 
            // reportPeriodComboBox
            // 
            this.reportPeriodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reportPeriodComboBox.Enabled = false;
            this.reportPeriodComboBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reportPeriodComboBox.FormattingEnabled = true;
            this.reportPeriodComboBox.Items.AddRange(new object[] {
            "Select Period",
            "Daily",
            "Monthly",
            "Yearly"});
            this.reportPeriodComboBox.Location = new System.Drawing.Point(1053, 31);
            this.reportPeriodComboBox.Name = "reportPeriodComboBox";
            this.reportPeriodComboBox.Size = new System.Drawing.Size(227, 33);
            this.reportPeriodComboBox.TabIndex = 39;
            // 
            // reportTypeComboBox
            // 
            this.reportTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reportTypeComboBox.Enabled = false;
            this.reportTypeComboBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reportTypeComboBox.FormattingEnabled = true;
            this.reportTypeComboBox.Items.AddRange(new object[] {
            "Select Period",
            "Daily",
            "Weekly",
            "Monthly",
            "Yearly"});
            this.reportTypeComboBox.Location = new System.Drawing.Point(448, 31);
            this.reportTypeComboBox.Name = "reportTypeComboBox";
            this.reportTypeComboBox.Size = new System.Drawing.Size(590, 33);
            this.reportTypeComboBox.TabIndex = 40;
            this.reportTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ReportTypeComboBox_SelectedIndexChanged);
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileNameTextBox.Location = new System.Drawing.Point(1297, 385);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(282, 33);
            this.fileNameTextBox.TabIndex = 41;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileNameLabel.Location = new System.Drawing.Point(1292, 357);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(100, 25);
            this.fileNameLabel.TabIndex = 42;
            this.fileNameLabel.Text = "File Name:";
            // 
            // totalLinePanel
            // 
            this.totalLinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.totalLinePanel.Location = new System.Drawing.Point(38, 89);
            this.totalLinePanel.Name = "totalLinePanel";
            this.totalLinePanel.Size = new System.Drawing.Size(5, 724);
            this.totalLinePanel.TabIndex = 43;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel1.Location = new System.Drawing.Point(38, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1239, 5);
            this.panel1.TabIndex = 43;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel2.Location = new System.Drawing.Point(1275, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 724);
            this.panel2.TabIndex = 43;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel3.Location = new System.Drawing.Point(41, 808);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1239, 5);
            this.panel3.TabIndex = 43;
            // 
            // generateReportButton
            // 
            this.generateReportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.generateReportButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.generateReportButton.FlatAppearance.BorderSize = 0;
            this.generateReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateReportButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateReportButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.generateReportButton.Image = global::EazyCart.Properties.Resources.generateReportButtonImage;
            this.generateReportButton.Location = new System.Drawing.Point(1297, 12);
            this.generateReportButton.Name = "generateReportButton";
            this.generateReportButton.Size = new System.Drawing.Size(282, 65);
            this.generateReportButton.TabIndex = 35;
            this.generateReportButton.UseVisualStyleBackColor = false;
            this.generateReportButton.Click += new System.EventHandler(this.GenerateReportButton_Click);
            // 
            // exportInformationLabel
            // 
            this.exportInformationLabel.AutoSize = true;
            this.exportInformationLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exportInformationLabel.Location = new System.Drawing.Point(1292, 492);
            this.exportInformationLabel.MaximumSize = new System.Drawing.Size(500, 282);
            this.exportInformationLabel.Name = "exportInformationLabel";
            this.exportInformationLabel.Size = new System.Drawing.Size(287, 25);
            this.exportInformationLabel.TabIndex = 44;
            this.exportInformationLabel.Text = "Exports the report in .png format";
            // 
            // StatisticsUserContol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exportInformationLabel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.totalLinePanel);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.reportTypeComboBox);
            this.Controls.Add(this.reportPeriodComboBox);
            this.Controls.Add(this.reportCategoryComboBox);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.exportReportButton);
            this.Controls.Add(this.generateReportButton);
            this.Name = "StatisticsUserContol";
            this.Size = new System.Drawing.Size(1600, 840);
            this.Load += new System.EventHandler(this.StatisticsUserContol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exportReportButton;
        private System.Windows.Forms.Button generateReportButton;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.ComboBox reportCategoryComboBox;
        private System.Windows.Forms.ComboBox reportPeriodComboBox;
        private System.Windows.Forms.ComboBox reportTypeComboBox;
        private LiveCharts.Wpf.CartesianChart reportChart;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Panel totalLinePanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label exportInformationLabel;
    }
}
