using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITYLAYER
{
    public class ECARD
    {
        private int _ID;
        private int _CardNo;
        private int _CCV;
        private int _SKT;
        private int _FakeBalance;
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

        public int CardNo
        {
            get
            {
                return _CardNo;
            }

            set
            {
                _CardNo = value;
            }
        }

        public int CCV
        {
            get
            {
                return _CCV;
            }

            set
            {
                _CCV = value;
            }
        }

        public int SKT
        {
            get
            {
                return _SKT;
            }

            set
            {
                _SKT = value;
            }
        }

        public int FakeBalance
        {
            get
            {
                return _FakeBalance;
            }

            set
            {
                _FakeBalance = value;
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
