using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PCStore.Application.Services.Contracts;
using PCStore.Domain.PCStoreEntities;
using PCStore.Domain.Repositories;

namespace PCStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly ILogger<BrandController> _logger;
        private IBrandsService brandsservice;
        public BrandController(ILogger<BrandController> logger,
            IBrandsService service)
        {
            _logger = logger;
            brandsservice = service;
        }

        //GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAllBrandsAsync()
        {
            try
            {
                var results = await brandsservice.GetAllAsync();
                _logger.LogInformation($"Отримали всі Brands з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllBrandsAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
    }
}
