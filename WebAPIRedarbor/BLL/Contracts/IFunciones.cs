using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRedarbor.Model;

namespace WebAPIRedarbor.BLL.Contracts
{
    public interface IFunciones
    {
        List<Employee> GetEmployees();
        void InsertEmployee(Employee employee);
        Employee GetEmployee(int employeeId);
        void UpdateEmployee(int employeeId, Employee employee);
        void DeleteEmployee(int employeeId);
        bool EmployeeExists(int employeeId);
        bool EmployeesExist();
    }
}
