using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ecms
{
    public partial class adminform : Form
    {
        public adminform()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            LOGIN lOGIN = new LOGIN();
            lOGIN.Show();
            this.Hide();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(AdminPassTb.Text == "")
            {
                MessageBox.Show("Enter The Admin Password");
            }
            else if(AdminPassTb.Text == "password")
            {
                usersform usersform = new usersform();
                usersform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Password,Contact The Admin");
                AdminPassTb.Text = "";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
