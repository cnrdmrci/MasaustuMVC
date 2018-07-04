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
    public class FKATEGORI
    {
        public static int listele()
        {
            return 1;
        }
        public static List<EKATEGORI> get_SubCatIdFonk(EKATEGORI item,int CatID)
        {
            List<EKATEGORI> liste = null;
            try
            {
                SqlCommand com = new SqlCommand("sayfalama_kategoriID", FCONNECTION.conn);
                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                    com.Connection.Open();
                com.Parameters.AddWithValue("num", CatID);
                SqlDataReader rdr = com.ExecuteReader();

                if (rdr.HasRows)
                {
                    liste = new List<EKATEGORI>();
                    while (rdr.Read())
                    {
                        EKATEGORI item1 = new EKATEGORI();
                        item1.Name = rdr["Name"].ToString();
                        item1.ID = Convert.ToInt32(rdr["ID"]);
                        liste.Add(item1);
                    }
                }
                com.Connection.Close();
                rdr.Close();
            }
            catch
            {

            }
            return liste;
        }
        public static int sayfa_sayisi(int a)
        {
            int temp;
            SqlCommand com = new SqlCommand("sayfa_sayisi", FCONNECTION.conn);
            com.CommandType = CommandType.StoredProcedure;

            if (com.Connection.State != ConnectionState.Open)
                com.Connection.Open();
            com.Parameters.AddWithValue("SubCategoryID", a);
            temp = (Int32)com.ExecuteScalar();
            com.Connection.Close();
            return temp;
        }
    }
}
