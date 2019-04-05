using Business;
using Business.Controllers;
using Data.Models;
using EazyCart.InteractionForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EazyCart.UserControls
{
    /// <summary>
    /// This is the user control responsible for managing cities, countries,
    /// suppliers and categories, which products need to have a reference to.
    /// </summary>
    public partial class LogisticsUserControl : UserControl
    {
        private CityBusiness cityBusiness;
        private CountryBusiness countryBusiness;
        private CategoryBusiness categoryBusiness;
        private SupplierBusiness supplierBusiness;

        private readonly Color enabledButtonColor = Color.FromArgb(44, 62, 80);
        private readonly Color disabledButtonColor = Color.FromArgb(127, 140, 141);
        private readonly Color enabledDeleteButtonColor = Color.FromArgb(231, 76, 60);
        private readonly Color promptTextColor = SystemColors.WindowFrame;
        private readonly Color activeTextColor = SystemColors.WindowText;

        public LogisticsUserControl()
        {
            InitializeComponent();
        }

        private void LogisticsUserControl_Load(object sender, EventArgs e)
        {
            this.UpdateUserControl();
        }

        // The following methods are responsible for updating information when it is changed.
        /// <summary>
        /// Updates the user control every time it is loaded.
        /// </summary>
        private void UpdateUserControl()
        {
            var eazyCartContext = new EazyCartContext();
            this.cityBusiness = new CityBusiness(eazyCartContext);
            this.countryBusiness = new CountryBusiness(eazyCartContext);
            this.categoryBusiness = new CategoryBusiness(eazyCartContext);
            this.supplierBusiness = new SupplierBusiness(eazyCartContext);
            this.ClearAndUpdateCategoryTab();
            this.ClearAndUpdateCountryTab();
            this.ClearAndUpdateCityTab();
            this.ClearAndUpdateSupplierTab();
        }

        /// <summary>
        /// Clears and updates the category tab.
        /// </summary>
        private void ClearAndUpdateCategoryTab()
        {
            // Resetting fields for input
            this.categoryIdTextBox.Text = "ID";
            this.categoryIdTextBox.ForeColor = promptTextColor;
            this.categoryNameTextBox.Text = "Category Name";
            this.categoryNameTextBox.ForeColor = promptTextColor;

            // Inserting data into the category dataGridView
            this.categoriesDataGridView.Rows.Clear();
            List<Category> allCategories = this.categoryBusiness.GetAll();
            foreach (var category in allCategories)
            {
                var newRow = this.categoriesDataGridView.Rows[categoriesDataGridView.Rows.Add()];

                newRow.Cells[0].Value = category.Id;
                newRow.Cells[1].Value = category.Name;
            }
        }

        /// <summary>
        /// Clears and updates the country tab.
        /// Calls method, which updates the comboBoxes containing information about countries.
        /// </summary>
        private void ClearAndUpdateCountryTab()
        {
            // Resetting fields for input
            this.countryIdTextBox.Text = "ID";
            this.categoryIdTextBox.ForeColor = promptTextColor;
            this.countryNameTextBox.Text = "Country Name";
            this.categoryNameTextBox.ForeColor = promptTextColor;

            // Inserting data into the country dataGridView
            this.countriesDataGridView.Rows.Clear();
            var allCountries = this.countryBusiness.GetAll();
            foreach (var country in allCountries)
            {
                DataGridViewRow newRow = this.countriesDataGridView.Rows[countriesDataGridView.Rows.Add()];

                newRow.Cells[0].Value = country.Id;
                newRow.Cells[1].Value = country.Name;
            }

            // Update comboBoxes related to countries.
            this.UpdateComboBoxesOnCountryUpdate();
        }

        /// <summary>
        /// Clears and updates the city tab. 
        /// Calls method, which updates the comboBoxes containing information about cities.
        /// </summary>
        private void ClearAndUpdateCityTab()
        {
            // Resetting fields for input
            this.cityIdTextBox.Text = "ID";
            this.cityIdTextBox.ForeColor = promptTextColor;
            this.cityNameTextBox.Text = "City Name";
            this.cityNameTextBox.ForeColor = promptTextColor;
            this.countryForCityComboBox.SelectedIndex = 0;

            // Inserting data into the city dataGridView
            this.citiesDataGridView.Rows.Clear();
            var allCities = this.cityBusiness.GetAll();
            foreach (var city in allCities)
            {
                var newRow = this.citiesDataGridView.Rows[citiesDataGridView.Rows.Add()];
                int countryId = city.CountryId;
                var country = this.countryBusiness.Get(countryId);

                newRow.Cells[0].Value = city.Id;
                newRow.Cells[1].Value = city.Name;
                newRow.Cells[2].Value = country.Name;
            }

            // Update comboBoxes related to cities.
            this.UpdateComboBoxesOnCityUpdate();
        }

        /// <summary>
        /// Clears and updates the supplier tab.
        /// </summary>
        private void ClearAndUpdateSupplierTab()
        {
            // Resetting fields for input
            this.supplierIdTextBox.Text = "ID";
            this.supplierIdTextBox.ForeColor = promptTextColor;
            this.supplierNameTextBox.Text = "Supplier Name";
            this.supplierNameTextBox.ForeColor = promptTextColor;
            this.countryForSupplierComboBox.SelectedIndex = 0;
            this.cityForSupplierComboBox.SelectedIndex = 0;
            this.cityForSupplierComboBox.Enabled = false;

            // Inserting data into the supplier dataGridView
            this.suppliersDataGridView.Rows.Clear();
            var allSuppliers = supplierBusiness.GetAll();
            foreach (var supplier in allSuppliers)
            {
                var newRow = this.suppliersDataGridView.Rows[suppliersDataGridView.Rows.Add()];
                int cityId = supplier.CityId;
                var city = this.cityBusiness.Get(cityId);
                int countryId = city.CountryId;
                var country = this.countryBusiness.Get(countryId);

                newRow.Cells[0].Value = supplier.Id;
                newRow.Cells[1].Value = supplier.Name;
                newRow.Cells[2].Value = city.Name;
                newRow.Cells[3].Value = country.Name;
            }
        }

        /// <summary>
        /// Calls several methods related to updating comboBoxes, when the country tab is updated.
        /// </summary>
        public void UpdateComboBoxesOnCountryUpdate()
        {
            this.UpdateCountryComboBox(this.countryForCityComboBox);
            this.UpdateCountryComboBox(this.countryForSupplierComboBox);
            this.UpdateCityComboBox(this.cityForSupplierComboBox);
        }

        /// <summary>
        /// Calls several methods related to updating comboBoxes, when the city tab is updated.
        /// </summary>
        public void UpdateComboBoxesOnCityUpdate()
        {
            this.UpdateCountryComboBox(this.countryForSupplierComboBox);
            this.UpdateCityComboBox(this.cityForSupplierComboBox);
        }

        /// <summary>
        /// Updates a comboBox, which has information about countries. Accepts a comboBox as a parameter
        /// </summary>
        /// <param name="comboBox"></param>
        public void UpdateCountryComboBox(ComboBox comboBox)
        {
            // Extract and add all country names to the comboBox.
            var allCountries = new List<string>
            {               
                "Select Country"
            };
            allCountries.AddRange(countryBusiness.GetAllNames());

            comboBox.DataSource = allCountries;
        }

        /// <summary>
        /// // Updates a comboBox, which contains information about cities. Accepts a comboBox as a parameter.
        /// </summary>
        /// <param name="comboBox"></param>
        private void UpdateCityComboBox(ComboBox comboBox)
        {
            comboBox.Enabled = false;

            // Extract and add all city names to the comboBox.
            var items = new List<string>
            {
                "Select City"
            };

            comboBox.DataSource = items;
        }

        /// <summary>
        /// Updates comboBoxes related to categories in the warehouseUserControl
        /// </summary>
        private void UpdateCategoryComboBoxOnWarehouseUserControl()
        {
            var eazyCartForm = (EazyCartForm)EazyCartForm.ActiveForm;
            eazyCartForm.WarehouseUserControl.UpdateUserControl();
            eazyCartForm.CashRegisterUserControl.UpdateUserControl();
        }

        /// <summary>
        /// Updates comboBoxes related to suppliers in the warehouseUserControl
        /// </summary>
        private void UpdateWarehouseAndCashRegisterTabs()
        {
            var eazyCartForm = (EazyCartForm)EazyCartForm.ActiveForm;
            eazyCartForm.WarehouseUserControl.UpdateUserControl();
            eazyCartForm.CashRegisterUserControl.UpdateUserControl();
        }

        // The following methods are related to user interaction with the user control.

        // Category Tab Interaction
        /// <summary>
        /// The event triggers when the user clicks on the "Add Category" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            var categoryName = this.categoryNameTextBox.Text;
            var categoryIdString = this.categoryIdTextBox.Text;
            int categoryId;
            bool canBeParsed = int.TryParse(categoryIdString, out categoryId);

            // Validation of input values
            if (!canBeParsed || categoryName == "Category Name")
            {
                string message = "Invalid values for category";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            try
            {
                this.categoryBusiness.Add(categoryName, categoryId);
            }
            catch (ArgumentException exc)
            {
                MessageForm messageForm = new MessageForm(exc.Message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            // Call methods to update the related tabs.
            this.ClearAndUpdateCategoryTab();
            this.UpdateCategoryComboBoxOnWarehouseUserControl();
        }

        /// <summary>
        /// The event triggers when the user clicks on the "Edit Category" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditCategoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Lock the ID textBox, so the user can't intentionally change the ID.
                this.categoryIdTextBox.Enabled = false;

                var item = this.categoriesDataGridView.SelectedRows[0].Cells;
                var categoryId = (int)item[0].Value;
                var category = this.categoryBusiness.Get(categoryId);

                // Update textBoxes so that they display correct information.
                this.categoryIdTextBox.Text = category.Id.ToString();
                this.categoryIdTextBox.ForeColor = activeTextColor;
                this.categoryNameTextBox.Text = category.Name.ToString();
                this.categoryNameTextBox.ForeColor = activeTextColor;
            }
            catch
            {
                string message = "You haven't selected a row";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            this.ToggleEditSave(editCategoryButton, saveChangesForCategoryButton, addCategoryButton, deleteCategoryButton);
        }

        /// <summary>
        /// The event triggers when the user clicks on the "Save Category" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveChangesForCategoryButton_Click(object sender, EventArgs e)
        {
            var categoryName = this.categoryNameTextBox.Text;
            var categoryId = int.Parse(this.categoryIdTextBox.Text);

            // Validation for input values.
            if (categoryName == "Category Name")
            {
                string message = "Invalid values for category";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            try
            {
                this.categoryBusiness.Update(categoryName, categoryId);
            }
            catch(ArgumentException exc)
            {
                MessageForm messageForm = new MessageForm(exc.Message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }
            
            // Call methods to update related tabs.
            this.categoryIdTextBox.Enabled = true;
            this.ToggleEditSave(editCategoryButton, saveChangesForCategoryButton, addCategoryButton, deleteCategoryButton);
            this.ClearAndUpdateCategoryTab();
            this.UpdateCategoryComboBoxOnWarehouseUserControl();
        }

        /// <summary>
        /// The event triggers when the user clicks on the "Delete Category" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteCategoryButton_Click(object sender, EventArgs e)
        {
            var categoryId = 0;

            // Check if the user has selected a row.
            try
            {
                var item = this.categoriesDataGridView.SelectedRows[0].Cells;
                categoryId = (int)item[0].Value;
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
                this.categoryBusiness.Delete(categoryId);
            }
            catch (ArgumentException exc)
            {
                MessageForm messageForm = new MessageForm(exc.Message, MessageFormType.Error);
                messageForm.ShowDialog();
            }
            
            // Update the appropriate tabs.
            this.ClearAndUpdateCategoryTab();
            this.UpdateCategoryComboBoxOnWarehouseUserControl();
        }

        // Country Tab Interactions
        /// <summary>
        /// The event triggers when the user clicks on the "Add Country" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCountryButton_Click(object sender, EventArgs e)
        {
            var countryName = this.countryNameTextBox.Text;
            var countryIdString = this.countryIdTextBox.Text;
            int countryId;
            bool canBeParsed = int.TryParse(countryIdString, out countryId);

            // Validation of input values
            if (!canBeParsed || countryName == "Country Name")
            {
                string message = "Invalid values for country";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            try
            {
                this.countryBusiness.Add(countryName, countryId);
            }
            catch (ArgumentException exc)
            {
                MessageForm messageForm = new MessageForm(exc.Message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            // Call method to update related tab.
            this.ClearAndUpdateCountryTab();
        }

        /// <summary>
        /// The event triggers when the user clicks on the "Edit Country" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditCountryButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Lock the ID textBox, so the user can't intentionally change the ID.
                this.countryIdTextBox.Enabled = false;

                var item = this.countriesDataGridView.SelectedRows[0].Cells;
                int countryId = (int)item[0].Value;
                var country = this.countryBusiness.Get(countryId);

                // Update textBoxes so that they display correct information.
                this.countryIdTextBox.Text = country.Id.ToString();
                this.countryIdTextBox.ForeColor = activeTextColor;
                this.countryNameTextBox.Text = country.Name.ToString();
                this.countryNameTextBox.ForeColor = activeTextColor;
            }
            catch
            {
                string message = "You haven't selected a row";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            this.ToggleEditSave(editCountryButton, saveChangesForCountryButton, addCountryButton, deleteCountryButton);
        }

        /// <summary>
        /// The event triggers when the user clicks on the "Save Country" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveChangesForCountryButton_Click(object sender, EventArgs e)
        {
            var countryName = this.countryNameTextBox.Text;
            var countryId = int.Parse(this.countryIdTextBox.Text);

            // Validation of input values.
            if (countryName == "Country Name")
            {
                string message = "Invalid values for country";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            this.countryBusiness.Update(countryName, countryId);

            // Update related tabs.
            this.countryIdTextBox.Enabled = true;
            this.ToggleEditSave(editCountryButton, saveChangesForCountryButton, addCountryButton, deleteCountryButton);
            this.ClearAndUpdateCountryTab();
            this.ClearAndUpdateCityTab();
            this.ClearAndUpdateSupplierTab();
        }

        /// <summary>
        /// The event triggers when the user clicks on the "Delete Country" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteCountryButton_Click(object sender, EventArgs e)
        {
            var countryId = 0;

            // Check if user has selected a row.
            try
            {
                var item = this.countriesDataGridView.SelectedRows[0].Cells;
                countryId = (int)item[0].Value;
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
                this.countryBusiness.Delete(countryId);
            }
            catch (ArgumentException exc)
            {
                MessageForm messageForm = new MessageForm(exc.Message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            // Update tab.
            this.ClearAndUpdateCountryTab();
        }

        // City Tab Interaction
        /// <summary>
        /// This event is triggered if the index of the Country For Supplier ComboBox is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CountryForSupplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCountry = (string)this.countryForSupplierComboBox.SelectedItem;

            // Filter cities if a country is selected and disable
            // the city comboBox if no country has been selected
            if (selectedCountry == "Select Country")
            {
                this.cityForSupplierComboBox.Text = "Select City";
                this.cityForSupplierComboBox.Enabled = false;               
            }
            else
            {
                var country = (string)countryForSupplierComboBox.SelectedItem;
                this.FilterCitiesForCountry(country);
                this.cityForSupplierComboBox.Enabled = true;
            }
        }

        /// <summary>
        /// This method is responsible for filtering cities when a country has been selected from the
        /// country combo box for supplier.
        /// </summary>
        /// <param name="country"></param>
        private void FilterCitiesForCountry(string country)
        {
            // Add all city names to the city for supplier comboBox
            var cityNames = new List<string>
            {
                "Select City"
            };
            cityNames.AddRange(cityBusiness.GetAllCityNamesFromCountry(country));

            this.cityForSupplierComboBox.DataSource = cityNames;
        }

        /// <summary>
        /// The event triggers when the user clicks on the "Add City" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCityButton_Click(object sender, EventArgs e)
        {
            var cityName = this.cityNameTextBox.Text;
            var cityIdString = this.cityIdTextBox.Text;
            var cityCategory = (string)this.countryForCityComboBox.SelectedItem;
            int cityId;
            bool canBeParsed = int.TryParse(cityIdString, out cityId);

            // Validate input.
            if (!canBeParsed || cityName == "City Name" || cityCategory == "Select Country")
            {
                string message = "Invalid values for city";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            try
            {
                this.cityBusiness.Add(cityName, cityId, cityCategory);
            }
            catch (ArgumentException exc)
            {
                MessageForm messageForm = new MessageForm(exc.Message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            // Update appropriate tab.
            this.ClearAndUpdateCityTab();
        }

        /// <summary>
        /// The event triggers when the user clicks on the "Edit City" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditCityButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Lock the ID textBox, so the user can't intentionally change the ID.
                cityIdTextBox.Enabled = false;

                var item = citiesDataGridView.SelectedRows[0].Cells;
                var cityId = (int)item[0].Value;
                var city = cityBusiness.Get(cityId);

                // Update the tab so that it displays correct information.
                this.cityIdTextBox.Text = city.Id.ToString();
                this.cityIdTextBox.ForeColor = activeTextColor;
                this.cityNameTextBox.Text = city.Name.ToString();
                this.cityNameTextBox.ForeColor = activeTextColor;
                var country = countryBusiness.Get(city.CountryId);
                this.countryForCityComboBox.SelectedItem = country.Name;
            }
            catch
            {
                string message = "You haven't selected a row";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            this.ToggleEditSave(editCityButton, saveChangesForCityButton, addCityButton, deleteCityButton);
        }

        /// <summary>
        /// The event triggers when the user clicks on the "Save City" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveChangesForCityButton_Click(object sender, EventArgs e)
        {
            var cityName = this.cityNameTextBox.Text;
            var cityId = int.Parse(this.cityIdTextBox.Text);
            var countryName = this.countryForCityComboBox.Text;

            // Validate values.
            if (cityName == "City Name" || countryName == "Select Country")
            {
                string message = "Invalid values for city";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            try
            {
                this.cityBusiness.Update(cityName, cityId, countryName);
            }
            catch(ArgumentException exc)
            {
                MessageForm messageForm = new MessageForm(exc.Message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            this.cityIdTextBox.Enabled = true;

            // Update appropriate tab.
            this.ToggleEditSave(editCityButton, saveChangesForCityButton, addCityButton, deleteCityButton);
            this.ClearAndUpdateCityTab();
            this.ClearAndUpdateSupplierTab();
        }

        /// <summary>
        /// The event triggers when the user clicks on the "Delete City" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteCityButton_Click(object sender, EventArgs e)
        {
            var cityId = 0;

            // Check if a row is selected.
            try
            {
                var item = this.citiesDataGridView.SelectedRows[0].Cells;
                cityId = (int)item[0].Value;
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
                this.cityBusiness.Delete(cityId);
            }
            catch (ArgumentException exc)
            {
                MessageForm messageForm = new MessageForm(exc.Message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            // Update the appropriate tab.
            this.ClearAndUpdateCityTab();
        }

        // Supplier Tab Interaction
        /// <summary>
        /// The event triggers when the user clicks on the "Add Supplier" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSupplierButton_Click(object sender, EventArgs e)
        {
            var supplierName = this.supplierNameTextBox.Text;
            var supplierIdString = this.supplierIdTextBox.Text;
            var supplierCity = (string) this.cityForSupplierComboBox.SelectedItem;
            var supplierCountry = (string) this.countryForSupplierComboBox.SelectedItem;
            int supplierId;
            var canBeParsed = int.TryParse(supplierIdString, out supplierId);

            // Perform validation.
            if (!canBeParsed || supplierName == "Supplier Name" || supplierCity == "Select City")
            {
                string message = "Invalid values for supplier";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            try
            {
                this.supplierBusiness.Add(supplierName, supplierId, supplierCity, supplierCountry);
            }
            catch (ArgumentException exc)
            {
                MessageForm messageForm = new MessageForm(exc.Message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            // Update appropriate tabs.
            this.ClearAndUpdateSupplierTab();
            this.UpdateWarehouseAndCashRegisterTabs();
        }

        /// <summary>
        /// The event triggers when the user clicks on the "Edit Supplier" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditSupplierButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Lock the ID textBox to prevent the user from changing.
                this.supplierIdTextBox.Enabled = false;

                var item = this.suppliersDataGridView.SelectedRows[0].Cells;
                var supplierId = (int)item[0].Value;
                var supplier = this.supplierBusiness.Get(supplierId);

                // Insert information and format controls of the supplier tab for updating.
                this.supplierIdTextBox.Text = supplier.Id.ToString();
                this.supplierIdTextBox.ForeColor = activeTextColor;
                this.supplierNameTextBox.Text = supplier.Name.ToString();
                this.supplierNameTextBox.ForeColor = activeTextColor;
                var city = this.cityBusiness.Get(supplier.CityId);
                var country = this.countryBusiness.Get(city.CountryId);
                this.countryForSupplierComboBox.SelectedItem = country.Name;
                this.FilterCitiesForCountry(country.Name);
                this.cityForSupplierComboBox.SelectedItem = city.Name;
            }
            catch
            {
                string message = "You haven't selected a row";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            this.ToggleEditSave(editSupplierButton, saveChangesForSupplierButton, addSupplierButton, deleteSupplierButton);
        }

        /// <summary>
        /// The event triggers when the user clicks on the "Save Supplier" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveChangesForSupplierButton_Click(object sender, EventArgs e)
        {
            // Extract the values for updating
            var supplierName = this.supplierNameTextBox.Text;
            var supplierId = int.Parse(this.supplierIdTextBox.Text);
            var countryName = this.countryForSupplierComboBox.Text;
            var cityName = this.cityForSupplierComboBox.Text;

            // Perform validation
            if (supplierName == "Supplier Name" || countryName == "Select Country" || cityName == "Select City")
            {
                string message = "Invalid values for supplier";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            try
            {
                this.supplierBusiness.Update(supplierName, supplierId, countryName, cityName);
            }
            catch(ArgumentException exc)
            {
                MessageForm messageForm = new MessageForm(exc.Message, MessageFormType.Error);
                messageForm.ShowDialog();
            }

            this.supplierIdTextBox.Enabled = true;

            // Update the appropriate tabs
            this.ToggleEditSave(editSupplierButton, saveChangesForSupplierButton, addSupplierButton, deleteSupplierButton);
            this.ClearAndUpdateSupplierTab();
            this.UpdateWarehouseAndCashRegisterTabs();
        }

        /// <summary>
        /// The event triggers when the user clicks on the "Delete Supplier" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteSupplierButton_Click(object sender, EventArgs e)
        {
            int supplierId = 0;
            
            // Check if a row is selected.
            try
            {
                var item = suppliersDataGridView.SelectedRows[0].Cells;
                supplierId = (int)item[0].Value;
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
                this.supplierBusiness.Delete(supplierId);
            }
            catch (ArgumentException exc)
            {
                MessageForm messageForm = new MessageForm(exc.Message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            // Update appropriate tabs.
            ClearAndUpdateSupplierTab();
            UpdateWarehouseAndCashRegisterTabs();
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
            if (editButton.Enabled)
            {
                // Disable all buttons except the Save Button
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
                // Enable all buttons and disable the Save Button
                editButton.Enabled = true;
                editButton.BackColor = enabledButtonColor;
                addButton.Enabled = true;
                addButton.BackColor = enabledButtonColor;
                deleteButton.Enabled = true;
                deleteButton.BackColor = enabledDeleteButtonColor;

                saveButton.Enabled = false;
                saveButton.BackColor = disabledButtonColor;
            }
        }

        // All of the following methods are connected with maintaining a clean UI
        private void CountryNameTextBox_Enter(object sender, EventArgs e)
        {
            this.RemovePromptFromTextBoxWhenTyping(this.countryNameTextBox, "Country Name");
        }

        private void CountryNameTextBox_Leave(object sender, EventArgs e)
        {
            this.AddPromptToTextBoxIfEmpty(this.countryNameTextBox, "Country Name");
        }

        private void CountryIdTextBox_Enter(object sender, EventArgs e)
        {
            this.RemovePromptFromTextBoxWhenTyping(this.countryIdTextBox, "ID");
        }

        private void CountryIdTextBox_Leave(object sender, EventArgs e)
        {
            this.AddPromptToTextBoxIfEmpty(this.countryIdTextBox, "ID");
        }

        private void CategoryNameTextBox_Enter(object sender, EventArgs e)
        {
            this.RemovePromptFromTextBoxWhenTyping(this.categoryNameTextBox, "Category Name");
        }

        private void CategoryNameTextBox_Leave(object sender, EventArgs e)
        {
            this.AddPromptToTextBoxIfEmpty(this.categoryNameTextBox, "Category Name");
        }

        private void CategoryIdTextBox_Enter(object sender, EventArgs e)
        {
            this.RemovePromptFromTextBoxWhenTyping(this.categoryIdTextBox, "ID");
        }

        private void CategoryIdTextBox_Leave(object sender, EventArgs e)
        {
            this.AddPromptToTextBoxIfEmpty(this.categoryIdTextBox, "ID");
        }

        private void CityIdTextBox_Enter(object sender, EventArgs e)
        {
            this.RemovePromptFromTextBoxWhenTyping(this.cityIdTextBox, "ID");
        }

        private void CityIdTextBox_Leave(object sender, EventArgs e)
        {
            this.AddPromptToTextBoxIfEmpty(this.cityIdTextBox, "ID");
        }

        private void CityNameTextBox_Enter(object sender, EventArgs e)
        {
            this.RemovePromptFromTextBoxWhenTyping(this.cityNameTextBox, "City Name");
        }

        private void CityNameTextBox_Leave(object sender, EventArgs e)
        {
            this.AddPromptToTextBoxIfEmpty(this.cityNameTextBox, "City Name");
        }

        private void SupplierIdTextBox_Enter(object sender, EventArgs e)
        {
            this.RemovePromptFromTextBoxWhenTyping(this.supplierIdTextBox, "ID");
        }

        private void SupplierIdTextBox_Leave(object sender, EventArgs e)
        {
            this.AddPromptToTextBoxIfEmpty(this.supplierIdTextBox, "ID");
        }

        private void SupplierNameTextBox_Enter(object sender, EventArgs e)
        {
            this.RemovePromptFromTextBoxWhenTyping(this.supplierNameTextBox, "Supplier Name");
        }

        private void SupplierNameTextBox_Leave(object sender, EventArgs e)
        {
            this.AddPromptToTextBoxIfEmpty(this.supplierNameTextBox, "Supplier Name");
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