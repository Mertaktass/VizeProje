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

namespace VizeProje
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }
        

        private void CustomersList()
        {
            //Select komutunun method hali.
            //Form ismiyle Facede layerdaki class aynı oldugu için refası gösteriyorum
            dataGridView1.DataSource = _BusinessLayer.Facade.Customers.List();
        }
        private void Customers_Load(object sender, EventArgs e)
        {
            CustomersList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (var item in groupBox1.Controls)
            {
                if (item is TextBox)
                    ((TextBox)item).Clear();
                if (item is MaskedTextBox)
                    ((MaskedTextBox)item).Clear();
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtCustomerID.Text = dataGridView1.Rows[e.RowIndex].Cells["cid"].Value.ToString();
            txtCompanyName.Text = dataGridView1.Rows[e.RowIndex].Cells["companyname"].Value.ToString();
            txtContactName.Text = dataGridView1.Rows[e.RowIndex].Cells["contactname"].Value.ToString();
            txtContactTitle.Text = dataGridView1.Rows[e.RowIndex].Cells["contacttitle"].Value.ToString();
            txtAdress.Text = dataGridView1.Rows[e.RowIndex].Cells["adress"].Value.ToString();
            txtCity.Text = dataGridView1.Rows[e.RowIndex].Cells["city"].Value.ToString();
            txtRegion.Text = dataGridView1.Rows[e.RowIndex].Cells["region"].Value.ToString();
            txtPostalCode.Text = dataGridView1.Rows[e.RowIndex].Cells["postalcode"].Value.ToString();
            txtCountry.Text = dataGridView1.Rows[e.RowIndex].Cells["country"].Value.ToString();
            msktxtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells["phone"].Value.ToString();
            masktxtFax.Text = dataGridView1.Rows[e.RowIndex].Cells["fax"].Value.ToString();
            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DialogResult Option = MessageBox.Show("Do you want to add the data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Option == DialogResult.Yes)
            {
                Customer entity = new Customer();
                entity.CustomerID = txtCustomerID.Text;
                entity.CompanyName = txtCompanyName.Text;
                entity.ContactName = txtContactName.Text;
                entity.ContactTitle = txtContactTitle.Text;
                entity.Address = txtAdress.Text;
                entity.City = txtCity.Text;
                entity.Region = txtRegion.Text;
                entity.PostalCode = txtPostalCode.Text;
                entity.Country = txtCountry.Text;
                entity.Phone = msktxtPhone.Text;
                entity.Fax = masktxtFax.Text;
                if (!_BusinessLayer.Facade.Customers.CustomerAdd(entity))//Form ismiyle Facede layerdaki class aynı oldugu için refası gösteriyorum
                    MessageBox.Show("Customer not added!");
                else
                    MessageBox.Show("Data added!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CustomersList();
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
                Customer entity = new Customer();
                entity.CustomerID = dataGridView1.CurrentRow.Cells["cid"].Value.ToString();
                if (!_BusinessLayer.Facade.Customers.CustomerDelete(entity))
                    MessageBox.Show("Could not deleted!");
                else
                    MessageBox.Show("Data deleted!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CustomersList();
            }
            else if (Option == DialogResult.No)
            {
                MessageBox.Show("Deleting the data has been canceled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult Option = MessageBox.Show("Do you want to update the license?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Option == DialogResult.Yes)
            {
                Customer entity = new Customer();
                entity.CustomerID = txtCustomerID.Text;
                entity.CompanyName = txtCompanyName.Text;
                entity.ContactName = txtContactName.Text;
                entity.ContactTitle = txtContactTitle.Text;
                entity.Address = txtAdress.Text;
                entity.City = txtCity.Text;
                entity.Region = txtRegion.Text;
                entity.PostalCode = txtPostalCode.Text;
                entity.Country = txtCountry.Text.ToString();
                entity.Phone = msktxtPhone.Text.ToString();
                entity.Fax = masktxtFax.Text;
                if (!_BusinessLayer.Facade.Customers.CustomerUpdate(entity))
                    MessageBox.Show("Update Failed!");
                else
                    MessageBox.Show("Update data!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CustomersList();
            }
            else if (Option == DialogResult.No)
            {
                MessageBox.Show("The data update has been canceled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Reports.Customers.CustomersReport CustomersReport = new Reports.Customers.CustomersReport();
            CustomersReport.Show();
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            txtCustomerID.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtCustomerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            

            if(e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar))
                MessageBox.Show("Please, just use letters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
