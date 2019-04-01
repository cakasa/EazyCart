using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Business;
using Data.Models;

namespace EazyCart
{
    /// <summary>
    /// This is the user control responsible for managing orders 
    /// </summary>
    public partial class CashRegisterUserControl : UserControl
    {
        private CategoryBusiness categoryBusiness;
        private ProductBusiness productBusiness;
        private ProductReceiptBusiness productReceiptBusiness;
        private ReceiptBusiness receiptBusiness;

        private readonly Color enabledButtonColor = Color.FromArgb(44, 62, 80);
        private readonly Color disabledButtonColor = Color.FromArgb(127, 140, 141);
        private readonly Color promptTextColor = SystemColors.WindowFrame;
        private readonly Color activeTextColor = SystemColors.WindowText;

        private int highestProductReceiptId;
        private int currentProductReceiptId;

        public CashRegisterUserControl()
        {
            InitializeComponent();
        }

        private void CashRegisterUserControl_Load(object sender, EventArgs e)
        {
            this.UpdateUserControl();
        }

        // The following methods are responsible for updating information when it is changed.
        /// <summary>
        /// Updates the user control every time it is loaded.
        /// </summary>
        private void UpdateUserControl()
        {
            this.categoryBusiness = new CategoryBusiness();
            this.productBusiness = new ProductBusiness();
            this.productReceiptBusiness = new ProductReceiptBusiness();
            this.receiptBusiness = new ReceiptBusiness();
            this.UpdateSelectProductTab();
            this.UpdateReceiptTab();
            this.highestProductReceiptId = productReceiptBusiness.GetHighestId();
            this.currentProductReceiptId = highestProductReceiptId + 1;
        }

        /// <summary>
        /// When a product is selected all fields restore their values accordingly.
        /// </summary>
        public void UpdateSelectProductTab()
        {
            this.UpdateCategoryComboBox();
            this.categoryComboBox.SelectedIndex = 0;
            this.searchBoxTextBox.Text = "Enter a product's name or its id";
            this.searchBoxTextBox.ForeColor = promptTextColor;
            this.quantityTextBox.Text = "Enter Quantity";
            this.quantityTextBox.ForeColor = promptTextColor;
            this.discountCheckBox.Checked = false;
            this.discountPercentageTextBox.Enabled = false;
            this.discountPercentageTextBox.Text = "Enter Discount (%)";
            this.discountPercentageTextBox.ForeColor = promptTextColor;
            this.UpdateAvailableProductsDataGrid(this.productBusiness.GetAll());
        }

        /// <summary>
        /// Updates the tabs related to receipt when a new / modified order occurs.
        /// </summary>
        private void UpdateReceiptTab()
        {
            // Deletes the last receipt, when the program is launched.
            this.receiptBusiness.DeleteLastReceiptIfEmpty();

            var receiptNumber = this.receiptBusiness.GetNextReceiptNumber();
            this.receiptNumberTextBox.Text = receiptNumber.ToString();
            this.receiptBusiness.AddNewReceipt(receiptNumber);
            this.UpdateReceiptDataGridView();
        }

        /// <summary>
        /// Update the data grid for ordered products.
        /// </summary>
        /// <param name="products"></param>
        private void UpdateReceiptDataGridView()
        {
            this.receiptDataGridView.Rows.Clear();
            int receiptNumber = int.Parse(this.receiptNumberTextBox.Text);
            List<ProductReceipt> productReceipts =
                this.productReceiptBusiness.GetAllByReceipt(receiptNumber);

            // Populate the receipt dataGridView.
            decimal grandTotal = 0;
            foreach (var productReceipt in productReceipts)
            {
                var row = this.receiptDataGridView.Rows[receiptDataGridView.Rows.Add()];
                var product = this.productBusiness.Get(productReceipt.ProductCode);
                decimal basePrice = product.SellingPrice * productReceipt.Quantity;
                decimal percentageOfBasePrice = 1 - 0.01M * (decimal)productReceipt.DiscountPercentage;
                decimal totalForProduct = basePrice * percentageOfBasePrice;
                row.Cells[0].Value = productReceipt.Id;
                row.Cells[1].Value = product.Code;
                row.Cells[2].Value = product.Name;
                row.Cells[3].Value = product.SellingPrice;
                row.Cells[4].Value = productReceipt.Quantity;
                row.Cells[5].Value = productReceipt.DiscountPercentage;
                row.Cells[6].Value = totalForProduct;
                grandTotal += totalForProduct;
            }
            grandTotalLabel.Text = string.Format("$ {0:f2}", grandTotal);
        }

        /// <summary>
        /// Calls several methods related to updating comboBoxes, when the category tab is updated.
        /// </summary>
        private void UpdateCategoryComboBox()
        {
            var categories = new List<string>();

            // Extract all category names
            categories.Add("Select Category");
            categories.AddRange(categoryBusiness.GetAllNames());

            this.categoryComboBox.DataSource = categories;
        }

        /// <summary>
        /// Display search matches.
        /// </summary>
        private void UpdateSearchResults()
        {
            var categoryString = this.categoryComboBox.Text;
            var searchPhrase = this.searchBoxTextBox.Text;

            // Search by the certain chosen information type.
            if (categoryString == "Select Category" && searchPhrase == "Enter a product's name or its id")
            {
                var products = this.productBusiness.GetAll();
                this.UpdateAvailableProductsDataGrid(products);
            }
            else if (categoryString == "Select Category")
            {
                var products = this.productBusiness.GetAllByNameOrId(searchPhrase);
                this.UpdateAvailableProductsDataGrid(products);
            }
            else if (searchPhrase == "Enter a product's name or its id")
            {
                var products = this.productBusiness.GetAllByCategory(categoryString);
                this.UpdateAvailableProductsDataGrid(products);
            }
            else
            {
                var products = this.productBusiness.GetAllByCategoryAndNameOrId(categoryString, searchPhrase);
                this.UpdateAvailableProductsDataGrid(products);
            }
        }

        /// <summary>
        /// Populate the search results into the dataGrid for available products.
        /// </summary>
        /// <param name="products"></param>
        private void UpdateAvailableProductsDataGrid(List<Product> products)
        {
            this.availableProductsDataGridView.Rows.Clear();
            foreach (var product in products)
            {
                var newRow = this.availableProductsDataGridView.Rows[this.availableProductsDataGridView.Rows.Add()];
                var category = this.categoryBusiness.Get(product.CategoryId);
                newRow.Cells[0].Value = product.Code;
                newRow.Cells[1].Value = product.Name;
                newRow.Cells[2].Value = category.Name;
                newRow.Cells[3].Value = product.SellingPrice;
            }
        }

        /// <summary>
        /// Updates the product data grid when a quantity has been added to the receipt.
        /// </summary>
        private void UpdateProductDataGridViewOnWarehouseUserControl()
        {
            var eazyCartForm = (EazyCartForm)EazyCartForm.ActiveForm;
            eazyCartForm.warehouseUserControl.UpdateProductDataGridView();
        }

        /// <summary>
        /// This event triggers the UpdateSearchResults() due to a change in the selected index
        /// of the category comboBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateSearchResults();
        }

        /// <summary>
        /// This event triggers the UpdateSearchResults() due to a change in the text
        /// of the searchBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBoxTextBox_TextChanged(object sender, EventArgs e)
        {
            this.UpdateSearchResults();
        }

        /// <summary>
        /// The event triggers when the user clicks on the "Add Product" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProductButton_Click(object sender, EventArgs e)
        {
            var productCode = (string)availableProductsDataGridView.SelectedRows[0].Cells[0].Value;
            var quantity = quantityTextBox.Text;

            // Try to add product into the receipt. If validation fails, a messageBox is shown.
            try
            {
                var discount = "0";
                if (this.discountCheckBox.Checked)
                {
                    discount = discountPercentageTextBox.Text;
                }
                this.productReceiptBusiness.Add(currentProductReceiptId, productCode, quantity, discount);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            this.highestProductReceiptId++;
            this.currentProductReceiptId++;

            // Update appropriate tabs.
            this.UpdateSelectProductTab();
            this.UpdateReceiptDataGridView();
        }

        /// <summary>
        /// The event triggers when the user clicks on the "Modify Product" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Take the necessary information.
                var selectedRow = this.receiptDataGridView.SelectedRows[0];
                var productCode = (string)selectedRow.Cells[1].Value;
                var product = this.productBusiness.Get(productCode);
                var productReceiptIndex = (int)selectedRow.Cells[0].Value;
                var productReceipt = this.productReceiptBusiness.Get(productReceiptIndex);
                var category = categoryBusiness.Get(product.CategoryId);

                // Update textBoxes so that they display correct information.
                this.categoryComboBox.SelectedItem = category.Name;
                this.searchBoxTextBox.Text = product.Name;
                this.searchBoxTextBox.ForeColor = activeTextColor;
                this.quantityTextBox.Text = productReceipt.Quantity.ToString();
                this.quantityTextBox.ForeColor = activeTextColor;
                if (productReceipt.DiscountPercentage != 0)
                {
                    this.discountCheckBox.Checked = true;
                    this.discountPercentageTextBox.Text = productReceipt.DiscountPercentage.ToString();
                    this.discountPercentageTextBox.ForeColor = activeTextColor;
                }

                currentProductReceiptId = productReceipt.Id;
            }
            catch
            {
                MessageBox.Show("You haven't selected a row");
                return;
            }

            // Update appropriate tabs.
            this.UpdateSearchResults();
            this.ToggleEditSave(editProductButton, saveProductButton, addProductButton, deleteProductButton);
        }       

        /// <summary>
        /// The event triggers when the user clicks on the "Save Product" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveProductButton_Click(object sender, EventArgs e)
        {
            var productCode = (string)this.availableProductsDataGridView.SelectedRows[0].Cells[0].Value;
            var quantity = quantityTextBox.Text;

            // Check if needed values have been entered.
            try
            {
                var discount = "0";
                if (this.discountCheckBox.Checked)
                {
                    discount = this.discountPercentageTextBox.Text;
                }
                this.productReceiptBusiness.Update(currentProductReceiptId, productCode, quantity, discount);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            // Update the appropriate tabs.
            this.UpdateSelectProductTab();
            this.UpdateReceiptDataGridView();
            this.currentProductReceiptId = highestProductReceiptId + 1;
            this.ToggleEditSave(editProductButton, saveProductButton, addProductButton, deleteProductButton);
        }

        /// <summary>
        /// The event triggers when the user clicks on the "Delete product" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteProduct_Click(object sender, EventArgs e)
        {
            var productReceiptId = 0;

            // Check if a row is selected.
            try
            {
                var row = this.receiptDataGridView.SelectedRows[0].Cells;
                productReceiptId = (int)row[0].Value;
            }
            catch
            {
                MessageBox.Show("You haven't selected a row");
                return;
            }

            try
            {
                this.productReceiptBusiness.Delete(productReceiptId);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            // Update the appropriate tabs.
            this.UpdateReceiptDataGridView();
        }

        /// <summary>
        /// The event triggers when the user clicks on the "Complete Order" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteOrderButton_Click(object sender, EventArgs e)
        {
            // Try to update the product in the receipt. If validation fails,
            // a messageBox is shown.
            try
            {
                var receiptNumber = int.Parse(receiptNumberTextBox.Text);
                this.receiptBusiness.Update(int.Parse(receiptNumberTextBox.Text));
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            // Update the appropriate tabs.
            this.UpdateSelectProductTab();
            this.UpdateReceiptTab();
            this.UpdateProductDataGridViewOnWarehouseUserControl();
        }      

        /// <summary>
        /// The event triggers when the user clicks on the "Cancel Order" button.
        /// </summary> 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelOrderButton_Click(object sender, EventArgs e)
        {
            var receiptNumber = int.Parse(this.receiptNumberTextBox.Text);
            this.receiptBusiness.Delete(receiptNumber);

            // Update the appropriate tabs.
            this.UpdateSelectProductTab();
            this.UpdateReceiptTab();
        }

        /// <summary>
        /// This method is tasked with enabling/disabling buttons when the Edit/Save buttons are clicked.
        /// </summary>
        /// <param name="editButton"></param>
        /// <param name="saveButton"></param>
        /// <param name="addButton"></param>
        /// <param name="deleteButton"></param>
        private void ToggleEditSave(Button editButton, Button saveButton, Button addButton, Button deleteButton)
        {
            if (this.editProductButton.Enabled)
            {
                // Disable all buttons except the Save Button.
                editButton.Enabled = false;
                editButton.BackColor = disabledButtonColor;
                addButton.Enabled = false;
                addButton.BackColor = disabledButtonColor;
                deleteButton.Enabled = false;
                deleteButton.BackColor = disabledButtonColor;

                saveButton.Enabled = true;
                saveButton.BackColor = enabledButtonColor;
            }
            else
            {
                // Enable all buttons and disable the Save Button.
                editProductButton.Enabled = true;
                editProductButton.BackColor = enabledButtonColor;
                addButton.Enabled = true;
                addButton.BackColor = enabledButtonColor;
                deleteButton.Enabled = true;
                deleteButton.BackColor = enabledButtonColor;

                saveButton.Enabled = false;
                saveButton.BackColor = disabledButtonColor;
            }
        }

        /// <summary>
        /// The event triggers when the discount checkBox has changed its checked state.
        /// Used to enable/disable the discountPercentageTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiscountCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.discountCheckBox.Checked)
            {
                this.discountPercentageTextBox.Enabled = true;
            }
            else this.discountPercentageTextBox.Enabled = false;
        }
        // All of the following methods are connected with maintaining a clean UI.
        
        private void SearchBoxTextBox_Enter(object sender, EventArgs e)
        {
            this.RemovePromptFromTextBoxWhenTyping(this.searchBoxTextBox, "Enter a product's name or its id");
        }

        private void SearchBoxTextBox_Leave(object sender, EventArgs e)
        {
            this.AddPromptToTextBoxIfEmpty(this.searchBoxTextBox, "Enter a product's name or its id");
        }

        private void QuantityTextBox_Enter(object sender, EventArgs e)
        {
            this.RemovePromptFromTextBoxWhenTyping(this.quantityTextBox, "Enter Quantity");
        }

        private void QuantityTextBox_Leave(object sender, EventArgs e)
        {
            this.AddPromptToTextBoxIfEmpty(this.quantityTextBox, "Enter Quantity");
        }

        private void DiscountPercentageTextBox_Enter(object sender, EventArgs e)
        {
            this.RemovePromptFromTextBoxWhenTyping(this.discountPercentageTextBox, "Enter Discount (%)");
        }

        private void DiscountPercentageTextBox_Leave(object sender, EventArgs e)
        {
            this.AddPromptToTextBoxIfEmpty(this.discountPercentageTextBox, "Enter Discount (%)");
        }

        /// <summary>
        /// This event is triggerred when one begins typing in a textBox.
        /// If the textBox had a prompt beforehand, it is removed.
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="prompt"></param>
        private void RemovePromptFromTextBoxWhenTyping(TextBox textBox, string prompt)
        {
            if (textBox.Text == prompt)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = activeTextColor;
            }
        }

        /// <summary>
        /// This event is triggered when one stops typing in a textBox.
        /// If the textBox was left empty, a prompt, suitable for the textbox, would be added.
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="prompt"></param>
        private void AddPromptToTextBoxIfEmpty(TextBox textBox, string prompt)
        {
            if (textBox.Text == string.Empty)
            {
                textBox.Text = prompt;
                textBox.ForeColor = promptTextColor;
            }
        }
    }
}
