using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RSAEncryptionLib;
using test.module;

namespace RSA.module
{
    class Generate_Keys
    {
        
        public static List<string> genertate_key(string id)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string private_keys = String.Format(System.IO.Directory.GetCurrentDirectory()+"/keys/privateKey_{0}.xml", id);
            string public_keys = String.Format(System.IO.Directory.GetCurrentDirectory()+"/keys/publicKey_{0}.xml", id);
            File.WriteAllText(private_keys, rsa.ToXmlString(true));  // Private Key
            File.WriteAllText(public_keys, rsa.ToXmlString(false));  // Public Key
            List<string> list_keys = new List<string>();
            list_keys.Append(private_keys);
            list_keys.Append(public_keys);
            return list_keys;
        }

        internal static RSAEncryption load_keys(string idkeys)
        {
            RSAEncryption myRsa = new RSAEncryption();
            string private_keys = String.Format(System.IO.Directory.GetCurrentDirectory() + "/keys/privateKey_{0}.xml", idkeys);
            string public_keys = String.Format(System.IO.Directory.GetCurrentDirectory() + "/keys/publicKey_{0}.xml", idkeys);

            myRsa.LoadPrivateFromXml(private_keys);
            return myRsa;

        }
       
        internal static RSAEncryption load_keysFile(string filekey)
        {
        
            RSAEncryption myRsa = new RSAEncryption();
            string public_keys = filekey;

            myRsa.LoadPublicFromXml(public_keys);
            return myRsa;

        }


        internal static RSAEncryption load_keys1(string idkeys)
        {
            RSAEncryption myRsa = new RSAEncryption();
            string public_keys = String.Format(System.IO.Directory.GetCurrentDirectory() + "/keys/publicKey_{0}.xml", idkeys);
            myRsa.LoadPublicFromXml(public_keys);
            return myRsa;
        }
    }
}
