using DAL.Extensions;
using DotNetEnv;
using DotNetEnv.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.Options;
using System.Security.Claims;


var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appSettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true)
    .AddEnvironmentVariables()
    .AddDotNetEnv("secrets.env", LoadOptions.TraversePath())
    .Build();

builder.Configuration.AddConfiguration(configuration);

// DBs
var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? Environment.GetEnvironmentVariable("POSTGRESQLCONNSTR_DefaultConnection") ?? throw new Exception("Connection String not configured.");

// Add services to the container.

builder.Services.RegisterDALs(defaultConnectionString);



builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();



//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
//})
//.AddCookie()
//.AddGoogle(options =>
//{
//    options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
//    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
//    options.Scope.Add("email");
//    options.Scope.Add("profile");

//    options.Events.OnCreatingTicket = ctx =>
//    {
//        var email = ctx.User.GetProperty("email").GetString();
//        var name = ctx.User.GetProperty("name").GetString();

//        // Add custom claims
//        ctx.Identity.AddClaim(new Claim("google_email", email));
//        ctx.Identity.AddClaim(new Claim("display_name", name));

//        return Task.CompletedTask;
//    };

//});


var app = builder.Build();

//app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();
//app.UseAuthentication();

app.MapControllers();

app.Run();
