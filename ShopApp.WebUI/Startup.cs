using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using ShopApp.Business.Abstract;
using ShopApp.Business.Concrete;
using ShopApp.DataAccess.Abstract;
using ShopApp.DataAccess.Concrete.EfCore;
using ShopApp.WebUI.Middlewares;

namespace ShopApp.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //If any method is chanhed in DataAccess
            //If you want to work with another data, you can just change the paramater EfCoreProductDal
            //All layers are independent 
            services.AddScoped<IProductDal, EfCoreProductDal>();
            services.AddScoped<ICategoryDal, EfCoreCategoryDal>(); //DataAccess
            services.AddScoped<IProductService, ProductManager>();//Business Logic
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddMvc()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //If the application is in development progress, seeddata will be provided
                //Once the app is completed, this code will be changed
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed();
            }
            app.UseStaticFiles();
            app.CustomStaticFiles(); //Opening node modules to the browser, study this part
            app.UseMvc(routes =>
            {

                routes.MapRoute(
                   name: "adminProducts",
                   template: "admin/products", //Will send the products according to their category, ? makes optional
                   defaults: new { controller = "Admin", action = "Index" }
                   );
                routes.MapRoute(
               name: "adminProducts",
               template: "admin/products/{id}", //Will send the products according to their category, ? makes optional
               defaults: new { controller = "Admin", action = "Edit" }
               );
                //Filtering and showing certain products to the user
                routes.MapRoute(
                    name: "products",
                    template: "products/{category?}", //Will send the products according to their category, ? makes optional
                    defaults: new {controller="Shop", action= "List"}
                    );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=index}/{id?}"
                    );

            });
        }

    }
}
