    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sipaz.Core.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Sipaz.Core.Interfaces;
using Sipaz.DAL.Repository;

namespace Sipaz.Web
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
            var connectionString = new ConnectionString(Configuration.GetConnectionString("Value"));
            services.AddSingleton(connectionString);

            // configure strongly typed settings objects
            IConfigurationSection appSettingsSection = Configuration.GetSection("AppSettings");
            //var appSettingss = new AppSettings(appSettingsSection);
            //services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            services.AddSingleton(appSettings);
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication("CookieAuthentication")
                           .AddCookie("CookieAuthentication", config =>
                           {
                               config.Cookie.Name = "UserLoginCookie";
                               config.LoginPath = "/Account/Login";
                           }).AddJwtBearer(x =>
                           {
                               x.RequireHttpsMetadata = false;
                               x.SaveToken = true;
                               x.TokenValidationParameters = new TokenValidationParameters
                               {
                                   ValidateIssuerSigningKey = true,
                                   IssuerSigningKey = new SymmetricSecurityKey(key),
                                   ValidateIssuer = false,
                                   ValidateAudience = false,
                                   ClockSkew = TimeSpan.Zero,
                                   ValidateLifetime=true
                               };
                           });

            InitailizeDependecies(services);
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddControllersWithViews();
            services.AddSession();
            services.AddControllers().AddNewtonsoftJson();

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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Property}/{action=Index}/{id?}");
            });
        }

        public void InitailizeDependecies(IServiceCollection services)
        {
            services.AddScoped<IUser, UserRepository>();
            services.AddScoped<IPropertyRent, PropertyRentRepo>();
        }
    }
}
