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
    public partial class ManagementUserControl : UserControl
    {
        private CityBusiness cityBusiness;
        private CountryBusiness countryBusiness;
        private CategoryBusiness categoryBusiness;
        private SupplierBusiness supplierBusiness;

        Color enabledButtonColor = Color.FromArgb(44, 62, 80);
        Color disabledButtonColor = Color.FromArgb(127, 140, 141);

        public ManagementUserControl()
        {
            InitializeComponent();
        }

        private void ManagementUserControl_Load(object sender, EventArgs e)
        {
            SetInitialState();
        }

        private void SetInitialState()
        {
            cityBusiness = new CityBusiness();
            countryBusiness = new CountryBusiness();
            categoryBusiness = new CategoryBusiness();
            supplierBusiness = new SupplierBusiness();
            UpdateCategoryTab();
            UpdateCountryTab();
            UpdateCityTab();
            UpdateSupplierTab();
        }

        private void UpdateCategoryTab()
        {
            categoryIdTextBox.Text = "ID";
            categoryIdTextBox.ForeColor = SystemColors.WindowFrame;
            categoryNameTextBox.Text = "Category Name";
            categoryNameTextBox.ForeColor = SystemColors.WindowFrame;

            categoriesDataGridView.Rows.Clear();
            List<Category> allCategories = categoryBusiness.GetAll();
            foreach(var category in allCategories)
            {
                DataGridViewRow newRow = categoriesDataGridView.Rows[categoriesDataGridView.Rows.Add()];

                newRow.Cells[0].Value = category.Id;
                newRow.Cells[1].Value = category.Name;
            }

        }

        private void UpdateCountryTab()
        {
            countryIdTextBox.Text = "ID";
            categoryIdTextBox.ForeColor = SystemColors.WindowFrame;
            countryNameTextBox.Text = "Country Name";
            categoryNameTextBox.ForeColor = SystemColors.WindowFrame;

            countriesDataGridView.Rows.Clear();
            List<Country> allCountries = countryBusiness.GetAll();
            foreach (var country in allCountries)
            {
                DataGridViewRow newRow = countriesDataGridView.Rows[countriesDataGridView.Rows.Add()];

                newRow.Cells[0].Value = country.Id;
                newRow.Cells[1].Value = country.Name;
            }

            UpdateComboBoxesOnCountryUpdate();
        }

        public void UpdateComboBoxesOnCountryUpdate()
        {
            UpdateCountryComboBox(countryForCityComboBox);
            UpdateCountryComboBox(countryForSupplierComboBox);
            UpdateCityComboBox(cityForSupplierComboBox);
        }

        public void UpdateComboBoxesOnCityUpdate()
        {
            UpdateCountryComboBox(countryForSupplierComboBox);
            UpdateCityComboBox(cityForSupplierComboBox);
        }

        public void UpdateCountryComboBox(ComboBox comboBox)
        {
            List<string> allCountries = new List<string>();
            allCountries.Add("Select Country");
            allCountries.AddRange(countryBusiness.GetAllNames());
            comboBox.DataSource = allCountries;
        }

        private void UpdateCityComboBox(ComboBox comboBox)
        {
            comboBox.Enabled = false;
            List<string> items = new List<string>();
            items.Add("Select City");
            comboBox.DataSource = items;
        }

        // Category Tab Interactions

        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            string categoryName = categoryNameTextBox.Text;
            string categoryIdString = categoryIdTextBox.Text;
            int categoryId;
            bool canBeParsed = int.TryParse(categoryIdString, out categoryId);

            if(!canBeParsed || categoryName == "Category Name")
            {
                MessageBox.Show("Invalid values for category");
                return;
            }

            try
            {
                categoryBusiness.Add(categoryName, categoryId);
            }
            catch(ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            UpdateCategoryTab();
        }

        private void EditCategoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                categoryIdTextBox.Enabled = false;
                var item = categoriesDataGridView.SelectedRows[0].Cells;
                int categoryId = (int)item[0].Value;
                Category category = categoryBusiness.Get(categoryId);
                categoryIdTextBox.Text = category.Id.ToString();
                categoryIdTextBox.ForeColor = SystemColors.WindowText;
                categoryNameTextBox.Text = category.Name.ToString();
                categoryNameTextBox.ForeColor = SystemColors.WindowText;
            }
            catch
            {
                MessageBox.Show("You haven't selected a row");
                return;
            }

            ToggleCategoryEditSave();
        }

        private void SaveChangesForCategoryButton_Click(object sender, EventArgs e)
        {
            string categoryName = categoryNameTextBox.Text;
            int categoryId = int.Parse(categoryIdTextBox.Text);

            if (categoryName == "Category Name")
            {
                MessageBox.Show("Invalid values for category");
                return;
            }

            categoryBusiness.Update(categoryName, categoryId);

            categoryIdTextBox.Enabled = true;
            ToggleCategoryEditSave();
            UpdateCategoryTab();
        }

        private void DeleteCategoryButton_Click(object sender, EventArgs e)
        {
            int categoryId = 0;
            try
            {
                var item = categoriesDataGridView.SelectedRows[0].Cells;
                categoryId = (int)item[0].Value;
            }
            catch
            {
                MessageBox.Show("You haven't selected a row");
                return;
            }

            try
            {
                categoryBusiness.Delete(categoryId);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
            }

            UpdateCategoryTab();
        }

        private void ToggleCategoryEditSave()
        {
            if(editCategoryButton.Enabled)
            {
                editCategoryButton.Enabled = false;
                editCategoryButton.BackColor = disabledButtonColor;

                saveChangesForCategoryButton.Enabled = true;
                saveChangesForCategoryButton.BackColor = enabledButtonColor;
            }
            else
            {
                editCategoryButton.Enabled = true;
                editCategoryButton.BackColor = enabledButtonColor;

                saveChangesForCategoryButton.Enabled = false;
                saveChangesForCategoryButton.BackColor = disabledButtonColor;
            }
        }

        // Country Tab Interactions

        private void AddCountryButton_Click(object sender, EventArgs e)
        {
            string countryName = countryNameTextBox.Text;
            string countryIdString = countryIdTextBox.Text;
            int countryId;
            bool canBeParsed = int.TryParse(countryIdString, out countryId);

            if (!canBeParsed || countryName == "Country Name")
            {
                MessageBox.Show("Invalid values for country");
                return;
            }

            try
            {
                countryBusiness.Add(countryName, countryId);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            UpdateCountryTab();
        }

        private void EditCountryButton_Click(object sender, EventArgs e)
        {
            try
            {
                countryIdTextBox.Enabled = false;
                var item = countriesDataGridView.SelectedRows[0].Cells;
                int countryId = (int)item[0].Value;
                Country country = countryBusiness.Get(countryId);
                countryIdTextBox.Text = country.Id.ToString();
                countryIdTextBox.ForeColor = SystemColors.WindowText;
                countryNameTextBox.Text = country.Name.ToString();
                countryNameTextBox.ForeColor = SystemColors.WindowText;
            }
            catch
            {
                MessageBox.Show("You haven't selected a row");
                return;
            }

            ToggleCountryEditSave();
        }

        private void SaveChangesForCountryButton_Click(object sender, EventArgs e)
        {
            string countryName = countryNameTextBox.Text;
            int countryId = int.Parse(countryIdTextBox.Text);

            if (countryName == "Country Name")
            {
                MessageBox.Show("Invalid values for country");
                return;
            }

            countryBusiness.Update(countryName, countryId);

            countryIdTextBox.Enabled = true;
            ToggleCountryEditSave();
            UpdateCountryTab();
        }

        private void DeleteCountryButton_Click(object sender, EventArgs e)
        {
            int countryId = 0;
            try
            {
                var item = countriesDataGridView.SelectedRows[0].Cells;
                countryId = (int)item[0].Value;
            }
            catch
            {
                MessageBox.Show("You haven't selected a row");
                return;
            }

            try
            {
                countryBusiness.Delete(countryId);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            UpdateCountryTab();
        }

        private void ToggleCountryEditSave()
        {
            if (editCountryButton.Enabled)
            {
                editCountryButton.Enabled = false;
                editCountryButton.BackColor = disabledButtonColor;

                saveChangesForCountryButton.Enabled = true;
                saveChangesForCountryButton.BackColor = enabledButtonColor;
            }
            else
            {
                editCountryButton.Enabled = true;
                editCountryButton.BackColor = enabledButtonColor;

                saveChangesForCountryButton.Enabled = false;
                saveChangesForCountryButton.BackColor = disabledButtonColor;
            }
        }

        // City Tab Interaction

        private void AddCityButton_Click(object sender, EventArgs e)
        {
            string cityName = cityNameTextBox.Text;
            string cityIdString = cityIdTextBox.Text;
            string cityCategory = (string) countryForCityComboBox.SelectedItem;
            int cityId;
            bool canBeParsed = int.TryParse(cityIdString, out cityId);

            if (!canBeParsed || cityName == "City Name" || cityCategory == "Select Country")
            {
                MessageBox.Show("Invalid values for city");
                return;
            }

            try
            {
                cityBusiness.Add(cityName, cityId, cityCategory);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            UpdateCityTab();
        }

        private void EditCityButton_Click(object sender, EventArgs e)
        {
            try
            {
                cityIdTextBox.Enabled = false;
                var item = citiesDataGridView.SelectedRows[0].Cells;
                var cityId = (int)item[0].Value;
                var city = cityBusiness.Get(cityId);
                cityIdTextBox.Text = city.Id.ToString();
                cityIdTextBox.ForeColor = SystemColors.WindowText;
                cityNameTextBox.Text = city.Name.ToString();
                cityNameTextBox.ForeColor = SystemColors.WindowText;

                var country = countryBusiness.Get(city.CountryId);
                 
                countryForCityComboBox.SelectedItem = country.Name;
            }
            catch
            {
                MessageBox.Show("You haven't selected a row");
                return;
            }

            ToggleCityEditSave();
        }

        private void SaveChangesForCityButton_Click(object sender, EventArgs e)
        {
            string cityName = cityNameTextBox.Text;
            int cityId = int.Parse(cityIdTextBox.Text);
            string countryName = countryForCityComboBox.Text;

            if (cityName == "City Name" || countryName == "Select Country")
            {
                MessageBox.Show("Invalid values for city");
                return;
            }

            cityBusiness.Update(cityName, cityId, countryName);

            cityIdTextBox.Enabled = true;
            ToggleCityEditSave();
            UpdateCityTab();
        }

        private void DeleteCityButton_Click(object sender, EventArgs e)
        {
            int cityId = 0;
            try
            {
                var item = citiesDataGridView.SelectedRows[0].Cells;
                cityId = (int)item[0].Value;
            }
            catch
            {
                MessageBox.Show("You haven't selected a row");
                return;
            }

            try
            {
                cityBusiness.Delete(cityId);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            UpdateCityTab();
        }

        private void ToggleCityEditSave()
        {
            if (editCityButton.Enabled)
            {
                editCityButton.Enabled = false;
                editCityButton.BackColor = disabledButtonColor;

                saveChangesForCityButton.Enabled = true;
                saveChangesForCityButton.BackColor = enabledButtonColor;
            }
            else
            {
                editCityButton.Enabled = true;
                editCityButton.BackColor = enabledButtonColor;

                saveChangesForCityButton.Enabled = false;
                saveChangesForCityButton.BackColor = disabledButtonColor;
            }
        }

        private void UpdateCityTab()
        {
            cityIdTextBox.Text = "ID";
            cityIdTextBox.ForeColor = SystemColors.WindowFrame;
            cityNameTextBox.Text = "City Name";
            cityNameTextBox.ForeColor = SystemColors.WindowFrame;
            countryForCityComboBox.SelectedIndex = 0;

            citiesDataGridView.Rows.Clear();
            List<City> allCities = cityBusiness.GetAll();
            foreach (var city in allCities)
            {
                DataGridViewRow newRow = citiesDataGridView.Rows[citiesDataGridView.Rows.Add()];
                int countryId = city.CountryId;
                var country = countryBusiness.Get(countryId);

                newRow.Cells[0].Value = city.Id;
                newRow.Cells[1].Value = city.Name;
                newRow.Cells[2].Value = country.Name;
            }

            UpdateComboBoxesOnCityUpdate();
        }
       
        private void FilterCitiesForCountry(string country)
        {
            var cityNames = new List<string>();
            cityNames.Add("Select City");
            cityNames.AddRange(cityBusiness.GetAllCityNamesFromCountry(country));

            cityForSupplierComboBox.DataSource = cityNames;
        }

        private void CountryForSupplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)countryForSupplierComboBox.SelectedItem != "Select Country")
            {
                string country = (string)countryForSupplierComboBox.SelectedItem;
                FilterCitiesForCountry(country);
                cityForSupplierComboBox.Enabled = true;
            }
            else
            {
                cityForSupplierComboBox.Text = "Select City";
                cityForSupplierComboBox.Enabled = false;
            }
        }

        private void AddSupplierButton_Click(object sender, EventArgs e)
        {
            string supplierName = supplierNameTextBox.Text;
            string supplierIdString = supplierIdTextBox.Text;
            string supplierCity = (string) cityForSupplierComboBox.SelectedItem;
            string supplierCountry = (string)countryForSupplierComboBox.SelectedItem; 
            int supplierId;
            bool canBeParsed = int.TryParse(supplierIdString, out supplierId);

            if (!canBeParsed || supplierName == "Supplier Name" || supplierCity == "Select City")
            {
                MessageBox.Show("Invalid values for supplier");
                return;
            }

            try
            {
                supplierBusiness.Add(supplierName, supplierId, supplierCity, supplierCountry);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            UpdateSupplierTab();
        }

        private void EditSupplierButton_Click(object sender, EventArgs e)
        {
            try
            {
                supplierIdTextBox.Enabled = false;
                var item = suppliersDataGridView.SelectedRows[0].Cells;
                var supplierId = (int)item[0].Value;
                var supplier = supplierBusiness.Get(supplierId);
                supplierIdTextBox.Text = supplier.Id.ToString();
                supplierIdTextBox.ForeColor = SystemColors.WindowText;
                supplierNameTextBox.Text = supplier.Name.ToString();
                supplierNameTextBox.ForeColor = SystemColors.WindowText;

                var city = cityBusiness.Get(supplier.CityId);
                var country = countryBusiness.Get(city.CountryId);

                countryForSupplierComboBox.SelectedItem = country.Name;
                FilterCitiesForCountry(country.Name);
                cityForSupplierComboBox.SelectedItem = city.Name;
            }
            catch
            {
                MessageBox.Show("You haven't selected a row");
                return;
            }

            ToggleSupplierEditSave();
        }

        private void SaveChangesForSupplierButton_Click(object sender, EventArgs e)
        {
            string supplierName = supplierNameTextBox.Text;
            int supplierId = int.Parse(supplierIdTextBox.Text);
            string countryName = countryForSupplierComboBox.Text;
            string cityName = cityForSupplierComboBox.Text;

            if (supplierName == "Supplier Name" || countryName == "Select Country" || cityName == "Select City")
            {
                MessageBox.Show("Invalid values for supplier");
                return;
            }

            supplierBusiness.Update(supplierName, supplierId, countryName, cityName);

            supplierIdTextBox.Enabled = true;
            ToggleSupplierEditSave();
            UpdateSupplierTab();
        }

        private void DeleteSupplierButton_Click(object sender, EventArgs e)
        {
            int supplierId = 0;
            try
            {
                var item = suppliersDataGridView.SelectedRows[0].Cells;
                supplierId = (int)item[0].Value;
            }
            catch
            {
                MessageBox.Show("You haven't selected a row");
                return;
            }

            try
            {
                supplierBusiness.Delete(supplierId);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            UpdateSupplierTab();
        }

        private void ToggleSupplierEditSave()
        {
            if (editSupplierButton.Enabled)
            {
                editSupplierButton.Enabled = false;
                editSupplierButton.BackColor = disabledButtonColor;

                saveChangesForSupplierButton.Enabled = true;
                saveChangesForSupplierButton.BackColor = enabledButtonColor;
            }
            else
            {
                editSupplierButton.Enabled = true;
                editSupplierButton.BackColor = enabledButtonColor;

                saveChangesForSupplierButton.Enabled = false;
                saveChangesForSupplierButton.BackColor = disabledButtonColor;
            }
        }

        private void UpdateSupplierTab()
        {
            supplierIdTextBox.Text = "ID";
            supplierIdTextBox.ForeColor = SystemColors.WindowFrame;
            supplierNameTextBox.Text = "Supplier Name";
            supplierNameTextBox.ForeColor = SystemColors.WindowFrame;
            countryForSupplierComboBox.SelectedIndex = 0;
            cityForSupplierComboBox.SelectedIndex = 0;
            cityForSupplierComboBox.Enabled = false;

            suppliersDataGridView.Rows.Clear();
            List<Supplier> allSuppliers = supplierBusiness.GetAll();
            foreach (var supplier in allSuppliers)
            {
                DataGridViewRow newRow = suppliersDataGridView.Rows[suppliersDataGridView.Rows.Add()];
                var city = cityBusiness.Get(supplier.CityId);
                int countryId = city.CountryId;
                var country = countryBusiness.Get(countryId);

                newRow.Cells[0].Value = supplier.Id;
                newRow.Cells[1].Value = supplier.Name;
                newRow.Cells[2].Value = city.Name;
                newRow.Cells[3].Value = country.Name;
            }
        }

        // All of the following methods are connected with maintaining a clean UI

        private void CountryNameTextBox_Enter(object sender, EventArgs e)
        {
            RemovePromptFromTextBoxWhenTyping(countryNameTextBox, "Country Name");
        }

        private void CountryNameTextBox_Leave(object sender, EventArgs e)
        {
            AddPromptToTextBoxIfEmpty(countryNameTextBox, "Country Name");
        }

        private void CountryIdTextBox_Enter(object sender, EventArgs e)
        {
            RemovePromptFromTextBoxWhenTyping(countryIdTextBox, "ID");
        }

        private void CountryIdTextBox_Leave(object sender, EventArgs e)
        {
            AddPromptToTextBoxIfEmpty(countryIdTextBox, "ID");
        }

        private void CategoryNameTextBox_Enter(object sender, EventArgs e)
        {
            RemovePromptFromTextBoxWhenTyping(categoryNameTextBox, "Category Name");
        }

        private void CategoryNameTextBox_Leave(object sender, EventArgs e)
        {
            AddPromptToTextBoxIfEmpty(categoryNameTextBox, "Category Name");
        }

        private void CategoryIdTextBox_Enter(object sender, EventArgs e)
        {
            RemovePromptFromTextBoxWhenTyping(categoryIdTextBox, "ID");
        }

        private void CategoryIdTextBox_Leave(object sender, EventArgs e)
        {
            AddPromptToTextBoxIfEmpty(categoryIdTextBox, "ID");
        }

        private void CityIdTextBox_Enter(object sender, EventArgs e)
        {
            RemovePromptFromTextBoxWhenTyping(cityIdTextBox, "ID");
        }

        private void CityIdTextBox_Leave(object sender, EventArgs e)
        {
            AddPromptToTextBoxIfEmpty(cityIdTextBox, "ID");
        }

        private void CityNameTextBox_Enter(object sender, EventArgs e)
        {
            RemovePromptFromTextBoxWhenTyping(cityNameTextBox, "City Name");
        }

        private void CityNameTextBox_Leave(object sender, EventArgs e)
        {
            AddPromptToTextBoxIfEmpty(cityNameTextBox, "City Name");
        }

        private void SupplierIdTextBox_Enter(object sender, EventArgs e)
        {
            RemovePromptFromTextBoxWhenTyping(supplierIdTextBox, "ID");
        }

        private void SupplierIdTextBox_Leave(object sender, EventArgs e)
        {
            AddPromptToTextBoxIfEmpty(supplierIdTextBox, "ID");
        }

        private void SupplierNameTextBox_Enter(object sender, EventArgs e)
        {
            RemovePromptFromTextBoxWhenTyping(supplierNameTextBox, "Supplier Name");
        }

        private void SupplierNameTextBox_Leave(object sender, EventArgs e)
        {
            AddPromptToTextBoxIfEmpty(supplierNameTextBox, "Supplier Name");
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

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
