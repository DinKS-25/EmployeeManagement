using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternWork.Models
{
    public class Login
    {
        [Required,Key]
        public String Username { get; set; }
        [Required(ErrorMessage ="password username doesn't match"),DataType(DataType.Password)]
        public string password { get; set; }
        [Required,Display(Name = "Remember Me")]
        public bool Rememberme { get; set; }
    }
}
