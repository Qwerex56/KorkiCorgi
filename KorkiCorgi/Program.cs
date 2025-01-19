using KorkiCorgi.Components;
using KorkiCorgi.Models;
using KorkiCorgi.Models.ModelFactory;
using KorkiCorgi.Options;
using KorkiCorgi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var key = builder.Configuration["ConnectionStrings:NpgsqlConnection"];

builder.Services.AddDbContext<CorgiDbContext>(options => options.UseNpgsql(
    connectionString: key));

builder.Services.AddScoped<IUserFactory, UserFactory>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseStaticFiles(new StaticFileOptions {
        OnPrepareResponse = ctx => {
            ctx.Context.Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
        }
    });
}
else {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllers();

// app.MapControllerRoute(
//     "default",
//     "api/v1/{controller}/{action=Index}/{id?}");

app.Run();