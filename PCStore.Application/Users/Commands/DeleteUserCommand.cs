using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Data.SqlClient.DataClassification;

namespace PCStore.Application.Users.Commands
{
    public record DeleteUserCommand(string id) : IRequest;
}
