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
    public partial class patientform : Form
    {
        public patientform()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "insert into PatientTbl values('" + PatNameTb.Text + "','" + PatPhoneTb.Text + "','" + AddressTb.Text + "','" + DOBDate.Value.Date + "','" + GenderCb.SelectedItem.ToString() + "','" + AllergyTb.Text + "')";
            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("patient successfully added");
                populate();
            }catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            
        }
        void populate()
        {
            MyPatient Pat = new MyPatient();
            String query = "select * from PatientTbl";
            DataSet ds = Pat.ShowPatient(query);
            PatientDGV.DataSource = ds.Tables[0];
        }
        private void patientform_Load(object sender, EventArgs e)
        {
            populate();
        }
        int key = 0;
        private void PatientDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PatNameTb.Text = PatientDGV.SelectedRows[0].Cells[1].Value.ToString();
            PatPhoneTb.Text = PatientDGV.SelectedRows[0].Cells[2].Value.ToString();
            AddressTb.Text = PatientDGV.SelectedRows[0].Cells[3].Value.ToString();
            GenderCb.SelectedItem = PatientDGV.SelectedRows[0].Cells[5].Value.ToString();
            AllergyTb.Text = PatientDGV.SelectedRows[0].Cells[6].Value.ToString();
            if(PatNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PatientDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if(key == 0)
            {
                MessageBox.Show("Select The Patient");
            }else
            {
                try
                {
                    String query = "Delete from PatientTbl where PatId=" + key + "";
                    Pat.DeletePatient(query);
                    MessageBox.Show("Patient Successfully Deleted");
                    populate();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
             
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select The Patient");
            }
            else
            {
                try
                {
                    String query = "Update PatientTbl set PatName='" + PatNameTb.Text + "',PatPhone='" + PatPhoneTb.Text + "',PatAddress='" + AddressTb.Text + "',PatDOB='" + DOBDate.Value.Date + "',PatGender='" + GenderCb.SelectedItem.ToString() + "',PatAllergies='" + AllergyTb.Text + "' where PatId= " + key + ";";
                    Pat.DeletePatient(query);
                    MessageBox.Show("Patient Successfully Updated");
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Treatmentsform treatmentsform = new Treatmentsform();
            treatmentsform.Show();
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

        private void label12_Click(object sender, EventArgs e)
        {
            LOGIN lOGIN = new LOGIN();
            lOGIN.Show();
            this.Hide();
        }
    }
}
