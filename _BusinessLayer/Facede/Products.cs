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
    public class Products
    {
        public static DataTable Select()
        {

            return Tools.ProcedureList("VizeProje_ProductList");

            //SqlDataAdapter adp = new SqlDataAdapter("ProductList",Tools.Connection);
            //adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            //DataTable dt = new DataTable();
            //adp.Fill(dt);
            //return dt;

        }
        public static bool ProductAdd(Product Entity)
        {
            
            SqlCommand cmd = new SqlCommand("VizeProje_ProductsAdd", Tools.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName",Entity.ProductName);
            cmd.Parameters.AddWithValue("@SupplierID",Entity.SupplierID);
            cmd.Parameters.AddWithValue("@CategoryID",Entity.CategoryID);
            cmd.Parameters.AddWithValue("@QuantityPerUnit",Entity.QuantityPerUnit);
            cmd.Parameters.AddWithValue("@UnitPrice", Entity.UnitPrice);
            cmd.Parameters.AddWithValue("@UnitInStock", Entity.UnitsInStock);
            cmd.Parameters.AddWithValue("@UnitsOnOrder", Entity.UnitsOnOrder);
            cmd.Parameters.AddWithValue("@ReorderLevel", Entity.ReorderLevel);
            cmd.Parameters.AddWithValue("@Discontiuned", Entity.Discontiuned);

            return Tools.ExecuteNonQuery(cmd);
            
        }

        public static bool ProductDelete(Product Entity)
        {
            SqlCommand cmd = new SqlCommand("VizeProje_ProductDelete", Tools.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", Entity.ProductID);
            return Tools.ExecuteNonQuery(cmd);

        }

        public static bool ProductUpdate(Product Entity)
        {
            SqlCommand cmd = new SqlCommand("VizeProje_ProductUpdate", Tools.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName",Entity.ProductName);
            cmd.Parameters.AddWithValue("@SupplierID", Entity.SupplierID);
            cmd.Parameters.AddWithValue("@CategoryID", Entity.CategoryID);
            cmd.Parameters.AddWithValue("@QuantityPerUnit",Entity.QuantityPerUnit);
            cmd.Parameters.AddWithValue("@UnitPrice",Entity.UnitPrice);
            cmd.Parameters.AddWithValue("@UnitsInStock",Entity.UnitsInStock);
            cmd.Parameters.AddWithValue("@UnitsInOrder",Entity.UnitsOnOrder);
            cmd.Parameters.AddWithValue("@ReorderLevel",Entity.ReorderLevel);
            cmd.Parameters.AddWithValue("@Discontinued",Entity.Discontiuned);

            return Tools.ExecuteNonQuery(cmd); 
        }
        

     
    }
}
