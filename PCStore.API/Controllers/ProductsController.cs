using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PCStore.Application.Services.Contracts;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private IProductsService productsservice;
        public ProductsController(ILogger<ProductsController> logger,
            IProductsService unitOfWork)
        {
            _logger = logger;
            productsservice = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsAsync()
        {
            try
            {
                var results = await productsservice.GetAllAsync();
                _logger.LogInformation($"Отримали всі Products з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllProductsAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
        [HttpGet("BrandID")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByBrandIDAsync(int id)
        {
            try
            {
                var results = await productsservice.GetProductsByBrandAsync(id);
                _logger.LogInformation($"Отримали всі Products з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllProductsByBrandAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
        [HttpGet("TypeID")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByTypeIDAsync(int id)
        {
            try
            {
                var results = await productsservice.GetProductsByTypeAsync(id);
                _logger.LogInformation($"Отримали всі Products з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetProductsByTypeIDAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
        [HttpGet("NameLike")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByNAMELikeAsync(string namelike)
        {
            try
            {
                var results = await productsservice.GetProductsByNameLikeAsync(namelike);
                _logger.LogInformation($"Отримали всі Products з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetProductsByNAMELikeAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
    }
}
