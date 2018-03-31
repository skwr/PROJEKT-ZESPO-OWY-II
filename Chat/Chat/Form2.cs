using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat
{
    public partial class Form2 : Form
    {
        public Form2(string DataReceived, string secend)
        {
            InitializeComponent();
            label1.Text = DataReceived;
            this.Text = secend;
            listBox2.Items.Add(this.label1.Text);
        }

        public void label2_Click(object sender, EventArgs e)
        {
           
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                listBox1.Items.Add(this.textBox1.Text);
                this.textBox1.Focus();
                this.textBox1.Clear();
            }
            else
            {
                MessageBox.Show("You did not type the message!");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
