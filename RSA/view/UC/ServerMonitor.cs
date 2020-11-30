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

namespace RSA.view.UC
{
    public partial class ServerMonitor : UserControl
    {
        public ServerMonitor()
        {
            InitializeComponent();
        }
        public void load()
        {
            dataGridView1.DataSource= Api.postAPIGetListFile();
        }
        private void ServerMonitor_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
