using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Comments.Commands
{
    public record UpdateCommentCommand(int id,Comment Comment):IRequest;
}
