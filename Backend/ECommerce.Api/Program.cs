using EComerce.Api.Data;
using EComerce.Api.Models;
using ECommerce.Api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Services
ConfigurationManager configuration = builder.Configuration;

//add dbContext:
var conString = configuration.GetConnectionString("AuthDb");
Console.WriteLine("Mysql Connection String: " + conString);
builder.Services.AddDbContext<ComerceDbContext>(options => options.UseMySql(conString, MySqlServerVersion.AutoDetect(conString)));

//Identity Service
builder.Services.AddIdentity<ApplicationUser, IdentityRole<long>>()
    .AddEntityFrameworkStores<ComerceDbContext>()
    .AddDefaultTokenProviders();

//Identity Service Pasword requirements
builder.Services.Configure<IdentityOptions>(options => {
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+/";
    options.User.RequireUniqueEmail = true;

    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
});
//configure JWT Validation
builder.Services.ConfigureJwtAuth(configuration);

//DI for Token Service
builder.Services.AddSingleton<ITokenService, TokenService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#endregion

var app = builder.Build();

#region Middleware

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

#endregion


app.Run();
