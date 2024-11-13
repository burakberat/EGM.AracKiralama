﻿using EGM.AracKiralama.API.Middlewares;
using EGM.AracKiralama.BL.Abstracts;
using EGM.AracKiralama.BL.Concretes;
using EGM.AracKiralama.DAL.Abstracts;
using EGM.AracKiralama.DAL.Concretes;
using EGM.AracKiralama.DAL.Context;
using EGM.AracKiralama.Model.Profiles;
using Infrastructure.Model.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Transactions;


var builder = WebApplication.CreateBuilder(args);
//API servislerini eklemek için
//deneme

builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidAudience = jwtSettings.Audience,
            ValidIssuer = jwtSettings.Issuer,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation    
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "EGM Proje",
        Description = " Swagger",
    });
    // To Enable authorization using Swagger (JWT)    
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Token Bilgisini Giriniz: \r\n\r\nÖrnek Kullanım: \r\nBearer eyJhbGciOiJIUzI1NiIsInR5...",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
});

builder.Services.AddDbContext<AracKiralamaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AracKiralamaDbConnection"));
});
builder.Services.AddDbContext<LogDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LogDbConnection"));
});

builder.Services.AddAutoMapper(typeof(AracKiralamaProfile));
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IAracKiralamaRepository, AracKiralamaRepository>();
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

TransactionManager.ImplicitDistributedTransactions = true;

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<LogMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

//app.UseMiddleware<FirstMiddleware>();
//app.UseMiddleware<SecondMiddleware>();

app.MapDefaultControllerRoute();

app.Run();
