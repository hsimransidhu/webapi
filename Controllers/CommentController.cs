using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Dtos;
using webapi.Services.Interfaces;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: api/comment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentReadDto>>> GetAllComments()
        {
            var comments = await _commentService.GetAllCommentsAsync();
            return Ok(comments);
        }

        // GET: api/comment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentReadDto>> GetCommentById(int id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        // POST: api/comment
        [HttpPost]
        public async Task<ActionResult<CommentReadDto>> CreateComment(CommentCreateDto commentCreateDto)
        {
            var createdComment = await _commentService.CreateCommentAsync(commentCreateDto);
            return CreatedAtAction(nameof(GetCommentById), new { id = createdComment.CommentId }, createdComment);
        }

        // PUT: api/comment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, CommentUpdateDto commentUpdateDto)
        {
            var result = await _commentService.UpdateCommentAsync(id, commentUpdateDto);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/comment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var result = await _commentService.DeleteCommentAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
