using DBmodels.Models;
using InfraStructuree.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
            private readonly ICommentRepository _commentRepository;

            public CommentController(ICommentRepository commentRepository)
            {
                _commentRepository = commentRepository;
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Comment>> GetComment(int id)
            {
                var comment = await _commentRepository.GetCommentByIdAsync(id);

                if (comment == null)
                {
                    return NotFound();
                }

                return comment;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
            {
                var comments = await _commentRepository.GetAllCommentsAsync();
                return comments;
            }

            [HttpPost]
            public async Task<ActionResult<Comment>> PostComment(Comment comment)
            {
                await _commentRepository.AddCommentAsync(comment);
                return CreatedAtAction(nameof(GetComment), new { id = comment.CommentId }, comment);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutComment(int id, Comment comment)
            {
                if (id != comment.CommentId)
                {
                    return BadRequest();
                }

                await _commentRepository.UpdateCommentAsync(comment);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteComment(int id)
            {
                await _commentRepository.DeleteCommentAsync(id);
                return NoContent();
            }
        
    }
}
