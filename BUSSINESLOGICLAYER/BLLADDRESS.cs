using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITYLAYER;
using FACADELAYER;

namespace BUSSINESLOGICLAYER
{
    public class BLLADDRESS
    {
        public static int insert_Address(EADDRESS item2)
        {
            return FADDRESS.insert_Address(item2); 
        }
        public static EADDRESS show_Address_item(int a)
        {
            return FADDRESS.show_Address_item(a);
        }
        public static int update_address(EADDRESS item)
        {
            return FADDRESS.update_address(item);
        }
    }
}
