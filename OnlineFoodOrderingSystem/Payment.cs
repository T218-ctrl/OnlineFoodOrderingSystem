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
    public partial class Payment : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-UOD7D7D;Database=Food Ordering System;Integrated Security=true");
        public Payment()
        {
            InitializeComponent();
            LoadData();
            LoadOrder();
        }
        void LoadData()
        {
            SqlCommand cmd = new SqlCommand("Select * from Payments", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void LoadOrder()
        {
            SqlCommand cmd = new SqlCommand("Select * from Orders", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Order.DataSource = dt;
            Order.DisplayMember = dt.Columns[1].ToString();
            Order.ValueMember = dt.Columns[0].ToString();
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Payments(Order_ID,Method,Payment_Date,Payment_Status) VALUES('"+Order.SelectedValue+"','" + txtMethod.Text + "','" + txtDate.Text + "','" + txtstatus.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Payment Record Added Successfully", "Message");
        }

        private void btndlt_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Payments WHERE Payment_ID='" + txtID.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Payment Deleted Successfully", "Message");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Payments WHERE Payment_ID='" + txtID.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("Payment with this ID does not exist", "Message");
                return;
            }
            txtMethod.Text = dt.Rows[0][1].ToString();
            txtDate.Text = dt.Rows[0][2].ToString();
            txtstatus.Text = dt.Rows[0][3].ToString();
            btnEdit.Visible = false;
            btnUpdate.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Payments SET Method='" + txtMethod.Text + "',Payment_Date='" + txtDate.Text + "',Payment_Status='" + txtstatus.Text+"''", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Payment Updated Successfully", "Message");
        }

        private void Payment_Load(object sender, EventArgs e)
        {

        }
    }
}
