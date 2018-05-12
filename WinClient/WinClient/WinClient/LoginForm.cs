using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinClient
{
    public partial class LoginForm : Form
    {
        Panel mainPanel;
        Label label;
        public TextBox nickNameTextBox;
        public Button loginButton;

        public LoginForm()
        {
            InitializeComponent();

            Width = 300;
            Height = 150;
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - Height / 2);

            mainPanel = new Panel();
            mainPanel.Parent = this;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Width = ClientSize.Width;
            mainPanel.Height = ClientSize.Height;

            label = new Label();
            label.Parent = mainPanel;
            label.Text = "Podaj swój nick:";
            label.Location = new Point(label.Parent.ClientSize.Width / 2 - label.Width / 2, 10);

            nickNameTextBox = new TextBox();
            nickNameTextBox.Parent = mainPanel;
            nickNameTextBox.Width = (int)(nickNameTextBox.Parent.ClientSize.Width * 0.8);
            nickNameTextBox.Location = new Point(nickNameTextBox.Parent.ClientSize.Width / 2 - nickNameTextBox.Width / 2, nickNameTextBox.Parent.ClientSize.Height / 2 - nickNameTextBox.Height);

            loginButton = new Button();
            loginButton.Text = "Zaloguj";
            loginButton.Parent = mainPanel;
            loginButton.Location = new Point(loginButton.Parent.ClientSize.Width / 2 - loginButton.Width / 2, loginButton.Parent.ClientSize.Height - (loginButton.Height + 10));
            loginButton.Click += new EventHandler(Login_Clicked);


            Show();
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            /*if (nickNameTextBox.Text != String.Empty)
            {
                Form1 chatWindow = new Form1();
                this.Dispose();
            }*/
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
