using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Types.Queries
{
    public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IEnumerable<PCStore.Domain.PCStoreEntities.Types>>
    {
        public GetAllTypesHandler(ITypesService typesService)
        {
            TypesService = typesService;
        }

        public ITypesService TypesService { get; }

        public Task<IEnumerable<PCStore.Domain.PCStoreEntities.Types>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            return TypesService.GetAllAsync();
        }
    }
}
