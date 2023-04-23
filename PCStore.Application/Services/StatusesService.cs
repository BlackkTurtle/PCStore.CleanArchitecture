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
    public class StatusesService : IStatusesService
    {
        private readonly IStatusesRepository statusesRepository;
        public StatusesService(IStatusesRepository repository)
        {
            this.statusesRepository = repository;
        }
        public Task<IEnumerable<Status>> GetAllAsync()
        {
            return statusesRepository.GetAllAsync();
        }
    }
}
