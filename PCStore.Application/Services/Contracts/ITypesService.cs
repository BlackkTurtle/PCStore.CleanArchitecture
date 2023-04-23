using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Services.Contracts;

public interface ITypesService
{
    Task<IEnumerable<Types>> GetAllAsync();
}