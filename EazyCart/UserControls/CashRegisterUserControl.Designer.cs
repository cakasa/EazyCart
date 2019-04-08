namespace EazyCart.UserControls
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.totalLinePanel = new System.Windows.Forms.Panel();
            this.grandTotalLabel = new System.Windows.Forms.Label();
            this.grandTotalCashLabel = new System.Windows.Forms.Label();
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
            this.receiptNumberLabel = new System.Windows.Forms.Label();
            this.receiptNumberTextBox = new System.Windows.Forms.TextBox();
            this.paidLabel = new System.Windows.Forms.Label();
            this.changeLabel = new System.Windows.Forms.Label();
            this.changeCashLabel = new System.Windows.Forms.Label();
            this.paidCashLabel = new System.Windows.Forms.Label();
            this.makePaymentButton = new System.Windows.Forms.Button();
            this.deleteProductButton = new System.Windows.Forms.Button();
            this.saveProductButton = new System.Windows.Forms.Button();
            this.editProductButton = new System.Windows.Forms.Button();
            this.addProductButton = new System.Windows.Forms.Button();
            this.cancelOrderButton = new System.Windows.Forms.Button();
            this.completeOrderButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.availableProductsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // totalLinePanel
            // 
            this.totalLinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.totalLinePanel.Location = new System.Drawing.Point(354, 601);
            this.totalLinePanel.Name = "totalLinePanel";
            this.totalLinePanel.Size = new System.Drawing.Size(366, 5);
            this.totalLinePanel.TabIndex = 17;
            // 
            // grandTotalLabel
            // 
            this.grandTotalLabel.AutoSize = true;
            this.grandTotalLabel.Font = new System.Drawing.Font("Segoe UI", 18.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grandTotalLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.grandTotalLabel.Location = new System.Drawing.Point(348, 612);
            this.grandTotalLabel.Name = "grandTotalLabel";
            this.grandTotalLabel.Size = new System.Drawing.Size(148, 35);
            this.grandTotalLabel.TabIndex = 18;
            this.grandTotalLabel.Text = "Grand Total:";
            // 
            // grandTotalCashLabel
            // 
            this.grandTotalCashLabel.AutoSize = true;
            this.grandTotalCashLabel.Font = new System.Drawing.Font("Segoe UI", 22.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grandTotalCashLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.grandTotalCashLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.grandTotalCashLabel.Location = new System.Drawing.Point(515, 607);
            this.grandTotalCashLabel.MinimumSize = new System.Drawing.Size(213, 34);
            this.grandTotalCashLabel.Name = "grandTotalCashLabel";
            this.grandTotalCashLabel.Size = new System.Drawing.Size(213, 41);
            this.grandTotalCashLabel.TabIndex = 19;
            this.grandTotalCashLabel.Text = " $ 0.00";
            this.grandTotalCashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // searchBoxTextBox
            // 
            this.searchBoxTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchBoxTextBox.Location = new System.Drawing.Point(738, 50);
            this.searchBoxTextBox.Name = "searchBoxTextBox";
            this.searchBoxTextBox.Size = new System.Drawing.Size(620, 29);
            this.searchBoxTextBox.TabIndex = 2;
            this.searchBoxTextBox.Text = "Enter a product\'s name or its id";
            this.searchBoxTextBox.TextChanged += new System.EventHandler(this.SearchBoxTextBox_TextChanged);
            this.searchBoxTextBox.Enter += new System.EventHandler(this.SearchBoxTextBox_Enter);
            this.searchBoxTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBoxTextBox_KeyDown);
            this.searchBoxTextBox.Leave += new System.EventHandler(this.SearchBoxTextBox_Leave);
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quantityTextBox.Location = new System.Drawing.Point(738, 563);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(620, 29);
            this.quantityTextBox.TabIndex = 4;
            this.quantityTextBox.Text = "Enter Quantity";
            this.quantityTextBox.Enter += new System.EventHandler(this.QuantityTextBox_Enter);
            this.quantityTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QuantityTextBox_KeyDown);
            this.quantityTextBox.Leave += new System.EventHandler(this.QuantityTextBox_Leave);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DropDownHeight = 200;
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.IntegralHeight = false;
            this.categoryComboBox.ItemHeight = 21;
            this.categoryComboBox.Items.AddRange(new object[] {
            "(none)",
            "Drinks",
            "Food",
            "Cleaning Products"});
            this.categoryComboBox.Location = new System.Drawing.Point(738, 15);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(620, 29);
            this.categoryComboBox.TabIndex = 1;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox_SelectedIndexChanged);
            this.categoryComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CategoryComboBox_KeyDown);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.availableProductsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.availableProductsDataGridView.ColumnHeadersHeight = 26;
            this.availableProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.availableProductsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeColumn,
            this.nameColumn,
            this.categoryTextBox,
            this.unitPriceColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.availableProductsDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.availableProductsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.availableProductsDataGridView.EnableHeadersVisualStyles = false;
            this.availableProductsDataGridView.Location = new System.Drawing.Point(738, 85);
            this.availableProductsDataGridView.MultiSelect = false;
            this.availableProductsDataGridView.Name = "availableProductsDataGridView";
            this.availableProductsDataGridView.ReadOnly = true;
            this.availableProductsDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.availableProductsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.availableProductsDataGridView.RowHeadersWidth = 4;
            this.availableProductsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.availableProductsDataGridView.RowTemplate.Height = 26;
            this.availableProductsDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.availableProductsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.availableProductsDataGridView.Size = new System.Drawing.Size(620, 472);
            this.availableProductsDataGridView.StandardTab = true;
            this.availableProductsDataGridView.TabIndex = 3;
            this.availableProductsDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AvailableProductsDataGridView_KeyDown);
            // 
            // codeColumn
            // 
            this.codeColumn.HeaderText = "CODE";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            this.codeColumn.Width = 85;
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "NAME";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.Width = 292;
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.HeaderText = "CATEGORY";
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.ReadOnly = true;
            this.categoryTextBox.Width = 127;
            // 
            // unitPriceColumn
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.unitPriceColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.unitPriceColumn.HeaderText = "UNIT PRICE";
            this.unitPriceColumn.Name = "unitPriceColumn";
            this.unitPriceColumn.ReadOnly = true;
            this.unitPriceColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.unitPriceColumn.Width = 110;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.receiptDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.receiptDataGridView.ColumnHeadersHeight = 26;
            this.receiptDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.receiptDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.receiptProductColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.quantityColumn,
            this.discountColumn,
            this.totalPriceColumn});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.receiptDataGridView.DefaultCellStyle = dataGridViewCellStyle9;
            this.receiptDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.receiptDataGridView.EnableHeadersVisualStyles = false;
            this.receiptDataGridView.Location = new System.Drawing.Point(13, 54);
            this.receiptDataGridView.MultiSelect = false;
            this.receiptDataGridView.Name = "receiptDataGridView";
            this.receiptDataGridView.ReadOnly = true;
            this.receiptDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.receiptDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.receiptDataGridView.RowHeadersWidth = 4;
            this.receiptDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.receiptDataGridView.RowTemplate.Height = 26;
            this.receiptDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.receiptDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.receiptDataGridView.Size = new System.Drawing.Size(707, 541);
            this.receiptDataGridView.TabIndex = 13;
            this.receiptDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReceiptDataGridView_KeyDown);
            // 
            // receiptProductColumn
            // 
            this.receiptProductColumn.HeaderText = "RECEIPTPRODUCTID";
            this.receiptProductColumn.Name = "receiptProductColumn";
            this.receiptProductColumn.ReadOnly = true;
            this.receiptProductColumn.Visible = false;
            this.receiptProductColumn.Width = 85;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "CODE";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 77;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "NAME";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 268;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn4.HeaderText = "UNIT PRICE";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 110;
            // 
            // quantityColumn
            // 
            dataGridViewCellStyle7.Format = "N3";
            this.quantityColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.quantityColumn.HeaderText = "QUANTITY";
            this.quantityColumn.Name = "quantityColumn";
            this.quantityColumn.ReadOnly = true;
            this.quantityColumn.Width = 81;
            // 
            // discountColumn
            // 
            this.discountColumn.HeaderText = "DISC. (%)";
            this.discountColumn.Name = "discountColumn";
            this.discountColumn.ReadOnly = true;
            this.discountColumn.Width = 80;
            // 
            // totalPriceColumn
            // 
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.totalPriceColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.totalPriceColumn.HeaderText = "TOTAL";
            this.totalPriceColumn.Name = "totalPriceColumn";
            this.totalPriceColumn.ReadOnly = true;
            this.totalPriceColumn.Width = 85;
            // 
            // discountPercentageTextBox
            // 
            this.discountPercentageTextBox.Enabled = false;
            this.discountPercentageTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discountPercentageTextBox.Location = new System.Drawing.Point(832, 594);
            this.discountPercentageTextBox.Name = "discountPercentageTextBox";
            this.discountPercentageTextBox.Size = new System.Drawing.Size(526, 29);
            this.discountPercentageTextBox.TabIndex = 6;
            this.discountPercentageTextBox.Text = "Enter Discount (%)";
            this.discountPercentageTextBox.Enter += new System.EventHandler(this.DiscountPercentageTextBox_Enter);
            this.discountPercentageTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DiscountPercentageTextBox_KeyDown);
            this.discountPercentageTextBox.Leave += new System.EventHandler(this.DiscountPercentageTextBox_Leave);
            // 
            // discountCheckBox
            // 
            this.discountCheckBox.AutoSize = true;
            this.discountCheckBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discountCheckBox.Location = new System.Drawing.Point(738, 598);
            this.discountCheckBox.Name = "discountCheckBox";
            this.discountCheckBox.Size = new System.Drawing.Size(90, 25);
            this.discountCheckBox.TabIndex = 5;
            this.discountCheckBox.Text = "Discount";
            this.discountCheckBox.UseVisualStyleBackColor = true;
            this.discountCheckBox.CheckedChanged += new System.EventHandler(this.DiscountCheckBox_CheckedChanged);
            this.discountCheckBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DiscountCheckBox_KeyDown);
            // 
            // receiptNumberLabel
            // 
            this.receiptNumberLabel.AutoSize = true;
            this.receiptNumberLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.receiptNumberLabel.Location = new System.Drawing.Point(260, 18);
            this.receiptNumberLabel.Name = "receiptNumberLabel";
            this.receiptNumberLabel.Size = new System.Drawing.Size(80, 21);
            this.receiptNumberLabel.TabIndex = 11;
            this.receiptNumberLabel.Text = "RECEIPT #";
            // 
            // receiptNumberTextBox
            // 
            this.receiptNumberTextBox.Enabled = false;
            this.receiptNumberTextBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.receiptNumberTextBox.Location = new System.Drawing.Point(343, 15);
            this.receiptNumberTextBox.Name = "receiptNumberTextBox";
            this.receiptNumberTextBox.Size = new System.Drawing.Size(161, 29);
            this.receiptNumberTextBox.TabIndex = 12;
            this.receiptNumberTextBox.TabStop = false;
            // 
            // paidLabel
            // 
            this.paidLabel.AutoSize = true;
            this.paidLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.paidLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.paidLabel.Location = new System.Drawing.Point(357, 656);
            this.paidLabel.Name = "paidLabel";
            this.paidLabel.Size = new System.Drawing.Size(94, 21);
            this.paidLabel.TabIndex = 20;
            this.paidLabel.Text = "Paid in cash:";
            // 
            // changeLabel
            // 
            this.changeLabel.AutoSize = true;
            this.changeLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.changeLabel.Location = new System.Drawing.Point(357, 678);
            this.changeLabel.Name = "changeLabel";
            this.changeLabel.Size = new System.Drawing.Size(69, 21);
            this.changeLabel.TabIndex = 22;
            this.changeLabel.Text = "Change:";
            // 
            // changeCashLabel
            // 
            this.changeCashLabel.AutoSize = true;
            this.changeCashLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeCashLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.changeCashLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.changeCashLabel.Location = new System.Drawing.Point(513, 678);
            this.changeCashLabel.MinimumSize = new System.Drawing.Size(212, 0);
            this.changeCashLabel.Name = "changeCashLabel";
            this.changeCashLabel.Size = new System.Drawing.Size(212, 21);
            this.changeCashLabel.TabIndex = 23;
            this.changeCashLabel.Text = " $ 0.00";
            this.changeCashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // paidCashLabel
            // 
            this.paidCashLabel.AutoSize = true;
            this.paidCashLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.paidCashLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.paidCashLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.paidCashLabel.Location = new System.Drawing.Point(513, 656);
            this.paidCashLabel.MinimumSize = new System.Drawing.Size(212, 0);
            this.paidCashLabel.Name = "paidCashLabel";
            this.paidCashLabel.Size = new System.Drawing.Size(212, 21);
            this.paidCashLabel.TabIndex = 21;
            this.paidCashLabel.Text = " $ 0.00";
            this.paidCashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makePaymentButton
            // 
            this.makePaymentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.makePaymentButton.BackgroundImage = global::EazyCart.Properties.Resources.makePaymentButtonImage;
            this.makePaymentButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.makePaymentButton.FlatAppearance.BorderSize = 0;
            this.makePaymentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.makePaymentButton.Font = new System.Drawing.Font("Segoe UI", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.makePaymentButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.makePaymentButton.Location = new System.Drawing.Point(13, 607);
            this.makePaymentButton.Name = "makePaymentButton";
            this.makePaymentButton.Size = new System.Drawing.Size(287, 44);
            this.makePaymentButton.TabIndex = 14;
            this.makePaymentButton.UseVisualStyleBackColor = false;
            this.makePaymentButton.Click += new System.EventHandler(this.MakePaymentButton_Click);
            // 
            // deleteProductButton
            // 
            this.deleteProductButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.deleteProductButton.BackgroundImage = global::EazyCart.Properties.Resources.deleteProductFromReceiptButtonImage;
            this.deleteProductButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deleteProductButton.FlatAppearance.BorderSize = 0;
            this.deleteProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteProductButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteProductButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteProductButton.Location = new System.Drawing.Point(1207, 634);
            this.deleteProductButton.Name = "deleteProductButton";
            this.deleteProductButton.Size = new System.Drawing.Size(151, 70);
            this.deleteProductButton.TabIndex = 10;
            this.deleteProductButton.UseVisualStyleBackColor = false;
            this.deleteProductButton.Click += new System.EventHandler(this.DeleteProduct_Click);
            this.deleteProductButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DeleteProductButton_KeyDown);
            // 
            // saveProductButton
            // 
            this.saveProductButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.saveProductButton.BackgroundImage = global::EazyCart.Properties.Resources.saveProductToReceiptButtonImage;
            this.saveProductButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveProductButton.Enabled = false;
            this.saveProductButton.FlatAppearance.BorderSize = 0;
            this.saveProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveProductButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveProductButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveProductButton.Location = new System.Drawing.Point(1050, 634);
            this.saveProductButton.Name = "saveProductButton";
            this.saveProductButton.Size = new System.Drawing.Size(151, 70);
            this.saveProductButton.TabIndex = 9;
            this.saveProductButton.UseVisualStyleBackColor = false;
            this.saveProductButton.Click += new System.EventHandler(this.SaveProductButton_Click);
            this.saveProductButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SaveProductButton_KeyDown);
            // 
            // editProductButton
            // 
            this.editProductButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.editProductButton.BackgroundImage = global::EazyCart.Properties.Resources.editProductFromReceiptButtonImage;
            this.editProductButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editProductButton.FlatAppearance.BorderSize = 0;
            this.editProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editProductButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editProductButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.editProductButton.Location = new System.Drawing.Point(895, 634);
            this.editProductButton.Name = "editProductButton";
            this.editProductButton.Size = new System.Drawing.Size(151, 70);
            this.editProductButton.TabIndex = 8;
            this.editProductButton.UseVisualStyleBackColor = false;
            this.editProductButton.Click += new System.EventHandler(this.EditProductButton_Click);
            this.editProductButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditProductButton_KeyDown);
            // 
            // addProductButton
            // 
            this.addProductButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.addProductButton.BackgroundImage = global::EazyCart.Properties.Resources.addProductToReceiptButtonImage;
            this.addProductButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addProductButton.FlatAppearance.BorderSize = 0;
            this.addProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addProductButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addProductButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addProductButton.Location = new System.Drawing.Point(738, 634);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(151, 70);
            this.addProductButton.TabIndex = 7;
            this.addProductButton.UseVisualStyleBackColor = false;
            this.addProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            this.addProductButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddProductButton_KeyDown);
            // 
            // cancelOrderButton
            // 
            this.cancelOrderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.cancelOrderButton.BackgroundImage = global::EazyCart.Properties.Resources.closeCancelIcon;
            this.cancelOrderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cancelOrderButton.FlatAppearance.BorderSize = 0;
            this.cancelOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelOrderButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.cancelOrderButton.Location = new System.Drawing.Point(298, 606);
            this.cancelOrderButton.Name = "cancelOrderButton";
            this.cancelOrderButton.Size = new System.Drawing.Size(38, 98);
            this.cancelOrderButton.TabIndex = 16;
            this.cancelOrderButton.Tag = "";
            this.cancelOrderButton.UseVisualStyleBackColor = false;
            this.cancelOrderButton.Click += new System.EventHandler(this.CancelOrderButton_Click);
            // 
            // completeOrderButton
            // 
            this.completeOrderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.completeOrderButton.BackgroundImage = global::EazyCart.Properties.Resources.completeOrderButtonImage;
            this.completeOrderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.completeOrderButton.FlatAppearance.BorderSize = 0;
            this.completeOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.completeOrderButton.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.completeOrderButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.completeOrderButton.Location = new System.Drawing.Point(13, 651);
            this.completeOrderButton.Name = "completeOrderButton";
            this.completeOrderButton.Size = new System.Drawing.Size(287, 53);
            this.completeOrderButton.TabIndex = 15;
            this.completeOrderButton.UseVisualStyleBackColor = false;
            this.completeOrderButton.Click += new System.EventHandler(this.CompleteOrderButton_Click);
            // 
            // CashRegisterUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.makePaymentButton);
            this.Controls.Add(this.deleteProductButton);
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
            this.Controls.Add(this.changeCashLabel);
            this.Controls.Add(this.paidCashLabel);
            this.Controls.Add(this.changeLabel);
            this.Controls.Add(this.grandTotalCashLabel);
            this.Controls.Add(this.paidLabel);
            this.Controls.Add(this.grandTotalLabel);
            this.Controls.Add(this.totalLinePanel);
            this.Controls.Add(this.completeOrderButton);
            this.Controls.Add(this.cancelOrderButton);
            this.Name = "CashRegisterUserControl";
            this.Size = new System.Drawing.Size(1366, 717);
            this.Load += new System.EventHandler(this.CashRegisterUserControl_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CashRegisterUserControl_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.availableProductsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button completeOrderButton;
        private System.Windows.Forms.Button cancelOrderButton;
        private System.Windows.Forms.Panel totalLinePanel;
        private System.Windows.Forms.Label grandTotalLabel;
        private System.Windows.Forms.Label grandTotalCashLabel;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.TextBox searchBoxTextBox;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Button editProductButton;
        private System.Windows.Forms.DataGridView availableProductsDataGridView;
        private System.Windows.Forms.Button saveProductButton;
        private System.Windows.Forms.DataGridView receiptDataGridView;
        private System.Windows.Forms.TextBox discountPercentageTextBox;
        private System.Windows.Forms.CheckBox discountCheckBox;
        private System.Windows.Forms.Label receiptNumberLabel;
        private System.Windows.Forms.TextBox receiptNumberTextBox;
        private System.Windows.Forms.Button deleteProductButton;
        private System.Windows.Forms.Label paidLabel;
        private System.Windows.Forms.Label changeLabel;
        private System.Windows.Forms.Label changeCashLabel;
        private System.Windows.Forms.Label paidCashLabel;
        private System.Windows.Forms.Button makePaymentButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiptProductColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPriceColumn;
    }
}
