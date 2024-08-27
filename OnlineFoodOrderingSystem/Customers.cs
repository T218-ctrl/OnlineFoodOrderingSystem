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
    public partial class Customers : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-UOD7D7D;Database=Food Ordering System;Integrated Security=true");
        public Customers()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            SqlCommand cmd = new SqlCommand("Select * from Customers", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Customers VALUES('"+txtName.Text+"','"+txtEmail.Text+"','"+txtPhone.Text+"','" + txtaddress.Text+"','"+txtpassword.Text+"')",con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Customer Added Successfully", "Message");
        }

        private void btndlt_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE Customer_ID='" + txtID.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Customer Deleted Successfully", "Message");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE Customer_ID='" + txtID.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("Customer with this ID does not exist", "Message");
                return;
            }

            txtName.Text = dt.Rows[0][1].ToString();
            txtEmail.Text = dt.Rows[0][2].ToString();
            txtPhone.Text = dt.Rows[0][3].ToString();
            txtaddress.Text = dt.Rows[0][4].ToString();
            txtpassword.Text = dt.Rows[0][5].ToString();
            btnEdit.Visible = false;
            btnUpdate.Visible = true;
        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Customers SET Cust_Name='" + txtName.Text + "',Cust_Email='" + txtEmail.Text + "',Cust_Phone='" + txtPhone.Text + "',Cust_Address='" + txtaddress.Text + "',Cust_Password='" + txtpassword.Text + "' WHERE Customer_ID='" + txtID.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Customer Updated Successfully", "Message");
        }

        private void Customers_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
    }
    }
