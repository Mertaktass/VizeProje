using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; // ConnectionString ayarlayabilmek için kullancağımız classa tanıtmamız gerek.(App.config)
using System.Data.SqlClient;// SqlConnectin bağlantısı yapmak için gerekli referens.
using System.Data;

namespace _DataLayer
{
    public class Tools
    {
        //Connection String ile ver tabanı bağlantımızı oluşturuyoruz.
        private static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConString"].ConnectionString);

        public static SqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        // try catch komutu ile Veri tabanın açık olup olmadığının kontrolünü sağlıyoruz ve kaydediyoruz
        public static bool ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)

                    cmd.Connection.Open();
                return cmd.ExecuteNonQuery() > 0;

            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }
       
        
        //DataTable ile SQL veritabanında oluşturulan Prosedürleri kullanmak için ConnectionStrign çağırarak çekiyoruz.
        public static DataTable ProcedureList(string ProcedureName)
        {
            SqlDataAdapter adp = new SqlDataAdapter(ProcedureName, Tools.Connection);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure; // SP kullanacağımız için CommanType StoredProcedure seçiyoruz.
            DataTable dt = new DataTable();// Satır Sutünları nesneleri oluşturuyoruz.
            adp.Fill(dt); // oluşturulan dt'yi kullanmak için SQLDataAdapterin içini dolduruyoruz.
            return dt;

        }
    }

   


   
}
