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
    public partial class UserViewAdd : Form
    {
        public UserViewAdd()
        {
            InitializeComponent();
        }
        public int idfile;
        private void load()
        {
           dataGridView1.DataSource= Api.getListUserofFile(idfile);
        }
        private void UserViewAdd_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           int check = Api.AddUserofSharedFile(textBox1.Text,idfile.ToString());
            if(check==1)
            {
                MessageBox.Show("Done!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(check==-1)
            {
                MessageBox.Show("Fail!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(check==2)
            {
                MessageBox.Show("Email not Exist!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(check==3)
            {
                MessageBox.Show("You can't add your email!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(check==4)
            {
                MessageBox.Show("This user exist!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
