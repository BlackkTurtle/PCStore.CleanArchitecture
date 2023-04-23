using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Services.Contracts;

public interface IPartOrdersService
{
    Task<IEnumerable<PartOrder>> GetAllPartOrdersByOrderIDAsync(int orderid);
    Task<PartOrder> GetByIdAsync(int id);
    Task AddAsync(PartOrder entity);
    Task UpdateAsync(PartOrder entity);
    Task DeleteByIdAsync(int id);
    Task SaveChangesAsync();
}