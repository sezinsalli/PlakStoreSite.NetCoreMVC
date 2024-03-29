﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlakStoreBusinessLayer.Abstract;
using PlakStoreBusinessLayer.Concrete.NewFolder2;
using PlakStoreViewModel.Constraints;
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
                return RedirectToAction(nameof(Login), nameof(HomeController));

            }
            return View();
        }
        //url ıstedıgımızı anlatmak ıcın
        [HttpGet]
        public IActionResult ActivatedUser(Guid id)
        {
            //burada bır guıd ım var bu guıd ı bll'e yollacagım
            //önce burada bunu olusturup sonra ı user bll 'e gıdıp metodu tanımlayacagım
            ResultService<bool> result = userService.ActivedUser(id);
            if (result.Data)
            {
                //true gelırse buradya
                return RedirectToAction(nameof(Login), nameof(UserController1));
            }
            //gelmezse actıvated usera gıdercek
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            //istek geldıgı vakıt
            if (Request.Cookies["cookie"]!=null)
            {
                //egerkı boyle bır cookıe varsa
                string bilgi = Request.Cookies["cookie"];
                string[] bilgiParcasi=bilgi.Split("|");
                UserLoginVM userLogin = new UserLoginVM();
                userLogin.Email = bilgiParcasi[0];
                userLogin.Password = bilgiParcasi[1];
                userLogin.IsRemember = true;
                return View(userLogin);
                //şu kadar zamandır gelmedınız yazısı falan
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLoginVM user)
        {
            //cookıe olsuturuyoruz hatırlaması ıcın
            if (user.IsRemember)
            {
                CookieOptions cookieoptions = new CookieOptions();
                cookieoptions.Expires = DateTime.Now.AddDays(10);

                Response.Cookies.Append("cookie", user.Email + "|" + user.Password, cookieoptions);

            }
            if (ModelState.IsValid)
            {
                //bool dönmesının sebebi 
                ResultService<bool> result=userService.CheckUserForLogin(user.Email,user.Password);
                if (result.HasError)
                {
                    //consta gıdıyor
                    //ViewBag.Message = result.Errors[0].ErrorMessage;
                    //ViewBag.Message = "Bılgılerınızı kontrol edınız";
                    ViewBag.Message = UserMessage.LoginMessage;
                }
                else
                {
                    RedirectToAction(nameof(Index), "Home");
                }
            }

            return View();
        }
    }
}
