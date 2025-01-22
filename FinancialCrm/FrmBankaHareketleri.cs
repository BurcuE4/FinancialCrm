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
    public partial class FrmBankaHareketleri : Form
    {
        public FrmBankaHareketleri()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmBankaHareketleri_Load(object sender, EventArgs e)
        {
            var values = db.BankProcesses.Select(x => new
            {
                x.BankProcessId,
                x.Description,
                x.ProcessDate,
                x.ProcessType,
                x.Amount,
                x.Banks.BankTitle
            }).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.BankProcesses.Select(x => new
            {
                x.BankProcessId,
                x.Description,
                x.ProcessDate,
                x.ProcessType,
                x.Amount,
                x.Banks.BankTitle
            }).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreateList_Click(object sender, EventArgs e)
        {
            string description = txtDescription.Text;
            decimal amount = decimal.Parse(txtAmount.Text);
            DateTime date =DateTime.Parse(dateTimePicker1.Text);
            string processType= txtProcessType.Text;
            int bankName = int.Parse(txtBankName.Text);

            BankProcesses bnkp = new BankProcesses();
            bnkp.Description = description;
            bnkp.Amount = amount;
            bnkp.ProcessDate = date;
            bnkp.ProcessType=processType;
            bnkp.BankId = bankName;
            db.BankProcesses.Add(bnkp);
            db.SaveChanges();
            MessageBox.Show("Banka işlemi başarıyla eklendi!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.BankProcesses.Select(x => new
            {
                x.BankProcessId,
                x.Description,
                x.ProcessDate,
                x.ProcessType,
                x.Amount,
                x.Banks.BankTitle
            }).ToList();
            dataGridView1.DataSource = values;

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var value = db.BankProcesses.Find(id);
            db.BankProcesses.Remove(value);
            db.SaveChanges();
            MessageBox.Show("Banka işlemi başarıyla silindi!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.BankProcesses.Select(x => new
            {
                x.BankProcessId,
                x.Description,
                x.ProcessDate,
                x.ProcessType,
                x.Amount,
                x.Banks.BankTitle
            }).ToList();
            dataGridView1.DataSource = values;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string description = txtDescription.Text;
            decimal amount = decimal.Parse(txtAmount.Text);
            DateTime date = DateTime.Parse(dateTimePicker1.Text);
            string processType = txtProcessType.Text;
            int bankName = int.Parse(txtBankName.Text);
            int id=int.Parse(txtId.Text);

            var value = db.BankProcesses.Find(id);

            value.Description = description;
            value.Amount = amount;
            value.ProcessType = processType;
            value.ProcessDate = date;
            value.BankId= bankName;
            db.BankProcesses.AddOrUpdate(value);
            db.SaveChanges();

            MessageBox.Show("Banka işlemi başarıyla güncellendi!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.BankProcesses.Select(x => new
            {
                x.BankProcessId,
                x.Description,
                x.ProcessDate,
                x.ProcessType,
                x.Amount,
                x.Banks.BankTitle
            }).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCategori_Click(object sender, EventArgs e)
        {
            FrmCategory category = new FrmCategory();
            category.Show();
            this.Hide();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks banks = new FrmBanks();
            banks.Show();
            this.Hide();
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            FrmBilling billing = new FrmBilling();
            billing.Show();
            this.Hide();
        }

        private void btnGiderler_Click(object sender, EventArgs e)
        {
            FrmBankaHareketleri bank=new FrmBankaHareketleri();
            bank.Show();
            this.Hide();
        }

        private void btnBankaHareketleri_Click(object sender, EventArgs e)
        {
            FrmBankaHareketleri frmbnk=new FrmBankaHareketleri();
            frmbnk.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frmd=new FrmDashboard();
            frmd.Show();
            this.Hide();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            FrmSettings settings = new FrmSettings();
            settings.Show();
            this.Hide();
        }
    }
}
