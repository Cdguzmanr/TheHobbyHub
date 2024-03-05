using Microsoft.EntityFrameworkCore;
using TheHobbyHub.PL.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Add the ability to access http context
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(1000);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        // TODO: Add the API functionality
        //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7081/api/") }); 


        // TODO: Delete this DBContext and replace with the one from the Data project or API once it works
        // Add connection string to the container
        /*        builder.Services.AddDbContext<HobbyHubEntities>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection"));
                    options.UseLazyLoadingProxies();
                });*/

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

        app.UseSession(); // IMPORTANT : This must be before UseAuthorization

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}