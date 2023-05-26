using PCStore.Application.Contracts;
using PCStore.Application.DTOs;

namespace PCStore.Infrastructure.Services
{
    public class FullProductService : IFullProductService
    {
        private readonly IProductsService productsRepository;
        private readonly IBrandsService brandsRepository;
        private readonly ITypesService typesRepository;
        public FullProductService(IProductsService productsrepository, ITypesService typesRepository, IBrandsService brandsRepository)
        {
            productsRepository = productsrepository;
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
