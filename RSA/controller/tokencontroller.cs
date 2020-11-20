using RSA.module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA.controller
{
    class Tokencontroller
    {
        public static void checkToken()
        {
            Api.Api_token_check();
        }
    }
}
