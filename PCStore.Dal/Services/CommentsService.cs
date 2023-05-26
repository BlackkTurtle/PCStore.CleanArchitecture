using Microsoft.EntityFrameworkCore;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;
using PCStore.Infrastructure.Exceptions;
using PCStore.Infrastructure.PCStoreDataBaseContext;

namespace PCStore.Infrastructure.Services;

public class CommentService : GenericService<Comment>, ICommentsService
{
    public CommentService(PcstoreContext databaseContext)
        : base(databaseContext)
    {
    }

    public async Task<IEnumerable<Comment>> GetAllCommentsByArticleAsync(int article)
    {
        return await databaseContext.Comments.Where(v => v.Article == article).ToListAsync()
            ?? throw new Exception($"Couldn't retrieve entities Comment");
    }

    public override async Task<Comment> GetCompleteEntityAsync(int id)
    {
        var my_event = await table.Include(ev => ev.UserId)
                                 .Include(ev => ev.Article)
                                 .SingleOrDefaultAsync(ev => ev.CommentId == id);
        return my_event ?? throw new EntityNotFoundException("NOT FOUND");
    }
    public async Task SaveChangesAsync()
    {
        await databaseContext.SaveChangesAsync();
    }
}


