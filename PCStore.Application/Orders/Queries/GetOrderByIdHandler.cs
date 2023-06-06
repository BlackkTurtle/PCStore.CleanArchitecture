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
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        public GetOrderByIdHandler(IOrdersService ordersService)
        {
            OrdersService = ordersService;
        }

        public IOrdersService OrdersService { get; }

        public Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return OrdersService.GetByIdAsync(request.id);
        }
    }
}
