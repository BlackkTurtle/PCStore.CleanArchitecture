using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Contracts;

public interface ITypesService : IGenericService<Types>
{
    Task SaveChangesAsync();
}