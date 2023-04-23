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
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository ordersRepository;
        public OrdersService(IOrdersRepository repository)
        {
            this.ordersRepository = repository;
        }
        public Task AddAsync(Order entity)
        {
            ordersRepository.AddAsync(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await ordersRepository.GetByIdAsync(id);
            if (entity != null)
            {
                await ordersRepository.DeleteAsync(entity);
                await ordersRepository.SaveChangesAsync();
            }
        }
        public Task<IEnumerable<Order>> GetAllOrdersByUserIDAsync(int userid)
        {
            return ordersRepository.GetAllOrdersByUserIDAsync(userid);
        }

        public Task<Order> GetByIdAsync(int id)
        {
            return ordersRepository.GetByIdAsync(id);
        }

        public Task SaveChangesAsync()
        {
            ordersRepository.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Order entity)
        {
            ordersRepository.UpdateAsync(entity);
            return Task.CompletedTask;
        }
    }
}
