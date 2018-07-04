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
    public class FADDRESS
    {
        public static int insert_Address(EADDRESS item2)
        {
            int satir = -1;
            try
            {
                SqlCommand com = new SqlCommand("ADRES_EKLE", FCONNECTION.conn);
                com.CommandType = CommandType.StoredProcedure;
                
                if (com.Connection.State != ConnectionState.Open)
                    com.Connection.Open();
                com.Parameters.AddWithValue("Cadde", item2.Cadde);
                com.Parameters.AddWithValue("Street", item2.Street);
                com.Parameters.AddWithValue("City", item2.City);
                com.Parameters.AddWithValue("town", item2.Town);
                com.Parameters.AddWithValue("Num", item2.Num);
                com.Parameters.AddWithValue("UsersID", item2.UsersID);
                satir = com.ExecuteNonQuery();
                com.Connection.Close();
            }
            catch
            {
                satir = -1;
            }
            return satir;
        }
        public static EADDRESS show_Address_item(int a)
        {
            EADDRESS item = new EADDRESS();
            try
            {
                SqlCommand com = new SqlCommand("ADRES_GOSTER", FCONNECTION.conn);
                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                    com.Connection.Open();
                com.Parameters.AddWithValue("UsersID", a);

                SqlDataReader rdr = com.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        item.Cadde = rdr["Cadde"].ToString();
                        item.Street = rdr["Street"].ToString();
                        item.Town = rdr["town"].ToString();
                        item.City = rdr["City"].ToString();
                        item.Num = Convert.ToInt32(rdr["Num"]);
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
        public static int update_address(EADDRESS item2)
        {
            int satir = -1;
            try
            {
                SqlCommand com = new SqlCommand("ADRES_GUNCELLE", FCONNECTION.conn);
                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                    com.Connection.Open();
                com.Parameters.AddWithValue("Cadde", item2.Cadde);
                com.Parameters.AddWithValue("Street", item2.Street);
                com.Parameters.AddWithValue("City", item2.City);
                com.Parameters.AddWithValue("town", item2.Town);
                com.Parameters.AddWithValue("Num", item2.Num);
                com.Parameters.AddWithValue("UsersID", item2.UsersID);
                satir = com.ExecuteNonQuery();
                com.Connection.Close();
            }
            catch
            {
                satir = -1;
            }
            return satir;

        }
    }
}
