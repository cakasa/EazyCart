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

        private void DiscountCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (discountCheckBox.Checked)
            {
                discountPercentageTextBox.Enabled = true;
            }
            else discountPercentageTextBox.Enabled = false;
            
        }
    }
}
