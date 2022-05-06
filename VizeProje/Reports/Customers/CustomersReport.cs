using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VizeProje.Reports.Customers
{
    public partial class CustomersReport : Form
    {
        public CustomersReport()
        {
            InitializeComponent();
        }

        private void CustomersReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);

            this.reportViewer1.RefreshReport();
        }
    }
}
