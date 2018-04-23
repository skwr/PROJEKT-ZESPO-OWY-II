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
    public partial class CustomDebugConsole : Form
    {

        TextBox log;

        TextBox val1;
        Label name1;

        TextBox val2;
        Label name2;

        TextBox val3;
        Label name3;

        TextBox val4;
        Label name4;

        public CustomDebugConsole()
        {
            InitializeComponent();
            Visible = true;
            Location = new Point(0, 0);
            Size = new Size(250, 350);
            Text = "Consola do debugowania";

            log = new TextBox();
            log.Multiline = true;
            log.Parent = this;
            log.Width = ClientSize.Width;
            log.Height = ClientSize.Height/2;
            log.ReadOnly = true;

            val1 = new TextBox();
            val1.Parent = this;
            val1.Width = ClientSize.Width/2;
            val1.TextAlign = HorizontalAlignment.Center;
            val1.ReadOnly = true;
            val1.Location = new Point(0, ClientSize.Height / 2 + 10);
            val1.Text = "val1";
            name1 = new Label();
            name1.Parent = this;
            name1.TextAlign = ContentAlignment.MiddleCenter;
            name1.Width = val1.Width;
            name1.Location = new Point(val1.Location.X, val1.Location.Y + val1.Height + 5);
            name1.Text = "name1";


            val2 = new TextBox();
            val2.Parent = this;
            val2.Width = ClientSize.Width / 2;
            val2.TextAlign = HorizontalAlignment.Center;
            val2.ReadOnly = true;
            val2.Location = new Point(ClientSize.Width/2, ClientSize.Height / 2 + 10);
            val2.Text = "val2";
            name2 = new Label();
            name2.Parent = this;
            name2.TextAlign = ContentAlignment.MiddleCenter;
            name2.Width = val1.Width;
            name2.Location = new Point(val2.Location.X, val2.Location.Y + val2.Height + 5);
            name2.Text = "name2";

            val3 = new TextBox();
            val3.Parent = this;
            val3.Width = ClientSize.Width / 2;
            val3.TextAlign = HorizontalAlignment.Center;
            val3.ReadOnly = true;
            val3.Location = new Point(0, ClientSize.Height / 2 + 20 + val1.Height + name1.Height);
            val3.Text = "val3";
            name3 = new Label();
            name3.Parent = this;
            name3.TextAlign = ContentAlignment.MiddleCenter;
            name3.Width = val3.Width;
            name3.Location = new Point(val3.Location.X, val3.Location.Y + val3.Height + 5);
            name3.Text = "name3";

        }

        public void println(string value)
        {
            try
            {
                log.AppendText(value);
                log.AppendText(Environment.NewLine);
            }
            catch
            {
                MessageBox.Show("Brak uruchomionej konsoli!!!");
            }
            
            
        }

        public void logValue(int cellIndex, string cellName, string value)
        {
            try
            {
                switch (cellIndex)
                {
                    case 0:
                        name1.Text = cellName;
                        val1.Text = value;
                        break;
                    case 1:
                        name2.Text = cellName;
                        val2.Text = value;
                        break;
                    case 2:
                        name3.Text = cellName;
                        val3.Text = value;
                        break;
                    default:
                        println("nieprawidłowy cellIndex");
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Brak uruchomionej konsoli!!!");

            }


        }
    }
}
