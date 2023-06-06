using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Application.Contracts;

namespace PCStore.Application.Users.Commands
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
    {
        public DeleteUserHandler(IUserService userService)
        {
            UserService = userService;
        }

        public IUserService UserService { get; }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await UserService.Remove(request.id);
        }
    }
}
