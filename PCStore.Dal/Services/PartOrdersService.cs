using Microsoft.EntityFrameworkCore;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;
using PCStore.Infrastructure.Exceptions;
using PCStore.Infrastructure.PCStoreDataBaseContext;

namespace PCStore.Infrastructure.Services;

public class PartOrdersService : GenericService<PartOrder>, IPartOrdersService
{
    public PartOrdersService(PcstoreContext databaseContext)
        : base(databaseContext)
    {
    }
    public async Task<IEnumerable<PartOrder>> GetAllPartOrdersByOrderIDAsync(int orderid)
    {
        return await databaseContext.PartOrders.Where(v => v.OrderId == orderid).ToListAsync()
            ?? throw new Exception($"Couldn't retrieve entities PartOrders");
    }
    public override async Task<PartOrder> GetCompleteEntityAsync(int id)
    {
        var my_event = await table.Include(ev => ev.Article)
                                 .Include(ev => ev.OrderId)
                                 .SingleOrDefaultAsync(ev => ev.PorderId == id);
        return my_event ?? throw new EntityNotFoundException("NOT FOUND");
    }
    public async Task SaveChangesAsync()
    {
        await databaseContext.SaveChangesAsync();
    }
}
