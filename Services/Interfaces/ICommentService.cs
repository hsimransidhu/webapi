using System.Threading.Tasks;
using webapi.Dtos; 

namespace webapi.Services.Interfaces
{
    public interface ICommentService
    {
        Task<CommentReadDto> GetCommentByIdAsync(int id);
        Task<IEnumerable<CommentReadDto>> GetAllCommentsAsync();
        Task<CommentReadDto> CreateCommentAsync(CommentCreateDto commentCreateDto);
        Task<CommentReadDto> UpdateCommentAsync(int id, CommentUpdateDto commentUpdateDto);
        Task<bool> DeleteCommentAsync(int id);
    }
}
