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
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                Form2 frm2 = new Form2(textBox1.Text, "Chat");
                frm2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You did not type your nickname!");
            }
            

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
