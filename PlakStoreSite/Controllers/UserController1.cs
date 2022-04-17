using Microsoft.AspNetCore.Mvc;
using PlakStoreBusinessLayer.Abstract;
using PlakStoreViewModel.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlakStoreSite.Controllers
{
    public class UserController1 : Controller
    {
        IUserBLL userService;
        public UserController1(IUserBLL userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserCreateVM user)
        {
            if (ModelState.IsValid)
            {
                //post edılen data dogru data ıse
               

            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
