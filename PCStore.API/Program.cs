using PCStore.Infrastructure.PCStoreDataBaseContext;
using Microsoft.AspNetCore.Identity;
using PCStore.Domain.PCStoreEntities;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PCStore.API.Models;
using PCStore.Application.Contracts;
using PCStore.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:7074/",
            ValidAudience= "https://localhost:7074/",
            IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9"))
        };
    });
builder.Services.AddDbContext<PcstoreContext>(options =>
{
    string ?connectionString = builder.Configuration.GetConnectionString("MSSQLConnection");
    options.UseSqlServer(connectionString,b=>b.MigrationsAssembly("PCStore.API"));
});


builder.Services.AddScoped<ITypesService, TypesService>();
builder.Services.AddScoped<IBrandsService, BrandsService>();
builder.Services.AddScoped<ICommentsService, CommentService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IPartOrdersService, PartOrdersService>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IStatusesService, StatusesService>();
builder.Services.AddScoped<UserLogin>();

builder.Services.AddScoped<IFullProductService, FullProductService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
