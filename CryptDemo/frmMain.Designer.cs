﻿namespace CryptDemo
{
    partial class frmMain
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
            this.btnOpenCrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenCrypt
            // 
            this.btnOpenCrypt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenCrypt.Location = new System.Drawing.Point(0, 0);
            this.btnOpenCrypt.Name = "btnOpenCrypt";
            this.btnOpenCrypt.Size = new System.Drawing.Size(295, 108);
            this.btnOpenCrypt.TabIndex = 0;
            this.btnOpenCrypt.Text = "&Open Crypt ...";
            this.btnOpenCrypt.UseVisualStyleBackColor = true;
            this.btnOpenCrypt.Click += new System.EventHandler(this.btnOpenCrypt_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 108);
            this.Controls.Add(this.btnOpenCrypt);
            this.Name = "frmMain";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenCrypt;
    }
}