using PCStore.Domain.PCStoreEntities;

namespace PCStore.Domain.Repositories;

public interface IUsersRepository : IGenericRepository<User>
{
    Task<User> GetUserByEmailAsync(string Email);
    Task<User> GetUserByPhoneAsync(string Email);
    Task SaveChangesAsync();
}