using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace test.module
{
    class Connect
    {
        public static SqlConnection public_con;
        public static int connect()
        { // Copy Data Source vào chuỗi
            String cn = @"Data Source=WINDOWS10\SQLEXPRESS;Initial Catalog=testdatabase;Integrated Security=True";
            try
            {
                public_con = new SqlConnection(cn);
                public_con.Open();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static void disconnect()   // gọi hàm này sau khi đã dùng xong csdl 
        {
            public_con.Close();
            public_con.Dispose();
            public_con = null;
        }

    }
}
