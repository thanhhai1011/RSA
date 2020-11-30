using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA.controller
{
    class FileController
    {
        public static string[] getPubickeys(string file)
        {
            string filePath = System.IO.Directory.GetCurrentDirectory() + "\\encryptdocs\\" + file;
            filePath= filePath.Replace("\\", @"\");
            DBFileManagerDataContext db = new DBFileManagerDataContext();
            var public_Keys_id = from table in db.myfiles where table.file_loca == filePath select table;
            string code = public_Keys_id.First().code.ToString();
            string path = public_Keys_id.First().file_loca.ToString();
            string[] result = { code, path };
            return result;
        }
    }
}
