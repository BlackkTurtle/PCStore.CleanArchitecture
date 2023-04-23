
using PCStore.Domain.PCStoreEntities;
using PCStore.Domain.Repositories;
using PCStore.Infrastructure.PCStoreDataBaseContext;

namespace PCStore.Infrastructure.Repositories;

public class TypesRepository : GenericRepository<Types>, ITypesRepository
{
    public TypesRepository(PcstoreContext databaseContext)
        : base(databaseContext)
    {
    }
    public override Task<Types> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
}
