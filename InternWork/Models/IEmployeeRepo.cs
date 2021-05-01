using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternWork.Models
{
    public interface IEmployeeRepo
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployeeById(int EmpId);
        Employee AddEmployee(Employee emp);
        Employee UpdateEmployee(Employee emp);
        public void Delete(int EmpId);
    }
}
