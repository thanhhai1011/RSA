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
using System.IO;
using Newtonsoft.Json.Converters;
using System.Net.Http.Headers;
using System.Web;
using System.Data;

namespace RSA.module
{
    class Api
    {
        class JSON_Infor
        {
            public string status;
            public string message;
        }

        internal static DataTable getListUserofFile(int idfile)
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("id", typeof(String));
            dtb.Columns.Add("email", typeof(String));
            string token = System.Configuration.ConfigurationManager.AppSettings["Token"].ToString();
            string value = System.Configuration.ConfigurationManager.AppSettings["getlistUser"].ToString();
            HttpClient htpc = new HttpClient();
            htpc.BaseAddress = new Uri(value);
            var res = htpc.PostAsync("",
                new StringContent(JsonConvert.SerializeObject(
                    new { token = token, idfile = idfile }
                ), Encoding.UTF8, "application/json")).Result;

            var contents = res.Content.ReadAsStringAsync();
            List<SUserModel> um = new List<SUserModel>();
            um = JsonConvert.DeserializeObject<List<SUserModel>>(contents.Result);
            foreach(SUserModel su in um)
            {
                dtb.Rows.Add(su.id, su.email);
            }
            return dtb;
        }

        internal static int AddUserofSharedFile(string email,string idfile)
        {
            string token = System.Configuration.ConfigurationManager.AppSettings["Token"].ToString();
            string value = System.Configuration.ConfigurationManager.AppSettings["userFileAddress"].ToString();

            HttpClient htpc = new HttpClient();
            htpc.BaseAddress = new Uri(value);
            var res = htpc.PostAsync("",
                new StringContent(JsonConvert.SerializeObject(
                    new { token = token,email = email,idfile=idfile }
                ), Encoding.UTF8, "application/json")).Result;

            var contents = res.Content.ReadAsStringAsync();
            if(contents.Result=="done")
            {
                return 1;
            }
            if (contents.Result == "fail")
            {
                return -1;
            }
            if (contents.Result == "notexist")
            {
                return 2;
            }
            if (contents.Result == "youremail")
            {
                return 3;
            }
            if (contents.Result == "themexist")
            {
                return 4;
            }
            return 0;
        }


        private static StreamContent CreateFileContent(Stream stream, string fileName, string contentType)
        {
            var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"files\"",
                FileName = "\"" + fileName + "\""
            }; // the extra quotes are key here
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            return fileContent;
        }
       
        public static DataTable postAPIGetListFile()
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("id", typeof(String));
            dtb.Columns.Add("file_name", typeof(String));
            dtb.Columns.Add("public_key", typeof(String));
            dtb.Columns.Add("date_upload", typeof(String));
            string token = System.Configuration.ConfigurationManager.AppSettings["Token"].ToString();
            string value = System.Configuration.ConfigurationManager.AppSettings["listFileAddress"].ToString();
            HttpClient htpc = new HttpClient();
            htpc.BaseAddress = new Uri(value);
            var res = htpc.PostAsync("", 
                new StringContent(JsonConvert.SerializeObject(
                    new { token = token }
                ), Encoding.UTF8, "application/json")).Result;
            var contents = res.Content.ReadAsStringAsync();
            List<SFileModel> fm = new List<SFileModel>();
            fm=JsonConvert.DeserializeObject<List<SFileModel>>(contents.Result);
            foreach(SFileModel item in fm)
            {
                DateTime dt = Convert.ToDateTime(item.create_at);
                dtb.Rows.Add(item.id,item.filename, item.key,(dt.Day+"/"+dt.Month+"/"+dt.Year).ToString());
            }
            return dtb;
        }

        public static int uploadFile(string file,string public_key)
        {
            string value = System.Configuration.ConfigurationManager.AppSettings["FilepostAddress"].ToString();
            HttpClient httpClient = new HttpClient();
            
            FileStream stream = File.OpenRead(file);
            byte[] fileBytes = new byte[stream.Length];
            stream.Read(fileBytes, 0, fileBytes.Length);
            
            FileStream stream1 = File.OpenRead(public_key);
            byte[] fileBytes1 = new byte[stream1.Length];
            stream1.Read(fileBytes1, 0, fileBytes1.Length);
          
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StringContent(Usermodel.user_session.id.ToString()), "iduser");
                content.Add(new ByteArrayContent(fileBytes,0, fileBytes.Length), "files", Path.GetFileName(file));
                content.Add(new ByteArrayContent(fileBytes1, 0, fileBytes1.Length), "files", Path.GetFileName(public_key));

                var test = httpClient.PostAsync(value, content).Result;
                stream.Close();
                stream1.Close();
                return Convert.ToInt32(test.EnsureSuccessStatusCode().StatusCode);
            }


        }

        internal static string DownloadFile(string id)
        {
            HttpClient htpc = new HttpClient();
            string token = System.Configuration.ConfigurationManager.AppSettings["Token"].ToString();
            string value = System.Configuration.ConfigurationManager.AppSettings["downloadFile"].ToString();
            htpc.BaseAddress = new Uri(value);
            var res = htpc.PostAsync("",
                      new StringContent(JsonConvert.SerializeObject(
                      new
                      {
                          token = token,
                          id = id
                      }),
                      Encoding.UTF8, "application/json")).Result;
            string contents = res.Content.ReadAsStringAsync().Result.ToString();
            return contents;
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
