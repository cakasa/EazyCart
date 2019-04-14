using Business.Controllers;
using Data.Models;
using EazyCart.InteractionForms;
using EazyCart.UserControls;
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
        public CashRegisterUserControl CashRegisterUserControl { get; private set; }
        public WarehouseUserControl WarehouseUserControl { get; private set; }
        public LogisticsUserControl logisticsUserControl { get; private set; }
        private StatisticsUserContol statisticsUserContol;    
        private GreetingScreenUserControl greetingScreenUserControl;

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
            this.LoadEazyCartForm();
        }

        /// <summary>
        /// This method is called when the application is first started to
        /// initialize everything.
        /// </summary>
        private void LoadEazyCartForm()
        {
            this.InitializeFormUserControls();
            this.mainMenuPanel.Visible = false;
            this.AddUnitsIfTheyAreNotInTheDatabase();         
        }

        /// <summary>
        /// Initialize the User Controls, add them to the form
        /// and set their position
        /// </summary>
        private void InitializeFormUserControls()
        {
            this.CashRegisterUserControl = new CashRegisterUserControl();
            this.WarehouseUserControl = new WarehouseUserControl();
            this.statisticsUserContol = new StatisticsUserContol();
            this.logisticsUserControl = new LogisticsUserControl();
            this.greetingScreenUserControl = new GreetingScreenUserControl();

            this.CashRegisterUserControl.Dock = DockStyle.Bottom;
            this.WarehouseUserControl.Dock = DockStyle.Bottom;
            this.statisticsUserContol.Dock = DockStyle.Bottom;
            this.logisticsUserControl.Dock = DockStyle.Bottom;
            this.greetingScreenUserControl.Dock = DockStyle.Bottom;

            this.Controls.Add(CashRegisterUserControl);
            this.Controls.Add(WarehouseUserControl);
            this.Controls.Add(statisticsUserContol);
            this.Controls.Add(logisticsUserControl);
            this.Controls.Add(greetingScreenUserControl);

            this.CashRegisterUserControl.Visible = false;
            this.WarehouseUserControl.Visible = false;
            this.statisticsUserContol.Visible = false;
            this.logisticsUserControl.Visible = false;
            this.greetingScreenUserControl.Visible = true;
        }

        /// <summary>
        /// Add units the first time the application is started or when
        /// the database is reset.
        /// </summary>
        private void AddUnitsIfTheyAreNotInTheDatabase()
        {
            var eazyCartContext = new EazyCartContext();
            this.unitBusiness = new UnitBusiness(eazyCartContext);
            if (this.unitBusiness.GetNumberOfUnits() == 0)
            {
                this.unitBusiness.Add(1, "Unit", "UN");
                this.unitBusiness.Add(2, "Kilogram", "KG");
                this.unitBusiness.Add(3, "Litre", "L");
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
            var receiptDataGridView = (DataGridView)this.CashRegisterUserControl.Controls["receiptDataGridView"];

            // If the receipt is not empty, prompt the user to cancel it 
            // before closing it.
            if (receiptDataGridView.Rows.Count != 0)
            {
                string message = "You have an uncompleted order.";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
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
                this.statisticsUserContol,
                this.logisticsUserControl,
                this.WarehouseUserControl,
            };

            Point mainMenuPanelLocationPoint = new Point(270, 48);
            this.UserControlChanged(userControlsToMakeInvisible, this.CashRegisterUserControl, mainMenuPanelLocationPoint);
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
                this.CashRegisterUserControl,
                this.logisticsUserControl,
                this.statisticsUserContol,
            };

            Point mainMenuPanelLocationPoint = new Point(488, 48);
            UserControlChanged(userControlsToMakeInvisible, this.WarehouseUserControl, mainMenuPanelLocationPoint);
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
                this.statisticsUserContol,
                this.CashRegisterUserControl,
                this.WarehouseUserControl,
            };

            Point mainMenuPanelLocationPoint = new Point(706, 48);
            UserControlChanged(userControlsToMakeInvisible, this.logisticsUserControl, mainMenuPanelLocationPoint);
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
                this.CashRegisterUserControl,
                this.logisticsUserControl,
                this.WarehouseUserControl,
            };

            Point mainMenuPanelLocationPoint = new Point(924, 48);
            UserControlChanged(userControlsToMakeInvisible, this.statisticsUserContol, mainMenuPanelLocationPoint);
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
            if (this.greetingScreenUserControl != null)
            {
                this.greetingScreenUserControl.Dispose();
            }

            var receiptDataGridView = (DataGridView)CashRegisterUserControl.Controls["receiptDataGridView"];

            // If the receipt is not empty, prompt the user to cancel it 
            // before closing it.
            if (receiptDataGridView.Rows.Count != 0)
            {
                string message = "You have an uncompleted order.";
                MessageForm messageForm = new MessageForm(message, MessageFormType.Error);
                messageForm.ShowDialog();
                return;
            }

            foreach (var userControl in userControlsToInvisible)
            {
                userControl.Visible = false;
            }
            userControlToVisible.Visible = true;

            this.mainMenuPanel.Visible = true;
            this.mainMenuPanel.Location = mainMenuPanelLocationPoint;
        }

        // Making the app movable with the use of the menu panel
        /// <summary>
        /// The event triggers when the user holds down the panel with a mouse.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuPanel_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDown = true;
            this.mouseX = e.X;
            this.mouseY = e.Y;
        }

        /// <summary>
        /// The event triggers when the user moves the mouse to the desired position.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDown == true)
            {
                this.SetDesktopLocation(MousePosition.X - this.mouseX, MousePosition.Y - this.mouseY);
            }
        }

        /// <summary>
        /// The event triggers when the user stops holding the panel with a mouse.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuPanel_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDown = false;
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
