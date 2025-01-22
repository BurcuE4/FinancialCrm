using FinancialCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db= new FinancialCrmDbEntities();
        private void FrmBanks_Load(object sender, EventArgs e)
        {
            //Banka Bakiyeleri
          var ziraatBankBalance=db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(y=>y.BankBalance).FirstOrDefault();
            var vakifBankBalance=db.Banks.Where(x=>x.BankTitle== "Vakıf Bankası").Select(y=>y.BankBalance).FirstOrDefault();
            var isBankBalance=db.Banks.Where(x=>x.BankTitle== "İş Bankası").Select(y=>y.BankBalance).FirstOrDefault();
            var akbankBalance=db.Banks.Where(x=>x.BankTitle=="Akbank").Select(y=>y.BankBalance).FirstOrDefault();
            var garantiBBVABalance=db.Banks.Where(x=>x.BankTitle== "Garanti BBVA").Select(y=>y.BankBalance).FirstOrDefault();

            lblZiraatBankBalance.Text=ziraatBankBalance.ToString() + " ₺";
            lblVakifBanlBalance.Text=vakifBankBalance.ToString() + " ₺";
            lblisBankBalance.Text=isBankBalance.ToString() + " ₺";
            lblAkbankBalance.Text = akbankBalance.ToString() + " ₺";
            lblGarantiBBVA.Text = garantiBBVABalance.ToString() + " ₺";

            //Banka Hareketleri
            var bankProcess1=db.BankProcesses.OrderByDescending(x=>x.BankProcessId).Take(1).FirstOrDefault();
            lblBankProcess1.Text=bankProcess1.Description + " " + bankProcess1.Amount + " " + bankProcess1.ProcessDate;

            var bankProcess2 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(2).Skip(1).FirstOrDefault();
            lblBankProcess2.Text = bankProcess2.Description + " " + bankProcess2.Amount + " " + bankProcess2.ProcessDate;

            var bankProcess3 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(3).Skip(2).FirstOrDefault();
            lblBankProcess3.Text = bankProcess3.Description + " " + bankProcess3.Amount + " " + bankProcess3.ProcessDate;

            var bankProcess4 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();
            lblBankProcess4.Text = bankProcess4.Description + " " + bankProcess4.Amount + " " + bankProcess4.ProcessDate;

            var bankProcess5 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();
            lblBankProcess5.Text = bankProcess5.Description + " " + bankProcess5.Amount + " " + bankProcess5.ProcessDate;

            var bankProcess6=db.BankProcesses.OrderByDescending(x=>x.BankProcessId).Take(6).Skip(5).FirstOrDefault();
            lblBankProcess6.Text=bankProcess6.Description + " " + bankProcess6.Amount + " " + bankProcess6.ProcessDate;
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmExit frm = new FrmExit();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategory frm = new FrmCategory();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            FrmBilling f=new FrmBilling();
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBankaHareketleri frm=new FrmBankaHareketleri();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashboard frm=new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmSettings frm=new FrmSettings();
            frm.Show();
            this.Hide();
        }
    }
}
