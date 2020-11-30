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
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
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

        private void btnText_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = ReadWordFile.test(txtFile.Text);
        }
        string idkeys;
        private void btnRSA_Click(object sender, EventArgs e)
        {
            string[] result = Usercontroller.encypt_text(richTextBox1.Text);
            richTextBox2.Text = result[0];
            idkeys = result[1];
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
    }
}
