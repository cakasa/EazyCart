namespace EazyCart
{
    partial class WarehouseUserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.generalPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.addCategoryButton = new System.Windows.Forms.Button();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.productNameTextBox = new System.Windows.Forms.TextBox();
            this.productCodeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.supplierInformationGroupBox = new System.Windows.Forms.GroupBox();
            this.supplierCityComboBox = new System.Windows.Forms.ComboBox();
            this.supplierCountryComboBox = new System.Windows.Forms.ComboBox();
            this.addCityButton = new System.Windows.Forms.Button();
            this.addCountryButton = new System.Windows.Forms.Button();
            this.addProviderButton = new System.Windows.Forms.Button();
            this.supplierNameComboBox = new System.Windows.Forms.ComboBox();
            this.pricingGroupBox = new System.Windows.Forms.GroupBox();
            this.unitsGroupBox = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.unitRadioButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.netProfitTextLabel = new System.Windows.Forms.Label();
            this.sellingPriceTextBox = new System.Windows.Forms.TextBox();
            this.deliveryPriceTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addProductButton = new System.Windows.Forms.Button();
            this.makeDeliveryGroupBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Quantity = new System.Windows.Forms.TextBox();
            this.productComboBox = new System.Windows.Forms.ComboBox();
            this.changesGroupBox = new System.Windows.Forms.GroupBox();
            this.revertChangesButton = new System.Windows.Forms.Button();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.allProductsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generalPropertiesGroupBox.SuspendLayout();
            this.supplierInformationGroupBox.SuspendLayout();
            this.pricingGroupBox.SuspendLayout();
            this.unitsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.makeDeliveryGroupBox.SuspendLayout();
            this.changesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allProductsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // generalPropertiesGroupBox
            // 
            this.generalPropertiesGroupBox.Controls.Add(this.quantityTextBox);
            this.generalPropertiesGroupBox.Controls.Add(this.addCategoryButton);
            this.generalPropertiesGroupBox.Controls.Add(this.categoryComboBox);
            this.generalPropertiesGroupBox.Controls.Add(this.productNameTextBox);
            this.generalPropertiesGroupBox.Controls.Add(this.productCodeMaskedTextBox);
            this.generalPropertiesGroupBox.Controls.Add(this.label2);
            this.generalPropertiesGroupBox.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.generalPropertiesGroupBox.Location = new System.Drawing.Point(6, 29);
            this.generalPropertiesGroupBox.Name = "generalPropertiesGroupBox";
            this.generalPropertiesGroupBox.Size = new System.Drawing.Size(475, 126);
            this.generalPropertiesGroupBox.TabIndex = 16;
            this.generalPropertiesGroupBox.TabStop = false;
            this.generalPropertiesGroupBox.Text = "General Properties*";
            this.generalPropertiesGroupBox.Enter += new System.EventHandler(this.generalPropertiesGroupBox_Enter);
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quantityTextBox.Location = new System.Drawing.Point(357, 71);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(106, 33);
            this.quantityTextBox.TabIndex = 20;
            this.quantityTextBox.Text = "Quantity";
            // 
            // addCategoryButton
            // 
            this.addCategoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.addCategoryButton.BackgroundImage = global::EazyCart.Properties.Resources.addCategoryImage;
            this.addCategoryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addCategoryButton.FlatAppearance.BorderSize = 0;
            this.addCategoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCategoryButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addCategoryButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addCategoryButton.Location = new System.Drawing.Point(101, 32);
            this.addCategoryButton.Name = "addCategoryButton";
            this.addCategoryButton.Size = new System.Drawing.Size(33, 33);
            this.addCategoryButton.TabIndex = 19;
            this.addCategoryButton.UseVisualStyleBackColor = false;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(133, 32);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(330, 33);
            this.categoryComboBox.TabIndex = 17;
            this.categoryComboBox.Text = "Category";
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.productNameTextBox.Location = new System.Drawing.Point(26, 71);
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.Size = new System.Drawing.Size(325, 33);
            this.productNameTextBox.TabIndex = 18;
            this.productNameTextBox.Text = "Product Name";
            // 
            // productCodeMaskedTextBox
            // 
            this.productCodeMaskedTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.productCodeMaskedTextBox.Location = new System.Drawing.Point(26, 32);
            this.productCodeMaskedTextBox.Mask = "000000";
            this.productCodeMaskedTextBox.Name = "productCodeMaskedTextBox";
            this.productCodeMaskedTextBox.PromptChar = ' ';
            this.productCodeMaskedTextBox.Size = new System.Drawing.Size(69, 33);
            this.productCodeMaskedTextBox.TabIndex = 17;
            this.productCodeMaskedTextBox.Text = "000000";
            this.productCodeMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.productCodeMaskedTextBox.ValidatingType = typeof(int);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "#";
            // 
            // supplierInformationGroupBox
            // 
            this.supplierInformationGroupBox.Controls.Add(this.supplierCityComboBox);
            this.supplierInformationGroupBox.Controls.Add(this.supplierCountryComboBox);
            this.supplierInformationGroupBox.Controls.Add(this.addCityButton);
            this.supplierInformationGroupBox.Controls.Add(this.addCountryButton);
            this.supplierInformationGroupBox.Controls.Add(this.addProviderButton);
            this.supplierInformationGroupBox.Controls.Add(this.supplierNameComboBox);
            this.supplierInformationGroupBox.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.supplierInformationGroupBox.Location = new System.Drawing.Point(6, 161);
            this.supplierInformationGroupBox.Name = "supplierInformationGroupBox";
            this.supplierInformationGroupBox.Size = new System.Drawing.Size(475, 126);
            this.supplierInformationGroupBox.TabIndex = 20;
            this.supplierInformationGroupBox.TabStop = false;
            this.supplierInformationGroupBox.Text = "Supplier Information*";
            // 
            // supplierCityComboBox
            // 
            this.supplierCityComboBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierCityComboBox.FormattingEnabled = true;
            this.supplierCityComboBox.Location = new System.Drawing.Point(265, 71);
            this.supplierCityComboBox.Name = "supplierCityComboBox";
            this.supplierCityComboBox.Size = new System.Drawing.Size(198, 33);
            this.supplierCityComboBox.TabIndex = 24;
            this.supplierCityComboBox.Text = "City";
            // 
            // supplierCountryComboBox
            // 
            this.supplierCountryComboBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierCountryComboBox.FormattingEnabled = true;
            this.supplierCountryComboBox.Location = new System.Drawing.Point(59, 71);
            this.supplierCountryComboBox.Name = "supplierCountryComboBox";
            this.supplierCountryComboBox.Size = new System.Drawing.Size(167, 33);
            this.supplierCountryComboBox.TabIndex = 23;
            this.supplierCountryComboBox.Text = "Country";
            // 
            // addCityButton
            // 
            this.addCityButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.addCityButton.BackgroundImage = global::EazyCart.Properties.Resources.addCategoryImage;
            this.addCityButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addCityButton.FlatAppearance.BorderSize = 0;
            this.addCityButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCityButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addCityButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addCityButton.Location = new System.Drawing.Point(232, 71);
            this.addCityButton.Name = "addCityButton";
            this.addCityButton.Size = new System.Drawing.Size(33, 33);
            this.addCityButton.TabIndex = 22;
            this.addCityButton.UseVisualStyleBackColor = false;
            // 
            // addCountryButton
            // 
            this.addCountryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.addCountryButton.BackgroundImage = global::EazyCart.Properties.Resources.addCategoryImage;
            this.addCountryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addCountryButton.FlatAppearance.BorderSize = 0;
            this.addCountryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCountryButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addCountryButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addCountryButton.Location = new System.Drawing.Point(26, 71);
            this.addCountryButton.Name = "addCountryButton";
            this.addCountryButton.Size = new System.Drawing.Size(33, 33);
            this.addCountryButton.TabIndex = 20;
            this.addCountryButton.UseVisualStyleBackColor = false;
            // 
            // addProviderButton
            // 
            this.addProviderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.addProviderButton.BackgroundImage = global::EazyCart.Properties.Resources.addCategoryImage;
            this.addProviderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addProviderButton.FlatAppearance.BorderSize = 0;
            this.addProviderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addProviderButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addProviderButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addProviderButton.Location = new System.Drawing.Point(26, 32);
            this.addProviderButton.Name = "addProviderButton";
            this.addProviderButton.Size = new System.Drawing.Size(33, 33);
            this.addProviderButton.TabIndex = 19;
            this.addProviderButton.UseVisualStyleBackColor = false;
            // 
            // supplierNameComboBox
            // 
            this.supplierNameComboBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierNameComboBox.FormattingEnabled = true;
            this.supplierNameComboBox.Location = new System.Drawing.Point(59, 32);
            this.supplierNameComboBox.Name = "supplierNameComboBox";
            this.supplierNameComboBox.Size = new System.Drawing.Size(404, 33);
            this.supplierNameComboBox.TabIndex = 17;
            this.supplierNameComboBox.Text = "Supplier Name";
            // 
            // pricingGroupBox
            // 
            this.pricingGroupBox.Controls.Add(this.unitsGroupBox);
            this.pricingGroupBox.Controls.Add(this.label3);
            this.pricingGroupBox.Controls.Add(this.netProfitTextLabel);
            this.pricingGroupBox.Controls.Add(this.sellingPriceTextBox);
            this.pricingGroupBox.Controls.Add(this.deliveryPriceTextBox);
            this.pricingGroupBox.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.pricingGroupBox.Location = new System.Drawing.Point(6, 293);
            this.pricingGroupBox.Name = "pricingGroupBox";
            this.pricingGroupBox.Size = new System.Drawing.Size(475, 156);
            this.pricingGroupBox.TabIndex = 25;
            this.pricingGroupBox.TabStop = false;
            this.pricingGroupBox.Text = "Pricing*";
            this.pricingGroupBox.Enter += new System.EventHandler(this.pricingGroupBox_Enter);
            // 
            // unitsGroupBox
            // 
            this.unitsGroupBox.Controls.Add(this.radioButton2);
            this.unitsGroupBox.Controls.Add(this.radioButton1);
            this.unitsGroupBox.Controls.Add(this.unitRadioButton);
            this.unitsGroupBox.Location = new System.Drawing.Point(250, 15);
            this.unitsGroupBox.Name = "unitsGroupBox";
            this.unitsGroupBox.Size = new System.Drawing.Size(161, 121);
            this.unitsGroupBox.TabIndex = 24;
            this.unitsGroupBox.TabStop = false;
            this.unitsGroupBox.Text = "Units";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 90);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(77, 24);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Litre (L)";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 58);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(120, 24);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Kilogram (KG)";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // unitRadioButton
            // 
            this.unitRadioButton.AutoSize = true;
            this.unitRadioButton.Location = new System.Drawing.Point(6, 26);
            this.unitRadioButton.Name = "unitRadioButton";
            this.unitRadioButton.Size = new System.Drawing.Size(89, 24);
            this.unitRadioButton.TabIndex = 0;
            this.unitRadioButton.TabStop = true;
            this.unitRadioButton.Text = "Unit (UN)";
            this.unitRadioButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(95, 116);
            this.label3.MinimumSize = new System.Drawing.Size(130, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "$0.33";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // netProfitTextLabel
            // 
            this.netProfitTextLabel.AutoSize = true;
            this.netProfitTextLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.netProfitTextLabel.Location = new System.Drawing.Point(27, 119);
            this.netProfitTextLabel.Name = "netProfitTextLabel";
            this.netProfitTextLabel.Size = new System.Drawing.Size(67, 17);
            this.netProfitTextLabel.TabIndex = 22;
            this.netProfitTextLabel.Text = "Net Profit:";
            // 
            // sellingPriceTextBox
            // 
            this.sellingPriceTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sellingPriceTextBox.Location = new System.Drawing.Point(26, 75);
            this.sellingPriceTextBox.Name = "sellingPriceTextBox";
            this.sellingPriceTextBox.Size = new System.Drawing.Size(200, 33);
            this.sellingPriceTextBox.TabIndex = 21;
            this.sellingPriceTextBox.Text = "Selling Price";
            // 
            // deliveryPriceTextBox
            // 
            this.deliveryPriceTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deliveryPriceTextBox.Location = new System.Drawing.Point(26, 36);
            this.deliveryPriceTextBox.Name = "deliveryPriceTextBox";
            this.deliveryPriceTextBox.Size = new System.Drawing.Size(200, 33);
            this.deliveryPriceTextBox.TabIndex = 20;
            this.deliveryPriceTextBox.Text = "Delivery Price";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addProductButton);
            this.groupBox1.Controls.Add(this.supplierInformationGroupBox);
            this.groupBox1.Controls.Add(this.pricingGroupBox);
            this.groupBox1.Controls.Add(this.generalPropertiesGroupBox);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.groupBox1.Location = new System.Drawing.Point(9, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 513);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Product";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
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
            this.addProductButton.Location = new System.Drawing.Point(32, 455);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(437, 41);
            this.addProductButton.TabIndex = 25;
            this.addProductButton.UseVisualStyleBackColor = false;
            // 
            // makeDeliveryGroupBox
            // 
            this.makeDeliveryGroupBox.Controls.Add(this.button1);
            this.makeDeliveryGroupBox.Controls.Add(this.Quantity);
            this.makeDeliveryGroupBox.Controls.Add(this.productComboBox);
            this.makeDeliveryGroupBox.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.makeDeliveryGroupBox.Location = new System.Drawing.Point(9, 557);
            this.makeDeliveryGroupBox.Name = "makeDeliveryGroupBox";
            this.makeDeliveryGroupBox.Size = new System.Drawing.Size(489, 129);
            this.makeDeliveryGroupBox.TabIndex = 27;
            this.makeDeliveryGroupBox.TabStop = false;
            this.makeDeliveryGroupBox.Text = "Make Delivery";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.button1.BackgroundImage = global::EazyCart.Properties.Resources.MakeDeliveryImage;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(133, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(336, 33);
            this.button1.TabIndex = 26;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Quantity
            // 
            this.Quantity.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Quantity.Location = new System.Drawing.Point(32, 77);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(95, 33);
            this.Quantity.TabIndex = 25;
            this.Quantity.Text = "Quantity";
            // 
            // productComboBox
            // 
            this.productComboBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productComboBox.FormattingEnabled = true;
            this.productComboBox.Location = new System.Drawing.Point(32, 38);
            this.productComboBox.Name = "productComboBox";
            this.productComboBox.Size = new System.Drawing.Size(437, 33);
            this.productComboBox.TabIndex = 18;
            this.productComboBox.Text = "Product";
            // 
            // changesGroupBox
            // 
            this.changesGroupBox.Controls.Add(this.revertChangesButton);
            this.changesGroupBox.Controls.Add(this.saveChangesButton);
            this.changesGroupBox.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.changesGroupBox.Location = new System.Drawing.Point(9, 709);
            this.changesGroupBox.Name = "changesGroupBox";
            this.changesGroupBox.Size = new System.Drawing.Size(489, 106);
            this.changesGroupBox.TabIndex = 28;
            this.changesGroupBox.TabStop = false;
            this.changesGroupBox.Text = "Changes";
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
            this.revertChangesButton.Location = new System.Drawing.Point(277, 32);
            this.revertChangesButton.Name = "revertChangesButton";
            this.revertChangesButton.Size = new System.Drawing.Size(192, 65);
            this.revertChangesButton.TabIndex = 29;
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
            this.saveChangesButton.Location = new System.Drawing.Point(17, 32);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(254, 65);
            this.saveChangesButton.TabIndex = 28;
            this.saveChangesButton.UseVisualStyleBackColor = false;
            // 
            // allProductsDataGridView
            // 
            this.allProductsDataGridView.AllowUserToAddRows = false;
            this.allProductsDataGridView.AllowUserToDeleteRows = false;
            this.allProductsDataGridView.AllowUserToResizeColumns = false;
            this.allProductsDataGridView.AllowUserToResizeRows = false;
            this.allProductsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.allProductsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.allProductsDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.allProductsDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.allProductsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.allProductsDataGridView.ColumnHeadersHeight = 30;
            this.allProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.allProductsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.categoryColumn,
            this.quantityColumn,
            this.unitsColumn,
            this.supplierNameColumn,
            this.countryColumn,
            this.cityColumn,
            this.deliveryPriceColumn,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.allProductsDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.allProductsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.allProductsDataGridView.EnableHeadersVisualStyles = false;
            this.allProductsDataGridView.Location = new System.Drawing.Point(496, 20);
            this.allProductsDataGridView.MultiSelect = false;
            this.allProductsDataGridView.Name = "allProductsDataGridView";
            this.allProductsDataGridView.ReadOnly = true;
            this.allProductsDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.allProductsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.allProductsDataGridView.RowHeadersWidth = 4;
            this.allProductsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.allProductsDataGridView.RowTemplate.Height = 30;
            this.allProductsDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.allProductsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.allProductsDataGridView.Size = new System.Drawing.Size(1088, 705);
            this.allProductsDataGridView.TabIndex = 30;
            this.allProductsDataGridView.TabStop = false;
            this.allProductsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.allProductsDataGridView_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "CODE";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 85;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "NAME";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 275;
            // 
            // categoryColumn
            // 
            this.categoryColumn.HeaderText = "CATEGORY";
            this.categoryColumn.Name = "categoryColumn";
            this.categoryColumn.ReadOnly = true;
            this.categoryColumn.Width = 125;
            // 
            // quantityColumn
            // 
            this.quantityColumn.HeaderText = "QNTY";
            this.quantityColumn.Name = "quantityColumn";
            this.quantityColumn.ReadOnly = true;
            this.quantityColumn.Width = 55;
            // 
            // unitsColumn
            // 
            this.unitsColumn.HeaderText = "UN";
            this.unitsColumn.Name = "unitsColumn";
            this.unitsColumn.ReadOnly = true;
            this.unitsColumn.Width = 50;
            // 
            // supplierNameColumn
            // 
            this.supplierNameColumn.HeaderText = "SUP. NAME";
            this.supplierNameColumn.Name = "supplierNameColumn";
            this.supplierNameColumn.ReadOnly = true;
            this.supplierNameColumn.Width = 110;
            // 
            // countryColumn
            // 
            this.countryColumn.HeaderText = "COUNTRY";
            this.countryColumn.Name = "countryColumn";
            this.countryColumn.ReadOnly = true;
            this.countryColumn.Width = 90;
            // 
            // cityColumn
            // 
            this.cityColumn.HeaderText = "CITY";
            this.cityColumn.Name = "cityColumn";
            this.cityColumn.ReadOnly = true;
            this.cityColumn.Width = 95;
            // 
            // deliveryPriceColumn
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.deliveryPriceColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.deliveryPriceColumn.HeaderText = "DEL. PRICE";
            this.deliveryPriceColumn.Name = "deliveryPriceColumn";
            this.deliveryPriceColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn4.HeaderText = "UN. PRICE";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // WarehouseUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.allProductsDataGridView);
            this.Controls.Add(this.changesGroupBox);
            this.Controls.Add(this.makeDeliveryGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "WarehouseUserControl";
            this.Size = new System.Drawing.Size(1600, 840);
            this.Load += new System.EventHandler(this.WarehouseUserControl_Load);
            this.generalPropertiesGroupBox.ResumeLayout(false);
            this.generalPropertiesGroupBox.PerformLayout();
            this.supplierInformationGroupBox.ResumeLayout(false);
            this.pricingGroupBox.ResumeLayout(false);
            this.pricingGroupBox.PerformLayout();
            this.unitsGroupBox.ResumeLayout(false);
            this.unitsGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.makeDeliveryGroupBox.ResumeLayout(false);
            this.makeDeliveryGroupBox.PerformLayout();
            this.changesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.allProductsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox generalPropertiesGroupBox;
        private System.Windows.Forms.MaskedTextBox productCodeMaskedTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox productNameTextBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Button addCategoryButton;
        private System.Windows.Forms.GroupBox supplierInformationGroupBox;
        private System.Windows.Forms.ComboBox supplierCityComboBox;
        private System.Windows.Forms.ComboBox supplierCountryComboBox;
        private System.Windows.Forms.Button addCityButton;
        private System.Windows.Forms.Button addCountryButton;
        private System.Windows.Forms.Button addProviderButton;
        private System.Windows.Forms.ComboBox supplierNameComboBox;
        private System.Windows.Forms.GroupBox pricingGroupBox;
        private System.Windows.Forms.GroupBox unitsGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label netProfitTextLabel;
        private System.Windows.Forms.TextBox sellingPriceTextBox;
        private System.Windows.Forms.TextBox deliveryPriceTextBox;
        private System.Windows.Forms.RadioButton unitRadioButton;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.GroupBox makeDeliveryGroupBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Quantity;
        private System.Windows.Forms.ComboBox productComboBox;
        private System.Windows.Forms.GroupBox changesGroupBox;
        private System.Windows.Forms.Button revertChangesButton;
        private System.Windows.Forms.Button saveChangesButton;
        private System.Windows.Forms.DataGridView allProductsDataGridView;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
