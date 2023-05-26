﻿using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;
using PCStore.Infrastructure.PCStoreDataBaseContext;

namespace PCStore.Infrastructure.Services;

public class BrandsService : GenericService<Brand>, IBrandsService
{
    public BrandsService(PcstoreContext databaseContext)
        : base(databaseContext)
    {
    }

    public override Task<Brand> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
    public async Task SaveChangesAsync()
    {
        await databaseContext.SaveChangesAsync();
    }
}
