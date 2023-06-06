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
    public class PostPartOrderHandler : IRequestHandler<PostPartOrderCommand>
    {
        public PostPartOrderHandler(IPartOrdersService partordersService)
        {
            PartOrdersService = partordersService;
        }

        public IPartOrdersService PartOrdersService { get; }

        public async Task Handle(PostPartOrderCommand request, CancellationToken cancellationToken)
        {
            await PartOrdersService.AddAsync(request.partorder);
            await PartOrdersService.SaveChangesAsync();
        }
    }
}
