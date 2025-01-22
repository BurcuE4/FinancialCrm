using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmAdminPaneli : Form
    {
        public FrmAdminPaneli()
        {
            InitializeComponent();
        }
        
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void btnGiris_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;

            
            var users = db.Logins.Where(x=>x.UserName==username && x.UserPassword==password);

            if (users != null)
            {
                FrmBanks frm = new FrmBanks();
                frm.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı", "Hatalı giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
}
