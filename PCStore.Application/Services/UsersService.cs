using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCStore.Application.Services.Contracts;
using PCStore.Domain.PCStoreEntities;
using PCStore.Domain.Repositories;

namespace PCStore.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;
        public UsersService(IUsersRepository repository)
        {
            this.usersRepository = repository;
        }
        public Task AddAsync(User entity)
        {
            usersRepository.AddAsync(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await usersRepository.GetByIdAsync(id);
            if (entity != null)
            {
                await usersRepository.DeleteAsync(entity);
                await usersRepository.SaveChangesAsync();
            }
        }


        public Task<User> GetUserByEmailAsync(string Email)
        {
            return usersRepository.GetUserByEmailAsync(Email);
        }

        public Task<User> GetUserByPhoneAsync(string Phone)
        {
            return usersRepository.GetUserByPhoneAsync(Phone);
        }

        public Task SaveChangesAsync()
        {
            usersRepository.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task UpdateAsync(User entity)
        {
            usersRepository.UpdateAsync(entity);
            return Task.CompletedTask;
        }

        Task<User> IUsersService.GetByIdAsync(int id)
        {
            return usersRepository.GetByIdAsync(id);
        }
    }
}
