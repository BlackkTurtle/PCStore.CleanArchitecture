using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Services.Contracts;

public interface ICommentsService
{
    Task<IEnumerable<Comment>> GetAllCommentsByArticleAsync(int article);
    Task<Comment> GetByIdAsync(int id);
    Task AddAsync(Comment entity);
    Task UpdateAsync(Comment entity);
    Task DeleteByIdAsync(int id);
    Task SaveChangesAsync();
}