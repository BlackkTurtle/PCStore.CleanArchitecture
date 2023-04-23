using Microsoft.EntityFrameworkCore;
using PCStore.Domain.PCStoreEntities;
using PCStore.Domain.Repositories;
using PCStore.Infrastructure.PCStoreDataBaseContext;

namespace PCStore.Infrastructure.Repositories;

public class UsersRepository : GenericRepository<User>, IUsersRepository
{
    public UsersRepository(PcstoreContext databaseContext)
        : base(databaseContext)
    {
    }

    public async Task<User> GetUserByEmailAsync(string Email)
    {
        return await databaseContext.Users.SingleOrDefaultAsync(v => v.Email == Email)
            ?? throw new Exception($"Couldn't retrieve entities Users");
    }

    public async Task<User> GetUserByPhoneAsync(string Phone)
    {
        return await databaseContext.Users.SingleOrDefaultAsync(v => v.Phone == Phone)
            ?? throw new Exception($"Couldn't retrieve entities Users");
    }

    public override Task<User> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
       databaseContext.SaveChanges();
        return Task.CompletedTask;
    }
}

