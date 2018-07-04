using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITYLAYER;
using FACADELAYER;

namespace BUSSINESLOGICLAYER
{
    public class BLLPICTURE
    {
        public static int AddPicture(EPICTURE item)
        {
            return FPICTURE.AddPicture(item);
        }
        public static EPICTURE resim_yolu(int a)
        {
            return FPICTURE.resim_yolu(a);
        }
    }
}
