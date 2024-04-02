using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Dtos; 
using webapi.Services.Interfaces;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: api/post
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostReadDto>>> GetAllPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

        // GET: api/post/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostReadDto>> GetPostById(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        // POST: api/post
        [HttpPost]
        public async Task<ActionResult<PostReadDto>> CreatePost(PostCreateDto postCreateDto)
        {
            var createdPost = await _postService.CreatePostAsync(postCreateDto);
            return CreatedAtAction(nameof(GetPostById), new { id = createdPost.PostId }, createdPost);
        }

        // PUT: api/post/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, PostUpdateDto postUpdateDto)
        {
            var result = await _postService.UpdatePostAsync(id, postUpdateDto);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/post/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var result = await _postService.DeletePostAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
