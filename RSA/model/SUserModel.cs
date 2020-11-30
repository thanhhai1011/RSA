using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA.model
{
    class SUserModel
    {
        public string id
        {
            get
            {
                return p_id;
            }
            set
            {
                p_id = value;
            }
        }
        public string email
        {
            get
            {
                return p_email;
            }
            set
            {
                p_email = value;
            }
        }
        private string p_id;
        private string p_email;
        public SUserModel(string id,string email)
        {
            this.p_id = id;
            this.email = email;
        }
    }
}
