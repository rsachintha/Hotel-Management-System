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
    public partial class UCReservationEdit : UserControl
    {
        public UCReservationEdit()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Campus Documents\C#\27\HotelDB.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT * FROM CustomerDetails";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(qry, con);
                DataSet ds = new DataSet();

                da.Fill(ds, "CustomerDetails");
                guna2DataGridView1.DataSource = ds.Tables["CustomerDetails"];
            }

            catch (SqlException SE)
            {
                MessageBox.Show(SE.ToString());
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UCReservationEdit_Load(object sender, EventArgs e)
        {
            GetData();
            

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtReservationID.Text);

            if (txtReservationID.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Campus Documents\C#\27\HotelDB.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Type,Roomno,Price,EntryDate,DepartDate from CustomerDetails where Id =" + ID + "", con);
                cmd.Parameters.AddWithValue("Id", int.Parse(txtReservationID.Text));
                SqlDataReader DR = cmd.ExecuteReader();
                while (DR.Read())
                {
                    
                    txtRoomType.Text = DR.GetValue(0).ToString();
                    txtRoomNo.Text = DR.GetValue(1).ToString();
                    txtPrice.Text = DR.GetValue(2).ToString();
                    //dateTimePickerEntryD.Text = DR.GetValue(3).ToString();
                    //dateTimePickerDepD.Text = DR.GetValue(4).ToString();

                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            DatabaseConnection con = new DatabaseConnection();
            string query = "Update CustomerDetails Set Type ='" + txtRoomType.Text + "',Roomno = " + txtRoomNo.Text + ",Price = " + txtPrice.Text + " ,EntryDate='" + dateTimePickerEntryD.Text + "',DepartDate='" + dateTimePickerDepD.Text + "' where Id = " + txtReservationID.Text + "";
            con.DataConnection(query);
            MessageBox.Show("Updated Successfully !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearAll();
            GetData();

        }

        public void ClearAll()
        {
            txtReservationID.Clear();
            txtRoomNo.Clear();
            txtPrice.Clear();
            txtRoomType.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (txtReservationID.Text != "")
            {
                if (MessageBox.Show("Are You Sure You Want To Delete?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DatabaseConnection con = new DatabaseConnection();
                    string query = "delete CustomerDetails where Id='" + int.Parse(txtReservationID.Text) + "'";
                    con.DataConnection(query);
                    MessageBox.Show("Deleted Successfully !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();

                    GetData();



                }

            }
            else
            {
                MessageBox.Show("Operation Error !", "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private void UCReservationEdit_Enter(object sender, EventArgs e)
        {
            UCReservationEdit_Load(this, null);
        }
    }
}
