using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VizeProje.Reports.Employees
{
    public partial class EmployeesReport : Form
    {
        public EmployeesReport()
        {
            InitializeComponent();
        }

        private void EmployeesReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.northwindDataSet.Employees);

            this.reportViewer1.RefreshReport();
        }
    }
}
