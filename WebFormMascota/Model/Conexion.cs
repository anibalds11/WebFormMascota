using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebFormMascota.Model
{
    public class Conexion
    {
        public SqlConnection cnn { get; set; }

        public void Connect()
        {
            try
            {
                cnn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                cnn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void Close()
        {
            try
            {
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}