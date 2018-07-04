using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITYLAYER;
using System.Data.SqlClient;
using System.Data;

namespace FACADELAYER
{
    public class FPICTURE
    {
        public static int AddPicture(EPICTURE item)
        {
            int satir = -1;
            try
            {
                SqlCommand com = new SqlCommand("Add_Picture", FCONNECTION.conn);
                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                    com.Connection.Open();
                com.Parameters.AddWithValue("ProductID", item.ProductID);
                com.Parameters.AddWithValue("PicDirectory", item.PicDirectory);
                satir = com.ExecuteNonQuery();

                com.Connection.Close();

            }
            catch
            {
                satir = -1;
            }
            return satir;
        }
        public static EPICTURE resim_yolu(int a)
        {
            EPICTURE item = new EPICTURE();
            try
            {
                SqlCommand com = new SqlCommand("resim_yazdir", FCONNECTION.conn);
                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                    com.Connection.Open();
                com.Parameters.AddWithValue("ProductID", a);

                SqlDataReader rdr = com.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        item.PicDirectory = rdr["PicDirectory"].ToString();
                    }
                }

                com.Connection.Close();
                rdr.Close();
            }
            catch
            {
            }
            return item;
        }
    }
}
