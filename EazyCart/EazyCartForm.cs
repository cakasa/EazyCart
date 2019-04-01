using Business;
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
        public CashRegisterUserControl cashRegisterUserControl { get; private set; }
        public WarehouseUserControl warehouseUserControl { get; private set; }
        private StatisticsUserContol statisticsUserContol;
        private ManagementUserControl managementUserControl;

        private int mouseX = 0;
        private int mouseY = 0;
        private bool mouseDown;

        private UnitBusiness unitBusiness;

        public EazyCartForm()
        {
            InitializeComponent();
        }

        private void EazyCartForm_Load(object sender, EventArgs e)
        {
            LoadEazyCartForm();
        }

        private void LoadEazyCartForm()
        {
            InitializeFormUserControls();
            mainMenuPanel.Visible = false;
            AddUnitsIfTheyAreNotInTheDatabase();         
        }

        private void InitializeFormUserControls()
        {
            cashRegisterUserControl = new CashRegisterUserControl();
            warehouseUserControl = new WarehouseUserControl();
            statisticsUserContol = new StatisticsUserContol();
            managementUserControl = new ManagementUserControl();

            cashRegisterUserControl.Dock = DockStyle.Bottom;
            warehouseUserControl.Dock = DockStyle.Bottom;
            statisticsUserContol.Dock = DockStyle.Bottom;
            managementUserControl.Dock = DockStyle.Bottom;

            this.Controls.Add(cashRegisterUserControl);
            this.Controls.Add(warehouseUserControl);
            this.Controls.Add(statisticsUserContol);
            this.Controls.Add(managementUserControl);

            cashRegisterUserControl.Visible = false;
            warehouseUserControl.Visible = false;
            statisticsUserContol.Visible = false;
            managementUserControl.Visible = false;
        }

        private void AddUnitsIfTheyAreNotInTheDatabase()
        {
            unitBusiness = new UnitBusiness();
            if (unitBusiness.GetNumberOfUnits() == 0)
            {
                unitBusiness = new UnitBusiness();
                unitBusiness.Add(1, "Unit", "UN");
                unitBusiness.Add(2, "Kilogram", "KG");
                unitBusiness.Add(3, "Litre", "L");
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            var receiptDataGridView = (DataGridView) cashRegisterUserControl.Controls["receiptDataGridView"];
            if (receiptDataGridView.Rows.Count != 0)
            {
                MessageBox.Show("You have an uncompleted order.");
                return;
            }
            this.Close();
        }

        private void WarehouseButton_Click(object sender, EventArgs e)
        {
            var userControlsToMakeInvisible = new List<UserControl>
            {
                cashRegisterUserControl,
                managementUserControl,
                statisticsUserContol,
            };

            Point mainMenuPanelLocationPoint = new Point(598, 57);
            UserControlChanged(userControlsToMakeInvisible, warehouseUserControl, mainMenuPanelLocationPoint);
        }

        private void UserControlChanged
            (List<UserControl> userControlsToInvisible, UserControl userControlToVisible, Point mainMenuPanelLocationPoint)
        {
            foreach(var userControl in userControlsToInvisible)
            {
                userControl.Visible = false;
            }
            userControlToVisible.Visible = true;

            mainMenuPanel.Visible = true;
            mainMenuPanel.Location = mainMenuPanelLocationPoint;
        }

        private void StatisticsButton_Click(object sender, EventArgs e)
        {
            var userControlsToMakeInvisible = new List<UserControl>
            {
                cashRegisterUserControl,
                managementUserControl,
                warehouseUserControl,
            };

            Point mainMenuPanelLocationPoint = new Point(1110, 57);
            UserControlChanged(userControlsToMakeInvisible, statisticsUserContol, mainMenuPanelLocationPoint);
        }
        
        private void CashRegisterButton_Click(object sender, EventArgs e)
        {
            var userControlsToMakeInvisible = new List<UserControl>
            {
                statisticsUserContol,
                managementUserControl,
                warehouseUserControl,
            };

            Point mainMenuPanelLocationPoint = new Point(342, 57);
            UserControlChanged(userControlsToMakeInvisible, cashRegisterUserControl, mainMenuPanelLocationPoint);
        }

        private void ManagementButton_Click(object sender, EventArgs e)
        {
            var userControlsToMakeInvisible = new List<UserControl>
            {
                statisticsUserContol,
                cashRegisterUserControl,
                warehouseUserControl,
            };

            Point mainMenuPanelLocationPoint = new Point(854, 57);
            UserControlChanged(userControlsToMakeInvisible, managementUserControl, mainMenuPanelLocationPoint);
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
