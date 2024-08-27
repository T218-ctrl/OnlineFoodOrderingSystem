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
using System.Xml.Linq;

namespace OnlineFoodOrderingSystem
{
    public partial class Orders : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-UOD7D7D;Database=Food Ordering System;Integrated Security=true");
        public Orders()
        {
            InitializeComponent();
            LoadData();
            LoadItems();
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
            Rest.DataSource = dt;
            Rest.DisplayMember = dt.Columns[1].ToString();
            Rest.ValueMember = dt.Columns[0].ToString();
        }
        void LoadItems()
        {
            SqlCommand cmd = new SqlCommand("Select * from Menu_Items", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Item.DataSource = dt;
            Item.DisplayMember = dt.Columns[1].ToString();
            Item.ValueMember = dt.Columns[0].ToString();
        }
        void LoadData()
        {
            SqlCommand cmd = new SqlCommand("Select * from Orders", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Orders_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Orders(Item_ID,Quantity,Status,Restaurant_ID,Cat_ID) VALUES('" +Item.SelectedValue + "','" + txtQuan.Text + "','" + txtStatus.Text + "','"+Rest.SelectedValue+"','"+Cat.SelectedValue+"')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Order Added Successfully", "Message");
        }

        private void btndlt_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Orders WHERE Order_ID='" + txtID.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Order Deleted Successfully", "Message");

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Order WHERE Order_ID='" + txtID.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("Order with this ID does not exist", "Message");
                return;
            }

            txtQuan.Text = dt.Rows[0][1].ToString();
            txtStatus.Text = dt.Rows[0][2].ToString();
            btnEdit.Visible = false;
            btnUpdate.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Order SET Quantity='" + txtQuan.Text + "', Status='" + txtStatus.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Order Updated Successfully", "Message");
        }
    }
}
