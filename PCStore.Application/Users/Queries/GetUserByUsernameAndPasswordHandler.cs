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
    public class GetUserByUsernameAndPasswordHandler : IRequestHandler<GetUserByUsernameAndPasswordQuery, User>
    {
        public GetUserByUsernameAndPasswordHandler(IUserService userService)
        {
            UserService = userService;
        }

        public IUserService UserService { get; }

        public Task<User> Handle(GetUserByUsernameAndPasswordQuery request, CancellationToken cancellationToken)
        {
            return UserService.GetByUserNameAndPassword(request.username,request.password);
        }
    }
}
