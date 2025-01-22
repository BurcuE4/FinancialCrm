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
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db=new FinancialCrmDbEntities();
        private void FrmCategory_Load(object sender, EventArgs e)
        {
            var values = (from c in db.Categories
                          join s in db.Spendings on c.CategoryId equals s.CategoryId
                          select new
                          {
                              c.CategoryId,
                              c.CategoryName,
                              s.SpendingAmount,
                              s.SpendingDate,
                              s.SpendingTitle
                            
                          }).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = (from c in db.Categories
                          join s in db.Spendings on c.CategoryId equals s.CategoryId
                          select new
                          {
                              c.CategoryId,
                              c.CategoryName,
                              s.SpendingAmount,
                              s.SpendingDate,
                              s.SpendingTitle
                          }).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text;

            Categories categories = new Categories();
            categories.CategoryName = txtCategoryName.Text;
            db.Categories.Add(categories);
            db.SaveChanges();

            MessageBox.Show("Kategori ekleme işlemi gerçekleşmiştir", "Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtcategoryId.Text);

            var deletedValue = db.Categories.Find(id);
            db.Categories.Remove(deletedValue);
            db.SaveChanges();

            MessageBox.Show("Kategori silme işlemi gerçekleşmiştir", "Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtcategoryId.Text);
            string categoryName = txtCategoryName.Text;

            var updateValue = db.Categories.Find(id);
            updateValue.CategoryName = categoryName;
            updateValue.CategoryId = id;

            db.Categories.AddOrUpdate(updateValue);
            db.SaveChanges();

            MessageBox.Show("Kategori Güncelleme işlemi gerçekleşmiştir", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategory frm= new FrmCategory();
            frm.Show();
            this.Hide();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm= new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            FrmBilling frm= new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frm= new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        //private void btnGiderler_Click(object sender, EventArgs e)
        //{
        //    FrmGiderler f = new FrmGiderler();
        //    f.Show();
        //    this.Hide();
        //}
    }
}
