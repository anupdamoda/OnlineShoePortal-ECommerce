using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using OnlineShoePortal_ECommerce.Data;
using OnlineShoePortal_ECommerce.Data.Entities;

namespace OnlineShoePortal_ECommerce
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<StoreUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
                //cfg.Password.RequiredLength = 5;
                //cfg.Password.RequireNonAlphanumeric = true;
                //cfg.Password.RequiredUniqueChars = 2;
            })
                .AddEntityFrameworkStores<ShoeContext>();

            services.AddAuthentication()
                .AddCookie()
                .AddJwtBearer(cfg => {
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = _config["Tokens:Issuer"],
                        ValidAudience = _config["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]))
                    };
                });

            services.AddDbContext<ShoeContext>(cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("ShoeConnectionString"));
            });
            services.AddTransient<ShoeSeeder>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IShoeRepository, ShoeRepository>();
            services.AddControllersWithViews();
            services.AddMvc();
            //services.AddControllers()
            //.ConfigureApiBehaviorOptions(options =>
            //{
            //    options.SuppressModelStateInvalidFilter = true;
            //});
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
                app.UseExceptionHandler("/error");
            }
            
            //app.UseDefaultFiles();

            app.UseStaticFiles();
            app.UseNodeModules();

            app.UseRouting();

            // the below methods are for the Identity management and important that it comes after routing and before endpoints
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute("Fallback",
                    "{controller}/{action}/{id?}",
                    new { controller = "App", action = "Index" });
            });

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            // });

        }
    }
}
