using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSA.model;
using test.module;

namespace RSA.model
{
    class Usermodel
    {
        public static Usermodel user_session;

        public int id
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
        public string token
        {
            get
            {
                return p_token;
            }
            set
            {
                p_token = value;
            }
        }
        public string username
        {
            get
            {
                return p_username;
            }
            set
            {
                p_username = value;
            }
        }
        public int idrole
        {
            get
            {
                return p_idrole;
            }
            set
            {
                p_idrole = value;
            }
        }


        internal int Login()
        {
            throw new NotImplementedException();
        }

        public string password
        {
            get
            {
                return p_password;
            }
            set
            {
                p_password = value;
            }
        }
        public string role
        {
            get
            {
                return p_role;
            }
            set
            {
                p_role = value;
            }
        }
        private int p_id;
        private int p_idrole;
        private string p_username;
        private string p_password;
        private string p_role;
        private string p_token;
        public Usermodel(string _username, string _password)
        {
            p_username = _username;
            p_password = _password;
        }

        public Usermodel(int id)
        {
            p_id = id;
        }

        public Usermodel()
        {
        }

        private DataTable getUser()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter get_user = new SqlDataAdapter("SELECT id, role FROM Users WHERE username='" + p_username + "'AND password'" + p_password + "'", Connect.public_con);
            get_user.Fill(dt);
            return dt;
        }
        public int login()
        {
            if (Connect.connect() == 1)
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Users WHERE username='" + p_username + "' AND password='" + p_password + "'", Connect.public_con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    DataTable User_InforMation = getUser();
                    p_id = Convert.ToInt32(User_InforMation.Rows[0][0].ToString());
                    p_role = User_InforMation.Rows[0][1].ToString();
                    return 1;
                }
                else
                    return 0;
            }
            return 0;
        }
    }
}
