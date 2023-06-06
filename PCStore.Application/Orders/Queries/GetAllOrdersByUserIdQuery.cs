using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Orders.Queries
{
    public record GetAllOrdersByUserIdQuery(int id) : IRequest<IEnumerable<Order>>;
}
