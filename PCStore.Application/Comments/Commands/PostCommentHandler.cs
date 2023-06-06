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
    public class PostCommentHandler : IRequestHandler<PostCommentCommand>
    {
        public PostCommentHandler(ICommentsService commentsService)
        {
            CommentsService = commentsService;
        }

        public ICommentsService CommentsService { get; }

        public async Task Handle(PostCommentCommand request, CancellationToken cancellationToken)
        {
            await CommentsService.AddAsync(request.Comment);
            await CommentsService.SaveChangesAsync();
        }
    }
}
