using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VizeProje.Forms
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
            this.ActiveForms = new Dictionary<string, Form>();
        }
        private Dictionary<string,Form> ActiveForms;

        Form form = null;
        private void ShowForm(string FormName)
        {
            if (this.ActiveForms.ContainsKey(FormName))
            {
                form = this.ActiveForms[FormName];
                form.WindowState = FormWindowState.Maximized;
                form.Activate();
            }
            else
            {
                switch (FormName)
                {
                    case "Categories":
                        form = new Categories();
                        form.FormClosed += Form_FormClosed;
                        break;
                    case "Customers":
                        form = new Customers();
                        form.FormClosed += Form_FormClosed1;
                        break;
                    case "Employees":
                        form = new Forms.EmployeesForm();
                        form.FormClosed += Form_FormClosed2;
                        break;
                    case "Products":
                        form = new Products_Form();
                        form.FormClosed += FormClosed3;
                        break;

                }
                form.MdiParent = this;
                form.Show();
                this.ActiveForms.Add(FormName, form);
            }
        }

        private void FormClosed3(object sender, FormClosedEventArgs e)
        {
            this.ActiveForms.Remove("Products");
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ActiveForms.Remove("Categories");
        }

        private void Form_FormClosed1(object sender, FormClosedEventArgs e)
        {
            this.ActiveForms.Remove("Customers");
        }

        private void Form_FormClosed2(object sender, FormClosedEventArgs e)
        {
            this.ActiveForms.Remove("Employees");
        }
       
        private void Main_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void categoriesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ShowForm("Categories");
        }

        private void customersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ShowForm("Customers");
        }

        private void employeesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ShowForm("Employees");
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowForm("Products");
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {

        }
        
        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult x = MessageBox.Show("Are you sure you want to exit the program?", "Warning", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (x == DialogResult.Yes)
            {
                //Evet tıklandığında Yapılacak İşlemler
                Environment.Exit(0); // Evet tıklandığında uygulama kapanacak

            }
            else if (x == DialogResult.No)
            {
                // Hayır tıklandığında yapılacak işlemler
                e.Cancel = true; // Hayır tıklandığında iptal edilecek
            }
        }
    }
}
