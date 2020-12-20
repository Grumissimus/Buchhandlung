using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Buchhandlung.Auth
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddUserManager<UserManager<AppUser>>()
                .AddRoleManager<RoleManager<AppRole>>()
                .AddSignInManager<SignInManager<AppUser>>()
                .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<AppUser, AppRole>>()
                .AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.AddIdentityServer(options =>
                   options.UserInteraction = new UserInteractionOptions()
                   {
                       LogoutUrl = "/account/logout",
                       LoginUrl = "/account/login",
                       LoginReturnUrlParameter = "returnUrl"
                   })
                .AddInMemoryClients(Configuration.GetClients())
                .AddInMemoryCaching()
                .AddInMemoryPersistedGrants()
                .AddInMemoryIdentityResources(Configuration.GetIdentityResources())
                .AddInMemoryApiResources(Configuration.GetApiResources())
                .AddInMemoryApiScopes(Configuration.GetApiScopes())
                .AddAspNetIdentity<AppUser>()
                .AddProfileService<MyProfileService>()
                .AddDeveloperSigningCredential();

            services.AddAuthentication();
            services.AddAuthorization();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
