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
    public class BLLSUBCATEGORY
    {
        public static DataTable kategori_ata_fonk()
        {
            return FSUBCATEGORY.kategori_ata_fonk();
        }
        public static List<ESUBCATEGORY> SubCategory_Listele(int a)
        {
            return FSUBCATEGORY.SubCategory_Listele(a);
        }
    }
}
