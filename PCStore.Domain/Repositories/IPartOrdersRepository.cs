using PCStore.Domain.PCStoreEntities;

namespace PCStore.Domain.Repositories;

public interface IPartOrdersRepository : IGenericRepository<PartOrder>
{
    Task<IEnumerable<PartOrder>> GetAllPartOrdersByOrderIDAsync(int orderid);
    Task SaveChangesAsync();
}