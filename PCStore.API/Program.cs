using PCStore.Application.Services.Contracts;
using PCStore.Application.Services;
using PCStore.Domain.Repositories;
using PCStore.Infrastructure.PCStoreDataBaseContext;
using PCStore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using PCStore.Domain.PCStoreEntities;
using Microsoft.EntityFrameworkCore;
using PCStore.Infrastructure.Identity;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PcstoreContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MSSQLConnection");
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
