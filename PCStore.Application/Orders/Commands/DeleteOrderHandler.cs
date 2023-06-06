using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Application.Contracts;

namespace PCStore.Application.Orders.Commands
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand>
    {
        public DeleteOrderHandler(IOrdersService ordersService)
        {
            OrdersService = ordersService;
        }

        public IOrdersService OrdersService { get; }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await OrdersService.GetByIdAsync(request.id);
            await OrdersService.DeleteAsync(result);
            await OrdersService.SaveChangesAsync();
        }
    }
}
