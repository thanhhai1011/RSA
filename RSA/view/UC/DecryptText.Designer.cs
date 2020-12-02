namespace RSA.view.UC
{
    partial class DecryptText
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnText = new System.Windows.Forms.Button();
            this.btnRSA = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox2.Location = new System.Drawing.Point(34, 290);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(491, 129);
            this.richTextBox2.TabIndex = 32;
            this.richTextBox2.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(34, 87);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(491, 132);
            this.richTextBox1.TabIndex = 31;
            this.richTextBox1.Text = "";
            // 
            // btnText
            // 
            this.btnText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnText.Location = new System.Drawing.Point(34, 56);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(103, 25);
            this.btnText.TabIndex = 30;
            this.btnText.Text = "Văn Bản";
            this.btnText.UseVisualStyleBackColor = true;
            this.btnText.Click += new System.EventHandler(this.btnText_Click);
            // 
            // btnRSA
            // 
            this.btnRSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRSA.Location = new System.Drawing.Point(34, 252);
            this.btnRSA.Name = "btnRSA";
            this.btnRSA.Size = new System.Drawing.Size(102, 32);
            this.btnRSA.TabIndex = 29;
            this.btnRSA.Text = "Decrypt";
            this.btnRSA.UseVisualStyleBackColor = true;
            this.btnRSA.Click += new System.EventHandler(this.btnRSA_Click);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(414, 30);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(111, 23);
            this.btnFile.TabIndex = 28;
            this.btnFile.Text = "Chọn File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(211, 30);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(197, 20);
            this.txtFile.TabIndex = 27;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(414, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Chọn File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(211, 62);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(197, 20);
            this.txtKey.TabIndex = 35;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(531, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(362, 332);
            this.dataGridView1.TabIndex = 36;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(531, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Your File";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(596, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Your Shared File";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(531, 41);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(133, 25);
            this.progressBar1.TabIndex = 39;
            // 
            // DecryptText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnText);
            this.Controls.Add(this.btnRSA);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.txtFile);
            this.Name = "DecryptText";
            this.Size = new System.Drawing.Size(900, 436);
            this.Load += new System.EventHandler(this.DecryptText_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.Button btnRSA;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
