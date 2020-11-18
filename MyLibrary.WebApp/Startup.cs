using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyLibrary.Business.Abstract;
using MyLibrary.Business.Concrete;
using MyLibrary.DataAccess;
using MyLibrary.DataAccess.Abstract;
using MyLibrary.DataAccess.Concrete;
using MyLibrary.DataAccess.UnitOfWorks;
using MyLibrary.WebApp.AppService;

namespace MyLibrary.WebApp
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
            services.AddHttpClient<BookApiService>(opt =>
            opt.BaseAddress = new Uri(Configuration["baseUrl"]));

            services.AddHttpClient<UserApiService>(opt =>
            opt.BaseAddress = new Uri(Configuration["baseUrl"]));

            services.AddBusinessServices(); //ServiceCollectionExtention den gelir.
            services.AddControllersWithViews();

            #region Authentication
            var authenticationBuilder = services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = "Authentication";
                options.DefaultScheme = "Authentication";
            });

            //add main cookie authentication
            authenticationBuilder.AddCookie("Authentication", options =>
            {
                options.Cookie.Name = $"Book.Cookie";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/Login";
                options.AccessDeniedPath = "/Error";
            });
            #endregion

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
          
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
















//services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//services.AddScoped(typeof(IService<>), typeof(Service));
//services.AddScoped<IBookService, BookService>();
//services.AddScoped<IUserService, UserService>();
//services.AddScoped<IUnitOfWork, UnitOfWork>();

//services.AddDbContext<MyLibraryDbContext>(options =>
//{
//    options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o =>
//    {
//        o.MigrationsAssembly("MyLibraryDb.Data");
//    });
//});