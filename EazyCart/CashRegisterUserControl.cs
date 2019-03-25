using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EazyCart
{
    public partial class CashRegisterUserControl : UserControl
    {
        public CashRegisterUserControl()
        {
            InitializeComponent();
        }

        private void CashRegisterUserControl_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Code", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Category", typeof(string));
            dataTable.Columns.Add("Unit Price", typeof(double));

            dataTable.Rows.Add("#000001", "Apples", "Fruit", 2.05);
            dataTable.Rows.Add("#000002", "Water, 500ml", "Drink" ,1.00);

            availableProductsDataGridView.Rows.Add("#000001", "Apples", "Fruit", 2.05);
            availableProductsDataGridView.Rows.Add("#000002", "Water, 500ml", "Drink",1.00);

            receiptDataGridView.Rows.Add("#000001", "Apples", 2.05, 3, 23, 2.05 * 3 * 77);
            receiptDataGridView.Rows.Add("#000002", "Water, 500ml", 3.42, 5, 10, 3.42 * 5 * 0.9);
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
