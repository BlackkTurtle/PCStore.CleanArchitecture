using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly ILogger<TypesController> _logger;
        private ITypesService typesservice;
        public TypesController(ILogger<TypesController> logger,
            ITypesService unitOfWork)
        {
            _logger = logger;
            typesservice = unitOfWork;
        }

        //GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Types>>> GetAllTypesAsync()
        {
            try
            {
                var results = await typesservice.GetAllAsync();
                _logger.LogInformation($"Отримали всі івенти з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllEventsAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
    }
}
