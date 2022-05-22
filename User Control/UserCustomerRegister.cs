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
    public partial class UserCustomerRegister : UserControl
    {
        public UserCustomerRegister()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReserveRoom_Click(object sender, EventArgs e)
        {
           if(txtRoomName.Text !="" && txtRoomID.Text !="" && txtMobileNo.Text !="" && txtGuests.Text !="" && txtAddress.Text !="" && txtCreditCard.Text !="" && dateTimePickerEntryD.Text !="" && txtType.Text !="" && txtRoomnumber.Text !="" && txtPrice.Text !="")
            {
                
                
                
                int roomid = int.Parse(txtRoomID.Text);
                string name = txtRoomName.Text;
                int mobileno = int.Parse(txtMobileNo.Text);
                string address = txtAddress.Text;
                string guestno = txtGuests.Text;
                int creditcard = int.Parse(txtCreditCard.Text);

                string bed = txtBed.Text;
                string roomtype = txtType.Text;
                int roomno = int.Parse(txtRoomnumber.Text);
                int price = int.Parse(txtPrice.Text);

                string qry = "INSERT INTO CustomerDetails VALUES ("+roomid+ ",'" + name + "'," + mobileno+ ",'" + address + "','" + guestno+"',"+creditcard+ ",'"+dateTimePickerEntryD.Text+"','"+dateTimePickerDepD.Text+"','"+bed+"','"+roomtype+"',"+roomno+","+price+ ")";
                DatabaseConnection objdb = new DatabaseConnection();
                objdb.DataConnection(qry);
                MessageBox.Show("Registered Successfully.", "Information !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UserCustomerRegister_Load(this, null);
                clearAll();
            }


            else
            {
                MessageBox.Show("Please Fill All Fields.", "Information !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserCustomerRegister_Load(object sender, EventArgs e)
        {

        }

        public void clearAll()
        {
            txtRoomID.Clear();
            txtRoomName.Clear();
            txtRoomnumber.Clear();
            txtMobileNo.Clear();
            txtAddress.Clear();
            txtCreditCard.Clear();
            txtGuests.SelectedIndex = -1;
            txtBed.SelectedIndex = -1;
            txtType.SelectedIndex = -1;
            txtRoomnumber.Clear();
            txtPrice.Clear();
            packagesView1.Visible = false;
            

        }

        private void UserCustomerRegister_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UserCustomerRegister_Enter(object sender, EventArgs e)
        {
            UserCustomerRegister_Load(this, null);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            packagesView1.Visible = true;
        }
    }
}
