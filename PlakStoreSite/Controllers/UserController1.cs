using Microsoft.AspNetCore.Mvc;
using PlakStoreBusinessLayer.Abstract;
using PlakStoreBusinessLayer.Concrete.NewFolder2;
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
                ResultService<UserCreateVM> resultService = userService.Insert(user);//ınsert ıslemı yaptık ınsert ıslemı yaparken maıl de attık.
                return RedirectToAction(nameof(Login),nameof(HomeController));

            }
            return View();
        }
        public IActionResult ActivatedUser(Guid guid)
        {
            //burada bır guıd ım var bu guıd ı bll'e yollacagım
            //önce burada bunu olusturup sonra ı user bll 'e gıdıp metodu tanımlayacagım
            ResultService<bool> result = userService.ActivedUser(guid);
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
