using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EazyCart
{
    public partial class EazyCartForm : Form
    {
        private CashRegisterUserControl cashRegisterUserControl;
        private WarehouseUserControl warehouseUserControl;
        private StatisticsUserContol statisticsUserContol;

        public EazyCartForm()
        {
            InitializeComponent();
        }

        private void EazyCartForm_Load(object sender, EventArgs e)
        {
            cashRegisterUserControl = new CashRegisterUserControl();
            warehouseUserControl = new WarehouseUserControl();
            statisticsUserContol = new StatisticsUserContol();

            cashRegisterUserControl.Dock = DockStyle.Bottom;
            warehouseUserControl.Dock = DockStyle.Bottom;
            statisticsUserContol.Dock = DockStyle.Bottom;

            this.Controls.Add(cashRegisterUserControl);
            this.Controls.Add(warehouseUserControl);
            this.Controls.Add(statisticsUserContol);

            cashRegisterUserControl.Visible = false;
            warehouseUserControl.Visible = false;
            statisticsUserContol.Visible = false;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WarehouseButton_Click(object sender, EventArgs e)
        {

            statisticsUserContol.Visible = false;
            cashRegisterUserControl.Visible = false;

            warehouseUserControl.Visible = true;
        }

        private void StatisticsButton_Click(object sender, EventArgs e)
        {
            warehouseUserControl.Visible = false;
            cashRegisterUserControl.Visible = false;

            statisticsUserContol.Visible = true;
        }

        
        private void CashRegisterButton_Click(object sender, EventArgs e)
        {

            warehouseUserControl.Visible = false;
            statisticsUserContol.Visible = false;

            cashRegisterUserControl.Visible = true;
        }
    }
}
