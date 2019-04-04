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
    /// <summary>
    /// The form responsible for managing payments on receipts
    /// </summary>
    public partial class PayForm : Form
    { 
        private readonly Color promptTextColor = SystemColors.WindowFrame;
        private readonly Color activeTextColor = SystemColors.WindowText;

        private int mouseX = 0;
        private int mouseY = 0;
        private bool mouseDown;

        public decimal grandTotal;
        public decimal enteredAmount;

        public PayForm(decimal grandTotal)
        {
            InitializeComponent();
            this.grandTotal = grandTotal;
            this.grandTotalCashLabel.Text = string.Format($"$ {this.grandTotal}");
        }

        /// <summary>
        /// This event is triggerred when one begins typing in a textBox.
        /// If the textBox had a prompt beforehand, it is removed.
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="prompt"></param>
        private void PayingAmountTextBox_Enter(object sender, EventArgs e)
        {
            if (this.payingAmountTextBox.Text == "Enter cash amount")
            {
                this.payingAmountTextBox.Text = string.Empty;
                this.payingAmountTextBox.ForeColor = activeTextColor;
            }
        }

        /// <summary>
        /// This event is triggered when one stops typing in a textBox.
        /// If the textBox was left empty, a prompt, suitable for the textbox, would be added.
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="prompt"></param>
        private void PayingAmountTextBox_Leave(object sender, EventArgs e)
        {
            if (this.payingAmountTextBox.Text == string.Empty)
            {
                this.payingAmountTextBox.Text = "Enter cash amount";
                this.payingAmountTextBox.ForeColor = promptTextColor;
            }
        }

        /// <summary>
        /// This event is triggered when the make payment button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakePaymentButton_Click(object sender, EventArgs e)
        {
            string cashString = this.payingAmountTextBox.Text;
            decimal cash = 0;

            // Perform validation
            try
            {
                cash = decimal.Parse(cashString);
            }
            catch
            {
                MessageBox.Show("Please enter a valid amount of money");
                return;
            }

            if(cash < this.grandTotal)
            {
                MessageBox.Show("Cash amount is less than the amount to pay");
                return;
            }

            this.enteredAmount = cash;
            this.Visible = false;
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

        /// <summary>
        /// Implements a shortcut for the 'Make Payment' button. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayingAmountTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.MakePaymentButton_Click(this, new EventArgs());
            }
        }

        /// <summary>
        /// Closes the PayForm without making any changes to the cashRegisterUserControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
