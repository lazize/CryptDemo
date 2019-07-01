using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptDemo
{
    public partial class frmCrypt : Form
    {
        public CryptKey key;

        public frmCrypt()
        {
            InitializeComponent();
        }
        private void frmCrypt_Load(object sender, EventArgs e)
        {
            btnKey_Click(sender, e);
        }

        private void txtPublicKey_MouseClick(object sender, MouseEventArgs e)
        {
            txtPublicKey.SelectAll();
        }

        private void txtPublicKeyPartner_Click(object sender, EventArgs e)
        {
            txtPublicKeyPartner.SelectAll();
        }

        private void btnCrypt_Click(object sender, EventArgs e)
        {
            try
            {
                EncryptedAsymmetric encrypted = CryptHandler.Encrypt(txtPrivateKey.Text, txtPublicKeyPartner.Text, txtClearText.Text);
                txtCryptText.Text = Newtonsoft.Json.JsonConvert.SerializeObject(encrypted);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                EncryptedAsymmetric encrypted = Newtonsoft.Json.JsonConvert.DeserializeObject<EncryptedAsymmetric>(txtCryptText.Text);
                txtClearText.Text = CryptHandler.Decrypt(txtPrivateKey.Text, txtPublicKeyPartner.Text, encrypted);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnKey_Click(object sender, EventArgs e)
        {
            key = CryptHandler.CreateKey();

            txtPrivateKey.Text = key.PrivateKey;
            txtPublicKey.Text = key.PublicKey;
        }

        private void txtClearText_TextChanged(object sender, EventArgs e)
        {
            tiptxtClearText.SetToolTip(txtClearText, txtClearText.Text.Length.ToString());
        }

        public void SetPublicKeyPartner(string xmlPublicKey)
        {
            txtPublicKeyPartner.Text = xmlPublicKey;
        }

        public void SetClearText(string text)
        {
            txtClearText.Text = text;
        }
    }
}
