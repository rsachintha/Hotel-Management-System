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

namespace HotelLoginForm.User_Control
{
    public partial class UCCustomerDetails : UserControl
    {
        public UCCustomerDetails()
        {
            InitializeComponent();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {

            
          
        }

        private void UCCustomerDetails_Load(object sender, EventArgs e)
        {
            
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Campus Documents\C#\27\HotelDB.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT * FROM CustomerDetails";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(qry, con);
                DataSet ds = new DataSet();

                da.Fill(ds, "CustomerDetails");
                DGVCustomer.DataSource = ds.Tables["CustomerDetails"];
            }

            catch(SqlException SE)
            {
                MessageBox.Show(SE.ToString());
            }

            
        }

        private void DGVCustomer_Enter(object sender, EventArgs e)
        {
            UCCustomerDetails_Load(this, null);
            txtComboBox.Visible = true;
            txtComboBox.BringToFront();
        }

        private void UCCustomerDetails_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void clearAll()
        {
            txtCustomerName.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text != "")
            {
                string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Campus Documents\C#\27\HotelDB.mdf;Integrated Security=True;Connect Timeout=30";
                string qry = "SELECT * FROM CustomerDetails WHERE Name = '" + txtCustomerName.Text + "'";

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(qry, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "CustomerDetails");
                    DGVCustomer.DataSource = ds.Tables["CustomerDetails"];
                }

                catch (SqlException SE)
                {
                    MessageBox.Show(SE.ToString());
                }
            }
            

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UCCustomerDetails_Load(this, null);
            txtComboBox.SelectedIndex = -1;
            txtComboBox.Visible = true;
            txtComboBox.BringToFront();
            txtRoomType.Clear();
            txtCustomerName.Clear();
        }

        private void txtComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtComboBox.Text == "Customer Name")
            {
                txtComboBox.Hide();
                txtCustomerName.Visible = true;
                txtCustomerName.BringToFront();
                guna2Button1.Hide();
                btnSearch.Visible = true;
                btnSearch.BringToFront();
            }
            else
            {
                txtComboBox.Hide();
                txtRoomType.Visible = true;
                txtRoomType.BringToFront();
                btnSearch.Hide();
                guna2Button1.Visible = true;
                guna2Button1.BringToFront();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtRoomType.Text != "")
            {
                string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Campus Documents\C#\27\HotelDB.mdf;Integrated Security=True;Connect Timeout=30";
                string qry = "SELECT * FROM CustomerDetails WHERE Type = '" + txtRoomType.Text + "'";

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(qry, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "CustomerDetails");
                    DGVCustomer.DataSource = ds.Tables["CustomerDetails"];
                }

                catch (SqlException SE)
                {
                    MessageBox.Show(SE.ToString());
                }

            }
        }
    }
}
