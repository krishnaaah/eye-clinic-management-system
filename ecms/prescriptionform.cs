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
    public partial class prescriptionform : Form
    {
        public prescriptionform()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "insert into PrescriptionTbl values('" + PrescNameTb.Text + "','" + PrescTreatTb.Text + "','" + MedicineTb.Text + "','"+ CostTb.Text +"','"+ QuatityTb.Text +"')";
            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("Prescription successfully added");
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
            String query = "select * from PrescriptionTbl";
            DataSet ds = Pat.ShowPatient(query);
            PrescriptionDGV.DataSource = ds.Tables[0];
        }
        private void prescriptionform_Load(object sender, EventArgs e)
        {
            populate();
        }
        int key = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select The Prescription");
            }
            else
            {
                try
                {
                    String query = "Update PrescriptionTbl set PatName='" + PrescNameTb.Text + "',TreatName='" + PrescTreatTb.Text + "',Medicines='" + MedicineTb.Text + "',MedQty='"+ QuatityTb.Text+"' where PrescId= " + key + ";";
                    Pat.DeletePatient(query);
                    MessageBox.Show("Prescription Successfully Updated");
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void PrescriptionDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            PrescNameTb.Text = PrescriptionDGV.SelectedRows[0].Cells[1].Value.ToString();
            PrescTreatTb.Text = PrescriptionDGV.SelectedRows[0].Cells[2].Value.ToString();
            MedicineTb.Text = PrescriptionDGV.SelectedRows[0].Cells[3].Value.ToString();
            CostTb.Text = PrescriptionDGV.SelectedRows[0].Cells[4].Value.ToString();
            QuatityTb.Text = PrescriptionDGV.SelectedRows[0].Cells[5].Value.ToString();

            if (PrescNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PrescriptionDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select The Prescription");
            }
            else
            {
                try
                {
                    String query = "Delete from PrescriptionTbl where PrescId=" + key + "";
                    Pat.DeletePatient(query);
                    MessageBox.Show("Prescription Successfully Deleted");
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

        private void label12_Click(object sender, EventArgs e)
        {
            LOGIN log = new LOGIN();
            log.Show();
            this.Hide();
        }
    }
}
