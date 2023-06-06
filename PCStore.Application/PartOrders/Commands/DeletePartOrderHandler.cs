using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Application.Contracts;

namespace PCStore.Application.PartOrders.Commands
{
    public class DeletePartOrderHandler : IRequestHandler<DeletePartOrderCommand>
    {
        public DeletePartOrderHandler(IPartOrdersService partOrdersService)
        {
            PartOrdersService = partOrdersService;
        }

        public IPartOrdersService PartOrdersService { get; }

        public async Task Handle(DeletePartOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await PartOrdersService.GetByIdAsync(request.id);
            await PartOrdersService.DeleteAsync(result);
            await PartOrdersService.SaveChangesAsync();
        }
    }
}
