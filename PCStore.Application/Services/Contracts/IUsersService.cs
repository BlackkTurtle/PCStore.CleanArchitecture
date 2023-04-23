using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Services.Contracts;

public interface IUsersService
{
    Task<User> GetUserByEmailAsync(string Email);
    Task<User> GetUserByPhoneAsync(string Phone);
    Task<User> GetByIdAsync(int id);
    Task AddAsync(User entity);
    Task UpdateAsync(User entity);
    Task DeleteByIdAsync(int id);
    Task SaveChangesAsync();
}