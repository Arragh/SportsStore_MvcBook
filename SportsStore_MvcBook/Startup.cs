using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportsStore_MvcBook.Models;
using SportsStore_MvcBook.Models.Identity;

namespace SportsStore_MvcBook
{
    public class Startup
    {
        IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SportsStore_Work")));
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Identity_Work")));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddControllersWithViews();
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(null, "{category}/Page{page}", new { controller = "Product", action = "List" });
                endpoints.MapControllerRoute(null, "Page{page}", new { controller = "Product", action = "List", page = 1 });
                endpoints.MapControllerRoute(null, "{category}", new { controller = "Product", action = "List", page = 1 });

                endpoints.MapControllerRoute("pagination", "Products/Page{page}", new { controller = "Product", action = "List" });
                endpoints.MapControllerRoute("default", "{controller=Product}/{action=List}/{id?}");
            });
        }
    }
}
