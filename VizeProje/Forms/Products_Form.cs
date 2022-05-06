using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _BusinessLayer.Entity;
using _BusinessLayer.Facade;

namespace VizeProje.Forms
{
    public partial class Products_Form : Form
    {
        public Products_Form()
        {
            InitializeComponent();
        }

        private void ProductsList()
        {
            dataGridView1.DataSource = Products.Select();
        }

        private void btnClaer_Click(object sender, EventArgs e)
        {
            foreach (var item in groupBox1.Controls)
            {
                if (item is TextBox)
                    ((TextBox)item).Clear();
            }
        }
        
        private void Products_Form_Load(object sender, EventArgs e)
        {
            ProductsList();
        }

        private void dataGridView1_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            txtProductID.Text = dataGridView1.Rows[e.RowIndex].Cells["pid"].Value.ToString();
            txtProductName.Text = dataGridView1.Rows[e.RowIndex].Cells["productname"].Value.ToString();
            txtSupplierID.Text = dataGridView1.Rows[e.RowIndex].Cells["supplierid"].Value.ToString();
            txtCategoryID.Text = dataGridView1.Rows[e.RowIndex].Cells["categoryid"].Value.ToString();
            txtquantityperunit.Text = dataGridView1.Rows[e.RowIndex].Cells["quantityperunit"].Value.ToString();
            txtUnitPrice.Text = dataGridView1.Rows[e.RowIndex].Cells["unitprice"].Value.ToString();
            txtUnitsinStock.Text = dataGridView1.Rows[e.RowIndex].Cells["unitsinstock"].Value.ToString();
            txtUnitsonOrder.Text = dataGridView1.Rows[e.RowIndex].Cells["unitsonorder"].Value.ToString();
            txtReorderLevel.Text = dataGridView1.Rows[e.RowIndex].Cells["reorderlevel"].Value.ToString();
            checkBox1.Checked = bool.Parse(dataGridView1.Rows[e.RowIndex].Cells["discountinued"].Value.ToString());
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            
            Product entity = new Product();
            entity.ProductName = txtProductName.Text;
            entity.SupplierID = Int32.Parse(txtSupplierID.Text);
            entity.CategoryID = Int32.Parse(txtCategoryID.Text);
            entity.QuantityPerUnit = txtquantityperunit.Text;
            entity.UnitPrice =  Decimal.Parse(txtUnitPrice.Text);
            entity.UnitsInStock = short.Parse(txtUnitsinStock.Text);
            entity.UnitsOnOrder = short.Parse(txtUnitsonOrder.Text);
            entity.ReorderLevel = short.Parse(txtReorderLevel.Text);
            entity.Discontiuned = checkBox1.Checked;
            if (!Products.ProductAdd(entity))
                MessageBox.Show("Products not added!");
            else
                MessageBox.Show("Products added!");
            ProductsList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product entity = new Product();
            entity.ProductID = (int)dataGridView1.CurrentRow.Cells["pid"].Value;
            if (!Products.ProductDelete(entity))
                MessageBox.Show("Could not deleted!");
            else
                MessageBox.Show("Deleted!");
            ProductsList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
          /*  Product entity = new Product();
            entity.ProductID = Convert.ToInt32(txtProductID.Text);
            entity.ProductName = txtProductName.Text;
            entity.SupplierID = Convert.ToInt32(txtSupplierID.Text);
            entity.CategoryID = Convert.ToInt32(txtCategoryID.Text);
            entity.QuantityPerUnit = txtquantityperunit.Text;
            entity.UnitPrice = txtUnitPrice.Text;
            entity.UnitsInStock = txtUnitsinStock.Text;
            entity.UnitsOnOrder = txtUnitsonOrder.Text;
            entity.ReorderLevel = txtReorderLevel.Text;
            entity.Discontiuned = txtDiscontinued.Text;
            if (!Products.ProductUpdate(entity))
                MessageBox.Show("Update Failed!");
            else
                MessageBox.Show("Update!");
            ProductsList();*/
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Reports.Products.ProductsReport ProductsReport = new Reports.Products.ProductsReport();
            ProductsReport.Show();
        }
    }
}
