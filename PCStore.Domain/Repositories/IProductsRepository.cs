using PCStore.Domain.PCStoreEntities;

namespace PCStore.Domain.Repositories;

public interface IProductsRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByNameLikeAsync(string LikeName);
    Task<IEnumerable<Product>> GetProductsByBrandAsync(int BrandID);
    Task<IEnumerable<Product>> GetProductsByTypeAsync(int TypeID);
}