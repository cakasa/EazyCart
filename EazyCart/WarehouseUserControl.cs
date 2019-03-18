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
        private CategoryBusiness categoryBusiness= new CategoryBusiness();
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

            UpdateForm();
            SetInitialState();
            
        }

        private void SetInitialState()
        {
            categoryComboBox.SelectedItem = categoryComboBox.Items[0];
            supplierCityComboBox.SelectedItem = supplierCityComboBox.Items[0];
            supplierCountryComboBox.SelectedItem = supplierCountryComboBox.Items[0];
            supplierNameComboBox.SelectedItem = supplierNameComboBox.Items[0];
            productComboBox.SelectedItem = productComboBox.Items[0];
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
            var country = new Country();
            string countryToAdd = supplierCountryComboBox.Text;
            if (countryBusiness.GetAllNames().Contains(countryToAdd))
            {
                MessageBox.Show($"There already is a country called {countryToAdd}");
                return;
            }
            country.Name = countryToAdd;
            countryBusiness.Add(country);
            UpdateForm();
        }

        private void AddCityButton_Click(object sender, EventArgs e)
        {
            var city = new City();
            string cityToAdd = supplierCityComboBox.Text;
            string selectedCountryString = supplierCountryComboBox.Text;
            Country selectedCountry = countryBusiness.GetByName(selectedCountryString);
            List<City> existingCitiesInSelectedCountry = countryBusiness.GetCities(selectedCountry.Id);

            // TODO: Fix the if, country always showing it has 0 cities.
            if (existingCitiesInSelectedCountry.Any(x => x.Name == cityToAdd))
            {
                MessageBox.Show($"There already is a city called {cityToAdd} in {selectedCountryString}");
                return;
            }

            city.Name = cityToAdd;
            city.CountryId = selectedCountry.Id;
            cityBusiness.Add(city);
            countryBusiness.AddCityToCountry(selectedCountry.Id, city);           
            UpdateForm();
        }

        private void AddSupplierButton_Click(object sender, EventArgs e)
        {
            var supplier = new Supplier();
            string supplierToAdd = supplierCityComboBox.Text;
            string selectedCityString = supplierCityComboBox.Text;
            string selectedCountryString = supplierCountryComboBox.Text;
            Country selectedCountry = countryBusiness.GetByName(selectedCountryString);
            City selectedCity = cityBusiness.GetByCountryAndName(selectedCountry, selectedCityString);
            List<Supplier> existingSuppliersInSelectedCity = cityBusiness.GetSuppliers(selectedCity);

            if(existingSuppliersInSelectedCity.Any(x => x.Name == supplierToAdd))
            {
                MessageBox.Show($"There already is a supplier called {supplierToAdd} in city {selectedCityString}");
                return;
            }

            supplier.Name = supplierToAdd;
            supplier.CityId = selectedCity.Id;
            supplierBusiness.Add(supplier);
            cityBusiness.AddSupplierToCity(selectedCity, supplier);
            UpdateForm();
        }

        private void UpdateForm()
        {
            categoryComboBox.DataSource = categoryBusiness.GetAllNames();
            supplierNameComboBox.DataSource = supplierBusiness.GetAllNames();
            supplierCountryComboBox.DataSource = countryBusiness.GetAllNames();
            supplierCityComboBox.DataSource = cityBusiness.GetAllNames();
            productComboBox.DataSource = productBusiness.GetAllNames();
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
            if(productCodeMaskedTextBox.Text == "000000")
            {
                productCodeMaskedTextBox.Text = string.Empty;
                productCodeMaskedTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void ProductCodeMaskedTextBox_Leave(object sender, EventArgs e)
        {
            if(productCodeMaskedTextBox.Text == string.Empty)
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
            if(textBox.Text == string.Empty)
            {
                textBox.Text = prompt;
                textBox.ForeColor = SystemColors.WindowFrame;
            }
        }

        
    }
}
