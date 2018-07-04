using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITYLAYER;
using FACADELAYER;
using System.Data;

namespace BUSSINESLOGICLAYER
{
    public class BLLUSERS
    {
        public static int Insert(EUSERS item)
        {
            return FUSERS.Insert(item);
        }
        public static int Login(EUSERS item,ref int UserIDNo)
        {
            return FUSERS.Login(item,ref UserIDNo);
        }
        public static EUSERS kullanici_ismi(int a)
        {
            return FUSERS.kullanici_ismi(a);
        }
        public static int get_user_ID(EUSERS item)
        {
            return FUSERS.get_user_ID(item);
        }
        public static int update_user(EUSERS item)
        {
            return FUSERS.update_user(item);
        }
        public static DataTable calisan_ata_fonk()
        {
            return FUSERS.calisan_ata_fonk();
        }
        public static int get_user_mode(string name)
        {
            return FUSERS.get_user_mode(name);
        }
        public static int User_ID_al(string name)
        {
            return FUSERS.User_ID_al(name);
        }
        public static int set_user_mode(int K_ID,int mode)
        {
            return FUSERS.set_user_mode(K_ID, mode);
        }
        public static int get_calisan_kategori_ID(int a)
        {
            return FUSERS.get_calisan_kategori_ID(a);
        }
    }
}
