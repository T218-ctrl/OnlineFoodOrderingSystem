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
    public partial class Categories : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-UOD7D7D;Database=Food Ordering System;Integrated Security=true");
        public Categories()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            SqlCommand cmd = new SqlCommand("Select * from Categories", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Categories_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Categories VALUES('" + txtName.Text + "','" + txtDesc.Text + "')",con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Category Added Successfully", "Message");
        }

        private void btndlt_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Categories WHERE Cat_ID='" + txtID.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Category Deleted Successfully", "Message");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Categories WHERE Cat_ID='" + txtID.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("Category with this ID does not exist", "Message");
                return;
            }
            txtName.Text = dt.Rows[0][1].ToString();
            txtDesc.Text = dt.Rows[0][2].ToString();
            btnEdit.Visible = false;
            btnUpdate.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Categories SET Cat_Name='" + txtName.Text + "',Cat_Desc='" + txtDesc.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Category Updated Successfully", "Message");
        }
    }
}
