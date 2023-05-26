using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Contracts;

public interface IBrandsService : IGenericService<Brand>
{
    Task SaveChangesAsync();
}