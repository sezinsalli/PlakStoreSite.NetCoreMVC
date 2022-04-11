using Microsoft.Extensions.DependencyInjection;
using PlakStoreBusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakStoreBusinessLayer.Concrete.DependencyInjection
{
    public static class EFContextBLL
    {
        public static void AddScopeBLL(this IServiceCollection services)
        {
            services.AddScopeBLL();
            services.AddScoped<IAlbumBLL, AlbumService>();
            services.AddScoped<IArtistBLL, ArtistService>();
            services.AddScoped<IUserBLL, UserService>();
            services.AddScoped<IGenreBLL, GenreService>();
            services.AddScoped<IOrderBLL, OrderService>();


        }
    }
}
