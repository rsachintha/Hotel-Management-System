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
    public partial class UCCheckOut : UserControl
    {
        public UCCheckOut()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            float price = float.Parse(txtRoomPrice.Text);
            int night = int.Parse(txtNights.Text);
            float total = (((price*night)/100)*10)+price;

            txtTotal.Text = "$" + total + "/=";
            Calculate cal = new Calculate();
            cal.setPrice(price);
            cal.setNight(night);
            cal.setTotal(total);
        }

        public void Clearall()
        {
            txtReservationID.Clear();
            txtRoomPrice.Clear();
            txtNights.Clear();
            txtTotal.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clearall();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Dream Villa Hotel", new Font("Arial", 36, FontStyle.Bold), Brushes.Black, new Point(0, 0));


            e.Graphics.DrawString("Bill Receipt", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(10, 45));

            e.Graphics.DrawString("____________________________________________________________________________________________________________________________________________________________", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(10, 100));
            e.Graphics.DrawString("Date:" + DateTime.Now.ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(25, 160));

            e.Graphics.DrawString("Reservation ID:" + txtReservationID.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(300, 160));

            e.Graphics.DrawString("............................................................................................................................................................", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(10, 200));


            e.Graphics.DrawString("Room Price Per Night: $" + txtRoomPrice.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(30, 255));
            e.Graphics.DrawString("Total Nights:" + txtNights.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(300, 255));
            e.Graphics.DrawString("Total:" + txtTotal.Text, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(470, 250));


            e.Graphics.DrawString("............................................................................................................................................................", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(10, 280));



            e.Graphics.DrawString("Thank You!", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(310, 750));
            e.Graphics.DrawString("dreamvilla@gmail.com", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(314, 775));
            e.Graphics.DrawString("0112 456 789", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(314, 795));

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            Clearall();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtReservationID.Text);

            if (txtReservationID.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Campus Documents\C#\27\HotelDB.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Price from CustomerDetails where Id =" + ID + "", con);
                cmd.Parameters.AddWithValue("Id", int.Parse(txtReservationID.Text));
                SqlDataReader DR = cmd.ExecuteReader();
                while (DR.Read())
                {
                    txtRoomPrice.Text = DR.GetValue(0).ToString();
                }
            }
        }
    }
}
