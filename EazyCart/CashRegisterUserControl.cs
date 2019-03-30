using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Data.Models;

namespace EazyCart
{
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
            UpdateUserControl();
        }

        private void UpdateUserControl()
        {
            categoryBusiness = new CategoryBusiness();
            productBusiness = new ProductBusiness();
            productReceiptBusiness = new ProductReceiptBusiness();
            receiptBusiness = new ReceiptBusiness();
            UpdateSelectProductTab();
            UpdateReceiptTab();
            highestProductReceiptId = productReceiptBusiness.GetHighestId();
            currentProductReceiptId = highestProductReceiptId + 1;
        }

        public void UpdateSelectProductTab()
        {
            UpdateCategoryComboBox();
            categoryComboBox.SelectedIndex = 0;
            searchBoxTextBox.Text = "Enter a product's name or its id";
            searchBoxTextBox.ForeColor = SystemColors.WindowFrame;
            quantityTextBox.Text = "Enter Quantity";
            quantityTextBox.ForeColor = SystemColors.WindowFrame;
            discountCheckBox.Checked = false;
            discountPercentageTextBox.Enabled = false;
            discountPercentageTextBox.Text = "Enter Discount (%)";
            discountPercentageTextBox.ForeColor = SystemColors.WindowFrame;
            UpdateAvailableProductsDataGrid(productBusiness.GetAll());
        }

        private void UpdateReceiptTab()
        {
            receiptBusiness.DeleteLastReceiptIfEmpty();
            int receiptNumber = receiptBusiness.GetNextReceiptNumber();
            receiptNumberTextBox.Text = receiptNumber.ToString();
            receiptBusiness.AddNewReceipt(receiptNumber);
            UpdateReceiptDataGridView();
        }

        private void UpdateReceiptDataGridView()
        {
            receiptDataGridView.Rows.Clear();
            List<ProductReceipt> productReceipts =
                productReceiptBusiness.GetAllByReceipt(int.Parse(receiptNumberTextBox.Text));

            decimal total = 0;
            foreach (var productReceipt in productReceipts)
            {
                DataGridViewRow row = receiptDataGridView.Rows[receiptDataGridView.Rows.Add()];
                var product = productBusiness.Get(productReceipt.ProductCode);
                decimal totalForProduct = (product.SellingPrice * productReceipt.Quantity) * (1 - 0.01M * (decimal)productReceipt.DiscountPercentage);
                row.Cells[0].Value = productReceipt.Id;
                row.Cells[1].Value = product.Code;
                row.Cells[2].Value = product.Name;
                row.Cells[3].Value = product.SellingPrice;
                row.Cells[4].Value = productReceipt.Quantity;
                row.Cells[5].Value = productReceipt.DiscountPercentage;
                row.Cells[6].Value = totalForProduct;
                total += totalForProduct;
            }
            totalToPayLabel.Text = string.Format("$ {0:f2}", total);
        }

        private void UpdateCategoryComboBox()
        {
            var categories = new List<string>();
            categories.Add("Select Category");
            categories.AddRange(categoryBusiness.GetAllNames());
            categoryComboBox.DataSource = categories;
        }

        private void UpdateSearchResults()
        {
            string categoryString = (string)categoryComboBox.Text;
            string searchPhrase = searchBoxTextBox.Text;

            if (categoryString == "Select Category" && searchPhrase == "Enter a product's name or its id")
            {
                var products = productBusiness.GetAll();
                UpdateAvailableProductsDataGrid(products);
            }
            else if (categoryString == "Select Category")
            {
                var products = productBusiness.GetAllByNameOrId(searchPhrase);
                UpdateAvailableProductsDataGrid(products);
            }
            else if (searchPhrase == "Enter a product's name or its id")
            {
                var products = productBusiness.GetAllByCategory(categoryString);
                UpdateAvailableProductsDataGrid(products);
            }
            else
            {
                var products = productBusiness.GetAllByCategoryAndNameOrId(categoryString, searchPhrase);
                UpdateAvailableProductsDataGrid(products);
            }
        }

        private void UpdateAvailableProductsDataGrid(List<Product> products)
        {
            availableProductsDataGridView.Rows.Clear();
            foreach (var product in products)
            {
                DataGridViewRow newRow = availableProductsDataGridView.Rows[availableProductsDataGridView.Rows.Add()];
                var category = categoryBusiness.Get(product.CategoryId);
                newRow.Cells[0].Value = product.Code;
                newRow.Cells[1].Value = product.Name;
                newRow.Cells[2].Value = category.Name;
                newRow.Cells[3].Value = product.SellingPrice;
            }
        }

        private void UpdateProductDataGridViewOnWarehouseUserControl()
        {
            EazyCartForm eazyCartForm = (EazyCartForm)EazyCartForm.ActiveForm;
            eazyCartForm.warehouseUserControl.UpdateProductDataGridView();
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSearchResults();
        }

        private void SearchBoxTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateSearchResults();
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            string productCode = (string)availableProductsDataGridView.SelectedRows[0].Cells[0].Value;
            string quantity = quantityTextBox.Text;
            try
            {
                string discount = "0";
                if (discountCheckBox.Checked)
                {
                    discount = discountPercentageTextBox.Text;
                }
                productReceiptBusiness.Add(currentProductReceiptId, productCode, quantity, discount);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            highestProductReceiptId++;
            currentProductReceiptId++;
            UpdateSelectProductTab();
            UpdateReceiptDataGridView();
        }

        private void EditProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = receiptDataGridView.Rows[0];
                string productCode = (string)selectedRow.Cells[1].Value;
                var product = productBusiness.Get(productCode);
                int productReceiptIndex = (int)selectedRow.Cells[0].Value;
                var productReceipt = productReceiptBusiness.Get(productReceiptIndex);
                var category = categoryBusiness.Get(product.CategoryId);
                categoryComboBox.SelectedItem = category.Name;
                searchBoxTextBox.Text = product.Name;
                searchBoxTextBox.ForeColor = SystemColors.WindowText;
                quantityTextBox.Text = productReceipt.Quantity.ToString();
                quantityTextBox.ForeColor = SystemColors.WindowText;
                if (productReceipt.DiscountPercentage != 0)
                {
                    discountCheckBox.Checked = true;
                    discountPercentageTextBox.Text = productReceipt.DiscountPercentage.ToString();
                    discountPercentageTextBox.ForeColor = SystemColors.WindowText;
                }

                currentProductReceiptId = productReceipt.Id;
            }
            catch
            {
                MessageBox.Show("You haven't selected a row");
                return;
            }
            UpdateSearchResults();
            ToggleEditSave();
        }       

        private void SaveProductButton_Click(object sender, EventArgs e)
        {
            string productCode = (string)availableProductsDataGridView.SelectedRows[0].Cells[0].Value;
            string quantity = quantityTextBox.Text;
            try
            {
                string discount = "0";
                if (discountCheckBox.Checked)
                {
                    discount = discountPercentageTextBox.Text;
                }
                productReceiptBusiness.Update(currentProductReceiptId, productCode, quantity, discount);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            UpdateSelectProductTab();
            UpdateReceiptDataGridView();
            currentProductReceiptId = highestProductReceiptId + 1;
            ToggleEditSave();
        }

        private void DeleteProduct_Click(object sender, EventArgs e)
        {
            int productReceiptId = 0;
            try
            {
                var row = receiptDataGridView.SelectedRows[0].Cells;
                productReceiptId = (int)row[0].Value;
            }
            catch
            {
                MessageBox.Show("You haven't selected a row");
                return;
            }

            try
            {
                productReceiptBusiness.Delete(productReceiptId);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            UpdateReceiptDataGridView();
        }

        private void CompleteOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                receiptBusiness.Update(int.Parse(receiptNumberTextBox.Text));
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
            UpdateSelectProductTab();
            UpdateReceiptTab();
            UpdateProductDataGridViewOnWarehouseUserControl();
        }      

        private void CancelOrderButton_Click(object sender, EventArgs e)
        {
            receiptBusiness.Delete(int.Parse(receiptNumberTextBox.Text));
            UpdateSelectProductTab();
            UpdateReceiptTab();
        }

        private void ToggleEditSave()
        {
            if (editProductButton.Enabled)
            {
                editProductButton.Enabled = false;
                editProductButton.BackColor = disabledButtonColor;

                saveProductButton.Enabled = true;
                saveProductButton.BackColor = enabledButtonColor;
            }
            else
            {
                editProductButton.Enabled = true;
                editProductButton.BackColor = enabledButtonColor;

                saveProductButton.Enabled = false;
                saveProductButton.BackColor = disabledButtonColor;
            }
        }

        // All of the following methods are connected with maintaining a clean UI
        private void DiscountCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (discountCheckBox.Checked)
            {
                discountPercentageTextBox.Enabled = true;
            }
            else discountPercentageTextBox.Enabled = false;
        }

        private void SearchBoxTextBox_Enter(object sender, EventArgs e)
        {
            RemovePromptFromTextBoxWhenTyping(searchBoxTextBox, "Enter a product's name or its id");
        }

        private void SearchBoxTextBox_Leave(object sender, EventArgs e)
        {
            AddPromptToTextBoxIfEmpty(searchBoxTextBox, "Enter a product's name or its id");
        }

        private void QuantityTextBox_Enter(object sender, EventArgs e)
        {
            RemovePromptFromTextBoxWhenTyping(quantityTextBox, "Enter Quantity");
        }

        private void QuantityTextBox_Leave(object sender, EventArgs e)
        {
            AddPromptToTextBoxIfEmpty(quantityTextBox, "Enter Quantity");
        }

        private void DiscountPercentageTextBox_Enter(object sender, EventArgs e)
        {
            RemovePromptFromTextBoxWhenTyping(discountPercentageTextBox, "Enter Discount (%)");
        }

        private void DiscountPercentageTextBox_Leave(object sender, EventArgs e)
        {
            AddPromptToTextBoxIfEmpty(discountPercentageTextBox, "Enter Discount (%)");
        }

        private void RemovePromptFromTextBoxWhenTyping(TextBox textBox, string prompt)
        {
            if (textBox.Text == prompt)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void AddPromptToTextBoxIfEmpty(TextBox textBox, string prompt)
        {
            if (textBox.Text == string.Empty)
            {
                textBox.Text = prompt;
                textBox.ForeColor = SystemColors.WindowFrame;
            }
        }
    }
}
