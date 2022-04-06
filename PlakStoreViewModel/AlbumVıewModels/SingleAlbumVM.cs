using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakStoreViewModel.AlbumVıewModels
{
    public class SingleAlbumVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string FullName { get; set; }
        public string AlbumArtUrl { get; set; }
    }
}
