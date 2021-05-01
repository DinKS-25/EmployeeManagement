using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternWork.Models
{
    public class MockLoginRepo : ILoginRepo
    {
        //List<Login> logindetails = new List<Login>
        //{
        //    new Login{EmpId = 1234  , password = "dineshkumar"},
        //    new Login{EmpId = 1236  , password = "shamlal"},
        //    new Login{EmpId = 1235  , password = "babubhiya"}
        //};


        //public Login Authenticate(Login login)
        //{
        //    Login person = logindetails.SingleOrDefault(item => item.EmpId == login.EmpId && item.password == login.password);
        //    return (person);
        //}
        public Login Authenticate(Login login)
        {
            throw new NotImplementedException();
        }
    }
}
