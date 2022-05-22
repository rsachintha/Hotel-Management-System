using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelLoginForm
{
    class Calculate
    {
        private float price;

        public void setPrice(float priceUser)
        {
            price = priceUser;
        }
        public float getPrice()
        {
            return price;
        }

        private float total;
        public void setTotal(float totalUser)
        {
            total = totalUser;
        }

        public float getTotal()
        {
            return total;
        }
        private int night;
        public void setNight(int nightUser)
        {
            night = nightUser;
        }
        public int getNight()
        {
            return night;
        }
    }
}
