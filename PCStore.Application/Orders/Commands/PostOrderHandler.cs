using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Orders.Commands
{
    public class PostOrderHandler : IRequestHandler<PostOrderCommand>
    {
        public PostOrderHandler(IOrdersService ordersService)
        {
            OrdersService = ordersService;
        }

        public IOrdersService OrdersService { get; }

        public async Task Handle(PostOrderCommand request, CancellationToken cancellationToken)
        {
            await OrdersService.AddAsync(request.order);
            await OrdersService.SaveChangesAsync();
        }
    }
}
