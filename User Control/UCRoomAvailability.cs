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
    public partial class UCRoomAvailability : UserControl
    {
        public UCRoomAvailability()
        {
            InitializeComponent();
        }

        private void textBoxRoomType_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnRoomSearch_Click(object sender, EventArgs e)
        {


            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Campus Documents\C#\27\HotelDB.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT * FROM RoomAvailability WHERE RoomType = '" + txtRoomTypeComboBox.Text + "'";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(qry, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "RoomAvailability");
                dataGridViewRooms.DataSource = ds.Tables["RoomAvailability"];
            }

            catch (SqlException SE)
            {
                MessageBox.Show(SE.ToString());
            }

        }

        void GetData()
        {
            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Campus Documents\C#\27\HotelDB.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "SELECT * FROM RoomAvailability";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(qry, Con);
                DataSet ds = new DataSet();

                da.Fill(ds, "RoomAvailability");
                dataGridViewRooms.DataSource = ds.Tables["RoomAvailability"];
            }

            catch (SqlException SE)
            {
                MessageBox.Show(SE.ToString());
            }
        }

        public void Clear()
        {
            textBoxRoomNumber.Clear();
            textBoxRoomType.Clear();
            textBoxFloor.Clear();
            textBoxAv.Clear();


        }

        private void buttonGet_Click(object sender, EventArgs e)
        {

            int Numb = int.Parse(textBoxRoomNumber.Text);


            if (textBoxRoomNumber.Text != "")
            {
                SqlConnection Connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Campus Documents\C#\27\HotelDB.mdf;Integrated Security=True;Connect Timeout=30");
                Connect.Open();
                SqlCommand cmd = new SqlCommand("select RoomType,Floor,Availability from RoomAvailability where RoomNumber=" + Numb + " ", Connect);
                cmd.Parameters.AddWithValue("Numb", int.Parse(textBoxRoomNumber.Text));
                SqlDataReader DR = cmd.ExecuteReader();
                while (DR.Read())
                {
                    textBoxRoomType.Text = DR.GetValue(0).ToString();
                    textBoxFloor.Text = DR.GetValue(1).ToString();
                    textBoxAv.Text = DR.GetValue(2).ToString();


                }
                
  
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            
            DatabaseConnection con = new DatabaseConnection();
            string query = "update RoomAvailability set RoomType='" + textBoxRoomType.Text + "',Floor =" + textBoxFloor.Text + ",  Availability='" + textBoxAv.Text + "' where RoomNumber='" + textBoxRoomNumber.Text + "' ";
            con.DataConnection(query);
            MessageBox.Show("Updated Successfully !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clear();
            GetData();
            UCRoomAvailability_Load(this, null);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void comboBoxRoomSelecter_Enter(object sender, EventArgs e)
        {
            if (txtRoomTypeComboBox.Text == "Select a Room Type")
                txtRoomTypeComboBox.Text = "";

            txtRoomTypeComboBox.ForeColor = Color.Black;
        }

        private void comboBoxRoomSelecter_Leave(object sender, EventArgs e)
        {
            if (txtRoomTypeComboBox.Text == "")
               txtRoomTypeComboBox.Text = "Select a Room Type";

               txtRoomTypeComboBox.ForeColor = Color.Silver;
        }

        private void UCRoomAvailability_Load(object sender, EventArgs e)
        {
           

            GetData();
        }

        private void UCRoomAvailability_Leave(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textBoxRoomNumber.Text !="" && textBoxRoomType.Text !="" && textBoxFloor.Text !="" && textBoxAv.Text !="")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Campus Documents\C#\27\HotelDB.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "INSERT INTO RoomAvailability Values(" + textBoxRoomNumber.Text + ",'" + textBoxRoomType.Text + "'," + textBoxFloor.Text + ",'" + textBoxAv.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException SE)
                {
                    MessageBox.Show("Error Generated !" + SE);
                }
                finally
                {
                    con.Close();
                }
                

                UCRoomAvailability_Load(this, null);
                GetData();
                Clear();
            }
            else
            {
                MessageBox.Show("Fill All Fields.", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetData();
            txtRoomTypeComboBox.SelectedIndex = -1;
        }

       
    }


}
