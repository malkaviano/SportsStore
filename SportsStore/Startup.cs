using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Migrations;
using SportsStore.Models;
using SportsStore.Services;

namespace SportsStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(
                    Configuration["Data:SportsStoreProducts:ConnectionString"]
                )
            );

            services.AddTransient<IProductRepository, EFProductRepository>();

            services.AddTransient<IOrderRepository, EFOrderRepository>();

            services.AddScoped(sp => sp.GetRequiredService<IHttpContextAccessor>().HttpContext.Session.GetCart());

            services.AddMvc();

            services.AddMemoryCache();

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(
                routes =>
                {
                    routes.MapRoute(
                        name: "pagination_filter",
                        template: "products/{category}/page{page:int}",
                        defaults: new { Controller = "Product", action = "List" }
                    );

                    routes.MapRoute(
                        name: "pagination",
                        template: "products/page{page:int}",
                        defaults: new { Controller = "Product", action = "List" }
                    );

                    routes.MapRoute(
                        name: "filter",
                        template: "products/{category}",
                        defaults: new { Controller = "Product", action = "List" }
                    );

                    routes.MapRoute(
                        name: "products",
                        template: "products",
                        defaults: new { Controller = "Product", action = "List" }
                    );

                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Product}/{action=List}/{id?}"
                    );
                }
            );

            SeedData.EnsurePopulated(app.ApplicationServices.GetRequiredService<ApplicationDbContext>());
        }
    }
}
