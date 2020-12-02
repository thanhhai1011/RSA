using RSA.model;
using RSA.module;
using RSAEncryptionLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.module;
using System.Numerics;
namespace RSA.controller
{
    class Usercontroller
    {
        private static RSAEncryption rsa;
        private static string id;
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
        private static string create_id()
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(11)
                .ToList().ForEach(e => builder.Append(e));
            string id = builder.ToString();
            return id;
        }
        private static void create_keys()
        {
            string idkeys = create_id();

            id = idkeys;
            List<string> list_keys =  Generate_Keys.genertate_key(idkeys);
            rsa = Generate_Keys.load_keys(idkeys);
        }

       
        public static string[] encypt_text(string text)
        {
            return null;
        }

        internal static string decypt_text(string text,string key)
        {


            rsa = Generate_Keys.load_keysFile(key);
            string[] text_array = text.Split('\n');
           
            List<string> result = new List<string>();
            foreach (string line in text_array)
            {
                try
                {
                    if (line != " ")
                    {

                        string[] test = line.Trim().Split(' ');

                        int[] myInts = Array.ConvertAll(test, s => int.Parse(s));
                        byte[] bytes = new byte[myInts.Length];
                        for (int i = 0; i < myInts.Length; i++)
                        {
                            bytes[i] = (byte)myInts[i];
                        }

                        byte[] decryptMsg = rsa.PublicDecryption(bytes);
                        string de_string = Encoding.UTF8.GetString(decryptMsg);
                        if (de_string.StartsWith("k@"))
                        {
                            de_string = de_string.Substring(2, de_string.Length - 2);
                        }
                        result.Add(de_string);
                        //rsa = Generate_Keys.load_keys1(id);
                        //byte[] decryptMsg = rsa.PublicDecryption(test1);
                        //string de_string = Encoding.UTF8.GetString(decryptMsg);
                    }
                }
                catch
                {
                    Console.WriteLine(1);
                }
            }
            string[] test1 = result.ToArray();
            string enc_result = String.Join("", test1);
            return enc_result;

        }
    }
}
