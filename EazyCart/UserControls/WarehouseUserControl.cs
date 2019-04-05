using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Data.Models;
using Business;
using System.Text;
using Business.Controllers;
using EazyCart.InteractionForms;

namespace EazyCart.UserControls
{
    /// <summary>
    /// This user control is responsible for the products available for sale
    /// and their management.
    /// </summary>
    public partial class WarehouseUserControl : UserControl
    {
        private ProductBusiness productBusiness;
        private CategoryBusiness categoryBusiness;
        private SupplierBusiness supplierBusiness;
        private UnitBusiness unitBusiness;
        private CountryBusiness countryBusiness;
        private CityBusiness cityBusiness;

        private readonly Color enabledButtonColor = Color.FromArgb(44, 62, 80);
        private readonly Color disabledButtonColor = Color.FromArgb(127, 140, 141);
        private readonly Color promptTextColor = SystemColors.WindowFrame;
        private readonly Color activeTextColor = SystemColors.WindowText;
        private readonly Color enabledDeleteButtonColor = Color.FromArgb(231, 76, 60);

        public WarehouseUserControl()
        {
            InitializeComponent();
        }

        private void WarehouseUserControl_Load(object sender, EventArgs e)
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
            this.productBusiness = new ProductBusiness(eazyCartContext);
            this.categoryBusiness = new CategoryBusiness(eazyCartContext);
            this.supplierBusiness = new SupplierBusiness(eazyCartContext);
            this.unitBusiness = new UnitBusiness(eazyCartContext);
            this.countryBusiness = new CountryBusiness(eazyCartContext);
            this.cityBusiness = new CityBusiness(eazyCartContext);
            this.ClearAndUpdateProductTab();
            this.ClearAndUpdateDeliveryTab();
        }

        /// <summary>
        /// Clears and updates the product tab.
        /// </summary>
        private void ClearAndUpdateProductTab()
        {
            // Update comboBoxes 
            this.UpdateCategoryComboBox();
            this.UpdateSupplierComboBox();

            // Sets the fields for input to default values.
            this.productCodeMaskedTextBox.Text = string.Empty;
            this.productCodeMaskedTextBox.ForeColor = promptTextColor;
            this.productNameTextBox.Text = "Product Name";
            this.productNameTextBox.ForeColor = promptTextColor;
            this.inventoryQuantityTextBox.Text = "Quantity";
            this.inventoryQuantityTextBox.ForeColor = promptTextColor;
            this.deliveryPriceTextBox.Text = "Delivery Price";
            this.deliveryPriceTextBox.ForeColor = promptTextColor;
            this.sellingPriceTextBox.Text = "Selling Price";
            this.sellingPriceTextBox.ForeColor = promptTextColor;
            this.categoryComboBox.SelectedIndex = 0;
            this.supplierNameComboBox.SelectedIndex = 0;
            this.supplierCountryTextBox.Text = "Country";
            this.supplierCityTextBox.Text = "City";

            this.unitRadioButton.Checked = false;
            this.kilogramRadioButton.Checked = false;
            this.litreRadioButton.Checked = false;

            // Update other details and the data grid.
            this.CalculateNetProfit();
            this.UpdateDeliveryProductComboBox();
            this.UpdateProductDataGridView();
        }

        /// <summary>
        /// Clears and updates the make delivery tab.
        /// </summary>
        private void ClearAndUpdateDeliveryTab()
        {
            this.UpdateDeliveryProductComboBox();

            // Setting the input field values to default.
            this.deliveryQuantityTextBox.Text = "Quantity";
            this.deliveryQuantityTextBox.ForeColor = this.promptTextColor;
            this.productComboBox.SelectedIndex = 0;

            this.UpdateProductDataGridView();
        }

        /// <summary>
        /// Update the dataGridView, which displays products.
        /// </summary>
        private void UpdateProductDataGridView()
        {
            this.allProductsDataGridView.Rows.Clear();
            List<Product> allProducts = productBusiness.GetAll();

            // Inserting data into the grid.
            foreach (var product in allProducts)
            {
                var newRow = this.allProductsDataGridView.Rows[allProductsDataGridView.Rows.Add()];
                var category = this.categoryBusiness.Get(product.CategoryId);
                var unit = this.unitBusiness.Get(product.UnitId);
                var supplier = this.supplierBusiness.Get(product.SupplierId);
                newRow.Cells[0].Value = product.Code;
                newRow.Cells[1].Value = product.Name;
                newRow.Cells[2].Value = category.Name;
                newRow.Cells[3].Value = product.Quantity;
                newRow.Cells[4].Value = unit.Code;
                newRow.Cells[5].Value = supplier.Name;
                newRow.Cells[6].Value = string.Format($"${product.DeliveryPrice:f2}");
                newRow.Cells[7].Value = string.Format($"${product.SellingPrice:f2}");
            }
        }

        /// <summary>
        /// Updates the category comboBox.
        /// </summary>
        private void UpdateCategoryComboBox()
        {
            var allCategories = new List<string>();

            // Extract all category names
            allCategories.Add("Select Category");
            allCategories.AddRange(this.categoryBusiness.GetAllNames());

            this.categoryComboBox.DataSource = allCategories;
        }

        /// <summary>
        /// Updates the supplier comboBox
        /// </summary>
        private void UpdateSupplierComboBox()
        {
            var allSuppliers = new List<string>();

            //Extracts all supplier names.
            allSuppliers.Add("Select Supplier");
            allSuppliers.AddRange(this.supplierBusiness.GetAllNames());

            this.supplierNameComboBox.DataSource = allSuppliers;
        }

        /// <summary>
        /// Updates the product for delivery comboBox
        /// </summary>
        private void UpdateDeliveryProductComboBox()
        {
            var allProducts = new List<string>();

            // Extract all product names
            allProducts.Add("Select Product");
            allProducts.AddRange(this.productBusiness.GetAllNames());

            this.productComboBox.DataSource = allProducts;
        }

        /// <summary>
        /// This method is responsible for inserting the product values into
        /// the correct textBoxes when a user wants to edit a given item
        /// </summary>
        /// <param name="product"></param>
        private void UpdateProductTabFieldsOnEdit(Product product)
        {
            // Update fields with product values.
            this.productCodeMaskedTextBox.Text = product.Code;
            this.productCodeMaskedTextBox.ForeColor = activeTextColor;
            this.productNameTextBox.Text = product.Name;
            this.productNameTextBox.ForeColor = activeTextColor;
            this.inventoryQuantityTextBox.Text = product.Quantity.ToString();
            this.inventoryQuantityTextBox.ForeColor = activeTextColor;
            this.deliveryPriceTextBox.Text = string.Format($"{product.DeliveryPrice:f2}");
            this.deliveryPriceTextBox.ForeColor = activeTextColor;
            this.sellingPriceTextBox.Text = string.Format($"{product.SellingPrice:f2}");
            this.sellingPriceTextBox.ForeColor = activeTextColor;
            var category = this.categoryBusiness.Get(product.CategoryId);
            this.categoryComboBox.SelectedItem = category.Name;
            var supplier = this.supplierBusiness.Get(product.SupplierId);
            this.supplierNameComboBox.SelectedItem = supplier.Name;
            var city = this.cityBusiness.Get(supplier.CityId);
            this.supplierCityTextBox.Text = city.Name;
            var country = this.countryBusiness.Get(city.CountryId);
            this.supplierCountryTextBox.Text = country.Name;
            var unitId = product.UnitId;

            // Check the appropriate unit radioButton.
            switch (unitId)
            {
                case 1:
                    {
                        this.unitRadioButton.Checked = true;
                        break;
                    }
                case 2:
                    {
                        this.kilogramRadioButton.Checked = true;
                        break;
                    }
                case 3:
                    {
                        this.litreRadioButton.Checked = true;
                        break;
                    }
            }
        }

        /// <summary>
        /// Updates the product tab when a product is featured in a receipt.
        /// Used when a new product is added so that this is reflected in
        /// the cash register user control.
        /// </summary>
        private void UpdateCashRegisterUserControl()
        {
            var eazyCartForm = (EazyCartForm)EazyCartForm.ActiveForm;
            eazyCartForm.CashRegisterUserControl.UpdateUserControl();
        }

        // The following methods are related to user interaction with the user control.
        /// <summary>
        /// The event triggers when the supplier comboBox has a change in the 
        /// selected item. It is used to update the city and country textBoxes
        /// the supplier is said to be in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplierNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSupplier = (string)this.supplierNameComboBox.SelectedItem;

            // Displays the name of the country and city the
            // supplier is in. If no supplier is selected, displays
            // default values for city and country.
            if (selectedSupplier == "Select Supplier")
            {
                this.supplierCountryTextBox.Text = "Country";
                this.supplierCityTextBox.Text = "City";
            }
            else
            {
                string supplier = (string)this.supplierNameComboBox.SelectedItem;
                string countryName = this.countryBusiness.GetNameBySupplier(supplier);
                string cityName = this.cityBusiness.GetNameBySupplier(supplier);
                this.supplierCityTextBox.Text = cityName;
                this.supplierCountryTextBox.Text = countryName;
            }
        }

        /// <summary>
        /// This event triggers when the "Add Product" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProductButton_Click(object sender, EventArgs e)
        {
            var productCode = this.productCodeMaskedTextBox.Text;
            productCode = RefactorProductCode(productCode);
            var category = (string)this.categoryComboBox.SelectedItem;
            var productName = this.productNameTextBox.Text;
            var quantityString = this.inventoryQuantityTextBox.Text;
            var supplierName = (string)this.supplierNameComboBox.SelectedItem;
            var deliveryPriceString = this.deliveryPriceTextBox.Text;
            var sellingPriceString = this.sellingPriceTextBox.Text;
            var unit = string.Empty;

            // Check that a unit is selected.
            if (this.unitRadioButton.Checked) unit = "Unit";
            else if (this.kilogramRadioButton.Checked) unit = "Kilogram";
            else if (this.litreRadioButton.Checked) unit = "Litre";
            else
            {
                string message = "Please select an unit";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            // Add product to the database. If the validation fails, a messageBox pops up.
            try
            {
                this.CheckIfValuesAreCorrect(productCode, category, productName, quantityString, supplierName, deliveryPriceString, sellingPriceString, unit);
                var quantity = decimal.Parse(quantityString);
                var deliveryPrice = decimal.Parse(deliveryPriceString);
                var sellingPrice = decimal.Parse(sellingPriceString);
                this.productBusiness.Add(productCode, category, productName, quantity, supplierName, deliveryPrice, sellingPrice, unit);
            }
            catch (ArgumentException exc)
            {
                MessageForm messageForm = new MessageForm(exc.Message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            // Update appropriate tabs.
            this.ClearAndUpdateProductTab();
            this.UpdateCashRegisterUserControl();
        }

        /// <summary>
        /// This event triggers when the "Edit Product" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditProductButton_Click(object sender, EventArgs e)
        {
            // Try to insert values to the fields for the user to modify.
            // If a row has not been selected a messageBox is shown.
            try
            {
                // Lock ID, so the user can't intentionally change the ID.
                this.productCodeMaskedTextBox.Enabled = false;

                // Extract the item to change
                var item = this.allProductsDataGridView.SelectedRows[0].Cells;
                var productCode = (string)item[0].Value;
                var product = this.productBusiness.Get(productCode);

                // Update the fields according to the product values.
                this.UpdateProductTabFieldsOnEdit(product);
            }
            catch
            {
                string message = "You haven't selected a row";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            this.ToggleEditSave();
            this.CalculateNetProfit();
        }

        /// <summary>
        /// The event triggers when the "Save Product" button is clicked. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveProductButton_Click(object sender, EventArgs e)
        {
            var productCode = this.productCodeMaskedTextBox.Text;
            productCode = RefactorProductCode(productCode);
            var category = (string)this.categoryComboBox.SelectedItem;
            var productName = this.productNameTextBox.Text;
            var quantityString = this.inventoryQuantityTextBox.Text;
            var supplierName = (string)this.supplierNameComboBox.SelectedItem;
            var sellingPriceString = this.sellingPriceTextBox.Text;
            var deliveryPriceString = this.deliveryPriceTextBox.Text;
            var unit = string.Empty;

            // Check that a unit is selected.
            if (this.unitRadioButton.Checked) unit = "Unit";
            else if (this.kilogramRadioButton.Checked) unit = "Kilogram";
            else if (this.litreRadioButton.Checked) unit = "Litre";
            else
            {
                string message = "Please select an unit";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            // Update the given product. If the validation fails, a messageBox is shown.
            try
            {
                CheckIfValuesAreCorrect(productCode, category, productName, quantityString, supplierName, deliveryPriceString, sellingPriceString, unit);
                var quantity = decimal.Parse(quantityString);
                var deliveryPrice = decimal.Parse(deliveryPriceString);
                var sellingPrice = decimal.Parse(sellingPriceString);
                productBusiness.Update(productCode, category, productName, quantity, supplierName, deliveryPrice, sellingPrice, unit);
            }
            catch (ArgumentException exc)
            {
                MessageForm messageForm = new MessageForm(exc.Message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            this.productCodeMaskedTextBox.Enabled = true;

            // Update the appropriate tabs.
            this.ClearAndUpdateProductTab();
            this.ToggleEditSave();
            this.UpdateCashRegisterUserControl();
        }

        /// <summary>
        /// This event triggers when the "Delete Product" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            var productCode = string.Empty;

            // Validate that a row is selected. If not, a messageBox is shown.
            try
            {
                var item = this.allProductsDataGridView.SelectedRows[0].Cells;
                productCode = (string)item[0].Value;
            }
            catch
            {
                string message = "You haven't selected a row";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            // Try to delete the product. If validation fails, a messageBox is shown.
            try
            {
                this.productBusiness.Delete(productCode);
            }
            catch (ArgumentException exc)
            {
                MessageForm messageForm = new MessageForm(exc.Message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            // Update the appropriate tabs.
            this.ClearAndUpdateProductTab();
            this.UpdateCashRegisterUserControl();
        }

        /// <summary>
        /// This method is responsible for checkin whether all values are correct.
        /// In other words, it performs validation of the passed values.
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="category"></param>
        /// <param name="productName"></param>
        /// <param name="quantityString"></param>
        /// <param name="supplierName"></param>
        /// <param name="deliveryPriceString"></param>
        /// <param name="sellingPriceString"></param>
        /// <param name="unit"></param>
        private void CheckIfValuesAreCorrect(string productCode, string category, string productName, string quantityString,
            string supplierName, string deliveryPriceString, string sellingPriceString, string unit)
        {
            // Check if product code consists of digits only
            foreach (var letter in productCode)
            {
                if (!Char.IsDigit(letter))
                {
                    throw new ArgumentException("Code must have only digits!");
                }
            }

            // Check if product code has length of exactly six characters.
            if (productCode.Length != 6)
            {
                throw new ArgumentException("Code must be exactly 6 digits!");
            }

            decimal quantity = 0;
            decimal deliveryPrice = 0;
            decimal sellingPrice = 0;
            bool quantityStringCanBeParsed = decimal.TryParse(quantityString, out quantity);
            bool deliveryPriceStringCanBeParsed = decimal.TryParse(deliveryPriceString, out deliveryPrice);
            bool sellingPriceStringCanBeParsed = decimal.TryParse(sellingPriceString, out sellingPrice);

            // Validate that a category and a supplier have been selected, check that each numeric
            // value can be successfully parsed and see whether the product name is valid.
            if (category == "Select Category" || productName == "Product Name" || supplierName == "Select Supplier"
                || !quantityStringCanBeParsed || !deliveryPriceStringCanBeParsed || !sellingPriceStringCanBeParsed)
            {
                throw new ArgumentException("Invalid Values!");
            }

            // If the selected unit type is unit and quantity is not a whole number, 
            // then it is invalid and an exception needs to be thrown.
            if (quantity != Math.Floor(quantity) && unit == "Unit")
            {
                throw new ArgumentException("Quantity must be a whole number");
            }
        }

        /// <summary>
        /// The event is triggered when the make delivery button is clicked.
        /// Adds the specified amount of product to its quantity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakeDeliveryButton_Click(object sender, EventArgs e)
        {
            var productName = (string)this.productComboBox.SelectedItem;
            var quantityString = this.deliveryQuantityTextBox.Text;
            decimal quantity;
            bool canQuantityStringBeParsed = decimal.TryParse(quantityString, out quantity);

            // Perform validation of values.
            if (!canQuantityStringBeParsed || productName == "Select Product")
            {
                string message = "Invalid values";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            // Try to make the delivery, if some of the information
            // is not correctly set, a messageBox will be shown.
            try
            {
                decimal totalToPayForDelivery =  this.productBusiness.MakeDelivery(productName, quantity);
                string message = string.Format($"The delivery of {quantity:f3} x {productName} costs ${totalToPayForDelivery:f2}");
                MessageForm messageForm = new MessageForm(message, MessageFormType.Information);
                messageForm.ShowDialog();
            }
            catch (ArgumentException exc)
            {
                MessageForm messageForm = new MessageForm(exc.Message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            // Update appropriate tab.
            this.ClearAndUpdateDeliveryTab();
            this.UpdateCashRegisterUserControl();
        }

        /// <summary>
        /// The event triggers when the text in the delivery price textBox has been changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeliveryPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            decimal netProfit = this.CalculateNetProfit();
            this.netProfitAmountLabel.Text = string.Format($"${netProfit:f2}");
        }

        /// <summary>
        /// The event triggers when the text in the selling price textBox has been changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SellingPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            decimal netProfit = this.CalculateNetProfit();
            this.netProfitAmountLabel.Text = string.Format($"${netProfit:f2}");
        }

        /// <summary>
        /// This method is responsible for calculating the net profit in the event
        /// that the text in selling price or delivery price textBoxes has been
        /// changed.
        /// </summary>
        /// <returns></returns>
        private decimal CalculateNetProfit()
        {
            string deliveryPriceString = this.deliveryPriceTextBox.Text;
            string sellingPriceString = this.sellingPriceTextBox.Text;

            var deliveryPrice = 0M;
            var sellingPrice = 0M;
            bool deliveryPriceCanBeParsed = decimal.TryParse(deliveryPriceString, out deliveryPrice);
            bool sellingPriceCanBeParsed = decimal.TryParse(sellingPriceString, out sellingPrice);

            // If the value inside the textBox cannot be parsed, we return 0.
            if (!deliveryPriceCanBeParsed || !sellingPriceCanBeParsed)
            {
                return 0;
            }
            else
            {
                // Net profit is calculated by subtracting the deliveryPrice from the sellingPrice
                var netProfit = sellingPrice - deliveryPrice;
                return netProfit;
            }
        }

        public string RefactorProductCode(string productCode)
        {
            StringBuilder stringBuilder = new StringBuilder(productCode);
            for (int i = 0; i < stringBuilder.Length; i++)
            {
                if (stringBuilder[i] == ' ')
                {
                    stringBuilder[i] = '0';
                }
            }
            for (int i = stringBuilder.Length; i < 6; i++)
            {
                stringBuilder.Append('0');
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// This method is responsible for enabling/disabling the edit/save buttons
        /// when either of them is clicked.
        /// </summary>
        private void ToggleEditSave()
        {
            if (editProductButton.Enabled)
            {
                // Disable all buttons except the Save Button
                editProductButton.Enabled = false;
                editProductButton.BackColor = disabledButtonColor;
                addProductButton.Enabled = false;
                addProductButton.BackColor = disabledButtonColor;
                deleteProductButton.Enabled = false;
                deleteProductButton.BackColor = disabledButtonColor;

                saveProductButton.Enabled = true;
                saveProductButton.BackColor = enabledButtonColor;
            }
            else
            {
                // Enable all buttons and disable the Save Button
                editProductButton.Enabled = true;
                editProductButton.BackColor = enabledButtonColor;
                addProductButton.Enabled = true;
                addProductButton.BackColor = enabledButtonColor;
                deleteProductButton.Enabled = true;
                deleteProductButton.BackColor = enabledDeleteButtonColor;

                saveProductButton.Enabled = false;
                saveProductButton.BackColor = disabledButtonColor;
            }
        }

        // All of the following methods are responsible for maintaining a consistent UI
        private void ProductNameTextBox_Enter(object sender, EventArgs e)
        {
            this.RemovePromptFromTextBox(this.productNameTextBox, "Product Name");
        }

        private void ProductNameTextBox_Leave(object sender, EventArgs e)
        {
            this.AddPromptToTextBox(this.productNameTextBox, "Product Name");
        }

        private void DeliveryPriceTextBox_Enter(object sender, EventArgs e)
        {
            this.RemovePromptFromTextBox(this.deliveryPriceTextBox, "Delivery Price");
        }

        private void DeliveryPriceTextBox_Leave(object sender, EventArgs e)
        {
            this.AddPromptToTextBox(this.deliveryPriceTextBox, "Delivery Price");
        }

        private void SellingPriceTextBox_Enter(object sender, EventArgs e)
        {
            this.RemovePromptFromTextBox(this.sellingPriceTextBox, "Selling Price");
        }

        private void SellingPriceTextBox_Leave(object sender, EventArgs e)
        {
            this.AddPromptToTextBox(this.sellingPriceTextBox, "Selling Price");
        }

        private void InventoryQuantityTextBox_Enter(object sender, EventArgs e)
        {
            this.RemovePromptFromTextBox(this.inventoryQuantityTextBox, "Quantity");
        }

        private void InventoryQuantityTextBox_Leave(object sender, EventArgs e)
        {
            this.AddPromptToTextBox(this.inventoryQuantityTextBox, "Quantity");
        }

        private void DeliveryQuantityTextBox_Enter(object sender, EventArgs e)
        {
            this.RemovePromptFromTextBox(this.deliveryQuantityTextBox, "Quantity");
        }

        private void DeliveryQuantityTextBox_Leave(object sender, EventArgs e)
        {
            this.AddPromptToTextBox(this.deliveryQuantityTextBox, "Quantity");
        }

        private void ProductCodeMaskedTextBox_Enter(object sender, EventArgs e)
        {
            if (this.productCodeMaskedTextBox.Text == string.Empty)
            {
                this.productCodeMaskedTextBox.ForeColor = activeTextColor;
            }
        }

        private void ProductCodeMaskedTextBox_Leave(object sender, EventArgs e)
        {
            if (this.productCodeMaskedTextBox.Text == string.Empty)
            {
                this.productCodeMaskedTextBox.ForeColor = promptTextColor;
            }
        }

        /// <summary>
        /// This event is triggerred when one begins typing in a textBox.
        /// If the textBox had a prompt beforehand, it is removed.
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="prompt"></param>
        private void RemovePromptFromTextBox(TextBox textBox, string prompt)
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
        private void AddPromptToTextBox(TextBox textBox, string prompt)
        {
            if (textBox.Text == string.Empty)
            {
                textBox.Text = prompt;
                textBox.ForeColor = promptTextColor;
            }
        }
    }
}
