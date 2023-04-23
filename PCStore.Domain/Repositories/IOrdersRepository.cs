using PCStore.Domain.PCStoreEntities;

namespace PCStore.Domain.Repositories;

public interface IOrdersRepository : IGenericRepository<Order>
{
    Task<IEnumerable<Order>> GetAllOrdersByUserIDAsync(int userid);
    Task SaveChangesAsync();
}