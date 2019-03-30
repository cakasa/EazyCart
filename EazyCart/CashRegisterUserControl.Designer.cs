namespace EazyCart
{
    partial class CashRegisterUserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.totalLinePanel = new System.Windows.Forms.Panel();
            this.totalLabel = new System.Windows.Forms.Label();
            this.totalToPayLabel = new System.Windows.Forms.Label();
            this.searchBoxTextBox = new System.Windows.Forms.TextBox();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.availableProductsDataGridView = new System.Windows.Forms.DataGridView();
            this.codeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiptDataGridView = new System.Windows.Forms.DataGridView();
            this.receiptProductColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountPercentageTextBox = new System.Windows.Forms.TextBox();
            this.discountCheckBox = new System.Windows.Forms.CheckBox();
            this.saveProductButton = new System.Windows.Forms.Button();
            this.editProductButton = new System.Windows.Forms.Button();
            this.addProductButton = new System.Windows.Forms.Button();
            this.cancelOrderButton = new System.Windows.Forms.Button();
            this.completeOrderButton = new System.Windows.Forms.Button();
            this.receiptNumberLabel = new System.Windows.Forms.Label();
            this.receiptNumberTextBox = new System.Windows.Forms.TextBox();
            this.deleteProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.availableProductsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // totalLinePanel
            // 
            this.totalLinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.totalLinePanel.Location = new System.Drawing.Point(406, 744);
            this.totalLinePanel.Name = "totalLinePanel";
            this.totalLinePanel.Size = new System.Drawing.Size(430, 5);
            this.totalLinePanel.TabIndex = 9;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.totalLabel.Location = new System.Drawing.Point(414, 766);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(84, 40);
            this.totalLabel.TabIndex = 10;
            this.totalLabel.Text = "Total:";
            // 
            // totalToPayLabel
            // 
            this.totalToPayLabel.AutoSize = true;
            this.totalToPayLabel.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalToPayLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.totalToPayLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.totalToPayLabel.Location = new System.Drawing.Point(503, 760);
            this.totalToPayLabel.MinimumSize = new System.Drawing.Size(330, 40);
            this.totalToPayLabel.Name = "totalToPayLabel";
            this.totalToPayLabel.Size = new System.Drawing.Size(330, 47);
            this.totalToPayLabel.TabIndex = 11;
            this.totalToPayLabel.Text = " $ 0.00";
            this.totalToPayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // searchBoxTextBox
            // 
            this.searchBoxTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchBoxTextBox.Location = new System.Drawing.Point(853, 54);
            this.searchBoxTextBox.Name = "searchBoxTextBox";
            this.searchBoxTextBox.Size = new System.Drawing.Size(729, 33);
            this.searchBoxTextBox.TabIndex = 2;
            this.searchBoxTextBox.Text = "Enter a product\'s name or its id";
            this.searchBoxTextBox.TextChanged += new System.EventHandler(this.SearchBoxTextBox_TextChanged);
            this.searchBoxTextBox.Enter += new System.EventHandler(this.SearchBoxTextBox_Enter);
            this.searchBoxTextBox.Leave += new System.EventHandler(this.SearchBoxTextBox_Leave);
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quantityTextBox.Location = new System.Drawing.Point(853, 657);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(729, 33);
            this.quantityTextBox.TabIndex = 4;
            this.quantityTextBox.Text = "Enter Quantity";
            this.quantityTextBox.Enter += new System.EventHandler(this.QuantityTextBox_Enter);
            this.quantityTextBox.Leave += new System.EventHandler(this.QuantityTextBox_Leave);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DropDownHeight = 200;
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.IntegralHeight = false;
            this.categoryComboBox.ItemHeight = 25;
            this.categoryComboBox.Items.AddRange(new object[] {
            "(none)",
            "Drinks",
            "Food",
            "Cleaning Products"});
            this.categoryComboBox.Location = new System.Drawing.Point(853, 15);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(729, 33);
            this.categoryComboBox.TabIndex = 1;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox_SelectedIndexChanged);
            // 
            // availableProductsDataGridView
            // 
            this.availableProductsDataGridView.AllowUserToAddRows = false;
            this.availableProductsDataGridView.AllowUserToDeleteRows = false;
            this.availableProductsDataGridView.AllowUserToResizeColumns = false;
            this.availableProductsDataGridView.AllowUserToResizeRows = false;
            this.availableProductsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.availableProductsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.availableProductsDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.availableProductsDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.availableProductsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.availableProductsDataGridView.ColumnHeadersHeight = 30;
            this.availableProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.availableProductsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeColumn,
            this.nameColumn,
            this.categoryTextBox,
            this.unitPriceColumn});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.availableProductsDataGridView.DefaultCellStyle = dataGridViewCellStyle12;
            this.availableProductsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.availableProductsDataGridView.EnableHeadersVisualStyles = false;
            this.availableProductsDataGridView.Location = new System.Drawing.Point(853, 93);
            this.availableProductsDataGridView.MultiSelect = false;
            this.availableProductsDataGridView.Name = "availableProductsDataGridView";
            this.availableProductsDataGridView.ReadOnly = true;
            this.availableProductsDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.availableProductsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.availableProductsDataGridView.RowHeadersWidth = 4;
            this.availableProductsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.availableProductsDataGridView.RowTemplate.Height = 30;
            this.availableProductsDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.availableProductsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.availableProductsDataGridView.Size = new System.Drawing.Size(729, 558);
            this.availableProductsDataGridView.StandardTab = true;
            this.availableProductsDataGridView.TabIndex = 3;
            // 
            // codeColumn
            // 
            this.codeColumn.HeaderText = "CODE";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "NAME";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.Width = 350;
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.HeaderText = "CATEGORY";
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.ReadOnly = true;
            this.categoryTextBox.Width = 150;
            // 
            // unitPriceColumn
            // 
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.unitPriceColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.unitPriceColumn.HeaderText = "UNIT PRICE";
            this.unitPriceColumn.Name = "unitPriceColumn";
            this.unitPriceColumn.ReadOnly = true;
            this.unitPriceColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.unitPriceColumn.Width = 130;
            // 
            // receiptDataGridView
            // 
            this.receiptDataGridView.AllowUserToAddRows = false;
            this.receiptDataGridView.AllowUserToDeleteRows = false;
            this.receiptDataGridView.AllowUserToResizeColumns = false;
            this.receiptDataGridView.AllowUserToResizeRows = false;
            this.receiptDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.receiptDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.receiptDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.receiptDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.receiptDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.receiptDataGridView.ColumnHeadersHeight = 30;
            this.receiptDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.receiptDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.receiptProductColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.quantityColumn,
            this.discountColumn,
            this.totalPriceColumn});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.receiptDataGridView.DefaultCellStyle = dataGridViewCellStyle17;
            this.receiptDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.receiptDataGridView.EnableHeadersVisualStyles = false;
            this.receiptDataGridView.Location = new System.Drawing.Point(13, 54);
            this.receiptDataGridView.MultiSelect = false;
            this.receiptDataGridView.Name = "receiptDataGridView";
            this.receiptDataGridView.ReadOnly = true;
            this.receiptDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.receiptDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.receiptDataGridView.RowHeadersWidth = 4;
            this.receiptDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.receiptDataGridView.RowTemplate.Height = 30;
            this.receiptDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.receiptDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.receiptDataGridView.Size = new System.Drawing.Size(825, 675);
            this.receiptDataGridView.TabIndex = 11;
            this.receiptDataGridView.TabStop = false;
            // 
            // receiptProductColumn
            // 
            this.receiptProductColumn.HeaderText = "RECEIPTPRODUCTID";
            this.receiptProductColumn.Name = "receiptProductColumn";
            this.receiptProductColumn.ReadOnly = true;
            this.receiptProductColumn.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "CODE";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "NAME";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 320;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle15.Format = "N2";
            dataGridViewCellStyle15.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn4.HeaderText = "UNIT PRICE";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 130;
            // 
            // quantityColumn
            // 
            this.quantityColumn.HeaderText = "QUANTITY";
            this.quantityColumn.Name = "quantityColumn";
            this.quantityColumn.ReadOnly = true;
            this.quantityColumn.Width = 90;
            // 
            // discountColumn
            // 
            this.discountColumn.HeaderText = "DISC. (%)";
            this.discountColumn.Name = "discountColumn";
            this.discountColumn.ReadOnly = true;
            this.discountColumn.Width = 90;
            // 
            // totalPriceColumn
            // 
            dataGridViewCellStyle16.Format = "N2";
            dataGridViewCellStyle16.NullValue = null;
            this.totalPriceColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.totalPriceColumn.HeaderText = "TOTAL";
            this.totalPriceColumn.Name = "totalPriceColumn";
            this.totalPriceColumn.ReadOnly = true;
            // 
            // discountPercentageTextBox
            // 
            this.discountPercentageTextBox.Enabled = false;
            this.discountPercentageTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discountPercentageTextBox.Location = new System.Drawing.Point(964, 696);
            this.discountPercentageTextBox.Name = "discountPercentageTextBox";
            this.discountPercentageTextBox.Size = new System.Drawing.Size(618, 33);
            this.discountPercentageTextBox.TabIndex = 6;
            this.discountPercentageTextBox.Text = "Enter Discount (%)";
            this.discountPercentageTextBox.Enter += new System.EventHandler(this.DiscountPercentageTextBox_Enter);
            this.discountPercentageTextBox.Leave += new System.EventHandler(this.DiscountPercentageTextBox_Leave);
            // 
            // discountCheckBox
            // 
            this.discountCheckBox.AutoSize = true;
            this.discountCheckBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discountCheckBox.Location = new System.Drawing.Point(853, 698);
            this.discountCheckBox.Name = "discountCheckBox";
            this.discountCheckBox.Size = new System.Drawing.Size(105, 29);
            this.discountCheckBox.TabIndex = 5;
            this.discountCheckBox.Text = "Discount";
            this.discountCheckBox.UseVisualStyleBackColor = true;
            this.discountCheckBox.CheckedChanged += new System.EventHandler(this.DiscountCheckBox_CheckedChanged);
            // 
            // saveProductButton
            // 
            this.saveProductButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.saveProductButton.BackgroundImage = global::EazyCart.Properties.Resources.saveProductPlaceholder;
            this.saveProductButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveProductButton.Enabled = false;
            this.saveProductButton.FlatAppearance.BorderSize = 0;
            this.saveProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveProductButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveProductButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveProductButton.Location = new System.Drawing.Point(1221, 743);
            this.saveProductButton.Name = "saveProductButton";
            this.saveProductButton.Size = new System.Drawing.Size(178, 82);
            this.saveProductButton.TabIndex = 9;
            this.saveProductButton.UseVisualStyleBackColor = false;
            this.saveProductButton.Click += new System.EventHandler(this.SaveProductButton_Click);
            // 
            // editProductButton
            // 
            this.editProductButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.editProductButton.BackgroundImage = global::EazyCart.Properties.Resources.ModifyProductPlaceHolder;
            this.editProductButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editProductButton.FlatAppearance.BorderSize = 0;
            this.editProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editProductButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editProductButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.editProductButton.Location = new System.Drawing.Point(1037, 743);
            this.editProductButton.Name = "editProductButton";
            this.editProductButton.Size = new System.Drawing.Size(178, 82);
            this.editProductButton.TabIndex = 8;
            this.editProductButton.UseVisualStyleBackColor = false;
            this.editProductButton.Click += new System.EventHandler(this.EditProductButton_Click);
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
            this.addProductButton.Location = new System.Drawing.Point(853, 743);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(178, 82);
            this.addProductButton.TabIndex = 7;
            this.addProductButton.UseVisualStyleBackColor = false;
            this.addProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // cancelOrderButton
            // 
            this.cancelOrderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.cancelOrderButton.BackgroundImage = global::EazyCart.Properties.Resources.closeIcon;
            this.cancelOrderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cancelOrderButton.FlatAppearance.BorderSize = 0;
            this.cancelOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelOrderButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.cancelOrderButton.Location = new System.Drawing.Point(350, 743);
            this.cancelOrderButton.Name = "cancelOrderButton";
            this.cancelOrderButton.Size = new System.Drawing.Size(38, 82);
            this.cancelOrderButton.TabIndex = 13;
            this.cancelOrderButton.Tag = "";
            this.cancelOrderButton.UseVisualStyleBackColor = false;
            this.cancelOrderButton.Click += new System.EventHandler(this.CancelOrderButton_Click);
            // 
            // completeOrderButton
            // 
            this.completeOrderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.completeOrderButton.BackgroundImage = global::EazyCart.Properties.Resources.completeOrderPlaceholder;
            this.completeOrderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.completeOrderButton.FlatAppearance.BorderSize = 0;
            this.completeOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.completeOrderButton.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.completeOrderButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.completeOrderButton.Location = new System.Drawing.Point(13, 743);
            this.completeOrderButton.Name = "completeOrderButton";
            this.completeOrderButton.Size = new System.Drawing.Size(337, 82);
            this.completeOrderButton.TabIndex = 12;
            this.completeOrderButton.UseVisualStyleBackColor = false;
            this.completeOrderButton.Click += new System.EventHandler(this.CompleteOrderButton_Click);
            // 
            // receiptNumberLabel
            // 
            this.receiptNumberLabel.AutoSize = true;
            this.receiptNumberLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.receiptNumberLabel.Location = new System.Drawing.Point(263, 18);
            this.receiptNumberLabel.Name = "receiptNumberLabel";
            this.receiptNumberLabel.Size = new System.Drawing.Size(97, 25);
            this.receiptNumberLabel.TabIndex = 31;
            this.receiptNumberLabel.Text = "RECEIPT #";
            // 
            // receiptNumberTextBox
            // 
            this.receiptNumberTextBox.Enabled = false;
            this.receiptNumberTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.receiptNumberTextBox.Location = new System.Drawing.Point(363, 15);
            this.receiptNumberTextBox.Name = "receiptNumberTextBox";
            this.receiptNumberTextBox.Size = new System.Drawing.Size(161, 33);
            this.receiptNumberTextBox.TabIndex = 32;
            // 
            // deleteProduct
            // 
            this.deleteProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.deleteProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deleteProduct.FlatAppearance.BorderSize = 0;
            this.deleteProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteProduct.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteProduct.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteProduct.Location = new System.Drawing.Point(1404, 743);
            this.deleteProduct.Name = "deleteProduct";
            this.deleteProduct.Size = new System.Drawing.Size(178, 82);
            this.deleteProduct.TabIndex = 10;
            this.deleteProduct.Text = "DELETE PRODUCT";
            this.deleteProduct.UseVisualStyleBackColor = false;
            this.deleteProduct.Click += new System.EventHandler(this.DeleteProduct_Click);
            // 
            // CashRegisterUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteProduct);
            this.Controls.Add(this.receiptNumberTextBox);
            this.Controls.Add(this.receiptNumberLabel);
            this.Controls.Add(this.discountCheckBox);
            this.Controls.Add(this.discountPercentageTextBox);
            this.Controls.Add(this.receiptDataGridView);
            this.Controls.Add(this.saveProductButton);
            this.Controls.Add(this.availableProductsDataGridView);
            this.Controls.Add(this.editProductButton);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.searchBoxTextBox);
            this.Controls.Add(this.addProductButton);
            this.Controls.Add(this.totalToPayLabel);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.totalLinePanel);
            this.Controls.Add(this.cancelOrderButton);
            this.Controls.Add(this.completeOrderButton);
            this.Name = "CashRegisterUserControl";
            this.Size = new System.Drawing.Size(1600, 840);
            this.Load += new System.EventHandler(this.CashRegisterUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.availableProductsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button completeOrderButton;
        private System.Windows.Forms.Button cancelOrderButton;
        private System.Windows.Forms.Panel totalLinePanel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label totalToPayLabel;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.TextBox searchBoxTextBox;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Button editProductButton;
        private System.Windows.Forms.DataGridView availableProductsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPriceColumn;
        private System.Windows.Forms.Button saveProductButton;
        private System.Windows.Forms.DataGridView receiptDataGridView;
        private System.Windows.Forms.TextBox discountPercentageTextBox;
        private System.Windows.Forms.CheckBox discountCheckBox;
        private System.Windows.Forms.Label receiptNumberLabel;
        private System.Windows.Forms.TextBox receiptNumberTextBox;
        private System.Windows.Forms.Button deleteProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiptProductColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPriceColumn;
    }
}
