using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InternWork.Models
{
    public class MockEmployeeRepo : IEmployeeRepo
    {
        List<Employee> empList = new List<Employee>
        {
            new Employee{EmpId=1234,Name="Dinesh kumar",FatherName="suriyan",MotherName="jeyalakshmi",Salary=234,Address="sbdffsdksdjfl;sjfdscmisdcsvfvh",Fresher=true,role=Role.Trainee},
            new Employee{EmpId=1235,Name="ram kumar",FatherName="ramesh",MotherName="ektha",Salary=234,Address="sbdffsdksdjfl;sjfdscmisdcsvfvh",Fresher=true,role=Role.Trainee},
            new Employee{EmpId=1236,Name="tapu",FatherName="jethalal",MotherName="daya",Salary=1234,Address="sbdffsdksdjfl;sjfdscmisdcsvfvh",Fresher=true,role=Role.AST},
        };

        public Employee AddEmployee(Employee emp)
        {
            emp.EmpId = empList.Max(item => item.EmpId) + 1;
            empList.Add(emp); 
            return emp;
        }

        public void Delete(int EmpId)
        {
            throw new System.NotImplementedException();
        }

        public FileResult ExportAsExcel()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return (empList);
        }

        public Employee GetEmployeeById(int EmpId)
        {
            return (empList.SingleOrDefault(item=>item.EmpId==EmpId));

        }

        public Employee UpdateEmployee(Employee emp)
        {
            throw new System.NotImplementedException();
        }
    }
}
