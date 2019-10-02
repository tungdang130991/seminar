using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Seminar.Repository;
using Seminar.Repository.Entity;
using Seminar.Repository.MySQL;
using Seminar.Web.Utility;
using Serilog;

namespace Seminar.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddLogging();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromSeconds(GetSessionTimeOut());
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddDbContext<SeminarDbContext>(options => options.UseMySql(Configuration.GetConnectionString("SeminarConnectionString"), 
                mySqlOptions => {
                    mySqlOptions.ServerVersion(new Version(8, 0, 11), ServerType.MySql);
            }));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISeminarRepository, SeminarRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IViewRenderService, ViewRenderService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();

            //Adding localisation to web
            services.AddLocalization(options => { options.ResourcesPath = "Resources"; });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                             .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, 
                             options => { options.ResourcesPath = "Resources"; })
                             .AddDataAnnotationsLocalization(options => {
                                 options.DataAnnotationLocalizerProvider = (type, factory) =>
                                 factory.Create(typeof(Resources));
                             });

            //Configure to determine the current culture for a request
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("ja-jp");
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("ja-jp") };
                options.SupportedUICultures = options.SupportedCultures;
            });
        }

        /// <summary>
        /// Get the session timeout in appsetting.json
        /// </summary>
        /// <returns></returns>
        private double GetSessionTimeOut()
        {
            string strSessionTimeOut = Configuration["AppSettings:SessionTimeOut"];
            if (string.IsNullOrEmpty(strSessionTimeOut))
            {
                return 5000; //Seconds
            }
            else
            {
                if (Double.TryParse(strSessionTimeOut, out double sessionTimeOut))
                {
                    return sessionTimeOut;
                }
                else
                {
                    return 5000; //Seconds
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
#if ShowDevExceptionPage
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
#else
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
#endif
            app.UseHttpsRedirection();
            loggerFactory.AddSerilog();
            app.UseSession();
            app.UseStaticFiles();

            //Configure to determine the current culture for a request
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseCookiePolicy();
        }
    }
}
