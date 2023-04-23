using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Services.Contracts;

public interface IProductsService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<IEnumerable<Product>> GetProductsByNameLikeAsync(string LikeName);
    Task<IEnumerable<Product>> GetProductsByBrandAsync(int BrandID);
    Task<IEnumerable<Product>> GetProductsByTypeAsync(int TypeID);
}