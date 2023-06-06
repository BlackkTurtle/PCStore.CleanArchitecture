using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.PartOrders.Commands
{
    public class UpdatePartOrderHandler : IRequestHandler<UpdatePartOrderCommand>
    {
        public UpdatePartOrderHandler(IPartOrdersService partOrdersService)
        {
            PartOrdersService = partOrdersService;
        }

        public IPartOrdersService PartOrdersService { get; }

        public async Task Handle(UpdatePartOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await PartOrdersService.GetByIdAsync(request.id);
            result.OrderId = request.PartOrder.OrderId;
            result.Article=request.PartOrder.Article;
            result.Price=request.PartOrder.Price;
            result.Quantity=request.PartOrder.Quantity;
            await PartOrdersService.SaveChangesAsync();
        }
    }
}
