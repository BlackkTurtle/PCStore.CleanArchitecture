using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Comments.Queries
{
    public class GetAllCommentsByArticleHandler : IRequestHandler<GetAllCommentsByArticleQuery, IEnumerable<Comment>>
    {
        public GetAllCommentsByArticleHandler(ICommentsService commentsService)
        {
            CommentsService = commentsService;
        }

        public ICommentsService CommentsService { get; }

        public Task<IEnumerable<Comment>> Handle(GetAllCommentsByArticleQuery request, CancellationToken cancellationToken)
        {
            return CommentsService.GetAllCommentsByArticleAsync(request.id);
        }
    }
}
