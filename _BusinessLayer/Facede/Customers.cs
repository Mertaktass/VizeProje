using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _BusinessLayer.Entity;
using System.Data;
using System.Data.SqlClient;
using _DataLayer;

namespace _BusinessLayer.Facade
{
    public class Customers
    {
        public static DataTable List()
        {
            return Tools.ProcedureList("VizeProje_CustomerList");
        }

        public static bool CustomerAdd(Customer Entity)
        {
            SqlCommand cmd = new SqlCommand("VizeProje_CustomerAdd", Tools.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerID", Entity.CustomerID);
            cmd.Parameters.AddWithValue("@CompanyName",Entity.CompanyName);
            cmd.Parameters.AddWithValue("@ContactName", Entity.ContactName);
            cmd.Parameters.AddWithValue("@ContactTitle", Entity.ContactTitle);
            cmd.Parameters.AddWithValue("@Address", Entity.Address);
            cmd.Parameters.AddWithValue("@City", Entity.City);
            cmd.Parameters.AddWithValue("@Region", Entity.Region);
            cmd.Parameters.AddWithValue("@PostalCode", Entity.PostalCode);
            cmd.Parameters.AddWithValue("@Country", Entity.Country);
            cmd.Parameters.AddWithValue("@Phone", Entity.Phone);
            cmd.Parameters.AddWithValue("@Fax", Entity.Fax);
            return Tools.ExecuteNonQuery(cmd);

        }

        public static bool CustomerDelete(Customer Entity)
        {
            SqlCommand cmd = new SqlCommand("VizeProje_CustomerDelete", Tools.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerID",Entity.CustomerID);
            return Tools.ExecuteNonQuery(cmd);

        }

        public static bool CustomerUpdate(Customer Entity)
        {
            SqlCommand cmd = new SqlCommand("VizeProje_CustomerUpdate", Tools.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerID", Entity.CustomerID);
            cmd.Parameters.AddWithValue("@CompanyName", Entity.CompanyName);
            cmd.Parameters.AddWithValue("@ContactName", Entity.ContactName);
            cmd.Parameters.AddWithValue("@ContactTitle", Entity.ContactTitle);
            cmd.Parameters.AddWithValue("@Address", Entity.Address);
            cmd.Parameters.AddWithValue("@City", Entity.City);
            cmd.Parameters.AddWithValue("@Region", Entity.Region);
            cmd.Parameters.AddWithValue("@PostalCode", Entity.PostalCode);
            cmd.Parameters.AddWithValue("@Country", Entity.Country);
            cmd.Parameters.AddWithValue("@Phone", Entity.Phone);
            cmd.Parameters.AddWithValue("@Fax", Entity.Fax);
            return Tools.ExecuteNonQuery(cmd);
        }
    }
}
