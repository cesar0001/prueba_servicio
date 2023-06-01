using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Client.Auth
{
     public interface ILoginService
    {
        Task Login(string token);
        Task Logout();
    }
}
