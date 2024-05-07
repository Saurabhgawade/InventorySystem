using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using projectDemo.Data;
using projectDemo.Redis;
using StackExchange.Redis;
using IRedis = projectDemo.Redis.IRedis;
namespace projectDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<projectDemoContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("projectDemoContext") ?? throw new InvalidOperationException("Connection string 'projectDemoContext' not found.")));

            // Add services to the container.
            //builder.Services.AddSingleton<IConnectionMultiplexer>(x => ConnectionMultiplexer.Connect(builder.Configuration.GetSection("Redis:Connection").Value!.ToString()));
            //builder.Services.AddTransient<IRedis, RedisService>();

            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<projectDemoContext>().AddDefaultTokenProviders();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            //}
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();

          

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
