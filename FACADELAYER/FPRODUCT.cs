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
    public class FPRODUCT
    {
        public static int AddItem(EPRODUCT item, ref int tempPicID)
        {
            int satir = -1;
            try
            {
                SqlCommand comm = new SqlCommand("URUN_EKLE", FCONNECTION.conn);
                comm.CommandType = CommandType.StoredProcedure;

                if (comm.Connection.State != ConnectionState.Open)
                    comm.Connection.Open();
                comm.Parameters.AddWithValue("Name", item.Name);
                comm.Parameters.AddWithValue("Price", item.Price);
                comm.Parameters.AddWithValue("SubCategoryID", item.SubCategoryID);
                comm.Parameters.AddWithValue("UsersID", item.UsersID);
                satir = comm.ExecuteNonQuery();
                comm.Connection.Close();


                SqlCommand com2 = new SqlCommand("get_UrunID", FCONNECTION.conn);
                com2.CommandType = CommandType.StoredProcedure;

                if (com2.Connection.State != ConnectionState.Open)
                    com2.Connection.Open();

                com2.Parameters.AddWithValue("Name", item.Name);
                com2.Parameters.AddWithValue("Price", item.Price);
                com2.Parameters.AddWithValue("SubCategoryID", item.SubCategoryID);
                com2.Parameters.AddWithValue("UsersID", item.UsersID);

                SqlDataReader rdr = com2.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        item.ID = Convert.ToInt32(rdr["ID"]);
                    }
                }
                tempPicID = item.ID;
                com2.Connection.Close();
                rdr.Close();

            }
            catch
            {
                satir = -1;
            }

            return satir;
        }
        public static EPRODUCT urun_yazdir(int a, int altCatId)
        {
            EPRODUCT Urun1 = new EPRODUCT();
            try
            {
                SqlCommand com = new SqlCommand("URUN_LISTELE", FCONNECTION.conn);
                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                    com.Connection.Open();
                com.Parameters.AddWithValue("Taban", a - 1);
                com.Parameters.AddWithValue("altCatId", altCatId);
                SqlDataReader rdr = com.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Urun1.Name = rdr["Name"].ToString();
                        Urun1.Price = Convert.ToInt32(rdr["Price"]);
                        Urun1.SubCategoryID = Convert.ToInt32(rdr["SubCategoryID"]);
                        Urun1.ID = Convert.ToInt32(rdr["ID"]);
                        Urun1.UsersID = Convert.ToInt32(rdr["UsersID"]);
                        //Urun1.Sold = Convert.ToInt32(rdr["Sold"]);
                        //Urun1.Onay = Convert.ToInt32(rdr["onay"]);
                    }
                }
                com.Connection.Close();
                rdr.Close();
            }
            catch
            {

            }
            return Urun1;
        }
        public static EPRODUCT urun_listele(int a)
        {
            EPRODUCT item = new EPRODUCT();
            try
            {
                SqlCommand com = new SqlCommand("urun_list_satin", FCONNECTION.conn);
                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                    com.Connection.Open();
                com.Parameters.AddWithValue("ID", a);
                SqlDataReader rdr = com.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        item.Name = rdr["Name"].ToString();
                        item.Price = Convert.ToInt32(rdr["Price"]);
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
