using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelLoginForm
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            ucHome1.Visible = true;
            ucHome1.BringToFront();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ucHome1.Visible = false;
            ucRoomAvailability1.Visible = true;
            ucRoomAvailability1.BringToFront();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ucAddRoom1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            userCustomerRegister1.Visible = true;
            userCustomerRegister1.BringToFront();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            guna2CircleButton3.Visible = false;
            guna2CircleButton4.Visible = true;
        }

        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            guna2CircleButton4.Visible = false;
            guna2CircleButton3.Visible = true;
        }

        private void ucCustomerDetails1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            ucCustomerDetails1.Visible = true;
            ucCustomerDetails1.BringToFront();
        }

        private void userCustomerRegister1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ucCheckOut1.Visible = true;
            ucCheckOut1.BringToFront();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ucReservationEdit1.Visible = true;
            ucReservationEdit1.BringToFront();
        }

        private void Dashboard_Enter(object sender, EventArgs e)
        {
            
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ucHome1.Visible = true;
            ucHome1.BringToFront();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Dashboard_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle,WM_NCLBUTTONDOWN,HT_CAPTION,0);

                   
            }
        }
    }
}
