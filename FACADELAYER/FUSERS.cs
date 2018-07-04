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
    public class FUSERS
    {
        public static int Insert(EUSERS item)
        {
            int satir = -1;
            try
            {
                SqlCommand com = new SqlCommand("ADD_USER", FCONNECTION.conn);
                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                    com.Connection.Open();
                com.Parameters.AddWithValue("Username", item.Username);
                com.Parameters.AddWithValue("Pass", item.Pass);
                com.Parameters.AddWithValue("Name", item.Name);
                com.Parameters.AddWithValue("Surname", item.Surname);
                com.Parameters.AddWithValue("Email", item.Email);
                com.Parameters.AddWithValue("SecurityAnswer", item.SecurityAnswer);
                satir = com.ExecuteNonQuery();
                com.Connection.Close();
            }
            catch
            {
                satir = -1;
            }
            return satir;
        }
        public static int Login(EUSERS item, ref int UserIDNo)
        {
            int temp;
            SqlCommand com = new SqlCommand("SEARCH_USER", FCONNECTION.conn);
            com.CommandType = CommandType.StoredProcedure;

            if (com.Connection.State != ConnectionState.Open)
                com.Connection.Open();
            com.Parameters.AddWithValue("Username", item.Username);
            com.Parameters.AddWithValue("Email", item.Email);
            com.Parameters.AddWithValue("Pass", item.Pass);
            temp = (Int32)com.ExecuteScalar();

            SqlCommand com2 = new SqlCommand("get_UserID", FCONNECTION.conn);
            com2.CommandType = CommandType.StoredProcedure;
            com2.Parameters.AddWithValue("Username", item.Username);
            com2.Parameters.AddWithValue("Email", item.Email);
            com2.Parameters.AddWithValue("Pass", item.Pass);

            SqlDataReader rdr = com2.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    item.ID = Convert.ToInt32(rdr["ID"]);
                }
            }
            UserIDNo = item.ID;
            com2.Connection.Close();
            rdr.Close();
            return temp;
        }
        public static int get_user_ID(EUSERS item)
        {

            SqlCommand com2 = new SqlCommand("get_UserID", FCONNECTION.conn);
            com2.CommandType = CommandType.StoredProcedure;
            com2.Parameters.AddWithValue("Username", item.Username);
            com2.Parameters.AddWithValue("Email", item.Email);
            com2.Parameters.AddWithValue("Pass", item.Pass);

            SqlDataReader rdr = com2.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    item.ID = Convert.ToInt32(rdr["ID"]);
                }
            }
            com2.Connection.Close();
            rdr.Close();
            return item.ID;
        }
        public static EUSERS kullanici_ismi(int a)
        {
            EUSERS item = new EUSERS();
            try
            {
                SqlCommand com = new SqlCommand("user_name_satin", FCONNECTION.conn);
                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                    com.Connection.Open();
                com.Parameters.AddWithValue("ID", a);
                SqlDataReader rdr = com.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        item.Username = rdr["Username"].ToString();
                        item.Name = rdr["Name"].ToString();
                        item.Surname = rdr["Surname"].ToString();
                        item.Email = rdr["Email"].ToString();
                        item.Mode = Convert.ToInt32(rdr["Mode"]);
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
        public static int update_user(EUSERS item)
        {
            int satir = -1;
            try
            {
                SqlCommand com = new SqlCommand("UPDATE_USER", FCONNECTION.conn);
                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                    com.Connection.Open();
                com.Parameters.AddWithValue("ID", item.ID);
                com.Parameters.AddWithValue("Username", item.Username);
                com.Parameters.AddWithValue("Name", item.Name);
                com.Parameters.AddWithValue("Surname", item.Surname);
                com.Parameters.AddWithValue("Email", item.Email);
                satir = com.ExecuteNonQuery();
                com.Connection.Close();
            }
            catch
            {
                satir = -1;
            }
            return satir;
        }
        public static DataTable calisan_ata_fonk()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand com = new SqlCommand("show_users", FCONNECTION.conn);
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
        public static int get_user_mode(string name)
        {
            EUSERS item = new EUSERS();
            SqlCommand com2 = new SqlCommand("get_user_mode", FCONNECTION.conn);
            com2.CommandType = CommandType.StoredProcedure;
            com2.Parameters.AddWithValue("Username", name);

            if (com2.Connection.State != ConnectionState.Open)
                com2.Connection.Open();

            SqlDataReader rdr = com2.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    item.Mode = Convert.ToInt32(rdr["Mode"]);
                }
            }
            com2.Connection.Close();
            rdr.Close();
            return item.Mode;
        }
        public static int User_ID_al(string name)
        {
            EUSERS item = new EUSERS();
            SqlCommand com2 = new SqlCommand("User_ID_al", FCONNECTION.conn);
            com2.CommandType = CommandType.StoredProcedure;
            com2.Parameters.AddWithValue("Username", name);

            if (com2.Connection.State != ConnectionState.Open)
                com2.Connection.Open();

            SqlDataReader rdr = com2.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    item.ID = Convert.ToInt32(rdr["ID"]);
                }
            }
            com2.Connection.Close();
            rdr.Close();
            return item.ID;
        }
        public static int set_user_mode(int K_ID,int mode)
        {
            int satir = -1;
            try
            {
                SqlCommand com = new SqlCommand("set_user_mode", FCONNECTION.conn);
                com.CommandType = CommandType.StoredProcedure;

                if (com.Connection.State != ConnectionState.Open)
                    com.Connection.Open();
                com.Parameters.AddWithValue("ID", K_ID);
                com.Parameters.AddWithValue("Mode", mode);
                satir = com.ExecuteNonQuery();
                com.Connection.Close();
            }
            catch
            {
                satir = -1;
            }
            return satir;
        }
        public static int get_calisan_kategori_ID(int a)
        {
            int CategoryID=-1;
            SqlCommand com2 = new SqlCommand("get_calisan_kategori_ID", FCONNECTION.conn);
            com2.CommandType = CommandType.StoredProcedure;
            com2.Parameters.AddWithValue("UserID", a);

            if (com2.Connection.State != ConnectionState.Open)
                com2.Connection.Open();

            SqlDataReader rdr = com2.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    CategoryID = Convert.ToInt32(rdr["Category"]);
                }
            }
            com2.Connection.Close();
            rdr.Close();
            return CategoryID;
        }
    }
}
