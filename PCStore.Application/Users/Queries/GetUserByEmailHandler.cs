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
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, User>
    {
        public GetUserByEmailHandler(IUserService userService)
        {
            UserService = userService;
        }

        public IUserService UserService { get; }

        public Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            return UserService.GetByEmail(request.Email);
        }
    }
}
