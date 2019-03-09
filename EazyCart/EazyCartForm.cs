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
        private SettingsUserControl settingsUserControl;

        public EazyCartForm()
        {
            InitializeComponent();
        }

        private void EazyCartForm_Load(object sender, EventArgs e)
        {
            cashRegisterUserControl = new CashRegisterUserControl();
            warehouseUserControl = new WarehouseUserControl();
            statisticsUserContol = new StatisticsUserContol();
            settingsUserControl = new SettingsUserControl();

            cashRegisterUserControl.Dock = DockStyle.Bottom;
            warehouseUserControl.Dock = DockStyle.Bottom;
            statisticsUserContol.Dock = DockStyle.Bottom;
            settingsUserControl.Dock = DockStyle.Bottom;

            this.Controls.Add(cashRegisterUserControl);
            this.Controls.Add(warehouseUserControl);
            this.Controls.Add(statisticsUserContol);
            this.Controls.Add(settingsUserControl);

            cashRegisterUserControl.Visible = false;
            warehouseUserControl.Visible = false;
            statisticsUserContol.Visible = false;
            settingsUserControl.Visible = false;

            mainMenuPanel.Visible = false;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WarehouseButton_Click(object sender, EventArgs e)
        {
            // User control switching
            statisticsUserContol.Visible = false;
            cashRegisterUserControl.Visible = false;
            settingsUserControl.Visible = false;

            warehouseUserControl.Visible = true;

            // Main Menu Panel Movement
            mainMenuPanel.Visible = true;
            mainMenuPanel.Location = new Point(598, 57);
        }

        private void StatisticsButton_Click(object sender, EventArgs e)
        {
            // User control switching
            warehouseUserControl.Visible = false;
            cashRegisterUserControl.Visible = false;
            settingsUserControl.Visible = false;

            statisticsUserContol.Visible = true;

            // Main Menu Panel Movement
            mainMenuPanel.Visible = true;
            mainMenuPanel.Location = new Point(854, 57);
        }
        
        private void CashRegisterButton_Click(object sender, EventArgs e)
        {
            // User control switching
            warehouseUserControl.Visible = false;
            statisticsUserContol.Visible = false;
            settingsUserControl.Visible = false;

            cashRegisterUserControl.Visible = true;

            // Main Menu Panel Movement
            mainMenuPanel.Visible = true;
            mainMenuPanel.Location = new Point(342, 57);
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            // User control switching
            warehouseUserControl.Visible = false;
            statisticsUserContol.Visible = false;
            cashRegisterUserControl.Visible = false;

            settingsUserControl.Visible = true;

            // Main Menu Panel Movement
            mainMenuPanel.Visible = true;
            mainMenuPanel.Location = new Point(1110, 57);
        }
    }
}
