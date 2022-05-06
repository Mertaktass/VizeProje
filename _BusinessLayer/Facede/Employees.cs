using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _BusinessLayer.Entity;
using System.Data.SqlClient;
using _DataLayer;

namespace _BusinessLayer.Facade
{
     public class Employees
    {
        public static DataTable List()
        {
            return Tools.ProcedureList("VizeProje_EmployeesList");
        }

        public static bool EmployeeAdd(Employee Entity)
        {

            SqlCommand cmd = new SqlCommand("VizeProje_EmployeesAdd", Tools.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LastName", Entity.LastName);
            cmd.Parameters.AddWithValue("@FirstName", Entity.FirstName);
            cmd.Parameters.AddWithValue("@Title", Entity.Title);
            cmd.Parameters.AddWithValue("@TitleOfCourtesy", Entity.TitleOfCourtesy);
            cmd.Parameters.AddWithValue("@BirthDate", Entity.BirthDate);
            cmd.Parameters.AddWithValue("@HireDate", Entity.HireDate);
            cmd.Parameters.AddWithValue("@Address", Entity.Address);
            cmd.Parameters.AddWithValue("@City", Entity.City);
            cmd.Parameters.AddWithValue("@Region", Entity.Region);
            cmd.Parameters.AddWithValue("@PostalCode", Entity.PostalCode);
            cmd.Parameters.AddWithValue("@Country", Entity.Country);
            cmd.Parameters.AddWithValue("@HomePhone", Entity.HomePhone);
            cmd.Parameters.AddWithValue("@Extension", Entity.Extension);
            cmd.Parameters.AddWithValue("@Notes", Entity.Notes);
            cmd.Parameters.AddWithValue("@ReportsTo", Entity.ReportsTo);
            return Tools.ExecuteNonQuery(cmd);
        }

        public static bool EmployeeDelete(Employee Entity)
        {
            SqlCommand cmd = new SqlCommand("VizeProje_EmployeeDelete", Tools.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeID", Entity.EmployeeID);
            return Tools.ExecuteNonQuery(cmd);

        }

        public static bool EmployeeUpdate(Employee Entity)
        {
            SqlCommand cmd = new SqlCommand("VizeProje_EmployeesUpdate", Tools.Connection);
             cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeID", Entity.EmployeeID);
            cmd.Parameters.AddWithValue("@LastName", Entity.LastName);
             cmd.Parameters.AddWithValue("@FirstName", Entity.FirstName);
             cmd.Parameters.AddWithValue("@Title", Entity.Title);
             cmd.Parameters.AddWithValue("@TitleOfCourtesy", Entity.TitleOfCourtesy);
             cmd.Parameters.AddWithValue("@BirthDate", Entity.BirthDate);
             cmd.Parameters.AddWithValue("@HireDate", Entity.HireDate);
             cmd.Parameters.AddWithValue("@Address", Entity.Address);
             cmd.Parameters.AddWithValue("@City", Entity.City);
             cmd.Parameters.AddWithValue("@Region", Entity.Region);
             cmd.Parameters.AddWithValue("@PostalCode", Entity.PostalCode);
             cmd.Parameters.AddWithValue("@Country", Entity.Country);
             cmd.Parameters.AddWithValue("@HomePhone", Entity.HomePhone);
             cmd.Parameters.AddWithValue("@Extension", Entity.Extension);
             cmd.Parameters.AddWithValue("@Notes", Entity.Notes);
             cmd.Parameters.AddWithValue("@ReportsTo", Entity.ReportsTo);

            return Tools.ExecuteNonQuery(cmd);
        }
    }
}
