using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db= new FinancialCrmDbEntities();
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string username = txtuserName.Text;
            string password = txtPassword.Text;

            int id=int.Parse(txtId.Text);

            var users = db.Logins.Where(x =>x.UserId== id  && x.UserName == username && x.UserPassword == password);

            var values = db.Logins.Find(id);
            values.UserName = username;
            values.UserPassword = password;
            values.UserId = id;
            db.Logins.AddOrUpdate(values);
            db.SaveChanges();

            MessageBox.Show("Kullanıcı Başarılı Bir Şekilde Sistemde Güncellendi!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategory category = new FrmCategory();
            category.Show();
            this.Hide();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks f= new FrmBanks();
            f.Show();
            this.Hide();
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            FrmBilling b= new FrmBilling();
            b.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string userName=txtuserName.Text;
            var password=txtPassword.Text;

            Login login = new Login();
            login.UserName = userName;
            login.UserPassword = password;
            db.Logins.Add(login);
            db.SaveChanges();

            MessageBox.Show("Yeni Kullanıcı Girişi Oluşmuştur","Dikkat",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGiderler_Click(object sender, EventArgs e)
        {
            FrmBankaHareketleri frm= new FrmBankaHareketleri();
            frm.Show();
            this.Hide();
        }

        private void btnBankaHareketleri_Click(object sender, EventArgs e)
        {
            FrmBankaHareketleri f= new FrmBankaHareketleri();
            f.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frm= new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            FrmSettings frm= new FrmSettings();
            frm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            FrmExit frm= new FrmExit();
            frm.Show();
            this.Hide();
        }
    }
}
