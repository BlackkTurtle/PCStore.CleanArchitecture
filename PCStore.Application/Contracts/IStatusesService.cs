using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Contracts;

public interface IStatusesService : IGenericService<Status>
{
    Task SaveChangesAsync();
}