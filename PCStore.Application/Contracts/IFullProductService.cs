using PCStore.Application.DTOs;

namespace PCStore.Application.Contracts;

public interface IFullProductService
{
    public Task<FullProductDTO> GetCompleteFullProductAsync(int article);
}