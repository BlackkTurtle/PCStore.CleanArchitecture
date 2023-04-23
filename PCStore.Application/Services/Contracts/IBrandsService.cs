using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Services.Contracts;

public interface IBrandsService
{
    Task<IEnumerable<Brand>> GetAllAsync();
}