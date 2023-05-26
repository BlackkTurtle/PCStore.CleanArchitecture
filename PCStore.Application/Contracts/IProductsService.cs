using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Contracts;

public interface IProductsService : IGenericService<Product>
{
    Task SaveChangesAsync();
    Task<IEnumerable<Product>> GetProductsByNameLikeAsync(string LikeName);
    Task<IEnumerable<Product>> GetProductsByBrandAsync(int BrandID);
    Task<IEnumerable<Product>> GetProductsByTypeAsync(int TypeID);
}