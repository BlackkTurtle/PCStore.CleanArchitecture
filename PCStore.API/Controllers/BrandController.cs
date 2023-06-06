using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PCStore.Application.Brands.Queries;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly ILogger<BrandController> _logger;
        private readonly IMediator mediator;

        public BrandController(ILogger<BrandController> logger,
            IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        //GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAllBrandsAsync()
        {
            try
            {
                var results = await mediator.Send(new GetAllBrandQuery());
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
