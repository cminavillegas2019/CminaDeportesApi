using DeportesApi.Application.Interfaces;
using DeportesApi.Application.Repositories;
using DeportesApi.Application.Services;
using DeportesApi.Infrastructure.Auth;
using DeportesApi.Infrastructure.Interfaces;
using DeportesApi.Infrastructure.Logging;
using DeportesApi.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de SQL Server
builder.Services.AddDbContext<DeportesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Configuración de JWT
var key = Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Secret"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        ValidateLifetime = true
    };
});

// Inyección de dependencias
builder.Services.AddScoped<IDeportistaRepository, DeportistaRepository>();
builder.Services.AddScoped<IResultadoService, ResultadoService>();
builder.Services.AddScoped<IIntentoService, IntentoService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IDeportistaService, DeportistaService>();


var loggingType = builder.Configuration["Logger:Type"];

if (loggingType == "Database")
{
    builder.Services.AddScoped<ILoggerService, DatabaseLoggerService>();
}
else
{
    builder.Services.AddSingleton<ILoggerService, FileLoggerService>();
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
