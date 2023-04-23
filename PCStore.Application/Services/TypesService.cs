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
    public class TypesService : ITypesService
    {
        private readonly ITypesRepository typesRepository;
        public TypesService(ITypesRepository repository)
        {
            this.typesRepository = repository;
        }
        public Task<IEnumerable<Types>> GetAllAsync()
        {
            return typesRepository.GetAllAsync();
        }
    }
}
