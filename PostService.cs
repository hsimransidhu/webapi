using System.Collections.Generic;
using System.Threading.Tasks;
using webapi.Models;
using webapi.Repositories.Interfaces;
using webapi.Services.Interfaces;
using webapi.Dtos;
using AutoMapper;

namespace webapi.Services
{

    // Constructor Injection: IPostRepository is injected via constructor
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        // Methods implement the contract defined in IPostService
        public async Task<IEnumerable<PostReadDto>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllPostsAsync();
            return _mapper.Map<IEnumerable<PostReadDto>>(posts);
        }

        public async Task<PostReadDto> GetPostByIdAsync(int id)
        {
            var post = await _postRepository.GetPostByIdAsync(id);
            if (post == null) return null;
            return _mapper.Map<PostReadDto>(post);
        }

        public async Task<PostReadDto> CreatePostAsync(PostCreateDto postCreateDto)
        {
            var post = _mapper.Map<Post>(postCreateDto);
            await _postRepository.AddPostAsync(post);
            // After adding the post to the DB, it should have an ID assigned (assuming auto-increment ID)
            return _mapper.Map<PostReadDto>(post);
        }

        public async Task<PostReadDto> UpdatePostAsync(int id, PostUpdateDto postUpdateDto)
        {
            // First, get the existing post from the repository
            var existingPost = await _postRepository.GetPostByIdAsync(id);
            if (existingPost == null)
            {
                // Handle not found situation, possibly return null or throw
                return null;
            }

            // Map the update DTO onto the retrieved post entity
            _mapper.Map(postUpdateDto, existingPost);

            // Save changes
            await _postRepository.UpdatePostAsync(existingPost);

            // Return the updated post
            return _mapper.Map<PostReadDto>(existingPost);
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            // Attempt to retrieve the post by ID
            var post = await _postRepository.GetPostByIdAsync(id);
            if (post == null)
            {
                // Return false or handle the case where the post does not exist
                return false;
            }

            // If the post exists, delete it using the repository
            await _postRepository.DeletePostAsync(post);

            // Return true to indicate successful deletion
            return true;
        }
    }
}
