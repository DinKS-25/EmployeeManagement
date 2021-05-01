using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternWork.Models
{
    public interface ILoginRepo
    {
        Login Authenticate(Login login);
    }
}
