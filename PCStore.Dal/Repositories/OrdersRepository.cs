using Microsoft.EntityFrameworkCore;
using PCStore.Domain.PCStoreEntities;
using PCStore.Domain.Repositories;
using PCStore.Infrastructure.Exceptions;
using PCStore.Infrastructure.PCStoreDataBaseContext;

namespace PCStore.Infrastructure.Repositories;

public class OrdersRepository : GenericRepository<Order>, IOrdersRepository
{
    public OrdersRepository(PcstoreContext databaseContext)
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

    public Task SaveChangesAsync()
    {
        databaseContext.SaveChangesAsync();
        return Task.CompletedTask;
    }
}
