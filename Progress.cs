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
    public partial class Progress : Form
    {
        public Progress()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            progressbar.Value = startpoint;

            if(progressbar.Value == 100)
            {
                progressbar.Value = 0;
                timer1.Stop();
                btnExit lg = new btnExit();
                this.Hide();
                lg.Show();
                
            }
        }

        private void Progress_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Progress_Leave(object sender, EventArgs e)
        {
            
        }
    }

}