using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessLogic
{
    public interface ILoginService
    {
        LoginVM Login(LoginVM _login);
    }
}
