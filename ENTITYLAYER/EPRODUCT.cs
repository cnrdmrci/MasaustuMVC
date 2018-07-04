using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITYLAYER
{
    public class EPRODUCT
    {
        private int _ID;
        private string _Name;
        private int _Price;
        private int _SubCategoryID;
        private int _UsersID;
        private int _Sold;
        private int _onay;
        private DateTime _AdvertDate;

        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }

        public int Price
        {
            get
            {
                return _Price;
            }

            set
            {
                _Price = value;
            }
        }

        public int SubCategoryID
        {
            get
            {
                return _SubCategoryID;
            }

            set
            {
                _SubCategoryID = value;
            }
        }

        public int UsersID
        {
            get
            {
                return _UsersID;
            }

            set
            {
                _UsersID = value;
            }
        }

        public int Sold
        {
            get
            {
                return _Sold;
            }

            set
            {
                _Sold = value;
            }
        }

        public int Onay
        {
            get
            {
                return _onay;
            }

            set
            {
                _onay = value;
            }
        }

        public DateTime AdvertDate
        {
            get
            {
                return _AdvertDate;
            }

            set
            {
                _AdvertDate = value;
            }
        }
    }
}
