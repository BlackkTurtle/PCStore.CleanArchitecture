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
    public class PartOrdersService : IPartOrdersService
    {
        private readonly IPartOrdersRepository partordersRepository;
        public PartOrdersService(IPartOrdersRepository repository)
        {
            this.partordersRepository = repository;
        }
        public Task AddAsync(PartOrder entity)
        {
            partordersRepository.AddAsync(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await partordersRepository.GetByIdAsync(id);
            if (entity != null)
            {
                await partordersRepository.DeleteAsync(entity);
                await partordersRepository.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<PartOrder>> GetAllPartOrdersByOrderIDAsync(int orderid)
        {
            return partordersRepository.GetAllPartOrdersByOrderIDAsync(orderid);
        }

        public Task<PartOrder> GetByIdAsync(int id)
        {
            return partordersRepository.GetByIdAsync(id);
        }

        public Task SaveChangesAsync()
        {
            partordersRepository.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task UpdateAsync(PartOrder entity)
        {
            partordersRepository.UpdateAsync(entity);
            return Task.CompletedTask;
        }
    }
}
