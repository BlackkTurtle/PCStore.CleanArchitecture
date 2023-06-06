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
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand>
    {
        public UpdateOrderHandler(IOrdersService ordersService)
        {
            OrdersService = ordersService;
        }

        public IOrdersService OrdersService { get; }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await OrdersService.GetByIdAsync(request.id);
            result.Status = request.Order.Status;
            result.Adress= request.Order.Adress;
            result.UserId=request.Order.UserId;
            await OrdersService.SaveChangesAsync();
        }
    }
}
