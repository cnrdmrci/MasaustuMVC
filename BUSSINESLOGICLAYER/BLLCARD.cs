using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITYLAYER;
using FACADELAYER;

namespace BUSSINESLOGICLAYER
{
    public class BLLCARD
    {
        public static int Card_kontrol(int a)
        {
            return FCARD.Card_kontrol(a);
        }
        public static int insert_Card(ECARD item)
        {
            return FCARD.insert_Card(item);
        }
        public static int update_Card(ECARD item)
        {
            return FCARD.update_Card(item);
        }
        public static ECARD show_Card_item(int a)
        {
            return FCARD.show_Card_item(a);
        }
    }
}
