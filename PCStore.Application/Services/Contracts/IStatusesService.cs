using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Services.Contracts;

public interface IStatusesService
{
    Task<IEnumerable<Status>> GetAllAsync();
}