using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlakStoreBusinessLayer.Abstract;
using PlakStoreBusinessLayer.Concrete;
using PlakStoreBusinessLayer.Concrete.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlakStoreSite
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
             //IServiceCollection services, services yazdýgýmýz ýcýn metodlarý cagýrabýlýyoruz.
            services.AddControllersWithViews();//
            services.AddScopeBLL();

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession();
            app.UseRouting();
            app.UseStaticFiles();//statýc dosyalara erýsmemýzý saglar bu da wwwrootun ýcerýsýndeký dosyalardýr statýc dosylar burada bulunur.css ve js dosyalarý.

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute(); // proje calýsýr calýsmaz HomeController da yer alan Index.cshtml  sayfasýna yonlendýrýlýr
            });
        }
    }
}
