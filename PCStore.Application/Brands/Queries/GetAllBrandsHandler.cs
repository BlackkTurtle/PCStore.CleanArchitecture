using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Brands.Queries
{
    public class GetAllBrandsHandler : IRequestHandler<GetAllBrandQuery, IEnumerable<Brand>>
    {
        public GetAllBrandsHandler(IBrandsService brandsService)
        {
            BrandsService = brandsService;
        }

        public IBrandsService BrandsService { get; }

        public Task<IEnumerable<Brand>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            return BrandsService.GetAllAsync();
        }
    }
}
