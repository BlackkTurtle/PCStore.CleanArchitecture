using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Contracts;

public interface IPartOrdersService : IGenericService<PartOrder>
{
    Task SaveChangesAsync();
    Task<IEnumerable<PartOrder>> GetAllPartOrdersByOrderIDAsync(int orderid);
}