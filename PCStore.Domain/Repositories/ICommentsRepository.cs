using PCStore.Domain.PCStoreEntities;


namespace PCStore.Domain.Repositories;

public interface ICommentsRepository : IGenericRepository<Comment>
{
    Task<IEnumerable<Comment>> GetAllCommentsByArticleAsync(int article);
    Task SaveChangesAsync();
}