using PlakStore.Model.Entities;
using PlakStoreBusinessLayer.Concrete.NewFolder2;
using PlakStoreViewModel.AlbumVıewModels;
using PlakStoreViewModel.CartViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakStoreBusinessLayer.Abstract
{
    public interface IAlbumBLL : IBaseBLL<Album>
    {
        ResultService<List<SingleAlbumVM>> GetSingleAlbums();
        ResultService<AlbumDetailVM> GetAlbumById(int id);
        ResultService<CartItem> GetCartById(int id);
    }
}
