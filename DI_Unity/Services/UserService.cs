﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DI_Unity.Services
{
    public class UserService : IUserService
    {
        public string GetUserName(string name)
        {
            return string.Format("Hello {0}", name);
        }
    }
}