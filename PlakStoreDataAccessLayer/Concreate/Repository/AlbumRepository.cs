using PlakStoreCore.DataAccess.EntityFramework;
using PlakStoreDataAccessLayer.Abstract;
using PlakStoreDataAccessLayer.Concreate.Context;
using PlakStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakStoreDataAccessLayer.Concreate.Repository
{
    class AlbumRepository : EFRepositoryBase<Album, PlakStoreDbContext>, IUserDAL
    {
        public AlbumRepository(PlakStoreDbContext context) : base(context)
        {
        }
    }

}
