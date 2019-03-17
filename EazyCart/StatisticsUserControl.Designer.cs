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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Daily Sales Report");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Weekly Sales Report");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Monthly Sales Report");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Yearly Sales Report");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Sold Products by Category");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Sales Reports", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Product Quantity in Inventory");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Products by Providers");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Providers by Country");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Products by Profit from Single Purchase");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Inventory Reports", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Number of Orders for the Week");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Number Of Products In Week\'s Orders");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Orders Featuring Discount for the Week");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Order Reports", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14});
            this.saveReportButton = new System.Windows.Forms.Button();
            this.generateReportButton = new System.Windows.Forms.Button();
            this.reportsTreeView = new System.Windows.Forms.TreeView();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChart1 = new LiveCharts.Wpf.CartesianChart();
            this.SuspendLayout();
            // 
            // saveReportButton
            // 
            this.saveReportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.saveReportButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveReportButton.FlatAppearance.BorderSize = 0;
            this.saveReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveReportButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveReportButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveReportButton.Location = new System.Drawing.Point(96, 694);
            this.saveReportButton.Name = "saveReportButton";
            this.saveReportButton.Size = new System.Drawing.Size(254, 65);
            this.saveReportButton.TabIndex = 36;
            this.saveReportButton.Text = "Save Report";
            this.saveReportButton.UseVisualStyleBackColor = false;
            // 
            // generateReportButton
            // 
            this.generateReportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.generateReportButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.generateReportButton.FlatAppearance.BorderSize = 0;
            this.generateReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateReportButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateReportButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.generateReportButton.Location = new System.Drawing.Point(96, 611);
            this.generateReportButton.Name = "generateReportButton";
            this.generateReportButton.Size = new System.Drawing.Size(254, 65);
            this.generateReportButton.TabIndex = 35;
            this.generateReportButton.Text = "Generate Report";
            this.generateReportButton.UseVisualStyleBackColor = false;
            // 
            // reportsTreeView
            // 
            this.reportsTreeView.BackColor = System.Drawing.Color.Gainsboro;
            this.reportsTreeView.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsTreeView.Location = new System.Drawing.Point(31, 87);
            this.reportsTreeView.Name = "reportsTreeView";
            treeNode1.Name = "dailySalesReport";
            treeNode1.Text = "Daily Sales Report";
            treeNode2.Name = "weeklySalesReport";
            treeNode2.Text = "Weekly Sales Report";
            treeNode3.Name = "monthlySalesReport";
            treeNode3.Text = "Monthly Sales Report";
            treeNode4.Name = "yearlySalesReport";
            treeNode4.Text = "Yearly Sales Report";
            treeNode5.Name = "soldProductsByCategory";
            treeNode5.Text = "Sold Products by Category";
            treeNode6.Name = "salesReports";
            treeNode6.Text = "Sales Reports";
            treeNode7.Name = "productQuantitiesReport";
            treeNode7.Text = "Product Quantity in Inventory";
            treeNode8.Name = "productsByProviders";
            treeNode8.Text = "Products by Providers";
            treeNode9.Name = "providersByCountry";
            treeNode9.Text = "Providers by Country";
            treeNode10.Name = "productsByProfitFromSinglePurchase";
            treeNode10.Text = "Products by Profit from Single Purchase";
            treeNode11.Name = "inventoryReports";
            treeNode11.Text = "Inventory Reports";
            treeNode12.Name = "numberOfOrdersForTheWeek";
            treeNode12.Text = "Number of Orders for the Week";
            treeNode13.Name = "numberOfProductsInWeeksOrders";
            treeNode13.Text = "Number Of Products In Week\'s Orders";
            treeNode14.Name = "Node13";
            treeNode14.Text = "Orders Featuring Discount for the Week";
            treeNode15.Name = "orderReports";
            treeNode15.Text = "Order Reports";
            this.reportsTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode11,
            treeNode15});
            this.reportsTreeView.Size = new System.Drawing.Size(394, 502);
            this.reportsTreeView.TabIndex = 34;
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(456, 53);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(1107, 724);
            this.elementHost1.TabIndex = 37;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.cartesianChart1;
            // 
            // StatisticsUserContol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.saveReportButton);
            this.Controls.Add(this.generateReportButton);
            this.Controls.Add(this.reportsTreeView);
            this.Name = "StatisticsUserContol";
            this.Size = new System.Drawing.Size(1600, 840);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveReportButton;
        private System.Windows.Forms.Button generateReportButton;
        private System.Windows.Forms.TreeView reportsTreeView;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private LiveCharts.Wpf.CartesianChart cartesianChart1;
    }
}
