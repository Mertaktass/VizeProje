using _BusinessLayer.Entity; 
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _DataLayer;


namespace _BusinessLayer.Facade
{
    public class Categorys
    {
        
        public static DataTable Select()
        {
            return Tools.ProcedureList("VizeProje_CategoryList");
        }

        public static bool CategoryAdd(Category Entity)
        {
            SqlCommand cmd = new SqlCommand("VizeProje_CategoryAdd",Tools.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryName",Entity.CategoryName);
            cmd.Parameters.AddWithValue("@Description",Entity.Description);

            return Tools.ExecuteNonQuery(cmd);
        }
        public static bool CategoryUpdate(Category Entity)
        {
            SqlCommand cmd = new SqlCommand("VizeProje_CategoryUpdate",Tools.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryName",Entity.CategoryName);
            cmd.Parameters.AddWithValue("@Description",Entity.Description);
            cmd.Parameters.AddWithValue("@CategoryID",Entity.CategoryID);

            return Tools.ExecuteNonQuery(cmd);
        }
        public static bool CategoryDelete(Category Entity)
        {
            SqlCommand cmd = new SqlCommand("VizeProje_CategoryDelete", Tools.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryID",Entity.CategoryID);

            return Tools.ExecuteNonQuery(cmd);
        }

    }
}
