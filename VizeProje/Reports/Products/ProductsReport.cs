using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VizeProje.Reports.Products
{
    public partial class ProductsReport : Form
    {
        public ProductsReport()
        {
            InitializeComponent();
        }

        private void ProductsReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.northwindDataSet.Products);

            this.reportViewer1.RefreshReport();
        }
    }
}
