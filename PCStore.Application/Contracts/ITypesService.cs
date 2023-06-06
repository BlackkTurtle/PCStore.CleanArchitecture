using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Contracts;

public interface ITypesService : IGenericService<PCStore.Domain.PCStoreEntities.Types>
{
    Task SaveChangesAsync();
}