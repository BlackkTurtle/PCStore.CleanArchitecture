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
    public class GetAllPartOrdersByOrderIdHandler : IRequestHandler<GetAllPartOrdersByOrderIdQuery, IEnumerable<PartOrder>>
    {
        public GetAllPartOrdersByOrderIdHandler(IPartOrdersService partOrdersService)
        {
            PartOrdersService = partOrdersService;
        }

        public IPartOrdersService PartOrdersService { get; }

        public Task<IEnumerable<PartOrder>> Handle(GetAllPartOrdersByOrderIdQuery request, CancellationToken cancellationToken)
        {
            return PartOrdersService.GetAllPartOrdersByOrderIDAsync(request.id);
        }
    }
}
