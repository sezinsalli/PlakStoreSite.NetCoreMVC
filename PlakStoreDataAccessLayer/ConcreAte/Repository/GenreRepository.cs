using PlakStore.Model.Entities;
using PlakStoreCore.DataAccess.EntityFramework;
using PlakStoreDataAccessLayer.Abstract;
using PlakStoreDataAccessLayer.Concreate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakStoreDataAccessLayer.Repository
{
    class GenreRepository : EFRepositoryBase<Genre, PlakStoreDbContext>, IGenreDAL
    {
        public GenreRepository(PlakStoreDbContext context) : base(context)
        {

        }
    }
}
