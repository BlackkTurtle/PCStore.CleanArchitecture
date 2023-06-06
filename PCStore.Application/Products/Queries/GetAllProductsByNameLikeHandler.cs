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
    public class GetAllProductsByNameLikeHandler : IRequestHandler<GetAllProductsByNameLikeQuery, IEnumerable<Product>>
    {
        public GetAllProductsByNameLikeHandler(IProductsService productsService)
        {
            ProductsService = productsService;
        }

        public IProductsService ProductsService { get; }

        public Task<IEnumerable<Product>> Handle(GetAllProductsByNameLikeQuery request, CancellationToken cancellationToken)
        {
            return ProductsService.GetProductsByNameLikeAsync(request.name);
        }
    }
}
