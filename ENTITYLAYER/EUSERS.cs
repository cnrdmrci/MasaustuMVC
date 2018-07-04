using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITYLAYER
{
    public class EUSERS
    {
        private int _ID;
        private string _Username;
        private string _Pass;
        private string _Name;
        private string _Surname;
        private string _Email;
        private int _Mode;
        private string _SecurityAnswer;

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
        public string Username
        {
            get
            {
                return _Username;
            }

            set
            {
                _Username = value;
            }
        }
        public string Pass
        {
            get
            {
                return _Pass;
            }

            set
            {
                _Pass = value;
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
        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
            }
        }
        public int Mode
        {
            get
            {
                return _Mode;
            }

            set
            {
                _Mode = value;
            }
        }
        public string SecurityAnswer
        {
            get
            {
                return _SecurityAnswer;
            }

            set
            {
                _SecurityAnswer = value;
            }
        }
        public string Surname
        {
            get
            {
                return _Surname;
            }

            set
            {
                _Surname = value;
            }
        }
    }
}
