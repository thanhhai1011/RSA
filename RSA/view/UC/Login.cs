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
using RSA.model;

namespace RSA.view.UC
{
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Api.post_API_login(txtUser.Text, txtPassword.Text) == 1)
            {
                if (Usermodel.user_session.idrole == 1)
                {
                    UCAdmin.static_admin = new UCAdmin();
                    FrmMain.static_FrmMain.panel1.Controls.Add(UCAdmin.static_admin);
                    UCAdmin.static_admin.Size =new Size(FrmMain.static_FrmMain.panel1.Size.Width, FrmMain.static_FrmMain.panel1.Size.Height);
                    UCAdmin.static_admin.Show();
                }
                else
                {
                    RSA_File_manager.static_rsa = new RSA_File_manager();
                    FrmMain.static_FrmMain.panel1.Controls.Add(RSA_File_manager.static_rsa);
                    RSA_File_manager.static_rsa.Size = new Size(FrmMain.static_FrmMain.panel1.Size.Width, FrmMain.static_FrmMain.panel1.Size.Height);
                    RSA_File_manager.static_rsa.Show();
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
