using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DI_Castle.Models
{
    public class UserService : IUserService
    {
        public string GetUserName(string name)
        {
            return string.Format("Hello {0}", name);
        }
    }
}