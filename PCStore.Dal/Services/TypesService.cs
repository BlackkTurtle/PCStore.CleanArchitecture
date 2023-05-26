using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;
using PCStore.Infrastructure.PCStoreDataBaseContext;

namespace PCStore.Infrastructure.Services;

public class TypesService : GenericService<Types>, ITypesService
{
    public TypesService(PcstoreContext databaseContext)
        : base(databaseContext)
    {
    }
    public override Task<Types> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
    public async Task SaveChangesAsync()
    {
        await databaseContext.SaveChangesAsync();
    }
}
