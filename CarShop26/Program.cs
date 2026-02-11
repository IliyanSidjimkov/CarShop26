using CarShop26.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace CarShop26
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<CarShop26DbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                ConfigureIdentity(options, builder.Configuration);


            })
                .AddEntityFrameworkStores<CarShop26DbContext>();

            //Allows us to use space when creating username//
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.User.AllowedUserNameCharacters +=
                    " ";
            });
            builder.Services.AddControllersWithViews();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint(); 
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }

        private static void ConfigureIdentity(IdentityOptions identityOptions, ConfigurationManager configuration)
        {
            identityOptions.SignIn.RequireConfirmedAccount = configuration.GetValue<bool>("IdentityOptions:SignIn:RequireConfirmedAccount");
            identityOptions.SignIn.RequireConfirmedPhoneNumber = configuration.GetValue<bool>("IdentityOptions:SignIn:RequireConfirmedPhoneNumber");
            identityOptions.SignIn.RequireConfirmedEmail = configuration.GetValue<bool>("IdentityOptions:SignIn:RequireConfirmedEmail");


            identityOptions.User.RequireUniqueEmail = configuration.GetValue<bool>("IdentityOptions:User:RequireUniqueEmail");

            identityOptions.Password.RequireDigit = configuration.GetValue<bool>("IdentityOptions:Password:RequireDigit");
            identityOptions.Password.RequireLowercase = configuration.GetValue<bool>("IdentityOptions:Password:RequireLowercase");
            identityOptions.Password.RequireUppercase = configuration.GetValue<bool>("IdentityOptions:Password:RequireUppercase");
            identityOptions.Password.RequireNonAlphanumeric = configuration.GetValue<bool>("IdentityOptions:Password:RequireNonAlphanumeric");
            identityOptions.Password.RequiredUniqueChars = configuration.GetValue<int>("IdentityOptions:Password:RequiredUniqueChars");
            identityOptions.Password.RequiredLength = configuration.GetValue<int>("IdentityOptions:Password:RequiredLength");

            identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(configuration.GetValue<int>("IdentityOptions:Lockout:DefaultLockoutTimeSpan"));
            identityOptions.Lockout.MaxFailedAccessAttempts = configuration.GetValue<int>("IdentityOptions:Lockout:MaxFailedAccessAttempts");

        }

      
    }
}   
