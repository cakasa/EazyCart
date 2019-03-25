using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Models;
using Data;
using Business;

namespace EazyCart
{
    public partial class WarehouseUserControl : UserControl
    {
        private ProductBusiness productBusiness = new ProductBusiness();
        private CategoryBusiness categoryBusiness = new CategoryBusiness();
        private SupplierBusiness supplierBusiness = new SupplierBusiness();
        private UnitBusiness unitBusiness = new UnitBusiness();
        private CountryBusiness countryBusiness = new CountryBusiness();
        private CityBusiness cityBusiness = new CityBusiness();

        public WarehouseUserControl()
        {
            InitializeComponent();
        }

        private void WarehouseUserControl_Load(object sender, EventArgs e)
        {
            SetInitialState();
            UpdateCategoryComboBox();
            UpdateSupplierComboBox();
            UpdateProductTab();
        }

        private void SetInitialState()
        {
            //categoryComboBox.SelectedItem = categoryComboBox.Items[0];
            //supplierCityComboBox.SelectedItem = supplierCityComboBox.Items[0];
            //supplierCountryComboBox.SelectedItem = supplierCountryComboBox.Items[0];
            //supplierNameComboBox.SelectedItem = supplierNameComboBox.Items[0];
            //productComboBox.SelectedItem = productComboBox.Items[0];
        }

        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            var category = new Category();
            var categoryToAdd = categoryComboBox.Text;

            if (categoryBusiness.GetAllNames().Contains(categoryToAdd))
            {
                MessageBox.Show($"There already is a category named {categoryToAdd}");
            }
            category.Name = categoryToAdd;
            categoryBusiness.Add(category);
            UpdateForm();
        }

        private void AddCountryButton_Click(object sender, EventArgs e)
        {
            //var country = new Country();
            //string countryToAdd = supplierCountryComboBox.Text;
            //if (countryBusiness.GetAllNames().Contains(countryToAdd))
            //{
            //    MessageBox.Show($"There already is a country called {countryToAdd}");
            //    return;
            //}
            //country.Name = countryToAdd;
            //countryBusiness.Add(country);
            //UpdateForm();
        }

        private void AddCityButton_Click(object sender, EventArgs e)
        {
            //var city = new City();
            //string cityToAdd = supplierCityComboBox.Text;
            //string selectedCountryString = supplierCountryComboBox.Text;
            //Country selectedCountry = countryBusiness.GetByName(selectedCountryString);
            //var existingCitiesInSelectedCountry = cityBusiness.GetAll().Where(x => x.CountryId == selectedCountry.Id);

            //// TODO: Fix the if, country always showing it has 0 cities.
            //if (existingCitiesInSelectedCountry.Any(x => x.Name == cityToAdd))
            //{
            //    MessageBox.Show($"There already is a city called {cityToAdd} in {selectedCountryString}");
            //    return;
            //}

            //city.Name = cityToAdd;
            //city.CountryId = selectedCountry.Id;
            //cityBusiness.Add(city);  
            //UpdateForm();
        }

        private void AddSupplierButton_Click(object sender, EventArgs e)
        {
            //var supplier = new Supplier();
            //string supplierToAdd = supplierNameComboBox.Text;
            //string selectedCityString = supplierCityComboBox.Text;
            //string selectedCountryString = supplierCountryComboBox.Text;
            //Country selectedCountry = countryBusiness.GetByName(selectedCountryString);
            //City selectedCity = cityBusiness.GetByCountryAndName(selectedCountry, selectedCityString);
            //var existingSuppliersInSelectedCity = supplierBusiness.GetAll().Where(x => x.CityId == selectedCity.Id);

            //if(existingSuppliersInSelectedCity.Any(x=>x.Name == supplierToAdd))
            //{
            //    MessageBox.Show($"There already is a supplier called {supplierToAdd} in city {selectedCityString}");
            //    return;
            //}

            //supplier.Name = supplierToAdd;
            //supplier.CityId = selectedCity.Id;
            //supplierBusiness.Add(supplier);
            //UpdateForm();
        }

        private void UpdateForm()
        {
            //categoryComboBox.DataSource = categoryBusiness.GetAllNames();
            //supplierNameComboBox.DataSource = supplierBusiness.GetAllNames();
            //supplierCountryComboBox.DataSource = countryBusiness.GetAllNames();
            //supplierCityComboBox.DataSource = cityBusiness.GetAllNames();
            //productComboBox.DataSource = productBusiness.GetAllNames();
            //UpdateDataGrid();
        }

        // All of the following methods are responsible for maintaining a consistent UI

        private void productNameTextBox_Enter(object sender, EventArgs e)
        {
            RemovePromptFromTextBox(productNameTextBox, "Product Name");
        }

        private void productNameTextBox_Leave(object sender, EventArgs e)
        {
            AddPromptToTextBox(productNameTextBox, "Product Name");
        }

        private void DeliveryPriceTextBox_Enter(object sender, EventArgs e)
        {
            RemovePromptFromTextBox(deliveryPriceTextBox, "Delivery Price");
        }

        private void DeliveryPriceTextBox_Leave(object sender, EventArgs e)
        {
            AddPromptToTextBox(deliveryPriceTextBox, "Delivery Price");
        }

        private void SellingPriceTextBox_Enter(object sender, EventArgs e)
        {
            RemovePromptFromTextBox(sellingPriceTextBox, "Selling Price");
        }

        private void SellingPriceTextBox_Leave(object sender, EventArgs e)
        {
            AddPromptToTextBox(sellingPriceTextBox, "Selling Price");
        }

        private void InventoryQuantityTextBox_Enter(object sender, EventArgs e)
        {
            RemovePromptFromTextBox(inventoryQuantityTextBox, "Quantity");
        }

        private void InventoryQuantityTextBox_Leave(object sender, EventArgs e)
        {
            AddPromptToTextBox(inventoryQuantityTextBox, "Quantity");
        }

        private void DeliveryQuantityTextBox_Enter(object sender, EventArgs e)
        {
            RemovePromptFromTextBox(deliveryQuantityTextBox, "Quantity");
        }

        private void DeliveryQuantityTextBox_Leave(object sender, EventArgs e)
        {
            AddPromptToTextBox(deliveryQuantityTextBox, "Quantity");
        }

        private void ProductCodeMaskedTextBox_Enter(object sender, EventArgs e)
        {
            if (productCodeMaskedTextBox.Text == "000000")
            {
                productCodeMaskedTextBox.Text = string.Empty;
                productCodeMaskedTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void ProductCodeMaskedTextBox_Leave(object sender, EventArgs e)
        {
            if (productCodeMaskedTextBox.Text == string.Empty)
            {
                productCodeMaskedTextBox.Text = "000000";
                productCodeMaskedTextBox.ForeColor = SystemColors.WindowFrame;
            }
        }

        private void RemovePromptFromTextBox(TextBox textBox, string prompt)
        {
            if (textBox.Text == prompt)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void AddPromptToTextBox(TextBox textBox, string prompt)
        {
            if (textBox.Text == string.Empty)
            {
                textBox.Text = prompt;
                textBox.ForeColor = SystemColors.WindowFrame;
            }
        }

        public void UpdateCategoryComboBox()
        {
            List<string> allCategories = new List<string>();
            allCategories.Add("Select Category");
            allCategories.AddRange(categoryBusiness.GetAllNames());
            categoryComboBox.DataSource = allCategories;
        }

        public void UpdateSupplierComboBox()
        {
            List<string> allSuppliers = new List<string>();
            allSuppliers.Add("Select Supplier");
            allSuppliers.AddRange(supplierBusiness.GetAllNames());
            supplierNameComboBox.DataSource = allSuppliers;
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            string productCode = productCodeMaskedTextBox.Text;
            string category = (string)categoryComboBox.SelectedItem;
            string productName = productNameTextBox.Text;
            string quantityString = inventoryQuantityTextBox.Text;
            string supplierName = (string)supplierNameComboBox.SelectedItem;
            string deliveryPriceString = deliveryPriceTextBox.Text;
            string sellingPriceString = sellingPriceTextBox.Text;
            string unit = "";

            if (unitRadioButton.Checked) unit = "Unit";
            else if (kilogramRadioButton.Checked) unit = "Kilogram";
            else if (litreRadioButton.Checked) unit = "Litre";
            else
            {
                MessageBox.Show("Please select an unit");
            }

            try
            {
                AreValuesCorrect(productCode, category, productName, quantityString, supplierName, deliveryPriceString, sellingPriceString, unit);
                decimal quantity = decimal.Parse(quantityString);
                decimal deliveryPrice = decimal.Parse(deliveryPriceString);
                decimal sellingPrice = decimal.Parse(sellingPriceString);
                productBusiness.Add(productCode, category, productName, quantity, supplierName, deliveryPrice, sellingPrice, unit);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            UpdateProductTab();
            //UpdateSupplierComboBoxOnWarehouseUserControl();
        }

        private void UpdateProductTab()
        {
            productCodeMaskedTextBox.Text = string.Empty;
            productCodeMaskedTextBox.ForeColor = SystemColors.WindowFrame;
            productNameTextBox.Text = "Product Name";
            productNameTextBox.ForeColor = SystemColors.WindowFrame;
            inventoryQuantityTextBox.Text = "Quantity";
            inventoryQuantityTextBox.ForeColor = SystemColors.WindowFrame;
            deliveryPriceTextBox.Text = "Delivery Price";
            deliveryPriceTextBox.ForeColor = SystemColors.WindowFrame;
            sellingPriceTextBox.Text = "Selling Price";
            sellingPriceTextBox.ForeColor = SystemColors.WindowFrame;
            categoryComboBox.SelectedIndex = 0;
            supplierNameComboBox.SelectedIndex = 0;
            supplierCountryTextBox.Text = "Country";
            supplierCityTextBox.Text = "City";
            unitRadioButton.Checked = false;
            kilogramRadioButton.Checked = false;
            litreRadioButton.Checked = false;
            CalculateNetProfit();

            allProductsDataGridView.Rows.Clear();
            List<Product> allProducts = productBusiness.GetAll();
            foreach (var product in allProducts)
            {
                DataGridViewRow newRow = allProductsDataGridView.Rows[allProductsDataGridView.Rows.Add()];
                var category = categoryBusiness.Get(product.CategoryId);
                var unit = unitBusiness.Get(product.UnitId);
                var supplier = supplierBusiness.Get(product.SupplierId);
                newRow.Cells[0].Value = product.Code;
                newRow.Cells[1].Value = product.Name;
                newRow.Cells[2].Value = category.Name;
                newRow.Cells[3].Value = product.Quantity;
                newRow.Cells[4].Value = unit.Code;
                newRow.Cells[5].Value = supplier.Name;
                newRow.Cells[6].Value = product.DeliveryPrice;
                newRow.Cells[7].Value = product.SellingPrice;
            }
        }

        private void AreValuesCorrect(string productCode, string category, string productName, string quantityString,
            string supplierName, string deliveryPriceString, string sellingPriceString, string unit)
        {
            foreach (var letter in productCode)
            {
                if (!Char.IsDigit(letter))
                {
                    throw new ArgumentException("Code must have only digits!");
                }
            }

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

            if (quantity != Math.Floor(quantity) && unit == "Unit")
            {
                throw new ArgumentException("Quantity must be a whole number");
            }

            if (category == "Select Category" || productName == "Product Name" || supplierName == "Select Supplier"
                || !quantityStringCanBeParsed || !deliveryPriceStringCanBeParsed || !sellingPriceStringCanBeParsed)
            {
                throw new ArgumentException("Invalid Values!");
            }
        }

        private void UpdateDataGrid()
        {
            List<Product> allProducts = productBusiness.GetAll();
            allProductsDataGridView.Rows.Clear();

            foreach(var product in allProducts)
            {
                DataGridViewRow newRow = allProductsDataGridView.Rows[allProductsDataGridView.Rows.Add()];

                var category = categoryBusiness
                                    .GetAll()
                                    .First(x => x.Id == product.CategoryId);

                var unit = unitBusiness
                                .GetAll()
                                .First(x => x.Id == product.UnitId);

                var supplier = supplierBusiness
                                    .GetAll()
                                    .First(x => x.Id == product.SupplierId);
                var city = cityBusiness
                                .GetAll()
                                .First(x => x.Id == supplier.CityId);

                var country = countryBusiness
                                .GetAll()
                                .First(x => x.Id == city.CountryId);

                newRow.Cells[0].Value = product.Code;
                newRow.Cells[1].Value = product.Name;
                newRow.Cells[2].Value = category.Name;
                newRow.Cells[3].Value = product.Quantity;
                newRow.Cells[4].Value = unit.Code;
                newRow.Cells[5].Value = supplier.Name;
                newRow.Cells[6].Value = country.Name;
                newRow.Cells[7].Value = city.Name;
                newRow.Cells[8].Value = product.DeliveryPrice;
                newRow.Cells[9].Value = product.SellingPrice;
            }
        }

        private void supplierNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)supplierNameComboBox.SelectedItem != "Select Supplier")
            {
                string supplier = (string)supplierNameComboBox.SelectedItem;
                string countryName = countryBusiness.GetNameBySupplier(supplier);
                string cityName = cityBusiness.GetNameBySupplier(supplier);
                supplierCityTextBox.Text = cityName;
                supplierCountryTextBox.Text = countryName;
            }
            else
            {
                supplierCountryTextBox.Text = "Country";
                supplierCityTextBox.Text = "City";
            }
        }

        private void deliveryPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            netProfitAmountLabel.Text = string.Format("$ {0:f2}", CalculateNetProfit());
        }

        private void sellingPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            netProfitAmountLabel.Text = string.Format("$ {0:f2}", CalculateNetProfit());
        }

        private double CalculateNetProfit()
        {
            string deliveryPriceString = deliveryPriceTextBox.Text;
            string sellingPriceString = sellingPriceTextBox.Text;
            if (deliveryPriceString == "Delivery Price" || sellingPriceString == "Selling Price")
            {
                return 0;
            }
            else
            {
                double deliveryPrice = 0;
                double sellingPrice = 0;
                bool deliveryPriceCanBeParsed = double.TryParse(deliveryPriceString, out deliveryPrice);
                bool sellingPriceCanBeParsed = double.TryParse(sellingPriceString, out sellingPrice);

                if (!deliveryPriceCanBeParsed || !sellingPriceCanBeParsed)
                {
                    return 0;
                }
                else
                {
                    return sellingPrice - deliveryPrice;
                }
            }
        }
    }
}
