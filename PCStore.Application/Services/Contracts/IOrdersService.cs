using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Services.Contracts;

public interface IOrdersService
{
    Task<IEnumerable<Order>> GetAllOrdersByUserIDAsync(int userid);
    Task<Order> GetByIdAsync(int id);
    Task AddAsync(Order entity);
    Task UpdateAsync(Order entity);
    Task DeleteByIdAsync(int id);
    Task SaveChangesAsync();
}