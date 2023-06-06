using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PCStore.Application.Comments.Commands;
using PCStore.Application.Comments.Queries;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CommentController> _logger;
        private readonly IMediator mediator;

        public CommentController(ILogger<CommentController> logger,
            IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        [HttpGet("{article}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetAllCommentsByProductArticleAsync(int article)
        {
            try
            {
                var result = await mediator.Send(new GetAllCommentsByArticleQuery(article));
                if (result == null)
                {
                    _logger.LogInformation($"Comment із article: {article}, не був знайдейний у базі даних");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Отримали comments з бази даних!");
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllCommentsByProductArticleAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
        [HttpPost]
        public async Task<ActionResult> PostCommentAsync([FromBody] Comment fullcomment)
        {
            try
            {
                if (fullcomment == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт comment є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт comment є некоректним");
                }
                var comment = new Comment()
                {
                    Article=fullcomment.Article,
                    Stars=fullcomment.Stars,
                    UserId=fullcomment.UserId,
                    CommentDate = DateTime.Now,
                    Comment1 =fullcomment.Comment1
                };
                await mediator.Send(new PostCommentCommand(comment));
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі PostCommentAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCommentAsync(int id, [FromBody] Comment updatedComment)
        {
            try
            {
                if (updatedComment == null)
                {
                    _logger.LogInformation($"Empty JSON received from the client");
                    return BadRequest("Comment object is null");
                }

                await mediator.Send(new UpdateCommentCommand(id,updatedComment));
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
        public async Task<ActionResult> DeleteCommentByIdAsync(int id)
        {
            try
            {
                await mediator.Send(new DeleteCommentCommand(id));
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
