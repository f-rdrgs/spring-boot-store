using dotnet_store_test.Database;
using dotnet_store_test.Database.Enums;
using dotnet_store_test.Database.Models;
using Microsoft.EntityFrameworkCore;
using dotnet_store_test.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using dotnet_store_test.Tools;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<SpringStoreContext>(options => options.UseNpgsql(connectionString,o => o.MapEnum<OrdersClientStatus>("order_status")));
builder.Services.AddDbContext<SpringStoreContext>(options => options.UseNpgsql(connectionString, o => o.MapEnum<ProductsCurrentStatus>("current_status")));

var JWTToken = builder.Configuration["JWTSha256Tok"] ?? throw new Exception("Missing JWT Token");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "spring-store",
        ValidAudience = null,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTToken))
    };
});
builder.Services.AddSingleton<JWTHandler>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
