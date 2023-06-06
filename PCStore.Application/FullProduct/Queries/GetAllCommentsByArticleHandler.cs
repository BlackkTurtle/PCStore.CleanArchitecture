using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Application.Contracts;
using PCStore.Application.DTOs;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.FullProduct.Queries
{
    public class GetFullProductByArticleHandler : IRequestHandler<GetFullProductByArticleQuery, FullProductDTO>
    {
        public GetFullProductByArticleHandler(IFullProductService fullProductService)
        {
            FullProductService = fullProductService;
        }

        public IFullProductService FullProductService { get; }

        public Task<FullProductDTO> Handle(GetFullProductByArticleQuery request, CancellationToken cancellationToken)
        {
            return FullProductService.GetCompleteFullProductAsync(request.id);
        }
    }
}
