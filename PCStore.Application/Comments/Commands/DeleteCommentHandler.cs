using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Application.Contracts;

namespace PCStore.Application.Comments.Commands
{
    public class DeleteCommentHandler:IRequestHandler<DeleteCommentCommand>
    {
        public DeleteCommentHandler(ICommentsService commentsService)
        {
            CommentsService = commentsService;
        }

        public ICommentsService CommentsService { get; }

        public async Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var result =await CommentsService.GetByIdAsync(request.id);
            await CommentsService.DeleteAsync(result);
            await CommentsService.SaveChangesAsync();
        }
    }
}
