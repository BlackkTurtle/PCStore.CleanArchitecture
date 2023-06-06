using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Users.Commands
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        public UpdateUserHandler(IUserService userService)
        {
            UserService = userService;
        }

        public IUserService UserService { get; }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await UserService.Update(request.id,request.User);
        }
    }
}
