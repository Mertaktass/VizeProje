using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using _DataLayer;

namespace VizeProje.Forms
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void Login()
        {
            try
            {

                SqlCommand cmd = new SqlCommand("select * from Employees where LastName = @LastName AND FirstName = @Pswrd", Tools.Connection);
                SqlParameter prm1 = new SqlParameter("Pswrd", textBox1.Text.Trim());
                SqlParameter prm2 = new SqlParameter("LastName", textBox2.Text.Trim());
                cmd.Parameters.Add(prm1);
                cmd.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Main_Form mf = new Main_Form();
                    mf.Show();
                }
                else
                    MessageBox.Show("Username or password is incorrect");
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

        }

        private void Login_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       
    }
}
