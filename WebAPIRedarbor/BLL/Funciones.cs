using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRedarbor.BLL.Contracts;
using WebAPIRedarbor.Model;

namespace WebAPIRedarbor.BLL
{
    public class Funciones : IFunciones
    {
        private readonly IConfiguration _configuration;
        public Funciones(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Employee> GetEmployees()
        {
            List<Employee> lstEmployees = new List<Employee>();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("WebAPIRedarborConection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Employee", sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader rd = sqlCommand.ExecuteReader();
                while (rd.Read())
                {
                    lstEmployees.Add(new Employee
                    {
                        EmployeeId = Convert.ToInt32(rd["EmployeeId"]),
                        CompanyId = rd["CompanyId"].ToString() == "" ? null : (int?)rd["CompanyId"],
                        CreatedOn = rd["CreatedOn"].ToString() == "" ? null : Convert.ToDateTime(rd["CreatedOn"]).ToString("yyyy-MM-dd HH:mm:ss"),
                        DeletedOn = rd["DeletedOn"].ToString() == "" ? null : Convert.ToDateTime(rd["DeletedOn"]).ToString("yyyy-MM-dd HH:mm:ss"),
                        Email = rd["Email"].ToString(),
                        Fax = rd["Fax"].ToString(),
                        Name = rd["Name"].ToString(),
                        Lastlogin = rd["Lastlogin"].ToString() == "" ? null : Convert.ToDateTime(rd["Lastlogin"]).ToString("yyyy-MM-dd HH:mm:ss"),
                        Password = rd["Password"].ToString(),
                        PortalId = rd["PortalId"].ToString() == "" ? null : (int?)rd["PortalId"],
                        RoleId = rd["RoleId"].ToString() == "" ? null : (int?)rd["RoleId"],
                        StatusId = rd["StatusId"].ToString() == "" ? null : (int?)rd["StatusId"],
                        Telephone = rd["Telephone"].ToString(),
                        UpdatedOn = rd["UpdatedOn"].ToString() == "" ? null : Convert.ToDateTime(rd["UpdatedOn"]).ToString("yyyy-MM-dd HH:mm:ss"),
                        Username = rd["Username"].ToString()
                    });
                }
            }
            return lstEmployees;
        }

        public void InsertEmployee(Employee employee)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("WebAPIRedarborConection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("sp_InsertEmployee", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("CompanyId", employee.CompanyId);
                sqlCommand.Parameters.AddWithValue("CreatedOn", employee.CreatedOn);
                sqlCommand.Parameters.AddWithValue("DeletedOn", employee.DeletedOn);
                sqlCommand.Parameters.AddWithValue("Email", employee.Email);
                sqlCommand.Parameters.AddWithValue("Fax", employee.Fax);
                sqlCommand.Parameters.AddWithValue("Name", employee.Name);
                sqlCommand.Parameters.AddWithValue("Lastlogin", employee.Lastlogin);
                sqlCommand.Parameters.AddWithValue("Password", employee.Password);
                sqlCommand.Parameters.AddWithValue("PortalId", employee.PortalId);
                sqlCommand.Parameters.AddWithValue("RoleId", employee.RoleId);
                sqlCommand.Parameters.AddWithValue("StatusId", employee.StatusId);
                sqlCommand.Parameters.AddWithValue("Telephone", employee.Telephone);
                sqlCommand.Parameters.AddWithValue("UpdatedOn", employee.UpdatedOn);
                sqlCommand.Parameters.AddWithValue("Username", employee.Username);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public Employee GetEmployee(int employeeId)
        {
            List<Employee> lstEmployees = new List<Employee>();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("WebAPIRedarborConection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Employee WHERE EmployeeId = " + employeeId.ToString(), sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader rd = sqlCommand.ExecuteReader();
                while (rd.Read())
                {
                    lstEmployees.Add(new Employee
                    {
                        EmployeeId = Convert.ToInt32(rd["EmployeeId"]),
                        CompanyId = rd["CompanyId"].ToString() == "" ? null : (int?)rd["CompanyId"],
                        CreatedOn = rd["CreatedOn"].ToString() == "" ? null : Convert.ToDateTime(rd["CreatedOn"]).ToString("yyyy-MM-dd HH:mm:ss"),
                        DeletedOn = rd["DeletedOn"].ToString() == "" ? null : Convert.ToDateTime(rd["DeletedOn"]).ToString("yyyy-MM-dd HH:mm:ss"),
                        Email = rd["Email"].ToString(),
                        Fax = rd["Fax"].ToString(),
                        Name = rd["Name"].ToString(),
                        Lastlogin = rd["Lastlogin"].ToString() == "" ? null : Convert.ToDateTime(rd["Lastlogin"]).ToString("yyyy-MM-dd HH:mm:ss"),
                        Password = rd["Password"].ToString(),
                        PortalId = rd["PortalId"].ToString() == "" ? null : (int?)rd["PortalId"],
                        RoleId = rd["RoleId"].ToString() == "" ? null : (int?)rd["RoleId"],
                        StatusId = rd["StatusId"].ToString() == "" ? null : (int?)rd["StatusId"],
                        Telephone = rd["Telephone"].ToString(),
                        UpdatedOn = rd["UpdatedOn"].ToString() == "" ? null : Convert.ToDateTime(rd["UpdatedOn"]).ToString("yyyy-MM-dd HH:mm:ss"),
                        Username = rd["Username"].ToString()
                    });
                }
            }
            Employee employee = lstEmployees.FirstOrDefault();
            return employee;
        }

        public void UpdateEmployee(int employeeId, Employee employee)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("WebAPIRedarborConection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("sp_UpdateEmployee", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("EmployeeId", employeeId);
                sqlCommand.Parameters.AddWithValue("CompanyId", employee.CompanyId);
                sqlCommand.Parameters.AddWithValue("CreatedOn", employee.CreatedOn);
                sqlCommand.Parameters.AddWithValue("DeletedOn", employee.DeletedOn);
                sqlCommand.Parameters.AddWithValue("Email", employee.Email);
                sqlCommand.Parameters.AddWithValue("Fax", employee.Fax);
                sqlCommand.Parameters.AddWithValue("Name", employee.Name);
                sqlCommand.Parameters.AddWithValue("Lastlogin", employee.Lastlogin);
                sqlCommand.Parameters.AddWithValue("Password", employee.Password);
                sqlCommand.Parameters.AddWithValue("PortalId", employee.PortalId);
                sqlCommand.Parameters.AddWithValue("RoleId", employee.RoleId);
                sqlCommand.Parameters.AddWithValue("StatusId", employee.StatusId);
                sqlCommand.Parameters.AddWithValue("Telephone", employee.Telephone);
                sqlCommand.Parameters.AddWithValue("UpdatedOn", employee.UpdatedOn);
                sqlCommand.Parameters.AddWithValue("Username", employee.Username);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("WebAPIRedarborConection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("DELETE Employee WHERE EmployeeId = " + employeeId.ToString(), sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.ExecuteNonQuery();
            }
        }

        public bool EmployeeExists(int employeeId)
        {
            bool employeeExists = false;
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("WebAPIRedarborConection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Employee WHERE EmployeeId = " + employeeId.ToString(), sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader rd = sqlCommand.ExecuteReader();
                employeeExists = rd.HasRows;
            }
            return employeeExists;
        }

        public bool EmployeesExist()
        {
            bool employeesExist = false;
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("WebAPIRedarborConection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Employee", sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader rd = sqlCommand.ExecuteReader();
                employeesExist = rd.HasRows;
            }
            return employeesExist;
        }


    }
}
