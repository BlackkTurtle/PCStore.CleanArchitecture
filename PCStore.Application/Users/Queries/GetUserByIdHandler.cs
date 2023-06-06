using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Users.Queries
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        public GetUserByIdHandler(IUserService userService)
        {
            UserService = userService;
        }

        public IUserService UserService { get; }

        public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return UserService.GetById(request.id.ToString());
        }
    }
}
