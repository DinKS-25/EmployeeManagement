using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternWork.Models
{
    public class RegisterUser:IdentityUser
    {
        [Required]
        public string Username { get; set; }

        [Required(ErrorMessage ="password must have atleast one numeric \n alphanumeric chars"),DataType(DataType.Password)]
        public string Password { get; set; }

        [Required,DataType(DataType.Password)]
        [Display(Name ="confirm password")]
        [Compare("Password",ErrorMessage ="password and confirm password must match!")]
        public string Repassword { get; set; }
    }
}
