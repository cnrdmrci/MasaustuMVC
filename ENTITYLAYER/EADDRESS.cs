using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITYLAYER
{
    public class EADDRESS
    {
        private int _ID;
        private string _Cadde;
        private string _Street;
        private string _City;
        private string _town;
        private int _Num;
        private int _UsersID;

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

        public string Cadde
        {
            get
            {
                return _Cadde;
            }

            set
            {
                _Cadde = value;
            }
        }

        public string Street
        {
            get
            {
                return _Street;
            }

            set
            {
                _Street = value;
            }
        }

        public string City
        {
            get
            {
                return _City;
            }

            set
            {
                _City = value;
            }
        }

        public string Town
        {
            get
            {
                return _town;
            }

            set
            {
                _town = value;
            }
        }

        public int Num
        {
            get
            {
                return _Num;
            }

            set
            {
                _Num = value;
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
    }
}
