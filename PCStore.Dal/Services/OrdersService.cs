using Microsoft.EntityFrameworkCore;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;
using PCStore.Infrastructure.Exceptions;
using PCStore.Infrastructure.PCStoreDataBaseContext;

namespace PCStore.Infrastructure.Services;

public class OrdersService : GenericService<Order>, IOrdersService
{
    public OrdersService(PcstoreContext databaseContext)
        : base(databaseContext)
    {
    }
    public async Task<IEnumerable<Order>> GetAllOrdersByUserIDAsync(int userid)
    {
        return await databaseContext.Orders.Where(v => v.UserId == userid).ToListAsync()
            ?? throw new Exception($"Couldn't retrieve entities Orders");
    }
    public override async Task<Order> GetCompleteEntityAsync(int id)
    {
        var my_event = await table.Include(ev => ev.UserId)
                                 .Include(ev => ev.StatusId)
                                 .SingleOrDefaultAsync(ev => ev.OrderId == id);
        return my_event ?? throw new EntityNotFoundException("NOT FOUND");
    }
    public async Task SaveChangesAsync()
    {
        await databaseContext.SaveChangesAsync();
    }
}
