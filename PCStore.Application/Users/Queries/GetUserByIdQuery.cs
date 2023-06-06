using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Users.Queries
{
    public record GetUserByIdQuery(int id) : IRequest<User>;
}
