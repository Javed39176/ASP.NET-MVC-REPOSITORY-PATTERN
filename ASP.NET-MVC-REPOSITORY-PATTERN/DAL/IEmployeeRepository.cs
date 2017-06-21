using System;
using System.Collections.Generic;
using ASP.NET_MVC_REPOSITORY_PATTERN.Models;

namespace ASP.NET_MVC_REPOSITORY_PATTERN.DAL
{
    public interface IEmployeeRepository:IDisposable
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByID(int EmployeeId);
        void InsertEmployee(Employee employee);
        void DeleteEmployee(int EmployeeId);
        void UpdateEmployee(Employee employee);
        void Save();
    }
}
