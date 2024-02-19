
using Microsoft.EntityFrameworkCore;
using TheHobbyHub.PL.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextPool<HobbyHubEntities>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection"), builder => {
    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
}));

var app = builder.Build();
app.Run();

