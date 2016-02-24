using DI_Ninject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DI_Ninject.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: User
        public ActionResult Index()
        {
            ViewBag.UserMessage = _userService.GetUserName("Dependency Ninject");
            return View();
        }
    }
}