﻿namespace RSA.view
{
    partial class RSA_File_manager
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
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnText = new System.Windows.Forms.Button();
            this.btnRSA = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(536, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 32);
            this.button1.TabIndex = 24;
            this.button1.Text = "Decrypt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox2.Location = new System.Drawing.Point(19, 314);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(491, 100);
            this.richTextBox2.TabIndex = 23;
            this.richTextBox2.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(19, 111);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(491, 132);
            this.richTextBox1.TabIndex = 22;
            this.richTextBox1.Text = "";
            // 
            // btnText
            // 
            this.btnText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnText.Location = new System.Drawing.Point(19, 80);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(103, 25);
            this.btnText.TabIndex = 21;
            this.btnText.Text = "Văn Bản";
            this.btnText.UseVisualStyleBackColor = true;
            this.btnText.Click += new System.EventHandler(this.btnText_Click);
            // 
            // btnRSA
            // 
            this.btnRSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRSA.Location = new System.Drawing.Point(19, 276);
            this.btnRSA.Name = "btnRSA";
            this.btnRSA.Size = new System.Drawing.Size(102, 32);
            this.btnRSA.TabIndex = 20;
            this.btnRSA.Text = "Encrypt";
            this.btnRSA.UseVisualStyleBackColor = true;
            this.btnRSA.Click += new System.EventHandler(this.btnRSA_Click);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(242, 51);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(111, 23);
            this.btnFile.TabIndex = 19;
            this.btnFile.Text = "Chọn File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(19, 54);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(197, 20);
            this.txtFile.TabIndex = 18;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(127, 276);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 32);
            this.button2.TabIndex = 26;
            this.button2.Text = "Download ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RSA_File_manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnText);
            this.Controls.Add(this.btnRSA);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.txtFile);
            this.MaximumSize = new System.Drawing.Size(796, 436);
            this.MinimumSize = new System.Drawing.Size(796, 436);
            this.Name = "RSA_File_manager";
            this.Size = new System.Drawing.Size(796, 436);
            this.Load += new System.EventHandler(this.RSA_File_manager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.Button btnRSA;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button button2;
    }
}
