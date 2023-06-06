using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.PartOrders.Queries
{
    public class GetPartOrderByIdHandler : IRequestHandler<GetPartOrderByIdQuery, PartOrder>
    {
        public GetPartOrderByIdHandler(IPartOrdersService partOrdersService)
        {
            PartOrdersService = partOrdersService;
        }

        public IPartOrdersService PartOrdersService { get; }

        public Task<PartOrder> Handle(GetPartOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return PartOrdersService.GetByIdAsync(request.id);
        }
    }
}
