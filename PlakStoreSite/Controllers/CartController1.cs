using Microsoft.AspNetCore.Mvc;
using PlakStoreViewModel.CartViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlakStoreSite.Helpers;
using Microsoft.AspNetCore.Http;
using PlakStoreBusinessLayer.Abstract;

namespace PlakStoreSite.Controllers
{

    public class CartController1 : Controller
    {
        //id ye ait ürün lazım ve ben urunlerı nereden alıyorum?
        IAlbumBLL albumService;
        public CartController1(IAlbumBLL albumService)
        {
            this.albumService = albumService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddToCard(int id)//sepete atacagım urunun ıdsı
        {
            CartItem cartItem = new CartItem();//sepetı ac
            Cart cart = new Cart();//urunu olsutur
            //result servıce buraada kaldım

            cart.Add(cartItem);//urunu sepete ekle
            //.net sessıonda ıstedıgın nesneyı saklayabılırsın
            HttpContext.Session.Set<Cart>("cart", cart);//sepetı sessıona kaydettım
            return RedirectToAction("Index", "Home");
        }
    }
}
