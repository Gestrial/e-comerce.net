using EComerce.Api.Data;
using EComerce.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Services
ConfigurationManager configuration = builder.Configuration;
var conString = configuration.GetConnectionString("AuthDb");
Console.WriteLine("Mysql Connection String: " + conString);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ComerceDbContext>(options => options.UseMySql(conString, MySqlServerVersion.AutoDetect(conString)));

builder.Services.AddIdentity<ApplicationUser, IdentityRole<long>>()
    .AddEntityFrameworkStores<ComerceDbContext>()
    .AddDefaultTokenProviders();



#endregion

var app = builder.Build();

#region Middleware

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#endregion


app.Run();
