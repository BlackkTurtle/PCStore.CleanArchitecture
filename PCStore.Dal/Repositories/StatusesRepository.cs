
using PCStore.Domain.PCStoreEntities;
using PCStore.Domain.Repositories;
using PCStore.Infrastructure.PCStoreDataBaseContext;

namespace PCStore.Infrastructure.Repositories;

public class StatusesRepository : GenericRepository<Status>, IStatusesRepository
{
    public StatusesRepository(PcstoreContext databaseContext)
        : base(databaseContext)
    {
    }

    public override async Task<Status> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
}
