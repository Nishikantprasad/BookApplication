using BookApplication.Business_Layer;
using BookApplication.Data;
using BookApplication.Repository;
using BookApplication.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbcontext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
            ));
            builder.Services.AddScoped<IEventFacade, EventFacade>();
            builder.Services.AddScoped<IAccountFacade, AccountFacade>();
            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IUnitOfWork,MyUnitOfWork>();
            builder.Services.AddScoped<IFacadeFactory, EventFacadeFactory>();
            //service for Identity framework
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbcontext>();

            //service to configure identity settings such as pasword complexity
            builder.Services.Configure<IdentityOptions>(options =>
            {
                //configure password complextity
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
            });

            //configure service when not log in
            builder.Services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Home/Login";
            });

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.Run();
        }
    }
}