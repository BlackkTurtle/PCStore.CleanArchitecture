using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Contracts;

public interface ICommentsService : IGenericService<Comment>
{
    Task SaveChangesAsync();
    Task<IEnumerable<Comment>> GetAllCommentsByArticleAsync(int article);
}