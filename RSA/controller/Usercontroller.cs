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

       
        public static string encypt_text(string text)
        {
            create_keys();
            int j = 0;
            int i = 0;
            List<string> get_list_text = new List<string>();
            while(i<text.Length)
            {
                if (j == 50)
                {
                    get_list_text.Add(text.Substring(i-50, 50));
                    j = 0;
                }
                else
                {
                    j += 1;
                    i += 1;
                }
            }
            int r = text.Length - get_list_text.Count * 50;
            get_list_text.Add(text.Substring(text.Length - r, r));
            string[] line_text = get_list_text.ToArray();
           
           
            List<string> k = new List<string>();
            foreach (string line in line_text)
            {
                byte[] message = Encoding.UTF8.GetBytes(line);
                rsa = Generate_Keys.load_keys(id);
                byte[] new_enc_byte = rsa.PrivateEncryption(message);
                byte[] decryptMsg = rsa.PublicDecryption(new_enc_byte);
                string de_string = Encoding.UTF8.GetString(decryptMsg);
                string test_string=line;
                while(de_string!= test_string)
                {
                    string a = "";
                    test_string = "k@" + line;
                    message = Encoding.UTF8.GetBytes(test_string);
                    new_enc_byte = rsa.PrivateEncryption(message);
                    decryptMsg = rsa.PublicDecryption(new_enc_byte);
                    de_string = Encoding.UTF8.GetString(decryptMsg);
                }
                int[] bytesAsInts = new_enc_byte.Select(x => (int)x).ToArray();
                List<string> new_lne = new List<string>();
                foreach(int a in bytesAsInts)
                {
                    new_lne.Add(a.ToString());
                }
                k.Add(String.Join(" ",new_lne));
            }
            string[] test = k.ToArray();
            string result = String.Join("\n",test);
            return result;
        }

        internal static string decypt_text(string text)
        {

            rsa = Generate_Keys.load_keys(id);
            string[] text_array = text.Split('\n');
           
            List<string> result = new List<string>();
            foreach (string line in text_array)
            {
                if (line != " " && line!="")
                {
                    try
                    {
                        string[] test = line.Split(' ');
                        int[] myInts = new int[128];
                        int j = 0;
                        foreach(string chec in test)
                        {
                            try
                            {
                                myInts[j] = int.Parse(chec);
                                j += 1;
                            }
                            catch
                            {

                            }
                        }
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
                    catch
                    {
                        Console.WriteLine(1);
                    }
                }
            }
            string[] test1 = result.ToArray();
            string enc_result = String.Join("", test1);
            return enc_result;

        }
    }
}
