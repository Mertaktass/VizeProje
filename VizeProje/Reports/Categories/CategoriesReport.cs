using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VizeProje.Reports
{
    public partial class CategoriesReport : Form
    {
        public CategoriesReport()
        {
            InitializeComponent();
        }

        private void CategoriesReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.northwindDataSet.Categories);

            this.reportViewer1.RefreshReport();
        }
    }
}
