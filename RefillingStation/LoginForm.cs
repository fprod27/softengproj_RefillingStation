using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RefillingStation
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "waterforless")
            {
                MainForm m = new MainForm();
                m.Show();
                this.Hide();
                
                
            }
            else
            {
                MessageBox.Show("Wrong Password",null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
    }
}
