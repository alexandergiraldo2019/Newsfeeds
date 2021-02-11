using Deloitte.DataNewsfeeds;
using Deloitte.DataNewsfeeds.Interfaces;
using Deloitte.DataNewsfeeds.Repositories;
using Deloitte.ServiceNewsfeeds.ExternalServices;
using Deloitte.ServiceNewsfeeds.Interfaces;
using Deloitte.ServiceNewsfeeds.Services;
using Deloitte.UINewsfeeds.Data;
using Deloitte.UINewsfeeds.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Deloitte.UINewsfeeds.AppStart
{
    public class ServiceConfiguration
    {
        public IConfiguration Configuration { get; }

        public ServiceConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void SCConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddScoped<IFeedService, FeedService>();
            services.AddScoped<INewsFeedService, NewsFeedService>();
            services.AddScoped<IConnectionFactory>(x => new DbConnectionFactory("System.Data.SqlClient", Configuration.GetConnectionString("DataContext")));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFeedRepository, FeedRepository>();
            services.AddScoped<IDbContext, DataNewsfeeds.DbContext>();
            services.Configure<JWT>(Configuration.GetSection("JWT"));

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddControllersWithViews();

            services.AddRazorPages();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void SCConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }

    }
}
