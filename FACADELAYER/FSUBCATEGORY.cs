using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITYLAYER;
using System.Data;
using System.Data.SqlClient;

namespace FACADELAYER
{
    public class FSUBCATEGORY
    {
        public static DataTable kategori_ata_fonk()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand com = new SqlCommand("show_kategori", FCONNECTION.conn);
                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                    com.Connection.Open();
                SqlDataReader rdr = com.ExecuteReader();
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                }
                com.Connection.Close();
                rdr.Close();
            }
            catch (Exception ex)
            {
            }
            return dt;
        }
        public static List<ESUBCATEGORY> SubCategory_Listele(int a)
        {
            List<ESUBCATEGORY> liste = null;
            try
            {
                SqlCommand com = new SqlCommand("alt_kategori_listele", FCONNECTION.conn);
                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                    com.Connection.Open();
                com.Parameters.AddWithValue("CategoryID", a);
                SqlDataReader rdr = com.ExecuteReader();

                if (rdr.HasRows)
                {
                    liste = new List<ESUBCATEGORY>();
                    while (rdr.Read())
                    {
                        ESUBCATEGORY item1 = new ESUBCATEGORY();
                        item1.ID = Convert.ToInt32(rdr["ID"]);
                        item1.Name = rdr["Name"].ToString();
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
    }
}
