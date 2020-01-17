using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticketing_System_Forms
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        public string qlid
        {
            get { return "bp185150"; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginBtn_pressed_Click(object sender, EventArgs e)
        {
            this.Hide();

            //bp185150 
            if(textBox1.Text == Environment.UserName)
            {
                Form2 frm2 = new Form2();
                frm2.ShowDialog();
                this.Close();
            }

            else
            {
                MessageBox.Show("Incorrect username or password\nTry again.");
            }
            
   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "bp185150";
        }
    }
}
