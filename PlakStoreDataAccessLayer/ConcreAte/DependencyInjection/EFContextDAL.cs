using Microsoft.Extensions.DependencyInjection;
using PlakStoreDataAccessLayer.Abstract;
using PlakStoreDataAccessLayer.Concreate.Context;
using PlakStoreDataAccessLayer.Concreate.Repository;
using PlakStoreDataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakStoreDataAccessLayer.ConcreAte.DependencyInjection
{
    public static class EFContextDAL
    {
        public static void AddScopeDAL(this IServiceCollection services)
        {
            services.AddDbContext<PlakStoreDbContext>();
            services.AddScoped<IAlbumDAL, AlbumRepository>();
            services.AddScoped<IArtistDAL, ArtistRepository>();
            services.AddScoped<IGenreDAL, GenreRepository>();
            services.AddScoped<IOrderDAL, OrderRepository>();
            services.AddScoped<IUserDAL, UserRepository>();
        }
    }
}
