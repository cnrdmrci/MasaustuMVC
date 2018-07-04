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
    public class FCARD
    {
        public static int Card_kontrol(int a)
        {
            int temp;
            SqlCommand com = new SqlCommand("Card_Control", FCONNECTION.conn);
            com.CommandType = CommandType.StoredProcedure;

            if (com.Connection.State != ConnectionState.Open)
                com.Connection.Open();
            com.Parameters.AddWithValue("UsersID",a);
            temp = (Int32)com.ExecuteScalar();

            com.Connection.Close();
            return temp;
        }
        public static int insert_Card(ECARD item)
        {
            int satir = -1;
            try
            {
                SqlCommand com = new SqlCommand("insert_Card", FCONNECTION.conn);
                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                    com.Connection.Open();
                com.Parameters.AddWithValue("CardNo", item.CardNo);
                com.Parameters.AddWithValue("SKT", item.SKT);
                com.Parameters.AddWithValue("CCV", item.CCV);
                com.Parameters.AddWithValue("FakeBalance", item.FakeBalance);
                com.Parameters.AddWithValue("UsersID", item.UsersID);
                satir = com.ExecuteNonQuery();
                com.Connection.Close();
            }
            catch
            {
                satir = -1;
            }
            return satir;
        }
        public static int update_Card(ECARD item)
        {
            int satir = -1;
            try
            {
                SqlCommand com = new SqlCommand("update_Card", FCONNECTION.conn);
                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                    com.Connection.Open();
                com.Parameters.AddWithValue("CardNo", item.CardNo);
                com.Parameters.AddWithValue("SKT", item.SKT);
                com.Parameters.AddWithValue("CCV", item.CCV);
                com.Parameters.AddWithValue("FakeBalance", item.FakeBalance);
                com.Parameters.AddWithValue("UsersID", item.UsersID);
                satir = com.ExecuteNonQuery();
                com.Connection.Close();
            }
            catch
            {
                satir = -1;
            }
            return satir;
        }
        public static ECARD show_Card_item(int a)
        {
            ECARD item = new ECARD();
            try
            {
                SqlCommand com = new SqlCommand("show_card_item", FCONNECTION.conn);
                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                    com.Connection.Open();
                com.Parameters.AddWithValue("UsersID", a);
                SqlDataReader rdr = com.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        item.CardNo = Convert.ToInt32(rdr["CardNo"]);
                        item.CCV = Convert.ToInt32(rdr["CCV"]);
                        item.SKT = Convert.ToInt32(rdr["SKT"]);
                        item.FakeBalance = Convert.ToInt32(rdr["FakeBalance"]);
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
