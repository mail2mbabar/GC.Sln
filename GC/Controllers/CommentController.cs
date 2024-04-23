using Microsoft.AspNetCore.Mvc;
using Services.Entities;
using Services.Managers.Interfaces;

namespace GC.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService, ILogger<CommentController> logger)
        {
            _commentService = commentService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentEntity>> GetComment(Guid id)
        {
            try
            {
                var comment = await _commentService.GetCommentByIdAsync(id);
                if (comment == null)
                {
                    return NotFound();
                }
                return comment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting the Comment with ID: {id}");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentEntity>>> GetComments()
        {
            try
            {
                var comments = await _commentService.GetAllCommentsAsync();
                return Ok(comments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all Comments");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CommentEntity>> AddComment(CommentEntity comment)
        {
            try
            {
                var addedComment = await _commentService.AddCommentAsync(comment);
                return CreatedAtAction(nameof(GetComment), new { id = addedComment.CommentId }, addedComment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a Comment");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(Guid id, CommentEntity comment)
        {
            try
            {
                if (id != comment.CommentId)
                {
                    return BadRequest();
                }
                await _commentService.UpdateCommentAsync(comment);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the Comment with ID: {id}");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            try
            {
                await _commentService.DeleteCommentAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting the Comment with ID: {id}");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }
    }

}
