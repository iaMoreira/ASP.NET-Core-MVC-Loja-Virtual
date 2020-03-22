using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries;
using LojaVirtual.Libraries.Session;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using LojaVirtual.Database;
using LojaVirtual.Repositories;
using LojaVirtual.Repositories.Contracts;

namespace LojaVirtual
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            EmailSettings.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           //bind repositories 
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<INewsLatterRepository, NewsLatterRepository>();
            // services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddControllersWithViews();
            // string connection = "server=db;port=1433;userid=sa;password=<YourStrong@Passw0rd>;database=LojaVirtual";
            string connection = "Server=127.0.0.1;Database=LojaVirtual;User Id=sa;Password=<YourStrong@Passw0rd>;";
            services.AddDbContext<LojaVirtualContext> (options => options.UseSqlServer(connection));
            services.AddMemoryCache(); // guardar dados na memória

            services.AddHttpContextAccessor();
            services.AddSession(options =>  {
                // options.io
            });
            services.AddScoped<Session>();
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
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
