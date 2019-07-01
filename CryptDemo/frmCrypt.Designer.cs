namespace CryptDemo
{
    partial class frmCrypt
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
            this.components = new System.ComponentModel.Container();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.grpLeft = new System.Windows.Forms.GroupBox();
            this.txtPublicKeyPartner = new System.Windows.Forms.TextBox();
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.btnCrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.grpMessage = new System.Windows.Forms.GroupBox();
            this.txtCryptText = new System.Windows.Forms.TextBox();
            this.txtClearText = new System.Windows.Forms.TextBox();
            this.btnKey = new System.Windows.Forms.Button();
            this.tiptxtClearText = new System.Windows.Forms.ToolTip(this.components);
            this.grpLeft.SuspendLayout();
            this.grpMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrivateKey.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrivateKey.Location = new System.Drawing.Point(6, 21);
            this.txtPrivateKey.Multiline = true;
            this.txtPrivateKey.Name = "txtPrivateKey";
            this.txtPrivateKey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPrivateKey.Size = new System.Drawing.Size(604, 160);
            this.txtPrivateKey.TabIndex = 0;
            // 
            // grpLeft
            // 
            this.grpLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLeft.Controls.Add(this.txtPublicKeyPartner);
            this.grpLeft.Controls.Add(this.txtPublicKey);
            this.grpLeft.Controls.Add(this.txtPrivateKey);
            this.grpLeft.Location = new System.Drawing.Point(12, 12);
            this.grpLeft.Name = "grpLeft";
            this.grpLeft.Size = new System.Drawing.Size(626, 522);
            this.grpLeft.TabIndex = 2;
            this.grpLeft.TabStop = false;
            this.grpLeft.Text = "Key";
            // 
            // txtPublicKeyPartner
            // 
            this.txtPublicKeyPartner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPublicKeyPartner.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPublicKeyPartner.Location = new System.Drawing.Point(6, 353);
            this.txtPublicKeyPartner.Multiline = true;
            this.txtPublicKeyPartner.Name = "txtPublicKeyPartner";
            this.txtPublicKeyPartner.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPublicKeyPartner.Size = new System.Drawing.Size(604, 160);
            this.txtPublicKeyPartner.TabIndex = 2;
            this.txtPublicKeyPartner.Click += new System.EventHandler(this.txtPublicKeyPartner_Click);
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPublicKey.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPublicKey.Location = new System.Drawing.Point(6, 187);
            this.txtPublicKey.Multiline = true;
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPublicKey.Size = new System.Drawing.Size(604, 160);
            this.txtPublicKey.TabIndex = 1;
            this.txtPublicKey.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPublicKey_MouseClick);
            // 
            // btnCrypt
            // 
            this.btnCrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrypt.Location = new System.Drawing.Point(644, 26);
            this.btnCrypt.Name = "btnCrypt";
            this.btnCrypt.Size = new System.Drawing.Size(83, 37);
            this.btnCrypt.TabIndex = 4;
            this.btnCrypt.Text = "&Crypt";
            this.btnCrypt.UseVisualStyleBackColor = true;
            this.btnCrypt.Click += new System.EventHandler(this.btnCrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDecrypt.Location = new System.Drawing.Point(644, 69);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(83, 37);
            this.btnDecrypt.TabIndex = 5;
            this.btnDecrypt.Text = "&Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // grpMessage
            // 
            this.grpMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMessage.Controls.Add(this.txtCryptText);
            this.grpMessage.Controls.Add(this.txtClearText);
            this.grpMessage.Location = new System.Drawing.Point(733, 12);
            this.grpMessage.Name = "grpMessage";
            this.grpMessage.Size = new System.Drawing.Size(626, 522);
            this.grpMessage.TabIndex = 3;
            this.grpMessage.TabStop = false;
            this.grpMessage.Text = "Message";
            // 
            // txtCryptText
            // 
            this.txtCryptText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCryptText.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCryptText.Location = new System.Drawing.Point(6, 187);
            this.txtCryptText.Multiline = true;
            this.txtCryptText.Name = "txtCryptText";
            this.txtCryptText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCryptText.Size = new System.Drawing.Size(604, 326);
            this.txtCryptText.TabIndex = 1;
            // 
            // txtClearText
            // 
            this.txtClearText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClearText.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClearText.Location = new System.Drawing.Point(6, 21);
            this.txtClearText.Multiline = true;
            this.txtClearText.Name = "txtClearText";
            this.txtClearText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtClearText.Size = new System.Drawing.Size(604, 160);
            this.txtClearText.TabIndex = 0;
            this.txtClearText.TextChanged += new System.EventHandler(this.txtClearText_TextChanged);
            // 
            // btnKey
            // 
            this.btnKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKey.Location = new System.Drawing.Point(644, 112);
            this.btnKey.Name = "btnKey";
            this.btnKey.Size = new System.Drawing.Size(83, 37);
            this.btnKey.TabIndex = 6;
            this.btnKey.Text = "&Key";
            this.btnKey.UseVisualStyleBackColor = true;
            this.btnKey.Click += new System.EventHandler(this.btnKey_Click);
            // 
            // frmCrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 542);
            this.Controls.Add(this.btnKey);
            this.Controls.Add(this.grpMessage);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnCrypt);
            this.Controls.Add(this.grpLeft);
            this.Name = "frmCrypt";
            this.Text = "Crypt Demo";
            this.Load += new System.EventHandler(this.frmCrypt_Load);
            this.grpLeft.ResumeLayout(false);
            this.grpLeft.PerformLayout();
            this.grpMessage.ResumeLayout(false);
            this.grpMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.GroupBox grpLeft;
        private System.Windows.Forms.TextBox txtPublicKeyPartner;
        private System.Windows.Forms.TextBox txtPublicKey;
        private System.Windows.Forms.Button btnCrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.GroupBox grpMessage;
        private System.Windows.Forms.TextBox txtCryptText;
        private System.Windows.Forms.TextBox txtClearText;
        private System.Windows.Forms.Button btnKey;
        private System.Windows.Forms.ToolTip tiptxtClearText;
    }
}

