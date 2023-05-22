using PCStore.Application.Services.Contracts;
using PCStore.Application.Services;
using PCStore.Domain.Repositories;
using PCStore.Infrastructure.PCStoreDataBaseContext;
using PCStore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using PCStore.Domain.PCStoreEntities;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
    options.UseSqlServer(connectionString);
});


builder.Services.AddScoped<ITypesService, TypesService>();
builder.Services.AddScoped<IBrandsService, BrandService>();
builder.Services.AddScoped<ICommentsService, CommentsService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IPartOrdersService, PartOrdersService>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IStatusesService, StatusesService>();
builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddScoped<ITypesRepository, TypesRepository>();
builder.Services.AddScoped<IBrandsRepository, BrandsRepository>();
builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IPartOrdersRepository, PartOrdersRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IStatusesRepository, StatusesRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
