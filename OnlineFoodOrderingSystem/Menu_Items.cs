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
    public partial class Menu_Items : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-UOD7D7D;Database=Food Ordering System;Integrated Security=true");
        public Menu_Items()
        {
            InitializeComponent();
            LoadData();
            LoadRest();
            LoadCats();
        }
        void LoadCats()
        {
            SqlCommand cmd = new SqlCommand("Select * from Categories", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Cat.DataSource = dt;
            Cat.DisplayMember = dt.Columns[1].ToString();
            Cat.ValueMember = dt.Columns[0].ToString();
        }
        void LoadRest()
        {
            SqlCommand cmd = new SqlCommand("Select * from Restaurant", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlRest.DataSource = dt;
            ddlRest.DisplayMember = dt.Columns[1].ToString();
            ddlRest.ValueMember = dt.Columns[0].ToString();
        }
        void LoadData()
        {
            SqlCommand cmd = new SqlCommand("Select * from Menu_Items", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Menu_Items (Item_Name,Item_Price,Item_Description,Restaurant_ID,Cat_ID) VALUES('" + txtName.Text + "','" + txtPrice.Text + "','" + txtDesc.Text + "','"+ddlRest.SelectedValue+ "','"+Cat.SelectedValue+"')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Item Added Successfully", "Message");
        }

        private void btndlt_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Menu_Items WHERE Item_ID='" + txtID.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Item Deleted Successfully", "Message");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Menu_Items WHERE Item_ID='" + txtID.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("Item with this ID does not exist", "Message");
                return;
            }

            txtName.Text = dt.Rows[0][1].ToString();
            txtPrice.Text = dt.Rows[0][2].ToString();
            txtDesc.Text = dt.Rows[0][3].ToString();
            btnEdit.Visible = false;
            btnUpdate.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
                SqlCommand cmd = new SqlCommand("UPDATE Menu_Items SET Item_Name='" + txtName.Text + "',Item_Price='" + txtPrice.Text + "',Item_Description='" + txtDesc.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Menu Updated Successfully", "Message");
           
        }

        private void Menu_Items_Load(object sender, EventArgs e)
        {

        }
    }
}
