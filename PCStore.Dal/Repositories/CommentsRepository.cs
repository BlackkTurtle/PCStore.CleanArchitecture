using Microsoft.EntityFrameworkCore;
using PCStore.Domain.PCStoreEntities;
using PCStore.Domain.Repositories;
using PCStore.Infrastructure.Exceptions;
using PCStore.Infrastructure.PCStoreDataBaseContext;

namespace PCStore.Infrastructure.Repositories;

public class CommentsRepository : GenericRepository<Comment>, ICommentsRepository
{
    public CommentsRepository(PcstoreContext databaseContext)
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

    public Task SaveChangesAsync()
    {
        databaseContext.SaveChanges();
        return Task.CompletedTask;
    }
}


