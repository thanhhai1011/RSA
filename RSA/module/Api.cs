using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using RSA.model;

namespace RSA.module
{
    class Api
    {
        class JSON_Infor
        {
            public string status;
            public string message;
        }
        class User_sequelize
        {
            public string id;
            public string username;
        }
        public static int post_API(string username,string password)
        {
            try
            {
                HttpClient htpc = new HttpClient();
                htpc.BaseAddress = new Uri("http://192.168.1.112:5000/users/api/login");
                var res = htpc.PostAsync("",
                          new StringContent(JsonConvert.SerializeObject(
                          new
                          {
                              username = username,
                              password = password
                          }),
                          Encoding.UTF8, "application/json")).Result;
                var contents = res.Content.ReadAsStringAsync();
                Usermodel.user_session = JsonConvert.DeserializeObject<Usermodel>(contents.Result);
                return 1;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
        
    }
}
