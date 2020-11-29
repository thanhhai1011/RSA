﻿using System;
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

namespace RSA.view
{
    public partial class RSA_File_manager : UserControl
    {
        public static RSA_File_manager static_rsa;
        public RSA_File_manager()
        {
            InitializeComponent();
        }

        private void RSA_File_manager_Load(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ReadWordFile.writeWordFile(richTextBox2.Text, Path.GetFileName(txtFile.Text),idkeys);
                MessageBox.Show("Done", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("Fail", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
