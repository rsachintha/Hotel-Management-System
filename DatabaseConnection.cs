using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace HotelLoginForm
{
    class DatabaseConnection
    {
        public string DataConnection(string QRY)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Campus Documents\C#\27\HotelDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand(QRY, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return "Operation Executed Successfully";
            }

            catch(SqlException SE)
            {
                return "Operation Was Not Successfull"+SE;
            }

            finally
            {
                con.Close();
            }
        }

        
           
        
    }
}
