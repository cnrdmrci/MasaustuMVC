using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITYLAYER;
using FACADELAYER;

namespace BUSSINESLOGICLAYER
{
    public class BLLPRODUCT
    {
        public static int AddItem(EPRODUCT item,ref int tempPicID)
        {
            return FPRODUCT.AddItem(item,ref tempPicID);
        }
        public static EPRODUCT urun_yazdir(int a,int b)
        {
            return FPRODUCT.urun_yazdir(a,b);
        }
        public static EPRODUCT urun_listele(int a)
        {
            return FPRODUCT.urun_listele(a);
        }
        /*public static EPRODUCT urun_yazdir_onay(int a,int calisan_kategori_ID)
        {
            return FPRODUCT.urun_yazdir_onay(a,calisan_kategori_ID);
        }
        public static int urun_onayla(int urun_ID)
        {
            return FPRODUCT.urun_onayla(urun_ID);
        }
        public static int urun_sil(int urun_ID)
        {
            return FPRODUCT.urun_sil(urun_ID);
        }*/
    }
    
}
