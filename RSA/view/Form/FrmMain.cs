using RSA.model;
using RSA.module;
using RSA.view.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA.view
{
    public partial class FrmMain : Form
    {
       public static FrmMain static_FrmMain;
       public FrmMain()
        {
            InitializeComponent();
        }
        public RSA_File_manager rsafile;
        public DecryptText dt;
        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (System.Configuration.ConfigurationManager.AppSettings["Token"] != null)
            {
                string token = System.Configuration.ConfigurationManager.AppSettings["Token"].ToString();
                Api.CheckToken(token);
                if(Usermodel.user_session.id>0)
                {
                    if(Usermodel.user_session.idrole==1)
                    {
                        rsafile = new RSA_File_manager();
                        panel1.Controls.Add(rsafile);
                        panel2.Hide();
                        rsafile.Show();
                        dt = new DecryptText();
                        panel1.Controls.Add(dt);
                        dt.Hide(); 
                 
                    }
                }
                if (Usermodel.user_session.id == -1)
                {
                    Login lg = new Login();
                    panel2.Controls.Add(lg);
                    lg.Show();
                }
            }
            else
            {
                Login lg = new Login();
                panel2.Controls.Add(lg);
                lg.Show();
            }
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            panel2.Location = new Point(
                this.ClientSize.Width / 2 - panel2.Size.Width / 2,
                this.ClientSize.Height / 2 - panel2.Size.Height / 2);
            panel2.Anchor = AnchorStyles.None;
            if (UCAdmin.static_admin != null)
            {
                UCAdmin.static_admin.Size = new Size(FrmMain.static_FrmMain.panel1.Size.Width, FrmMain.static_FrmMain.panel1.Size.Height);
            }
            if (RSA_File_manager.static_rsa != null)
            {
                RSA_File_manager.static_rsa.Size = new Size(FrmMain.static_FrmMain.panel1.Size.Width, FrmMain.static_FrmMain.panel1.Size.Height);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dt.Show();
            rsafile.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt.Hide();
            rsafile.Show();
        }
    }
}
