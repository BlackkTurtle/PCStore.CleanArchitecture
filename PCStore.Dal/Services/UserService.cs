using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;
using PCStore.Infrastructure.DbSettings;

namespace PCStore.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;
        public UserService(IUsersDbSettings usersDbSettings,IMongoClient mongoClient)
        {
            var database=mongoClient.GetDatabase(usersDbSettings.DatabaseName);
            _users = database.GetCollection<User>(usersDbSettings.UsersCollectionName);
        }
        public async Task<User> Create(User user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _users.Find(u => u.Email == email).SingleOrDefaultAsync();
        }

        public async Task<User> GetById(string id)
        {
            return await _users.Find(u => u.UserId == id).SingleOrDefaultAsync();
        }

        public async Task<User> GetByPhone(string phone)
        {
            return await _users.Find(u => u.Phone == phone).SingleOrDefaultAsync();
        }

        public async Task<User> GetByUserName(string userName)
        {
            return await _users.Find(u => u.UserName == userName).SingleOrDefaultAsync();
        }

        public async Task<User> GetByUserNameAndPassword(string UserName, string Password)
        {
            return await _users.Find(u=>u.UserName== UserName && u.Password == Password).SingleOrDefaultAsync();
        }

        public async Task Remove(string id)
        {
            await _users.DeleteOneAsync(u => u.UserId == id);
        }

        public async Task Update(string id, User user)
        {
            await _users.ReplaceOneAsync(u=>u.UserId==id,user);
        }
    }
}
