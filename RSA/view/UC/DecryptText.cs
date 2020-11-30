using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using RSA.module;
using RSA.controller;
using RSA.view.FormViewList;

namespace RSA.view.UC
{
    public partial class DecryptText : UserControl
    {
        public DecryptText()
        {
            InitializeComponent();
        }

        private void btnRSA_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = Usercontroller.decypt_text(richTextBox1.Text,txtKey.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }
        int file_view;
        public void load()
        {
            file_view = 0;
            dataGridView1.DataSource = Api.postAPIGetListFile();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName = dlg.FileName;
                txtKey.Text = fileName;
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

        private void label1_Click(object sender, EventArgs e)
        {
            load();
        }

        private void DecryptText_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(file_view==0)
            {
                UserViewAdd uva = new UserViewAdd();
                uva.idfile =Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                uva.Show();
            }
        }
    }
}
