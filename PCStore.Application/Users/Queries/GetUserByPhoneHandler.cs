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
    public class GetUserByPhoneHandler : IRequestHandler<GetUserByPhoneQuery, User>
    {
        public GetUserByPhoneHandler(IUserService userService)
        {
            UserService = userService;
        }

        public IUserService UserService { get; }

        public Task<User> Handle(GetUserByPhoneQuery request, CancellationToken cancellationToken)
        {
            return UserService.GetByPhone(request.phone);
        }
    }
}
