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
                    RSA_File_manager rsafile = new RSA_File_manager();
                    FrmMain.static_FrmMain.panel1.Controls.Add(rsafile);
                    FrmMain.static_FrmMain.panel2.Hide();
                    rsafile.Show();
                }
            }
            else
            {
                MessageBox.Show("Sai tai khoan va mat khau", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
