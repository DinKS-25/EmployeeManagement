using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternWork.Models
{
    public class LoginRepo : ILoginRepo
    {
        private readonly AppDbContext db;

        public LoginRepo(AppDbContext db)
        {
            this.db = db;
        }

        public Login Authenticate(Login login)
        {
            throw new NotImplementedException();
        }
        //public Login Authenticate(Login login)
        //{
        //   return db.Logins.SingleOrDefault(item => item.EmpId == login.EmpId && item.password == login.password);
        //}
    }
}
