using Microsoft.AspNetCore.Mvc;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private IOrdersService service;
        public OrdersController(ILogger<OrdersController> logger,
            IOrdersService ado_unitofwork)
        {
            _logger = logger;
            service = ado_unitofwork;
        }
        //GET: api/events
        [HttpGet("UserID/{userid}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrdersByUserAsync(int userid)
        {
            try
            {
                var results = await service.GetAllOrdersByUserIDAsync(userid);
                _logger.LogInformation($"Отримали всі Orders з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllOrdersByUserAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        //GET: api/events/Id
        [HttpGet("id/{id}")]
        public async Task<ActionResult<Order>> GetOrderByIdAsync(int id)
        {
            try
            {
                var result = await service.GetByIdAsync(id);
                if (result == null)
                {
                    _logger.LogInformation($"Order із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Отримали order з бази даних!");
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetOrderByIdAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        //POST: api/events
        [HttpPost]
        public async Task<ActionResult> PostOrderAsync([FromBody] Order fullorder)
        {
            try
            {
                if (fullorder == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт comment є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт comment є некоректним");
                }
                var comment = new Order()
                {
                    OrderDate=DateTime.Now,
                    Adress=fullorder.Adress,
                    UserId=fullorder.UserId,
                    StatusId=fullorder.StatusId
                };
                await service.AddAsync(comment);
                await service.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі PostCommentAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        //POST: api/events/id
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrderAsync(int id, [FromBody] Order updatedOrder)
        {
            try
            {
                if (updatedOrder == null)
                {
                    _logger.LogInformation($"Empty JSON received from the client");
                    return BadRequest("Comment object is null");
                }

                var OrderEntity = await service.GetByIdAsync(id);
                if (OrderEntity == null)
                {
                    _logger.LogInformation($"Order with ID: {id} was not found in the database");
                    return NotFound();
                }

                // Update only the specific properties of the comment entity
                OrderEntity.StatusId = updatedOrder.StatusId;
                OrderEntity.Adress = updatedOrder.Adress;
                OrderEntity.UserId = updatedOrder.UserId;

                await service.SaveChangesAsync();
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Transaction failed! Something went wrong in UpdateCommentAsync() method - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error occurred.");
            }
        }

        //GET: api/events/Id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrderByIdAsync(int id)
        {
            try
            {
                await service.DeleteByIdAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі DeleteCommentByIdAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
    }
}
