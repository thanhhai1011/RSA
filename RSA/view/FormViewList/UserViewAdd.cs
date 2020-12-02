using RSA.module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
        private WebClient webClient;
        private void load()
        {
            label2.Text = "";
           dataGridView1.DataSource= Api.getListUserofFile(idfile);
           webClient = new WebClient();
           webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
           webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);

         
        }
        private string FormatBytes(long bytes, int decimalPlaces, bool showByteType)
        {
            double newBytes = bytes;
            string formatString = "{0";
            string byteType = "B";

            // Check if best size in KB
            if (newBytes > 1024 && newBytes < 1048576)
            {
                newBytes /= 1024;
                byteType = "KB";
            }
            else if (newBytes > 1048576 && newBytes < 1073741824)
            {
                // Check if best size in MB
                newBytes /= 1048576;
                byteType = "MB";
            }
            else
            {
                // Best size in GB
                newBytes /= 1073741824;
                byteType = "GB";
            }

            // Show decimals
            if (decimalPlaces > 0)
                formatString += ":0.";

            // Add decimals
            for (int i = 0; i < decimalPlaces; i++)
                formatString += "0";

            // Close placeholder
            formatString += "}";

            // Add byte type
            if (showByteType)
                formatString += byteType;

            return string.Format(formatString, newBytes);
        }
        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Update progressbar on download
            label2.Text = string.Format("Downloaded {0} of {1}", FormatBytes(e.BytesReceived, 1, true), FormatBytes(e.TotalBytesToReceive, 1, true));
            progressBar1.Value = e.ProgressPercentage;
       
        }

        private void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }
            else if (e.Cancelled)
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            else
            {
                label2.Text = "Verifying Download...";
                this.Close();
            }
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
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
            load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string api = Api.DownloadFile(idfile.ToString());

            if (api!="fail")
            {
                label2.Text = "Wait";
                try { webClient.DownloadFileAsync(new Uri("http://192.168.2.2:5000"+api), @"C:\\Users\\nam\\Desktop\\test\\"+Path.GetFileName(api)); }
                catch { this.DialogResult = DialogResult.No; this.Close(); }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
