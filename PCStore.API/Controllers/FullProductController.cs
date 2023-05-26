using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PCStore.Application.Contracts;
using PCStore.Application.DTOs;

namespace PCStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FullProductController : ControllerBase
    {
        private readonly ILogger<TypesController> _logger;
        private IFullProductService fullproductsservice;
        public FullProductController(ILogger<TypesController> logger,
            IFullProductService service)
        {
            _logger = logger;
            this.fullproductsservice = service;
        }

        //GET: api/events
        [HttpGet("{article}")]
        public async Task<ActionResult<FullProductDTO>> GetFullProductByArticleAsync(int article)
        {
            try
            {
                var results = await fullproductsservice.GetCompleteFullProductAsync(article);
                _logger.LogInformation($"Отримали fullProduct з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetFullProductByArticleAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
    }
}
