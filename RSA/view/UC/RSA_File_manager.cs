using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSA.module;
using RSA.controller;
using System.IO;
using RSA.model;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using RSAEncryptionLib;

namespace RSA.view
{
    public partial class RSA_File_manager : UserControl
    {
        public static RSA_File_manager static_rsa;
        public RSA_File_manager()
        {
            InitializeComponent();
        }
        public DataTable getListFile()
        {
            DataTable dtb = new DataTable();
            return dtb;
        }
        public void ConvertDocToDocx(string path)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();

            if (path.ToLower().EndsWith(".doc"))
            {
                var sourceFile = new FileInfo(path);
                var document = word.Documents.Open(sourceFile.FullName);

                string newFileName = sourceFile.FullName.Replace(".doc", ".docx");
                document.SaveAs2(newFileName, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatXMLDocument,
                                 CompatibilityMode: Microsoft.Office.Interop.Word.WdCompatibilityMode.wdWord2010);

                word.ActiveDocument.Close();
                word.Quit();

                File.Delete(path);
            }
        }
        public static string TextFromWord(string filename)
        {
            StringBuilder textBuilder = new StringBuilder();
            using (WordprocessingDocument wDoc = WordprocessingDocument.Open(filename, false))
            {
                var parts = wDoc.MainDocumentPart.Document.Descendants().FirstOrDefault();
                if (parts != null)
                {
                    foreach (var node in parts.ChildElements)
                    {
                        if (node is Paragraph)
                        {
                            ProcessParagraph((Paragraph)node, textBuilder);
                            textBuilder.AppendLine("");
                        }

                        if (node is Table)
                        {
                            ProcessTable((Table)node, textBuilder);
                        }
                    }
                }
            }
            return textBuilder.ToString();
        }

        private static void ProcessTable(Table node, StringBuilder textBuilder)
        {
            foreach (var row in node.Descendants<TableRow>())
            {
                textBuilder.Append("| ");
                foreach (var cell in row.Descendants<TableCell>())
                {
                    foreach (var para in cell.Descendants<Paragraph>())
                    {
                        ProcessParagraph(para, textBuilder);
                    }
                    textBuilder.Append(" | ");
                }
                textBuilder.AppendLine("");
            }
        }

        private static void ProcessParagraph(Paragraph node, StringBuilder textBuilder)
        {
            foreach (var text in node.Descendants<Text>())
            {
                textBuilder.Append(text.InnerText);
            }
        }
        public void load()
        {
            txtFile.Text = "";
            textBox1.Text = "";
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            DataTable datafile = new DataTable();
            datafile.Columns.Add("file", typeof(String));
            datafile.Columns.Add("create_at", typeof(String));
            string filepath = System.IO.Directory.GetCurrentDirectory() + "/encryptdocs/";
            DirectoryInfo d = new DirectoryInfo(filepath);

            foreach (var file in d.GetFiles("*.doc"))
            {
                if (file.Name[0].ToString() != "~")
                {
                    datafile.Rows.Add(file.Name, file.CreationTime);
                }
            }
            foreach (var file in d.GetFiles("*.docx"))
            {
                if (file.Name[0].ToString() != "~")
                {
                    datafile.Rows.Add(file.Name, file.CreationTime);
                }
            }

            dataGridView1.DataSource = datafile;

        }
        private void RSA_File_manager_Load(object sender, EventArgs e)
        {
            load();
            backgroundWorker1.WorkerReportsProgress = true;
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            i1 = 0;
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName = dlg.FileName;
                txtFile.Text = fileName;
            }
            string filePath = dlg.FileName;
            string[] lines;
            string str;
            if (System.IO.File.Exists(filePath))
            {
                lines = System.IO.File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine("Line{0}: {1}", i, lines[i]);
                }
                Console.WriteLine();
                str = System.IO.File.ReadAllText(filePath);
                Console.WriteLine("String: {0}", str);
            }
            else
            {
                Console.WriteLine("File does not exits");
            }
        }
        string totaltext;
        int n_find;
        Microsoft.Office.Interop.Word.Application word;
        Microsoft.Office.Interop.Word.Document docs;
        private void btnText_Click(object sender, EventArgs e)
        {
            ConvertDocToDocx(txtFile.Text);
            string text = TextFromWord(txtFile.Text);
            richTextBox1.Text = text;
            //backgroundWorker1.RunWorkerAsync(docs);
            return;
        }
        string idkeys;
        private void btnRSA_Click(object sender, EventArgs e)
        {
            e_text = richTextBox1.Text;
            backgroundWorker1.RunWorkerAsync();
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //richTextBox3.Text = Usercontroller.decypt_text(richTextBox2.Text);
        }
        string filetext;
        public static string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                filetext= ReadWordFile.writeWordFile(richTextBox2.Text, Path.GetFileName(txtFile.Text),idkeys);
                FileModel fm = new FileModel(idkeys,filetext);
                fm.insertFile();

                MessageBox.Show("Done", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RSA_File_manager_Load(sender, e);

            }
            catch (Exception)
            {
                MessageBox.Show("Fail", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
           
           string[] infor = FileController.getPubickeys(textBox1.Text);
           string filePath = infor[1];
           string public_key = System.IO.Directory.GetCurrentDirectory() + "/keys/" + "publicKey_" + infor[0]+".xml";
           int check = Api.uploadFile(filePath,public_key);
           if(check==200)
           {
                System.IO.File.Delete(filePath);
                FrmMain.static_FrmMain.serverm.load();
                load();
                MessageBox.Show("Upload Complete!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
           else
           {
                MessageBox.Show("Fail!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }
        int i = 0;
        private static RSAEncryption rsa;
        private static string id;
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
            List<string> list_keys = Generate_Keys.genertate_key(idkeys);
            rsa = Generate_Keys.load_keys(idkeys);
        }

        string[] result1;
        string e_text;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string text = e_text;
            create_keys();
            int j = 0;
            int i = 0;
            List<string> get_list_text = new List<string>();
            while (i < text.Length)
            {
                if (j == 50)
                {
                    get_list_text.Add(text.Substring(i - 50, 50));
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

            int i1 = 0;
            List<string> k = new List<string>();
            foreach (string line in line_text)
            {
                i1 += 1;

                byte[] message = Encoding.UTF8.GetBytes(line);
                rsa = Generate_Keys.load_keys(id);
                byte[] new_enc_byte = rsa.PrivateEncryption(message);
                byte[] decryptMsg = rsa.PublicDecryption(new_enc_byte);
                string de_string = Encoding.UTF8.GetString(decryptMsg);
                string test_string = line;
                while (de_string != test_string)
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
                foreach (int a in bytesAsInts)
                {
                    new_lne.Add(a.ToString());
                }
                k.Add(String.Join(" ", new_lne));
                double rep = Convert.ToDouble(i1) / Convert.ToDouble(line_text.Length);
                int rport = Convert.ToInt32(rep * 100);
                backgroundWorker1.ReportProgress(rport);
            }
            string[] test = k.ToArray();
            string[] check1 = { String.Join("\n", test), id };
            result1 = check1;
           

        }
        int i1=0;
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        
            progressBar1.Value = 0;
            richTextBox2.Text = result1[0];
            idkeys = result1[1];
        }
    }
}
