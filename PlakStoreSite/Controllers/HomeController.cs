using Microsoft.AspNetCore.Mvc;
using PlakStoreBusinessLayer.Abstract;
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
            ResultService<List<SingleAlbumVM>> albumResult = albumService.GetSingleAlbums();
            if (!albumResult.HasError)
            {
                return View(albumResult.Data);
            }
            else
            {
                ViewBag.Message = albumResult.Errors[0].ErrorMessage;
                return View();
            }
        }
    }
}
