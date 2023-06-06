using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Statuses.Queries
{
    public class GetAllStatusesHandler : IRequestHandler<GetAllStatusesQuery, IEnumerable<Status>>
    {
        public GetAllStatusesHandler(IStatusesService statusesService)
        {
            StatusesService = statusesService;
        }

        public IStatusesService StatusesService { get; }

        public Task<IEnumerable<Status>> Handle(GetAllStatusesQuery request, CancellationToken cancellationToken)
        {
            return StatusesService.GetAllAsync();
        }
    }
}
