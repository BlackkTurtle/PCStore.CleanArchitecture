using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Orders.Queries
{
    public class GetAllOrdersByUserIdHandler : IRequestHandler<GetAllOrdersByUserIdQuery, IEnumerable<Order>>
    {
        public GetAllOrdersByUserIdHandler(IOrdersService ordersService)
        {
            OrdersService = ordersService;
        }

        public IOrdersService OrdersService { get; }

        public Task<IEnumerable<Order>> Handle(GetAllOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            return OrdersService.GetAllOrdersByUserIDAsync(request.id);
        }
    }
}
