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
using System.Configuration;

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

        public static int post_API_login(string username,string password)
        {
            try
            {
                HttpClient htpc = new HttpClient();
                string value = System.Configuration.ConfigurationManager.AppSettings["ApiAddress"].ToString();
                htpc.BaseAddress = new Uri(value);
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
                
                if (System.Configuration.ConfigurationManager.AppSettings["Token"]!=null)
                {
                    var config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config1.AppSettings.Settings.Remove("Token");
                    config1.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Add("Token", Usermodel.user_session.token);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                return 1;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
        internal static void postFile()
        {

        }
        internal static void CheckToken(string token)
        {
            HttpClient htpc = new HttpClient();
            string value = System.Configuration.ConfigurationManager.AppSettings["TokenAddress"].ToString();
            htpc.BaseAddress = new Uri(value);
            var res = htpc.PostAsync("",new StringContent(JsonConvert.SerializeObject(new{token = token}),Encoding.UTF8, "application/json")).Result;
            var contents = res.Content.ReadAsStringAsync();
            Dictionary<string, string> resdict = JsonConvert.DeserializeObject<Dictionary<string, string>>(contents.Result);
            Usermodel.user_session = new Usermodel();
            if (resdict["signal"] == "done")
            {
                Usermodel.user_session.id= Convert.ToInt32(resdict["user"]);
                Usermodel.user_session.idrole = Convert.ToInt32(resdict["userrole"]);
            }
            if(resdict["signal"]=="login")
            {
                Usermodel.user_session.id = -1;
            }
            if (resdict["signal"] == "fail")
            {
                Usermodel.user_session.id = -1;
          
            }
        }

        internal static void Api_token_check()
        {
            string value = System.Configuration.ConfigurationManager.AppSettings["ApiAddress"].ToString();
            
        }
    }
}
