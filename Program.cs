using CarRentalApplication.Interfaces;
using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Dictionary;
using CarRentalApplication.Models.Entities.Users;
using CarRentalApplication.Services;
using CarRentalApplication.Services.Selectors;
using CarRentalApplication.Services.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CarRentalApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            builder.Services.AddScoped<IUserClaimsPrincipalFactory<User>, CustomClaimsPrincipalFactory>();

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ICarsService, CarsService>();
            builder.Services.AddScoped<IBrandsService, BrandsService>();
            builder.Services.AddScoped<ISelectorsService, SelectorsService>();
            builder.Services.AddScoped(typeof(IGenericSelectorService<,>), typeof(GenericSelectorService<,>));
            builder.Services.AddScoped<CitiesService>();
            builder.Services.AddScoped<ColorsService>();
            builder.Services.AddScoped<EnginesService>();
            builder.Services.AddScoped<FuelCapacitiesService>();
            builder.Services.AddScoped<GearboxesService>();
            builder.Services.AddScoped<SeatsService>();
            builder.Services.AddScoped<YearsService>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Auth/Login";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/Home/NotFound");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Introduction}/{id?}");

            app.Run();
        }
    }
}
