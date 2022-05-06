using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _BusinessLayer.Facade;
using _BusinessLayer.Entity;

namespace VizeProje
{
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }

       
        private void CategoriesList()
        { //Select komutunun method hali.
            dataGridView1.DataSource = Categorys.Select();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Groupbox içerisinde textboxları temizleme
            foreach (var item in groupBox1.Controls)
            {
                if (item is TextBox)
                    ((TextBox)item).Clear();

            }
        }

        private void Categories_Load(object sender, EventArgs e)
        {
            CategoriesList();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DialogResult Option = MessageBox.Show("Do you want to add the data?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if(Option == DialogResult.Yes)
            {
                //Category nesnesi yaratarak özelliklere erişiyoruz ve textboxlarla eşleştiriyoruz.
                Category entity = new Category();
                entity.CategoryName = txtcname.Text;
                entity.Description = txtdesc.Text;
                //Ekleme işlemi duruma göre mesaj.

                 if (!Categorys.CategoryAdd(entity))
                    MessageBox.Show("Category not added!");
                else
                    MessageBox.Show("Data added!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CategoriesList();

                //Liste yenileme

            }
            else if (Option == DialogResult.No)
            {
                MessageBox.Show("Adding the data was canceled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Option = MessageBox.Show("Do you want to delete the data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Option == DialogResult.Yes)
            {
                Category entity = new Category();
                //silenecek satırın ID göre seçip işlem yapamsını sağlıyoruz
                entity.CategoryID = (int)dataGridView1.CurrentRow.Cells["cid"].Value;
                //Ekleme işlem kontrolü
                if (!Categorys.CategoryDelete(entity))
                    MessageBox.Show("Could not deleted!");
                else
                    MessageBox.Show("Data deleted!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CategoriesList();
            }
            else if (Option == DialogResult.No)
            {
                MessageBox.Show("Deleting the data has been canceled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

         private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
          {
            //Seçilen satırın tetxtboxlara yansıtılması
             txtid.Text = dataGridView1.Rows[e.RowIndex].Cells["cid"].Value.ToString();
             txtcname.Text = dataGridView1.Rows[e.RowIndex].Cells["cname"].Value.ToString();
             txtdesc.Text = dataGridView1.Rows[e.RowIndex].Cells["cdesc"].Value.ToString();
             
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult Option = MessageBox.Show("Do you want to update the license?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Option == DialogResult.Yes)
            {
                Category entity = new Category();
                entity.CategoryID = Convert.ToInt32(txtid.Text);
                entity.CategoryName = txtcname.Text;
                entity.Description = txtdesc.Text;
                if (!Categorys.CategoryUpdate(entity))
                    MessageBox.Show("Update Failed!");
                else
                    MessageBox.Show("Update data!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CategoriesList();
            }
            else if (Option == DialogResult.No)
            {
                MessageBox.Show("The data update has been canceled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Reports.CategoriesReport CategoriesReport = new Reports.CategoriesReport();
            CategoriesReport.Show();
        }
    }
}
