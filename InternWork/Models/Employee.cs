using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternWork.Models
{
    public class Employee
    {
        [Key,Required]
        public int EmpId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string MotherName { get; set; }
        [Required(ErrorMessage ="please mention salary")]
        public double Salary { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public bool Fresher { get; set; }
        [Required]
        public Role role { get; set; }
    }
}
