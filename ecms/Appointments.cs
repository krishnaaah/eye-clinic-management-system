using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ecms
{
    public partial class Appointments : Form
    {
        public Appointments()
        {
            InitializeComponent();
        }
         
        int key = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            string query = "insert into AppointmentTbl values('" + NameTb.Text + "','" + TreatmentTb.Text + "','" + Date.Value.Date + "','" + Time.Value.TimeOfDay + "')";
            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("Appointment successfully added");
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
            String query = "select * from AppointmentTbl";
            DataSet ds = Pat.ShowPatient(query);
            AppointmentDGV.DataSource = ds.Tables[0];
        }
        
        private void Appointments_Load(object sender, EventArgs e)
        {
            
            populate();
        }
        private void AppointmentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = AppointmentDGV.SelectedRows[0].Cells[1].Value.ToString();
            TreatmentTb.Text = AppointmentDGV.SelectedRows[0].Cells[2].Value.ToString();
            if (NameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(AppointmentDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select The Appointment");
            }
            else
            {
                try
                {
                    String query = "Update AppointmentTbl set Patient='" + NameTb.Text + "',Treatment='" + TreatmentTb.Text + "',ApDate='" + Date.Value.Date + "',ApTime= '"+ Time.Value.TimeOfDay+"' where ApId= " + key + ";";
                    Pat.DeletePatient(query);
                    MessageBox.Show("Appointment Successfully Updated");
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
                MessageBox.Show("Select The Patient");
            }
            else
            {
                try
                {
                    String query = "Delete from AppointmentTbl where ApId=" + key + "";
                    Pat.DeletePatient(query);
                    MessageBox.Show("Appointment Successfully Deleted");
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
