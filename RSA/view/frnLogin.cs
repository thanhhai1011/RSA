using RSA.controller;
using RSA.model;
using RSA.module;
using RSA.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Api.post_API_login(txtUser.Text,txtPassword.Text) == 1)
            {
                if (Usermodel.user_session.idrole == 1)
                {
                   
                }
                else
                {
                  
                }
                FrmMain.static_FrmMain.panel2.Hide();
            }
            else
            {
                MessageBox.Show("Sai tai khoan va mat khau", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}
