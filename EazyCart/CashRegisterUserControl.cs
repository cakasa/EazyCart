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

        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox2.SelectedIndex;
            ChangeListBoxSelection(index);
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            ChangeListBoxSelection(index);
        }

        private void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox3.SelectedIndex;
            ChangeListBoxSelection(index);
        }

        private void ListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox4.SelectedIndex;
            ChangeListBoxSelection(index);
        }

        private void ChangeListBoxSelection(int index)
        {
            listBox1.SelectedIndex = index;
            listBox2.SelectedIndex = index;
            listBox3.SelectedIndex = index;
            listBox4.SelectedIndex = index;
        }
    }
}
