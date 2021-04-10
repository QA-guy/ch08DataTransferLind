using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using OlympicGames.Models;


namespace OlympicGames
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
            //page 325 configuring services to use session state
            services.AddMemoryCache();
            services.AddSession();

            services.AddControllersWithViews().AddNewtonsoftJson();

            services.AddControllersWithViews();
            services.AddDbContext<CountryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CountryContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
           
            app.UseDeveloperExceptionPage();           
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            //Page 325, must be called before UseEndPoints()editing to chane default session state settings
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "custom",
                   pattern: "{controller=Home}/{action=Index}/sport/{activeSport}/game/{activeGame}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
