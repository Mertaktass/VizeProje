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

namespace VizeProje.Forms
{
    public partial class EmployeesForm : Form
    {
        public EmployeesForm()
        {
            InitializeComponent();
        }

        private void EmployeesList()
        {
            dataGridView1.DataSource = Employees.List();
        }

        private void EmployeesForm_Load(object sender, EventArgs e)
        {
            EmployeesList();
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
            txtEmployeeid.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            txtlastname.Text = dataGridView1.Rows[e.RowIndex].Cells["lastname"].Value.ToString();
            txtfirstname.Text = dataGridView1.Rows[e.RowIndex].Cells["firstname"].Value.ToString();
            txttitle.Text = dataGridView1.Rows[e.RowIndex].Cells["title"].Value.ToString();
            txttitleofcourtesy.Text = dataGridView1.Rows[e.RowIndex].Cells["titleofcourtesy"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells["birthdate"].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells["hiredate"].Value.ToString();
            txtadress.Text = dataGridView1.Rows[e.RowIndex].Cells["address"].Value.ToString();
            txtcity.Text = dataGridView1.Rows[e.RowIndex].Cells["city"].Value.ToString();
            txtregion.Text = dataGridView1.Rows[e.RowIndex].Cells["region"].Value.ToString();
            txtpostalcode.Text = dataGridView1.Rows[e.RowIndex].Cells["postalcode"].Value.ToString();
            txtcountry.Text = dataGridView1.Rows[e.RowIndex].Cells["country"].Value.ToString();
            msktxtHomePhone.Text = dataGridView1.Rows[e.RowIndex].Cells["homephone"].Value.ToString();
            txtextension.Text = dataGridView1.Rows[e.RowIndex].Cells["extension"].Value.ToString();
            txtnotes.Text = dataGridView1.Rows[e.RowIndex].Cells["notes"].Value.ToString();
            numericReports.Text = dataGridView1.Rows[e.RowIndex].Cells["reportsto"].Value.ToString();

        }
        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Option = MessageBox.Show("Do you want to delete the data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Option == DialogResult.Yes)
            {
                Employee entity = new Employee();
                entity.EmployeeID = (int)dataGridView1.CurrentRow.Cells["id"].Value;
                if (!Employees.EmployeeDelete(entity))
                    MessageBox.Show("Could not deleted!");
                else
                    MessageBox.Show("Data deleted!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EmployeesList();
            }
            else if (Option == DialogResult.No)
            {
                MessageBox.Show("Deleting the data has been canceled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DialogResult Option = MessageBox.Show("Do you want to add the data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Option == DialogResult.Yes)
            {
                Employee entity = new Employee();
                entity.LastName = txtlastname.Text;
                entity.FirstName = txtfirstname.Text;
                entity.Title = txttitle.Text;
                entity.TitleOfCourtesy = txttitleofcourtesy.Text;
                entity.BirthDate = dateTimePicker1.Value.Date;
                entity.HireDate = dateTimePicker2.Value.Date;
                entity.Address = txtadress.Text;
                entity.City = txtcity.Text;
                entity.Region = txtregion.Text;
                entity.PostalCode = txtpostalcode.Text;
                entity.Country = txtcountry.Text;
                entity.HomePhone = msktxtHomePhone.Text;
                entity.Extension = txtextension.Text;
                entity.Notes = txtnotes.Text;
                entity.ReportsTo = Int32.Parse(numericReports.Text);
                if (!Employees.EmployeeAdd(entity))
                    MessageBox.Show("Employee not added");
                else
                    MessageBox.Show("Data added!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EmployeesList();
            }
            else if (Option == DialogResult.No)
            {
                MessageBox.Show("Adding the data was canceled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Reports.Employees.EmployeesReport EmployeesReport = new Reports.Employees.EmployeesReport();
            EmployeesReport.Show();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult Option = MessageBox.Show("Do you want to update the license?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Option == DialogResult.Yes)
            {
                Employee entity = new Employee();
                entity.EmployeeID = Int32.Parse(txtEmployeeid.Text);
                entity.LastName = txtlastname.Text;
                entity.FirstName = txtfirstname.Text;
                entity.Title = txttitle.Text;
                entity.TitleOfCourtesy = txttitleofcourtesy.Text;
                entity.BirthDate = dateTimePicker1.Value.Date;
                entity.HireDate = dateTimePicker2.Value.Date;
                entity.Address = txtadress.Text;
                entity.City = txtcity.Text;
                entity.Region = txtregion.Text;
                entity.PostalCode = txtpostalcode.Text;
                entity.Country = txtcountry.Text;
                entity.HomePhone = msktxtHomePhone.Text;
                entity.Extension = txtextension.Text;
                entity.Notes = txtnotes.Text;
                entity.ReportsTo = Int32.Parse(numericReports.Text);
                if (!Employees.EmployeeUpdate(entity))
                    MessageBox.Show("Employee not update");
                else
                    MessageBox.Show("Update data!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EmployeesList();
            }
            else if (Option == DialogResult.No)
            {
                MessageBox.Show("The data update has been canceled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtextension_KeyPress(object sender, KeyPressEventArgs e)
        {
           if( e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            MessageBox.Show("Please, just use numbers.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
