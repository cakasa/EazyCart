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
            }

            try
            {
                countryBusiness.Delete(countryId);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
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
