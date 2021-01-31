using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NicheMarket.Data;
using NicheMarket.Services;
using System;
using System.Linq;

namespace NicheMarket.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<ICloudinaryService>(instance => new CloudinaryService(
    this.Configuration["Cloudinary:CloudName"],
    this.Configuration["Cloudinary:ApiKey"],
    this.Configuration["Cloudinary:ApiSecret"]));

            services.AddTransient<IProductService, ProductService>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using (var dbContext = serviceScope.ServiceProvider.GetRequiredService<NicheMarketDBContext>())
                {
                    dbContext.Database.Migrate();

                    if (dbContext.Roles.Count() == 0)
                    {
                        dbContext.Roles.Add(new IdentityRole
                        {
                            Name = "Admin",
                            NormalizedName = "ADMIN",
                            ConcurrencyStamp = Guid.NewGuid().ToString()
                        });

                        dbContext.Roles.Add(new IdentityRole
                        {
                            Name = "Client",
                            NormalizedName = "CLIENT",
                            ConcurrencyStamp = Guid.NewGuid().ToString()
                        });

                        dbContext.Roles.Add(new IdentityRole
                        {
                            Name = "Retailer",
                            NormalizedName = "RETAILER",
                            ConcurrencyStamp = Guid.NewGuid().ToString()
                        });
                    }
                }


                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();

                app.UseAuthorization();
                app.UseAuthentication();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");

                    endpoints.MapRazorPages();
                });
            }
        }
    }
}
