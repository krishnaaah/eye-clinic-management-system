using Microsoft.VisualBasic;
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
    public partial class usersform : Form
    {
       
        public usersform()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "insert into UserTbl values('" + UnameTb.Text + "','" + UpassTb.Text + "','" + UphoneTb.Text + "')";
            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("User successfully added");
                populate();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        void populate()
        {
            MyPatient Pat = new MyPatient();
            String query = "select * from UserTbl";
            DataSet ds = Pat.ShowPatient(query);
            UserDGV.DataSource = ds.Tables[0];
        }
        private void usersform_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UnameTb.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            UpassTb.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
            UphoneTb.Text = UserDGV.SelectedRows[0].Cells[3].Value.ToString();
            if (UnameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(UserDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select The User");
            }
            else
            {
                try
                {
                    String query = "Update UserTbl set Uname='" + UnameTb.Text + "',Upass='" + UpassTb.Text + "',Phone='" + UphoneTb.Text + "';";
                    Pat.DeletePatient(query);
                    MessageBox.Show("User Successfully Updated");
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select The User");
            }
            else
            {
                try
                {
                    String query = "Delete from UserTbl where UId=" + key + "";
                    Pat.DeletePatient(query);
                    MessageBox.Show("User Successfully Deleted");
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            LOGIN lOGIN = new LOGIN();
            lOGIN.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            patientform pat = new patientform();
            pat.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Treatmentsform treat = new Treatmentsform();
            treat.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Appointments app = new Appointments();
            app.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            prescriptionform pre = new prescriptionform();
            pre.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            usersform user = new usersform();
            user.Show();
            this.Hide();
        }
    }
}
