using KorkiCorgi.Components;
using KorkiCorgi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<CorgiDbContext>(options => options.UseNpgsql(
    connectionString: "Host=localhost;Port=5432;Username=TestAccount;Password=Pass;Database=TestDb;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} else {
    // builder.Services.AddDbContext<DbContext>(options => {
    //     options.UseNpgsql(builder.Configuration["ConnectionStrings:NpgsqlConnection"]);
    // }); // Connection string for a development scenario, for production uses appsettings
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
