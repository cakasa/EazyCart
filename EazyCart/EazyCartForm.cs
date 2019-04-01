﻿using Business;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EazyCart
{
    /// <summary>
    /// This is the main form, containing all the user controls.
    /// </summary>
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

        /// <summary>
        /// This method is called when the application is first started to
        /// initialize everything.
        /// </summary>
        private void LoadEazyCartForm()
        {
            InitializeFormUserControls();
            mainMenuPanel.Visible = false;
            AddUnitsIfTheyAreNotInTheDatabase();         
        }

        /// <summary>
        /// Initialize the User Controls, add them to the form
        /// and set their position
        /// </summary>
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

        /// <summary>
        /// Add units the first time the application is started or when
        /// the database is reset.
        /// </summary>
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

        /// <summary>
        /// This event is triggered when the user clicks the 'Close' button.
        /// If no order has been initialized, the application closes successfully.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            var receiptDataGridView = (DataGridView) cashRegisterUserControl.Controls["receiptDataGridView"];

            // If the receipt is not empty, prompt the user to cancel it 
            // before closing it.
            if (receiptDataGridView.Rows.Count != 0)
            {
                MessageBox.Show("You have an uncompleted order.");
                return;
            }
            this.Close();
        }

        /// <summary>
        /// This event is triggered when the user clicks on the 'Cash Register' button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This event is triggered when the user clicks on the 'Warehouse' button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This event is triggered when the user clicks on the 'Management' button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This event is triggered when the user clicks on the 'Statistics' button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        
        /// <summary>
        /// This method is supposed to change the state of the userControls
        /// so the one, which is called becomes visible and the others, invisible
        /// Also moves the highlight panel to the appropriate space
        /// </summary>
        /// <param name="userControlsToInvisible">List of the userControls to become invisible</param>
        /// <param name="userControlToVisible">The userControl to become visible</param>
        /// <param name="mainMenuPanelLocationPoint">A point, which sets the location of the highlight panel</param>
        private void UserControlChanged
            (List<UserControl> userControlsToInvisible, UserControl userControlToVisible, Point mainMenuPanelLocationPoint)
        {
            foreach (var userControl in userControlsToInvisible)
            {
                userControl.Visible = false;
            }
            userControlToVisible.Visible = true;

            mainMenuPanel.Visible = true;
            mainMenuPanel.Location = mainMenuPanelLocationPoint;
        }

        // Making the app movable with the use of the menu panel
        /// <summary>
        /// The event triggers when the user holds down the panel with a mouse.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseX = e.X;
            mouseY = e.Y;
        }

        /// <summary>
        /// The event triggers when the user moves the mouse to the desired position.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                this.SetDesktopLocation(MousePosition.X - mouseX, MousePosition.Y - mouseY);
            }
        }

        /// <summary>
        /// The event triggers when the user stops holding the panel with a mouse.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }       
    }
}
