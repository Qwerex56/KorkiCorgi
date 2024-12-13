using KorkiCorgi.Components;
using KorkiCorgi.Models;
using KorkiCorgi.Options;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// TODO: Hide that
var key = builder.Configuration["ConnectionStrings:NpgsqlConnection"];

builder.Services.AddDbContext<CorgiDbContext>(options => options.UseNpgsql(
    connectionString: key));

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
