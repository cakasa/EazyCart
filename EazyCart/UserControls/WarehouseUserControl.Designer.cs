using System;

namespace EazyCart.UserControls
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.generalPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.inventoryQuantityTextBox = new System.Windows.Forms.TextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.productNameTextBox = new System.Windows.Forms.TextBox();
            this.productCodeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.supplierInformationGroupBox = new System.Windows.Forms.GroupBox();
            this.supplierCityTextBox = new System.Windows.Forms.TextBox();
            this.supplierCountryTextBox = new System.Windows.Forms.TextBox();
            this.supplierNameComboBox = new System.Windows.Forms.ComboBox();
            this.pricingGroupBox = new System.Windows.Forms.GroupBox();
            this.netProfitAmountLabel = new System.Windows.Forms.Label();
            this.netProfitTextLabel = new System.Windows.Forms.Label();
            this.sellingPriceTextBox = new System.Windows.Forms.TextBox();
            this.deliveryPriceTextBox = new System.Windows.Forms.TextBox();
            this.unitsGroupBox = new System.Windows.Forms.GroupBox();
            this.litreRadioButton = new System.Windows.Forms.RadioButton();
            this.kilogramRadioButton = new System.Windows.Forms.RadioButton();
            this.unitRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.totalLinePanel = new System.Windows.Forms.Panel();
            this.deleteProductButton = new System.Windows.Forms.Button();
            this.saveProductButton = new System.Windows.Forms.Button();
            this.editProductButton = new System.Windows.Forms.Button();
            this.addProductButton = new System.Windows.Forms.Button();
            this.makeDeliveryGroupBox = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.makeDeliveryButton = new System.Windows.Forms.Button();
            this.deliveryQuantityTextBox = new System.Windows.Forms.TextBox();
            this.productComboBox = new System.Windows.Forms.ComboBox();
            this.allProductsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generalPropertiesGroupBox.SuspendLayout();
            this.supplierInformationGroupBox.SuspendLayout();
            this.pricingGroupBox.SuspendLayout();
            this.unitsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.makeDeliveryGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allProductsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // generalPropertiesGroupBox
            // 
            this.generalPropertiesGroupBox.Controls.Add(this.inventoryQuantityTextBox);
            this.generalPropertiesGroupBox.Controls.Add(this.categoryComboBox);
            this.generalPropertiesGroupBox.Controls.Add(this.productNameTextBox);
            this.generalPropertiesGroupBox.Controls.Add(this.productCodeMaskedTextBox);
            this.generalPropertiesGroupBox.Controls.Add(this.label2);
            this.generalPropertiesGroupBox.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.generalPropertiesGroupBox.Location = new System.Drawing.Point(6, 42);
            this.generalPropertiesGroupBox.Name = "generalPropertiesGroupBox";
            this.generalPropertiesGroupBox.Size = new System.Drawing.Size(404, 108);
            this.generalPropertiesGroupBox.TabIndex = 2;
            this.generalPropertiesGroupBox.TabStop = false;
            this.generalPropertiesGroupBox.Text = "General Properties";
            // 
            // inventoryQuantityTextBox
            // 
            this.inventoryQuantityTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inventoryQuantityTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.inventoryQuantityTextBox.Location = new System.Drawing.Point(305, 58);
            this.inventoryQuantityTextBox.Name = "inventoryQuantityTextBox";
            this.inventoryQuantityTextBox.Size = new System.Drawing.Size(93, 29);
            this.inventoryQuantityTextBox.TabIndex = 8;
            this.inventoryQuantityTextBox.Text = "Quantity";
            this.inventoryQuantityTextBox.Enter += new System.EventHandler(this.InventoryQuantityTextBox_Enter);
            this.inventoryQuantityTextBox.Leave += new System.EventHandler(this.InventoryQuantityTextBox_Leave);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.categoryComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.categoryComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryComboBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(91, 23);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(307, 29);
            this.categoryComboBox.TabIndex = 6;
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.productNameTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.productNameTextBox.Location = new System.Drawing.Point(25, 58);
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.Size = new System.Drawing.Size(274, 29);
            this.productNameTextBox.TabIndex = 7;
            this.productNameTextBox.Text = "Product Name";
            this.productNameTextBox.Enter += new System.EventHandler(this.ProductNameTextBox_Enter);
            this.productNameTextBox.Leave += new System.EventHandler(this.ProductNameTextBox_Leave);
            // 
            // productCodeMaskedTextBox
            // 
            this.productCodeMaskedTextBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.productCodeMaskedTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.productCodeMaskedTextBox.Location = new System.Drawing.Point(25, 23);
            this.productCodeMaskedTextBox.Mask = "000000";
            this.productCodeMaskedTextBox.Name = "productCodeMaskedTextBox";
            this.productCodeMaskedTextBox.PromptChar = '0';
            this.productCodeMaskedTextBox.Size = new System.Drawing.Size(60, 29);
            this.productCodeMaskedTextBox.TabIndex = 4;
            this.productCodeMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.productCodeMaskedTextBox.ValidatingType = typeof(int);
            this.productCodeMaskedTextBox.Enter += new System.EventHandler(this.ProductCodeMaskedTextBox_Enter);
            this.productCodeMaskedTextBox.Leave += new System.EventHandler(this.ProductCodeMaskedTextBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "#";
            // 
            // supplierInformationGroupBox
            // 
            this.supplierInformationGroupBox.Controls.Add(this.supplierCityTextBox);
            this.supplierInformationGroupBox.Controls.Add(this.supplierCountryTextBox);
            this.supplierInformationGroupBox.Controls.Add(this.supplierNameComboBox);
            this.supplierInformationGroupBox.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.supplierInformationGroupBox.Location = new System.Drawing.Point(8, 156);
            this.supplierInformationGroupBox.Name = "supplierInformationGroupBox";
            this.supplierInformationGroupBox.Size = new System.Drawing.Size(402, 107);
            this.supplierInformationGroupBox.TabIndex = 9;
            this.supplierInformationGroupBox.TabStop = false;
            this.supplierInformationGroupBox.Text = "Supplier Information";
            // 
            // supplierCityTextBox
            // 
            this.supplierCityTextBox.Enabled = false;
            this.supplierCityTextBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.supplierCityTextBox.Location = new System.Drawing.Point(232, 58);
            this.supplierCityTextBox.Name = "supplierCityTextBox";
            this.supplierCityTextBox.Size = new System.Drawing.Size(164, 29);
            this.supplierCityTextBox.TabIndex = 13;
            this.supplierCityTextBox.Text = "City";
            // 
            // supplierCountryTextBox
            // 
            this.supplierCountryTextBox.Enabled = false;
            this.supplierCountryTextBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.supplierCountryTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.supplierCountryTextBox.Location = new System.Drawing.Point(23, 58);
            this.supplierCountryTextBox.Name = "supplierCountryTextBox";
            this.supplierCountryTextBox.Size = new System.Drawing.Size(203, 29);
            this.supplierCountryTextBox.TabIndex = 12;
            this.supplierCountryTextBox.Text = "Country";
            // 
            // supplierNameComboBox
            // 
            this.supplierNameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.supplierNameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.supplierNameComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierNameComboBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.supplierNameComboBox.FormattingEnabled = true;
            this.supplierNameComboBox.Location = new System.Drawing.Point(23, 23);
            this.supplierNameComboBox.Name = "supplierNameComboBox";
            this.supplierNameComboBox.Size = new System.Drawing.Size(373, 29);
            this.supplierNameComboBox.TabIndex = 11;
            this.supplierNameComboBox.SelectedIndexChanged += new System.EventHandler(this.SupplierNameComboBox_SelectedIndexChanged);
            // 
            // pricingGroupBox
            // 
            this.pricingGroupBox.Controls.Add(this.netProfitAmountLabel);
            this.pricingGroupBox.Controls.Add(this.netProfitTextLabel);
            this.pricingGroupBox.Controls.Add(this.sellingPriceTextBox);
            this.pricingGroupBox.Controls.Add(this.deliveryPriceTextBox);
            this.pricingGroupBox.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.pricingGroupBox.Location = new System.Drawing.Point(8, 269);
            this.pricingGroupBox.Name = "pricingGroupBox";
            this.pricingGroupBox.Size = new System.Drawing.Size(241, 133);
            this.pricingGroupBox.TabIndex = 16;
            this.pricingGroupBox.TabStop = false;
            this.pricingGroupBox.Text = "Pricing";
            // 
            // netProfitAmountLabel
            // 
            this.netProfitAmountLabel.AutoSize = true;
            this.netProfitAmountLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.netProfitAmountLabel.Location = new System.Drawing.Point(93, 96);
            this.netProfitAmountLabel.MinimumSize = new System.Drawing.Size(130, 20);
            this.netProfitAmountLabel.Name = "netProfitAmountLabel";
            this.netProfitAmountLabel.Size = new System.Drawing.Size(130, 20);
            this.netProfitAmountLabel.TabIndex = 20;
            this.netProfitAmountLabel.Text = "$0.00";
            this.netProfitAmountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // netProfitTextLabel
            // 
            this.netProfitTextLabel.AutoSize = true;
            this.netProfitTextLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.netProfitTextLabel.Location = new System.Drawing.Point(22, 100);
            this.netProfitTextLabel.Name = "netProfitTextLabel";
            this.netProfitTextLabel.Size = new System.Drawing.Size(61, 15);
            this.netProfitTextLabel.TabIndex = 19;
            this.netProfitTextLabel.Text = "Net Profit:";
            // 
            // sellingPriceTextBox
            // 
            this.sellingPriceTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sellingPriceTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.sellingPriceTextBox.Location = new System.Drawing.Point(23, 58);
            this.sellingPriceTextBox.Name = "sellingPriceTextBox";
            this.sellingPriceTextBox.Size = new System.Drawing.Size(200, 29);
            this.sellingPriceTextBox.TabIndex = 18;
            this.sellingPriceTextBox.Text = "Selling Price";
            this.sellingPriceTextBox.TextChanged += new System.EventHandler(this.SellingPriceTextBox_TextChanged);
            this.sellingPriceTextBox.Enter += new System.EventHandler(this.SellingPriceTextBox_Enter);
            this.sellingPriceTextBox.Leave += new System.EventHandler(this.SellingPriceTextBox_Leave);
            // 
            // deliveryPriceTextBox
            // 
            this.deliveryPriceTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deliveryPriceTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.deliveryPriceTextBox.Location = new System.Drawing.Point(23, 23);
            this.deliveryPriceTextBox.Name = "deliveryPriceTextBox";
            this.deliveryPriceTextBox.Size = new System.Drawing.Size(200, 29);
            this.deliveryPriceTextBox.TabIndex = 17;
            this.deliveryPriceTextBox.Text = "Delivery Price";
            this.deliveryPriceTextBox.TextChanged += new System.EventHandler(this.DeliveryPriceTextBox_TextChanged);
            this.deliveryPriceTextBox.Enter += new System.EventHandler(this.DeliveryPriceTextBox_Enter);
            this.deliveryPriceTextBox.Leave += new System.EventHandler(this.DeliveryPriceTextBox_Leave);
            // 
            // unitsGroupBox
            // 
            this.unitsGroupBox.Controls.Add(this.litreRadioButton);
            this.unitsGroupBox.Controls.Add(this.kilogramRadioButton);
            this.unitsGroupBox.Controls.Add(this.unitRadioButton);
            this.unitsGroupBox.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.unitsGroupBox.Location = new System.Drawing.Point(255, 269);
            this.unitsGroupBox.Name = "unitsGroupBox";
            this.unitsGroupBox.Size = new System.Drawing.Size(155, 133);
            this.unitsGroupBox.TabIndex = 21;
            this.unitsGroupBox.TabStop = false;
            this.unitsGroupBox.Text = "Units";
            // 
            // litreRadioButton
            // 
            this.litreRadioButton.AutoSize = true;
            this.litreRadioButton.Location = new System.Drawing.Point(6, 90);
            this.litreRadioButton.Name = "litreRadioButton";
            this.litreRadioButton.Size = new System.Drawing.Size(69, 21);
            this.litreRadioButton.TabIndex = 24;
            this.litreRadioButton.TabStop = true;
            this.litreRadioButton.Text = "Litre (L)";
            this.litreRadioButton.UseVisualStyleBackColor = true;
            // 
            // kilogramRadioButton
            // 
            this.kilogramRadioButton.AutoSize = true;
            this.kilogramRadioButton.Location = new System.Drawing.Point(6, 58);
            this.kilogramRadioButton.Name = "kilogramRadioButton";
            this.kilogramRadioButton.Size = new System.Drawing.Size(107, 21);
            this.kilogramRadioButton.TabIndex = 23;
            this.kilogramRadioButton.TabStop = true;
            this.kilogramRadioButton.Text = "Kilogram (KG)";
            this.kilogramRadioButton.UseVisualStyleBackColor = true;
            // 
            // unitRadioButton
            // 
            this.unitRadioButton.AutoSize = true;
            this.unitRadioButton.Location = new System.Drawing.Point(6, 26);
            this.unitRadioButton.Name = "unitRadioButton";
            this.unitRadioButton.Size = new System.Drawing.Size(80, 21);
            this.unitRadioButton.TabIndex = 22;
            this.unitRadioButton.TabStop = true;
            this.unitRadioButton.Text = "Unit (UN)";
            this.unitRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.unitsGroupBox);
            this.groupBox1.Controls.Add(this.totalLinePanel);
            this.groupBox1.Controls.Add(this.deleteProductButton);
            this.groupBox1.Controls.Add(this.saveProductButton);
            this.groupBox1.Controls.Add(this.editProductButton);
            this.groupBox1.Controls.Add(this.addProductButton);
            this.groupBox1.Controls.Add(this.supplierInformationGroupBox);
            this.groupBox1.Controls.Add(this.pricingGroupBox);
            this.groupBox1.Controls.Add(this.generalPropertiesGroupBox);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 551);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Products";
            // 
            // totalLinePanel
            // 
            this.totalLinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.totalLinePanel.Location = new System.Drawing.Point(8, 24);
            this.totalLinePanel.Name = "totalLinePanel";
            this.totalLinePanel.Size = new System.Drawing.Size(420, 5);
            this.totalLinePanel.TabIndex = 34;
            // 
            // deleteProductButton
            // 
            this.deleteProductButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.deleteProductButton.BackgroundImage = global::EazyCart.Properties.Resources.deleteProductButtonImage;
            this.deleteProductButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deleteProductButton.FlatAppearance.BorderSize = 0;
            this.deleteProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteProductButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteProductButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteProductButton.Location = new System.Drawing.Point(31, 502);
            this.deleteProductButton.Name = "deleteProductButton";
            this.deleteProductButton.Size = new System.Drawing.Size(373, 35);
            this.deleteProductButton.TabIndex = 25;
            this.deleteProductButton.UseVisualStyleBackColor = false;
            this.deleteProductButton.Click += new System.EventHandler(this.DeleteProductButton_Click);
            // 
            // saveProductButton
            // 
            this.saveProductButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.saveProductButton.BackgroundImage = global::EazyCart.Properties.Resources.saveProductButtonImage;
            this.saveProductButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveProductButton.FlatAppearance.BorderSize = 0;
            this.saveProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveProductButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveProductButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveProductButton.Location = new System.Drawing.Point(221, 450);
            this.saveProductButton.Name = "saveProductButton";
            this.saveProductButton.Size = new System.Drawing.Size(183, 35);
            this.saveProductButton.TabIndex = 25;
            this.saveProductButton.UseVisualStyleBackColor = false;
            this.saveProductButton.Click += new System.EventHandler(this.SaveProductButton_Click);
            // 
            // editProductButton
            // 
            this.editProductButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.editProductButton.BackgroundImage = global::EazyCart.Properties.Resources.editProductButtonImage;
            this.editProductButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editProductButton.FlatAppearance.BorderSize = 0;
            this.editProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editProductButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editProductButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.editProductButton.Location = new System.Drawing.Point(31, 450);
            this.editProductButton.Name = "editProductButton";
            this.editProductButton.Size = new System.Drawing.Size(183, 35);
            this.editProductButton.TabIndex = 25;
            this.editProductButton.UseVisualStyleBackColor = false;
            this.editProductButton.Click += new System.EventHandler(this.EditProductButton_Click);
            // 
            // addProductButton
            // 
            this.addProductButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.addProductButton.BackgroundImage = global::EazyCart.Properties.Resources.addProductButtonImage;
            this.addProductButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addProductButton.FlatAppearance.BorderSize = 0;
            this.addProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addProductButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addProductButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addProductButton.Location = new System.Drawing.Point(31, 408);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(373, 35);
            this.addProductButton.TabIndex = 25;
            this.addProductButton.UseVisualStyleBackColor = false;
            this.addProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // makeDeliveryGroupBox
            // 
            this.makeDeliveryGroupBox.Controls.Add(this.panel2);
            this.makeDeliveryGroupBox.Controls.Add(this.makeDeliveryButton);
            this.makeDeliveryGroupBox.Controls.Add(this.deliveryQuantityTextBox);
            this.makeDeliveryGroupBox.Controls.Add(this.productComboBox);
            this.makeDeliveryGroupBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.makeDeliveryGroupBox.Location = new System.Drawing.Point(9, 559);
            this.makeDeliveryGroupBox.Name = "makeDeliveryGroupBox";
            this.makeDeliveryGroupBox.Size = new System.Drawing.Size(416, 150);
            this.makeDeliveryGroupBox.TabIndex = 26;
            this.makeDeliveryGroupBox.TabStop = false;
            this.makeDeliveryGroupBox.Text = "Make Delivery";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel2.Location = new System.Drawing.Point(8, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(460, 5);
            this.panel2.TabIndex = 35;
            // 
            // makeDeliveryButton
            // 
            this.makeDeliveryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.makeDeliveryButton.BackgroundImage = global::EazyCart.Properties.Resources.makeDeliveryButtonPicture;
            this.makeDeliveryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.makeDeliveryButton.FlatAppearance.BorderSize = 0;
            this.makeDeliveryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.makeDeliveryButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.makeDeliveryButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.makeDeliveryButton.Location = new System.Drawing.Point(25, 106);
            this.makeDeliveryButton.Name = "makeDeliveryButton";
            this.makeDeliveryButton.Size = new System.Drawing.Size(379, 35);
            this.makeDeliveryButton.TabIndex = 29;
            this.makeDeliveryButton.UseVisualStyleBackColor = false;
            this.makeDeliveryButton.Click += new System.EventHandler(this.MakeDeliveryButton_Click);
            // 
            // deliveryQuantityTextBox
            // 
            this.deliveryQuantityTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deliveryQuantityTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.deliveryQuantityTextBox.Location = new System.Drawing.Point(25, 71);
            this.deliveryQuantityTextBox.Name = "deliveryQuantityTextBox";
            this.deliveryQuantityTextBox.Size = new System.Drawing.Size(379, 29);
            this.deliveryQuantityTextBox.TabIndex = 28;
            this.deliveryQuantityTextBox.Text = "Quantity";
            this.deliveryQuantityTextBox.Enter += new System.EventHandler(this.DeliveryQuantityTextBox_Enter);
            this.deliveryQuantityTextBox.Leave += new System.EventHandler(this.DeliveryQuantityTextBox_Leave);
            // 
            // productComboBox
            // 
            this.productComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.productComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.productComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productComboBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.productComboBox.FormattingEnabled = true;
            this.productComboBox.Items.AddRange(new object[] {
            "Product",
            "Coca Cola",
            "Perfume"});
            this.productComboBox.Location = new System.Drawing.Point(25, 36);
            this.productComboBox.Name = "productComboBox";
            this.productComboBox.Size = new System.Drawing.Size(379, 29);
            this.productComboBox.TabIndex = 27;
            // 
            // allProductsDataGridView
            // 
            this.allProductsDataGridView.AllowUserToAddRows = false;
            this.allProductsDataGridView.AllowUserToDeleteRows = false;
            this.allProductsDataGridView.AllowUserToOrderColumns = true;
            this.allProductsDataGridView.AllowUserToResizeRows = false;
            this.allProductsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.allProductsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.allProductsDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.allProductsDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.allProductsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.allProductsDataGridView.ColumnHeadersHeight = 27;
            this.allProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.allProductsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.categoryColumn,
            this.quantityColumn,
            this.unitsColumn,
            this.supplierNameColumn,
            this.deliveryPriceColumn,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.allProductsDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.allProductsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.allProductsDataGridView.EnableHeadersVisualStyles = false;
            this.allProductsDataGridView.Location = new System.Drawing.Point(431, 9);
            this.allProductsDataGridView.MultiSelect = false;
            this.allProductsDataGridView.Name = "allProductsDataGridView";
            this.allProductsDataGridView.ReadOnly = true;
            this.allProductsDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.allProductsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.allProductsDataGridView.RowHeadersWidth = 4;
            this.allProductsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.allProductsDataGridView.RowTemplate.Height = 27;
            this.allProductsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.allProductsDataGridView.Size = new System.Drawing.Size(928, 700);
            this.allProductsDataGridView.TabIndex = 33;
            this.allProductsDataGridView.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "CODE";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 68;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "NAME";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 246;
            // 
            // categoryColumn
            // 
            this.categoryColumn.HeaderText = "CATEGORY";
            this.categoryColumn.Name = "categoryColumn";
            this.categoryColumn.ReadOnly = true;
            this.categoryColumn.Width = 140;
            // 
            // quantityColumn
            // 
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.quantityColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.quantityColumn.HeaderText = "QUANTITY";
            this.quantityColumn.Name = "quantityColumn";
            this.quantityColumn.ReadOnly = true;
            this.quantityColumn.Width = 85;
            // 
            // unitsColumn
            // 
            this.unitsColumn.HeaderText = "UN";
            this.unitsColumn.Name = "unitsColumn";
            this.unitsColumn.ReadOnly = true;
            this.unitsColumn.Width = 43;
            // 
            // supplierNameColumn
            // 
            this.supplierNameColumn.HeaderText = "SUPPLIER NAME";
            this.supplierNameColumn.Name = "supplierNameColumn";
            this.supplierNameColumn.ReadOnly = true;
            this.supplierNameColumn.Width = 195;
            // 
            // deliveryPriceColumn
            // 
            dataGridViewCellStyle3.NullValue = null;
            this.deliveryPriceColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.deliveryPriceColumn.HeaderText = "DEL. PR.";
            this.deliveryPriceColumn.Name = "deliveryPriceColumn";
            this.deliveryPriceColumn.ReadOnly = true;
            this.deliveryPriceColumn.Width = 73;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn4.HeaderText = "SEL. PR.";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 72;
            // 
            // WarehouseUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.allProductsDataGridView);
            this.Controls.Add(this.makeDeliveryGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "WarehouseUserControl";
            this.Size = new System.Drawing.Size(1366, 717);
            this.Load += new System.EventHandler(this.WarehouseUserControl_Load);
            this.generalPropertiesGroupBox.ResumeLayout(false);
            this.generalPropertiesGroupBox.PerformLayout();
            this.supplierInformationGroupBox.ResumeLayout(false);
            this.supplierInformationGroupBox.PerformLayout();
            this.pricingGroupBox.ResumeLayout(false);
            this.pricingGroupBox.PerformLayout();
            this.unitsGroupBox.ResumeLayout(false);
            this.unitsGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.makeDeliveryGroupBox.ResumeLayout(false);
            this.makeDeliveryGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allProductsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox generalPropertiesGroupBox;
        private System.Windows.Forms.MaskedTextBox productCodeMaskedTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox productNameTextBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.GroupBox supplierInformationGroupBox;
        private System.Windows.Forms.ComboBox supplierNameComboBox;
        private System.Windows.Forms.GroupBox pricingGroupBox;
        private System.Windows.Forms.GroupBox unitsGroupBox;
        private System.Windows.Forms.Label netProfitAmountLabel;
        private System.Windows.Forms.Label netProfitTextLabel;
        private System.Windows.Forms.TextBox sellingPriceTextBox;
        private System.Windows.Forms.TextBox deliveryPriceTextBox;
        private System.Windows.Forms.RadioButton unitRadioButton;
        private System.Windows.Forms.RadioButton litreRadioButton;
        private System.Windows.Forms.RadioButton kilogramRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.GroupBox makeDeliveryGroupBox;
        private System.Windows.Forms.Button makeDeliveryButton;
        private System.Windows.Forms.TextBox deliveryQuantityTextBox;
        private System.Windows.Forms.ComboBox productComboBox;
        private System.Windows.Forms.DataGridView allProductsDataGridView;
        private System.Windows.Forms.TextBox inventoryQuantityTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel totalLinePanel;
        private System.Windows.Forms.TextBox supplierCityTextBox;
        private System.Windows.Forms.TextBox supplierCountryTextBox;
        private System.Windows.Forms.Button deleteProductButton;
        private System.Windows.Forms.Button saveProductButton;
        private System.Windows.Forms.Button editProductButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
