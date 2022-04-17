using Microsoft.Extensions.DependencyInjection;
using PlakStoreBusinessLayer.Abstract;
using PlakStoreDataAccessLayer.ConcreAte.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakStoreBusinessLayer.Concrete.DependencyInjection
{
    public static class EfContextBLL
    {
        //Extension Metod oldugu ıcın direk servıcesden çagırabılıyoruz.
        public static void AddScopeBLL(this IServiceCollection services)
        {
            services.AddScopeDAL();
            services.AddScoped<IAlbumBLL, AlbumService>();
            services.AddScoped<IArtistBLL, ArtistService>();
            services.AddScoped<IUserBLL, UserService>();
            services.AddScoped<IGenreBLL, GenreService>();
            services.AddScoped<IOrderBLL, OrderService>();
        }
    }
}
