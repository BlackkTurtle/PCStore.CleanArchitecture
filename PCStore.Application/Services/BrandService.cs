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
    public class BrandService : IBrandsService
    {
        private readonly IBrandsRepository brandsRepository;
        public BrandService(IBrandsRepository brandsRepository)
        {
            this.brandsRepository = brandsRepository;
        }

        public Task<IEnumerable<Brand>> GetAllAsync()
        {
            return brandsRepository.GetAllAsync();
        }
    }
}
