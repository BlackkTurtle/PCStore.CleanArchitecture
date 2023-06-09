﻿using Microsoft.EntityFrameworkCore;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;
using PCStore.Infrastructure.Exceptions;
using PCStore.Infrastructure.PCStoreDataBaseContext;

namespace PCStore.Infrastructure.Services;

public class ProductsService : GenericService<Product>, IProductsService
{
    public ProductsService(PcstoreContext databaseContext)
        : base(databaseContext)
    {
    }
    public async Task<IEnumerable<Product>> GetProductsByBrandAsync(int BrandID)
    {
        return await databaseContext.Products.Where(v => v.BrandId == BrandID).ToListAsync()
            ?? throw new Exception($"Couldn't retrieve entities Products");
    }

    public async Task<IEnumerable<Product>> GetProductsByNameLikeAsync(string LikeName)
    {
        return await databaseContext.Products.Where(v => v.Name.Contains(LikeName)).ToListAsync()
            ?? throw new Exception($"Couldn't retrieve entities Products");
    }

    public async Task<IEnumerable<Product>> GetProductsByTypeAsync(int TypeID)
    {
        return await databaseContext.Products.Where(v => v.Type == TypeID).ToListAsync()
            ?? throw new Exception($"Couldn't retrieve entities Products");
    }
    public override async Task<Product> GetCompleteEntityAsync(int id)
    {
        var my_event = await table.Include(ev => ev.Type)
                                 .Include(ev => ev.BrandId)
                                 .SingleOrDefaultAsync(ev => ev.Article == id);
        return my_event ?? throw new EntityNotFoundException("NOT FOUND");
    }
    public async Task SaveChangesAsync()
    {
        await databaseContext.SaveChangesAsync();
    }
}
