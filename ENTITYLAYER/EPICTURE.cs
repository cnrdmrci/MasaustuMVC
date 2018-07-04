using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITYLAYER
{
    public class EPICTURE
    {
        private int _ID;
        private int _ProductID;
        private string _PicDirectory;

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

        public int ProductID
        {
            get
            {
                return _ProductID;
            }

            set
            {
                _ProductID = value;
            }
        }

        public string PicDirectory
        {
            get
            {
                return _PicDirectory;
            }

            set
            {
                _PicDirectory = value;
            }
        }
    }
}
