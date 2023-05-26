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
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> _logger;
        private IStatusesService statusesservice;
        public StatusController(ILogger<StatusController> logger,
            IStatusesService unitOfWork)
        {
            _logger = logger;
            statusesservice = unitOfWork;
        }

        //GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetAllStatusesAsync()
        {
            try
            {
                var results = await statusesservice.GetAllAsync();
                _logger.LogInformation($"Отримали всі Statuses з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllStatusesAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
    }
}
