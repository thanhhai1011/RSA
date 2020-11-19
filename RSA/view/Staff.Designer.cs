namespace RSA.view
{
    partial class Staff
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDown = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnText = new System.Windows.Forms.Button();
            this.btnRSA = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(503, 320);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(111, 23);
            this.btnDown.TabIndex = 13;
            this.btnDown.Text = "Tải xuống";
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(185, 320);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(278, 20);
            this.textBox2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(306, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 31);
            this.label1.TabIndex = 11;
            this.label1.Text = "Phần Mềm RSA";
            // 
            // btnText
            // 
            this.btnText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnText.Location = new System.Drawing.Point(185, 179);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(185, 100);
            this.btnText.TabIndex = 10;
            this.btnText.Text = "Văn Bản";
            this.btnText.UseVisualStyleBackColor = true;
            // 
            // btnRSA
            // 
            this.btnRSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRSA.Location = new System.Drawing.Point(429, 179);
            this.btnRSA.Name = "btnRSA";
            this.btnRSA.Size = new System.Drawing.Size(185, 100);
            this.btnRSA.TabIndex = 9;
            this.btnRSA.Text = "RSA";
            this.btnRSA.UseVisualStyleBackColor = true;
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(503, 104);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(111, 23);
            this.btnFile.TabIndex = 8;
            this.btnFile.Text = "Chọn File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(185, 104);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(278, 20);
            this.txtFile.TabIndex = 7;
            //this.txtFile.TextChanged += new System.EventHandler(this.txtFile_TextChanged);
            // 
            // Staff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnText);
            this.Controls.Add(this.btnRSA);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.txtFile);
            this.Name = "Staff";
            this.Text = "Staff";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.Button btnRSA;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox txtFile;
    }
}