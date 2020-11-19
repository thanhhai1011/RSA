using RSA.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.module;

namespace RSA.controller
{
    class Usercontroller
    {
        public static int testConnect()
        {
            int check = Connect.connect();
            return check;
        }
        public static int login(string username, string password)
        {
            Usermodel.user_session = new Usermodel(_username: username, _password: password);
            int login_check = Usermodel.user_session.login();
            return login_check;
        }
    }
}
