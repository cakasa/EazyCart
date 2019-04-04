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
    public partial class MessageForm : Form
    {
        private int mouseX = 0;
        private int mouseY = 0;
        private bool mouseDown;

        public MessageForm(string message, MessageFormType type)
        {
            InitializeComponent();
            this.messageLabel.Text = message;
            if (type == MessageFormType.Error)
            {
                Image errorImage = Properties.Resources.exclamationMark;
                this.signPictureBox.Image = errorImage;
                titleLabel.Text = "Error";
            }
            else
            {
                Image informationImage = Properties.Resources.informationMark;
                this.signPictureBox.Image = informationImage;
                titleLabel.Text = "Information";
            }
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

        private void MakePaymentButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
