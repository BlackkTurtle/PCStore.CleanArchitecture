
using PCStore.Domain.PCStoreEntities;
using PCStore.Domain.Repositories;
using PCStore.Infrastructure.PCStoreDataBaseContext;

namespace PCStore.Infrastructure.Repositories;

public class BrandsRepository : GenericRepository<Brand>, IBrandsRepository
{
    public BrandsRepository(PcstoreContext databaseContext)
        : base(databaseContext)
    {
    }

    public override Task<Brand> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
        databaseContext.SaveChanges();
    }
}
