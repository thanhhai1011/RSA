﻿using RSA.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.module;

namespace RSA.module
{
    class ReadWordFile
    {
        public static string test(string file)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = file;
            object readOnly = true;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            string totaltext = "";
            for (int i = 0; i < docs.Paragraphs.Count; i++)
            {
                
                totaltext += " \r\n " + docs.Paragraphs[i + 1].Range.Text.ToString();
            }
            docs.Close();
            word.Quit();
            return totaltext;

        }
        private static string createWordFile(string file)
        {
            Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
            winword.Visible = false;
            object missing = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            object filename = System.IO.Directory.GetCurrentDirectory() + "/encryptdocs/"+file;
            document.SaveAs2(filename);
            document.Close(ref missing, ref missing, ref missing);
            document = null;
            winword.Quit(ref missing, ref missing, ref missing);
            return filename.ToString();
        }
        public static string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }
        public static string writeWordFile(string text,string file_name,string id)
        {
            string file = Usermodel.user_session.id + "_" + file_name;
            string docx = createWordFile(Path.GetFileNameWithoutExtension(file)+"_"+GetRandomString() + Path.GetExtension(file)).Replace('/','\\');
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(docx);
            object missing = System.Reflection.Missing.Value;
            doc.Content.Text +=text;
            app.Visible = false;  
            doc.Save();
            doc.Close();
            return docx;
        }
    }
}
