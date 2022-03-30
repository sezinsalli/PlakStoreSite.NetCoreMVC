using PlakStoreCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakStore.Model.Entities
{
    public class Artist: BaseEntity
    {
        public Artist()
        {
            ısActive = true;
            Albums = new HashSet<Album>();
        }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public ICollection<Album> Albums { get; set; }


    }
}
