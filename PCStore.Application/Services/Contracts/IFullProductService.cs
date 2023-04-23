using PCStore.Domain.PCStoreEntities;
using PCStore.Domain.Repositories;
using PCStore.Application.DTOs;

namespace PCStore.Application.Services.Contracts;

public interface IFullProductService
{
    public Task<FullProductDTO> GetCompleteFullProductAsync(int article);
}