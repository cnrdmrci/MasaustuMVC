using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITYLAYER;
using FACADELAYER;

namespace BUSSINESLOGICLAYER
{
    public class BLLKATEGORI
    {
        public static int listele()
        {
            return FKATEGORI.listele();
        }
        public static List<EKATEGORI> get_SubCatIdFonk(EKATEGORI item,int CatID)
        {
            return FKATEGORI.get_SubCatIdFonk(item, CatID);
        }
        public static int sayfa_sayisi(int a)
        {
            return FKATEGORI.sayfa_sayisi(a);
        }
    }
}
