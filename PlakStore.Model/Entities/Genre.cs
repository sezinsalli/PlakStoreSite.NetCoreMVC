using PlakStoreCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakStore.Model.Entities
{
    public class Genre : BaseEntity
    {
        public Genre()
        {
            ısActive = true;
            Albums = new HashSet<Album>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
