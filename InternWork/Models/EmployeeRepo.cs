using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace InternWork.Models
{
    public class EmployeeRepo : IEmployeeRepo
    {

        private readonly AppDbContext db;

        public EmployeeRepo(AppDbContext db)
        {
            this.db = db;
        }
        public Employee AddEmployee(Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
            return (emp);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return db.Employees;
        }

        public Employee GetEmployeeById(int EmpId)
        {
            return (db.Employees.SingleOrDefault(item => item.EmpId == EmpId));
        }

        public Employee UpdateEmployee(Employee emp)
        {
            db.Employees.Update(emp);
            db.SaveChanges();
            return (emp);
        }

        public void Delete(int EmpId)
        {
            db.Employees.Remove(db.Employees.SingleOrDefault(item => item.EmpId == EmpId));
            db.SaveChanges();
        }
        
    }
}
