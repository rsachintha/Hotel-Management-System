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
    public partial class UCAddRoom : UserControl
    {
        
        
        public UCAddRoom()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "" && txtType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                int Roomid = int.Parse(txtRoomID.Text);
                string Roomno = txtRoomNo.Text;
                string Roomtype = txtType.Text;
                string Roombed = txtBed.Text;
                int Roomprice = int.Parse(txtPrice.Text);


                string qry = "INSERT INTO Room VALUES (" + Roomid + "," + Roomno + ",'" + Roomtype + "','" + Roombed + "'," + Roomprice + ")";
                DatabaseConnection ObjDB = new DatabaseConnection();

                string feedback = ObjDB.DataConnection(qry);
                MessageBox.Show(feedback);

                UCAddRoom_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Fill All Fields.", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void clearAll()
        {
            txtRoomID.Clear();
            txtRoomNo.Clear();
            txtType.SelectedIndex = -1;
            txtBed.SelectedIndex = -1;
            txtPrice.Clear();
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UCAddRoom_Load(object sender, EventArgs e)
        {
            string Con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kevin\Documents\HotelDB.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT * FROM Room";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(qry, Con);
                DataSet ds = new DataSet();

                da.Fill(ds, "Room");
                DGVRoom.DataSource = ds.Tables["Room"];

            }

            catch(SqlException SE)
            {
                MessageBox.Show(SE.ToString());
            }
        }

        private void UCAddRoom_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UCAddRoom_Enter(object sender, EventArgs e)
        {
            UCAddRoom_Load(this, null);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int Roomid = int.Parse(txtRoomID.Text);
            string Roomno = txtRoomNo.Text;
            string Roomtype = txtType.Text;
            string Roombed = txtBed.Text;
            


            string qry = "DELETE FROM Room WHERE Roomid =" + Roomid + "";
            DatabaseConnection ObjDB = new DatabaseConnection();

            string feedback = ObjDB.DataConnection(qry);
            MessageBox.Show(feedback);
            UCAddRoom_Load(this, null);
            clearAll();
        }
    }
}
