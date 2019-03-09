using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deneme.Bll.Abstract;
using Deneme.Bll.Concrete;
using Deneme.Dal.Abstract;
using Deneme.Dal.Concrete.EntityFrameWork;
using Deneme.UI.Entities;
using Deneme.UI.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Deneme.UI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddDbContext<CustomIdentityDbContext>(options =>
                options.UseSqlServer("Server=(localDb)\\mssqllocaldb; Database=Northwind;Trusted_Connection=True"));
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
                .AddEntityFrameworkStores<CustomIdentityDbContext>().AddDefaultTokenProviders();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();
            app.UseIdentity();
            app.UseNodeModules(env.ContentRootPath);
            app.UseMvc(routes =>
                routes.MapRoute(
                    name: "Default",
                    template: "{controller=Product}/{action=Index}/{id?}"));

        }
    }
}
