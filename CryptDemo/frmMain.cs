using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptDemo
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnOpenCrypt_Click(object sender, EventArgs e)
        {
            frmCrypt frm = new frmCrypt();
            frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmCrypt frm1 = new frmCrypt();
            frm1.Show();

            frmCrypt frm2 = new frmCrypt();
            frm2.Show();

            frm1.SetPublicKeyPartner(frm2.key.PublicKey);
            frm2.SetPublicKeyPartner(frm1.key.PublicKey);

            frm2.SetClearText(string.Concat(Enumerable.Repeat<string>("0123456789", 50)));
        }
    }
}
