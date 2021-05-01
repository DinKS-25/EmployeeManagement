using ClosedXML.Excel;
using InternWork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InternWork.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo employeeRepo;
        private readonly AppDbContext db;

        public EmployeeController(IEmployeeRepo employeeRepo, AppDbContext db)
        {
            this.employeeRepo = employeeRepo;
            this.db = db;
        }
        public IActionResult ViewEmployee()
        {
            return View(employeeRepo.GetAllEmployee());
        }
        public IActionResult ViewEmployeeById(int id)
        {
            Employee emp = employeeRepo.GetEmployeeById(id);
            return View(emp);
        }
        public IActionResult AddEmployee()
        {
            Employee emp = new Employee();
            return View(emp);
        }
        public IActionResult Option(Login user)
        {
            return View(user);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                if (emp.EmpId == 0)
                {
                    employeeRepo.AddEmployee(emp);
                }
                else
                {
                    employeeRepo.UpdateEmployee(emp);
                }
                return RedirectToAction("ViewEmployee");
            }
            return View();
        }
        
        public IActionResult Update(int id)
        {
            Employee emp = employeeRepo.GetEmployeeById(id);
            return View("AddEmployee",emp);
        }
       [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            employeeRepo.Delete(id);
            return RedirectToAction("ViewEmployee");
        }
        public IActionResult DownloadExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[8] { new DataColumn("EmpId"),
                                            new DataColumn("Name"),
                                            new DataColumn("FatherName"),
                                            new DataColumn("MotherName"),
                                            new DataColumn("Salary"),
                                            new DataColumn("Address"),
                                            new DataColumn("Fresher"),
                                            new DataColumn("role")});

            var employee = from customer in db.Employees
                           select customer;

            foreach (var item in employee)
            {
                dt.Rows.Add(item.EmpId, item.Name, item.FatherName, item.MotherName, item.Salary, item.Address, item.Fresher, item.role);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    //return controller.File(stream.ToArray(), mimeType, filename);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
            }
        }
    }
}
