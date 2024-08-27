using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineFoodOrderingSystem
{
    public partial class Restaurants : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-UOD7D7D;Database=Food Ordering System;Integrated Security=true");
        public Restaurants()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            SqlCommand cmd = new SqlCommand("Select * from Restaurant", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtName_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_Click(object sender, EventArgs e)
        {

        }

        private void txtRating_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            SqlCommand cmd = new SqlCommand("INSERT INTO Restaurant VALUES('" + txtName.Text + "','" + txtEmail.Text + "','" + txtPhone.Text + "','" + txtRating.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Restaurant Added Successfully","Message");
        }

        private void btndlt_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Restaurant WHERE Restaurant_ID='"+txtID.Text+"'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Restaurant Deleted Successfully", "Message");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Restaurant WHERE Restaurant_ID='"+txtID.Text+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("Restaurant with this ID does not exist", "Message");
                return;
            }

            txtName.Text = dt.Rows[0][1].ToString();
            txtEmail.Text = dt.Rows[0][2].ToString();
            txtPhone.Text = dt.Rows[0][3].ToString();
            txtRating.Text = dt.Rows[0][4].ToString();

            btnEdit.Visible = false;
            btnUpdate.Visible = true;
        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRating_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Restaurant SET Restaurant_Name='" + txtName.Text + "',Restaurant_Email='" + txtEmail.Text + "',Restaurant_phone='" + txtPhone.Text + "',Rating='" + txtRating.Text + "' WHERE Restaurant_ID='"+txtID.Text+"'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Restaurant Updated Successfully", "Message");
        }
    }
}
