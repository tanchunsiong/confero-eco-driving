using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Confero
{
    class CUser
    {

        private string _loginID;

        public string LoginID
        {
            get { return _loginID; }
            set { _loginID = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
