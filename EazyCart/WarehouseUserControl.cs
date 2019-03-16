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
    public partial class WarehouseUserControl : UserControl
    {
        public WarehouseUserControl()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pricingGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void generalPropertiesGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void WarehouseUserControl_Load(object sender, EventArgs e)
        {
            allProductsDataGridView.Rows.Add("#012345", "Sugar", "Sweetener", 300, "UN", "Sugar For Life LTD", "Bulgaria", "Sofia", 2.30, 3.20);
        }

        private void allProductsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
