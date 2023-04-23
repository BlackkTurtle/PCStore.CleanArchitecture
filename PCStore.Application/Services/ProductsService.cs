using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCStore.Application.Services.Contracts;
using PCStore.Domain.PCStoreEntities;
using PCStore.Domain.Repositories;

namespace PCStore.Application.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository productsRepository;
        public ProductsService(IProductsRepository repository)
        {
            this.productsRepository = repository;
        }
        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return productsRepository.GetAllAsync();
        }

        public Task<IEnumerable<Product>> GetProductsByBrandAsync(int BrandID)
        {
            return productsRepository.GetProductsByBrandAsync(BrandID);
        }

        public Task<IEnumerable<Product>> GetProductsByNameLikeAsync(string LikeName)
        {
            return productsRepository.GetProductsByNameLikeAsync(LikeName);
        }

        public Task<IEnumerable<Product>> GetProductsByTypeAsync(int TypeID)
        {
            return productsRepository.GetProductsByTypeAsync(TypeID);
        }
    }
}
