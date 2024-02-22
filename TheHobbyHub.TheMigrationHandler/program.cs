using TheHobbyHub.PL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextPool<HobbyHubEntities>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection"), builder => {
    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
}));

var app = builder.Build();
app.Run();

