using System;
using System.Drawing;
using System.Windows.Forms;

namespace EazyCart.InteractionForms
{
    /// <summary>
    /// This form is used to display information to
    /// the user so as to show whether or not
    /// his actions have been right.
    /// </summary>
    public partial class MessageForm : Form
    {
        private int mouseX = 0;
        private int mouseY = 0;
        private bool mouseDown;

        /// <summary>
        /// Sets the properties.
        /// </summary>
        /// <param name="message">Message string.</param>
        /// <param name="type">Type of message</param>
        public MessageForm(string message, MessageFormType type)
        {
            InitializeComponent();
            this.messageLabel.Text = message;
            if (type == MessageFormType.Error)
            {
                Image errorImage = Properties.Resources.exclamationMark;
                this.signPictureBox.BackgroundImage = errorImage;
                titleLabel.Text = "Error";
                System.Media.SystemSounds.Hand.Play();
            }
            else
            {
                Image informationImage = Properties.Resources.informationMark;
                this.signPictureBox.BackgroundImage = informationImage;
                titleLabel.Text = "Information";
                System.Media.SystemSounds.Beep.Play();
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

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
