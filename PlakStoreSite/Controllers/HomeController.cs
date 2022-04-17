using Microsoft.AspNetCore.Mvc;
using PlakStoreBusinessLayer.Abstract;
using PlakStoreBusinessLayer.Concrete;
using PlakStoreBusinessLayer.Concrete.NewFolder2;
using PlakStoreViewModel.AlbumVıewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlakStoreSite.Controllers
{
    public class HomeController : Controller
    {
        IAlbumBLL albumService;
        public HomeController(IAlbumBLL albumService)
        {
            this.albumService = albumService;
        }
        public IActionResult Index()
        {
            ResultService <List< SingleAlbumVM>>
            albumresult = albumService.GetSingleAlbums();
            if (!albumresult.HasError) 
            {
                //hatasız ıse
                return View(albumresult.Data);
            }
            else
            {
                //hatası var ıse hata mesajı bas vıewbag ıle
                ViewBag.Message = albumresult.Errors[0].ErrorMessage;
            }
            return View();
            
        }
        public IActionResult AlbumStore()//Layoutlu bır album store olusturduk.
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
