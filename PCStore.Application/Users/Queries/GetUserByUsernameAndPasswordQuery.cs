using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Users.Queries
{
    public record GetUserByUsernameAndPasswordQuery(string username,string password) : IRequest<User>;
}
