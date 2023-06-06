using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Products.Queries
{
    public class GetAllProductsByBrandHandler : IRequestHandler<GetAllProductsByBrandQuery, IEnumerable<Product>>
    {
        public GetAllProductsByBrandHandler(IProductsService productsService)
        {
            ProductsService = productsService;
        }

        public IProductsService ProductsService { get; }

        public Task<IEnumerable<Product>> Handle(GetAllProductsByBrandQuery request, CancellationToken cancellationToken)
        {
            return ProductsService.GetProductsByBrandAsync(request.id);
        }
    }
}
