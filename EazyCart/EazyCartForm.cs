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
        public WarehouseUserControl warehouseUserControl;
        private StatisticsUserContol statisticsUserContol;
        private SettingsUserControl settingsUserControl;
        private ManagementUserControl managementUserControl;

        public EazyCartForm()
        {
            InitializeComponent();
            InitializeFormUserControls();
        }

        private void InitializeFormUserControls()
        {
            cashRegisterUserControl = new CashRegisterUserControl();
            warehouseUserControl = new WarehouseUserControl();
            statisticsUserContol = new StatisticsUserContol();
            settingsUserControl = new SettingsUserControl();
            managementUserControl = new ManagementUserControl();
        }

        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void EazyCartForm_Load(object sender, EventArgs e)
        {
            cashRegisterUserControl.Dock = DockStyle.Bottom;
            warehouseUserControl.Dock = DockStyle.Bottom;
            statisticsUserContol.Dock = DockStyle.Bottom;
            settingsUserControl.Dock = DockStyle.Bottom;
            managementUserControl.Dock = DockStyle.Bottom;

            this.Controls.Add(cashRegisterUserControl);
            this.Controls.Add(warehouseUserControl);
            this.Controls.Add(statisticsUserContol);
            this.Controls.Add(settingsUserControl);
            this.Controls.Add(managementUserControl);

            cashRegisterUserControl.Visible = false;
            warehouseUserControl.Visible = false;
            statisticsUserContol.Visible = false;
            settingsUserControl.Visible = false;
            managementUserControl.Visible = false;

            mainMenuPanel.Visible = false;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WarehouseButton_Click(object sender, EventArgs e)
        {
            // User control switching
            statisticsUserContol.Visible = false;
            cashRegisterUserControl.Visible = false;
            settingsUserControl.Visible = false;
            managementUserControl.Visible = false;

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
            managementUserControl.Visible = false;

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
            managementUserControl.Visible = false;

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
            managementUserControl.Visible = false;

            settingsUserControl.Visible = true;

            // Main Menu Panel Movement
            mainMenuPanel.Visible = true;
            mainMenuPanel.Location = new Point(1110, 57);
        }

        private void ManagementButton_Click(object sender, EventArgs e)
        {
            warehouseUserControl.Visible = false;
            statisticsUserContol.Visible = false;
            cashRegisterUserControl.Visible = false;
            settingsUserControl.Visible = false;

            managementUserControl.Visible = true;

            // Main Menu Panel Movement
            mainMenuPanel.Visible = true;
            mainMenuPanel.Location = new Point(1110, 57);
        }
                
        // Making the app movable with the use of the menu panel 
        private void MenuPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void MenuPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                this.SetDesktopLocation(MousePosition.X - mouseX, MousePosition.Y - mouseY);
            }
        }

        private void MenuPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }       
    }
}
