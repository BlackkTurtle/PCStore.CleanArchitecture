using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Contracts;

public interface IOrdersService : IGenericService<Order>
{
    Task SaveChangesAsync();
    Task<IEnumerable<Order>> GetAllOrdersByUserIDAsync(int userid);
}