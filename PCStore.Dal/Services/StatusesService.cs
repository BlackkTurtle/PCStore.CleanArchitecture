using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;
using PCStore.Infrastructure.PCStoreDataBaseContext;

namespace PCStore.Infrastructure.Services;

public class StatusesService : GenericService<Status>, IStatusesService
{
    public StatusesService(PcstoreContext databaseContext)
        : base(databaseContext)
    {
    }

    public override async Task<Status> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
    public async Task SaveChangesAsync()
    {
        await databaseContext.SaveChangesAsync();
    }
}
