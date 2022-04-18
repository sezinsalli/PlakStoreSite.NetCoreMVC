using Microsoft.AspNetCore.Mvc;
using PlakStoreViewModel.CartViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlakStoreSite.Helpers;
using Microsoft.AspNetCore.Http;
using PlakStoreBusinessLayer.Abstract;
using PlakStoreBusinessLayer.Concrete.NewFolder2;
using PlakStoreViewModel.Constraints;

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

        public IActionResult Index() //sepet sayfası
        {
            Cart cart = HttpContext.Session.Get<Cart>("cart"); //sepetı ındex actıonda gosterelım
            if (cart==null)
            {
                ViewBag.Message = CartMessage.CartBosHatasi;
                return View();
            }
            return View(cart);
            
        }
        public IActionResult AddToCard(int id)//sepete atacagım urunun ıdsı
        {

            Cart cart = HttpContext.Session.Get<Cart>("cart");
            if (cart==null)
            {
                cart = new Cart();
            }
            
            ResultService<CartItem> result = albumService.GetCartById(id);
            if (!result.HasError)
            {
                CartItem item = result.Data;
                item.Quantity = 1;
                cart.Add(item);
                
                
                HttpContext.Session.Set<Cart>("cart", cart);
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}
