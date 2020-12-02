using RSA.module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA.view.FormViewList
{
    public partial class UserviewAdd1 : Form
    {
        public UserviewAdd1()
        {
            InitializeComponent();
        }
        public int idfile;
        private void load()
        {
            int check = Api.check_permision_of_file(idfile.ToString());
            if(check==1)
            {
                btnDownload.Visible = true;
                btnPublic.Visible = true;
            }
            else
            {
                btnDownload.Visible = true;
                btnPublic.Visible = false;
            }
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {

        }

        private void UserviewAdd1_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
