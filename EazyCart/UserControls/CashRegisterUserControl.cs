using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Business.Controllers;
using Data.Models;
using EazyCart.InteractionForms;

namespace EazyCart.UserControls
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
        private readonly Color enabledDeleteButtonColor = Color.FromArgb(231, 76, 60);

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
        public void UpdateUserControl()
        {
            var eazyCartContext = new EazyCartContext();
            this.categoryBusiness = new CategoryBusiness(eazyCartContext);
            this.productBusiness = new ProductBusiness(eazyCartContext);
            this.productReceiptBusiness = new ProductReceiptBusiness(eazyCartContext);
            this.receiptBusiness = new ReceiptBusiness(eazyCartContext);
            this.UpdateSelectProductTab();
            this.UpdateReceiptTab();
            this.UpdatePaidAmountAndChange(0);
            this.SetButtonAvailability();
            this.highestProductReceiptId = this.productReceiptBusiness.GetHighestId();
            this.currentProductReceiptId = this.highestProductReceiptId + 1;
        }

        /// <summary>
        /// When a product is selected all fields restore their values accordingly.
        /// </summary>
        private void UpdateSelectProductTab()
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
            this.receiptBusiness.DeleteLastReceiptIfEmpty();

            var receiptNumber = this.receiptBusiness.GetNextReceiptNumber();
            this.receiptNumberTextBox.Text = receiptNumber.ToString();
            this.receiptBusiness.Add(receiptNumber);
            this.UpdateReceiptDataGridView();
        }

        /// <summary>
        /// Update the data grid for ordered products.
        /// </summary>
        private void UpdateReceiptDataGridView()
        {
            this.receiptDataGridView.Rows.Clear();
            int receiptNumber = int.Parse(this.receiptNumberTextBox.Text);
            List<ProductReceipt> productReceipts =
                this.productReceiptBusiness.GetAllByReceiptId(receiptNumber);

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
                row.Cells[3].Value = string.Format($"$ {product.SellingPrice:f2}");
                row.Cells[4].Value = productReceipt.Quantity;
                row.Cells[5].Value = productReceipt.DiscountPercentage;
                row.Cells[6].Value = string.Format($"$ {totalForProduct:f2}");
                grandTotal += totalForProduct;
            }
            this.grandTotalCashLabel.Text = string.Format("$ {0:f2}", grandTotal);
        }

        /// <summary>
        /// Sets the buttons to their default availabitilites.
        /// </summary>
        private void SetButtonAvailability()
        {
            this.makePaymentButton.Enabled = true;
            this.makePaymentButton.BackColor = enabledButtonColor;
            this.completeOrderButton.Enabled = false;
            this.completeOrderButton.BackColor = disabledButtonColor;
            this.addProductButton.Enabled = true;
            this.addProductButton.BackColor = enabledButtonColor;
            this.editProductButton.Enabled = true;
            this.editProductButton.BackColor = enabledButtonColor;
            this.deleteProductButton.Enabled = true;
            this.deleteProductButton.BackColor = enabledDeleteButtonColor;

            this.saveProductButton.Enabled = false;
            this.saveProductButton.BackColor = disabledButtonColor;
        }

        /// <summary>
        /// Calls several methods related to updating comboBoxes,
        /// when the category tab is updated.
        /// </summary>
        private void UpdateCategoryComboBox()
        {
            var categories = new List<string>();

            // Extract all category names
            categories.Add("Select Category");
            categories.AddRange(this.categoryBusiness.GetAllNames());

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
        /// Update the paid amount and change labels when a payment has been made.
        /// </summary>
        private void UpdatePaidAmountAndChange(decimal paidAmount)
        {
            decimal grandTotal = decimal.Parse(this.grandTotalCashLabel.Text.Remove(0, 2));
            decimal change = paidAmount - grandTotal;
            this.paidCashLabel.Text = string.Format($"$ {paidAmount:f2}");
            this.changeCashLabel.Text = string.Format($"$ {change:f2}");
        }

        /// <summary>
        /// Populate the search results into the dataGrid for available products.
        /// </summary>
        /// <param name="products">List of products to update the data grid view with.</param>
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
                newRow.Cells[3].Value = string.Format($"$ {product.SellingPrice:f2}");
            }
        }

        /// <summary>
        /// Updates the product data grid when a quantity has been added to the receipt.
        /// </summary>
        private void UpdateProductDataGridViewOnWarehouseUserControl()
        {
            var eazyCartForm = (EazyCartForm)EazyCartForm.ActiveForm;
            eazyCartForm.WarehouseUserControl.UpdateUserControl();
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
            string productCode = string.Empty;
            try
            {
                productCode = (string)availableProductsDataGridView.SelectedRows[0].Cells[0].Value;
            }
            catch
            {
                MessageForm messageForm = new MessageForm("You haven't selected a row!", MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }
            var quantity = this.quantityTextBox.Text;

            // Try to add product into the receipt. If validation fails, a messageForm is shown.
            try
            {
                var discount = "0";
                if (this.discountCheckBox.Checked)
                {
                    discount = this.discountPercentageTextBox.Text;
                }
                this.productReceiptBusiness.Add(currentProductReceiptId, productCode, quantity, discount);
            }
            catch (ArgumentException exc)
            {
                MessageForm messageForm = new MessageForm(exc.Message, MessageFormType.Error);
                messageForm.ShowDialog();
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
                var category = this.categoryBusiness.Get(product.CategoryId);

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

                this.currentProductReceiptId = productReceipt.Id;
            }
            catch
            {
                string message = "You haven't selected a row";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            // Update appropriate tabs.
            this.UpdateSearchResults();
            this.ToggleEditSave(this.editProductButton, this.saveProductButton, 
                        this.addProductButton, this.deleteProductButton);
        }

        /// <summary>
        /// The event triggers when the user clicks on the "Save Product" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveProductButton_Click(object sender, EventArgs e)
        {
            string productCode = string.Empty;
            try
            {
                productCode = (string)availableProductsDataGridView.SelectedRows[0].Cells[0].Value;
            }
            catch
            {
                MessageForm messageForm = new MessageForm("You haven't selected a row!", MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }
            var quantity = this.quantityTextBox.Text;

            // Check if needed values have been entered.
            try
            {
                var discount = "0";
                if (this.discountCheckBox.Checked)
                {
                    discount = this.discountPercentageTextBox.Text;
                }
                this.productReceiptBusiness.Update(this.currentProductReceiptId, productCode, quantity, discount);
            }
            catch (ArgumentException exc)
            {
                MessageForm messageForm = new MessageForm(exc.Message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            // Update the appropriate tabs.
            this.UpdateSelectProductTab();
            this.UpdateReceiptDataGridView();
            this.currentProductReceiptId = highestProductReceiptId + 1;
            this.ToggleEditSave(this.editProductButton, this.saveProductButton, 
                        this.addProductButton, this.deleteProductButton);
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
                string message = "You haven't selected a row";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            try
            {
                this.productReceiptBusiness.Delete(productReceiptId);
            }
            catch (ArgumentException exc)
            {
                MessageForm messageForm = new MessageForm(exc.Message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            // Update the appropriate tabs.
            this.UpdateReceiptDataGridView();
        }

        /// <summary>
        /// This event triggers when the user clicks on the "Make Payment" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakePaymentButton_Click(object sender, EventArgs e)
        {
            var grandTotal = decimal.Parse(this.grandTotalCashLabel.Text.Remove(0, 2));
            var payForm = new PayForm(grandTotal);
            payForm.Show();
            payForm.VisibleChanged += this.PayFormVisibleChanged;          
        }

        /// <summary>
        /// This event is triggered when the pay form changes its visible state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayFormVisibleChanged(object sender, EventArgs e)
        {
            var payForm = (PayForm)sender;
            if (!payForm.Visible)
            {
                decimal paidAmount = payForm.enteredAmount;
                UpdatePaidAmountAndChange(paidAmount);
                payForm.Dispose();
            }

            this.DisableAllButtonsToCompleteAnOrder();
        }

        /// <summary>
        /// Disables all buttons when the user is about to complete an order
        /// </summary>
        public void DisableAllButtonsToCompleteAnOrder()
        {
            this.addProductButton.Enabled = false;
            this.editProductButton.Enabled = false;
            this.saveProductButton.Enabled = false;
            this.deleteProductButton.Enabled = false;
            this.makePaymentButton.Enabled = false;
            this.addProductButton.BackColor = this.disabledButtonColor;
            this.editProductButton.BackColor = this.disabledButtonColor;
            this.saveProductButton.BackColor = this.disabledButtonColor;
            this.deleteProductButton.BackColor = this.disabledButtonColor;
            this.makePaymentButton.BackColor = this.disabledButtonColor;

            this.completeOrderButton.Enabled = true;
            this.completeOrderButton.BackColor = this.enabledButtonColor;
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
                var receiptNumber = int.Parse(this.receiptNumberTextBox.Text);
                this.receiptBusiness.Update(int.Parse(this.receiptNumberTextBox.Text));
            }
            catch (ArgumentException exc)
            {
                MessageForm messageForm = new MessageForm(exc.Message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            // Update the appropriate tabs.
            this.UpdateSelectProductTab();
            this.UpdateReceiptTab();
            this.SetButtonAvailability();
            this.UpdatePaidAmountAndChange(0);
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
            this.UpdatePaidAmountAndChange(0);
            this.SetButtonAvailability();
        }

        /// <summary>
        /// This method is tasked with enabling/disabling buttons when the Edit/Save buttons are clicked.
        /// </summary>
        /// <param name="editButton">Edit button.</param>
        /// <param name="saveButton">Save button.</param>
        /// <param name="addButton">Add button.</param>
        /// <param name="deleteButton">Delete button.</param>
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
                this.makePaymentButton.Enabled = false;
                this.makePaymentButton.BackColor = disabledButtonColor;

                saveButton.Enabled = true;
                saveButton.BackColor = enabledButtonColor;
            }
            else
            {
                // Enable all buttons and disable the Save Button.
                this.editProductButton.Enabled = true;
                this.editProductButton.BackColor = enabledButtonColor;
                addButton.Enabled = true;
                addButton.BackColor = enabledButtonColor;
                deleteButton.Enabled = true;
                deleteButton.BackColor = enabledDeleteButtonColor;
                this.makePaymentButton.Enabled = true;
                this.makePaymentButton.BackColor = enabledButtonColor;

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

        // The following methods are connected with implementing shortcuts
        private void CashRegisterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            this.InterpretShortcut(e);
        }

        private void CategoryComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.InterpretShortcut(e);
        }

        private void SearchBoxTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.InterpretShortcut(e);
        }

        private void AvailableProductsDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            this.InterpretShortcut(e);
        }

        private void QuantityTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.InterpretShortcut(e);
        }

        private void DiscountCheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.InterpretShortcut(e);
        }

        private void DiscountPercentageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.InterpretShortcut(e);
        }

        private void AddProductButton_KeyDown(object sender, KeyEventArgs e)
        {
            this.InterpretShortcut(e);
        }

        private void EditProductButton_KeyDown(object sender, KeyEventArgs e)
        {
            this.InterpretShortcut(e);
        }

        private void SaveProductButton_KeyDown(object sender, KeyEventArgs e)
        {
            this.InterpretShortcut(e);
        }

        private void DeleteProductButton_KeyDown(object sender, KeyEventArgs e)
        {
            this.InterpretShortcut(e);
        }

        private void ReceiptDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            this.InterpretShortcut(e);
        }

        /// <summary>
        /// This method interprets the key that was pressed if it corresponds
        /// to a shortcut key.
        /// </summary>
        /// <param name="e"></param>
        private void InterpretShortcut(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && this.addProductButton.Enabled == true)
            {
                this.AddProductButton_Click(this, new EventArgs());
                this.searchBoxTextBox.Focus();
            }
            if(e.KeyData == Keys.F7 && this.editProductButton.Enabled == true)
            {
                this.EditProductButton_Click(this, new EventArgs());
                this.quantityTextBox.Focus();
            }
            if(e.KeyData == Keys.F8 && this.saveProductButton.Enabled == true)
            {
                this.SaveProductButton_Click(this, new EventArgs());
                this.searchBoxTextBox.Focus();
            }
            if(e.KeyData == Keys.Delete && this.deleteProductButton.Enabled == true)
            {
                this.DeleteProduct_Click(this, new EventArgs());
                this.searchBoxTextBox.Focus();
            }
            if(e.KeyData == Keys.F5)
            {
                if(makePaymentButton.Enabled == true)
                {
                    this.MakePaymentButton_Click(this, new EventArgs());
                    this.completeOrderButton.Focus();
                }
                else if(completeOrderButton.Enabled == true)
                {
                    this.CompleteOrderButton_Click(this, new EventArgs());
                    this.searchBoxTextBox.Focus();
                }
            }
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
        /// <param name="textBox">Text box from which to remove the prompt.</param>
        /// <param name="prompt">Prompt to remove from the text box.</param>
        private void RemovePromptFromTextBoxWhenTyping(TextBox textBox, string prompt)
        {
            if (textBox.Text == prompt)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = this.activeTextColor;
            }
        }

        /// <summary>
        /// This event is triggered when one stops typing in a textBox.
        /// If the textBox was left empty, a prompt, suitable for the textbox, would be added.
        /// </summary>
        /// <param name="textBox">Text box from which to add the prompt.</param>
        /// <param name="prompt">Prompt to add to the text box.</param>
        private void AddPromptToTextBoxIfEmpty(TextBox textBox, string prompt)
        {
            if (textBox.Text == string.Empty)
            {
                textBox.Text = prompt;
                textBox.ForeColor = this.promptTextColor;
            }
        }
    }
}
