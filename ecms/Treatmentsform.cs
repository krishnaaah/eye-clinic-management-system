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
    public partial class Treatmentsform : Form
    {
        public Treatmentsform()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "insert into TreatmentTbl values('" + TreatNameTb.Text + "','" + TreatCostTb.Text + "','" + TreatDesc.Text + "')";
            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("Treatment successfully added");
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
            String query = "select * from TreatmentTbl";
            DataSet ds = Pat.ShowPatient(query);
            TreatmentsDGV.DataSource = ds.Tables[0];
        }
        private void Treatmentsform_Load(object sender, EventArgs e)
        {
            populate();
        }
        int key = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select The Treatment");
            }
            else
            {
                try
                {
                    String query = "Update TreatmentTbl set TreatName='" + TreatNameTb.Text + "',TreatCost='" + TreatCostTb.Text + "',TreatDesc='" + TreatDesc.Text + "' where TreatId= " + key + ";";
                    Pat.DeletePatient(query);
                    MessageBox.Show("Treatment Successfully Updated");
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void TreatmentsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            TreatNameTb.Text = TreatmentsDGV.SelectedRows[0].Cells[1].Value.ToString();
            TreatCostTb.Text = TreatmentsDGV.SelectedRows[0].Cells[2].Value.ToString();
            TreatDesc.Text = TreatmentsDGV.SelectedRows[0].Cells[3].Value.ToString();
             
            if (TreatNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TreatmentsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select The Treatment");
            }
            else
            {
                try
                {
                    String query = "Delete from TreatmentTbl where TreatId=" + key + "";
                    Pat.DeletePatient(query);
                    MessageBox.Show("Treatment Successfully Deleted");
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

        private void label9_Click(object sender, EventArgs e)
        {
            
        }
    }
}
