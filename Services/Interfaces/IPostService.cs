using System.Collections.Generic;
using System.Threading.Tasks;
using webapi.Dtos; 

namespace webapi.Services.Interfaces
{
    public interface IPostService
    {
        Task<PostReadDto> GetPostByIdAsync(int id);
        Task<IEnumerable<PostReadDto>> GetAllPostsAsync();
        Task<PostReadDto> CreatePostAsync(PostCreateDto postCreateDto);
        Task<PostReadDto> UpdatePostAsync(int id, PostUpdateDto postUpdateDto);
        Task<bool> DeletePostAsync(int id);
    }
}
