using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCStore.Application.DTOs;
using PCStore.Application.Services.Contracts;
using PCStore.Domain.PCStoreEntities;
using PCStore.Domain.Repositories;

namespace PCStore.Application.Services
{
    public class FullProductService : IFullProductService
    {
        private readonly IProductsRepository productsRepository;
        private readonly IBrandsRepository brandsRepository;
        private readonly ITypesRepository typesRepository;
        public FullProductService(IProductsRepository productsrepository,ITypesRepository typesRepository,IBrandsRepository brandsRepository)
        {
            this.productsRepository = productsrepository;
            this.brandsRepository = brandsRepository;
            this.typesRepository = typesRepository;
        }

        public async Task<FullProductDTO> GetCompleteFullProductAsync(int article)
        {
            var product = await productsRepository.GetByIdAsync(article);
            var brand = await brandsRepository.GetByIdAsync(product.BrandId);
            var type = await typesRepository.GetByIdAsync(product.Type);
            var fullproduct = new FullProductDTO
            {
                Article = product.Article,
                Name = product.Name,
                Picture = product.Picture,
                Type = product.Type,
                Price = product.Price,
                ProductInfo = product.ProductInfo,
                BrandId = product.BrandId,
                Availability = product.Availability,
                BrandName = brand.BrandName,
                TypeName = type.TypeName
            };
            if (product == null)
            {
                throw new ArgumentException("NOT FOUND");
            }
            else
            {
                return fullproduct;
            }
        }
    }
}
