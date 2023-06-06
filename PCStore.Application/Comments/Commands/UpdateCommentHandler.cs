using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Comments.Commands
{
    public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand>
    {
        public UpdateCommentHandler(ICommentsService commentsService)
        {
            CommentsService = commentsService;
        }

        public ICommentsService CommentsService { get; }

        public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var result =await CommentsService.GetByIdAsync(request.id);
            result.Article = request.Comment.Article;
            result.Stars=request.Comment.Stars;
            result.UserId=request.Comment.UserId;
            result.Comment1 = request.Comment.Comment1;
            await CommentsService.SaveChangesAsync();
        }
    }
}
