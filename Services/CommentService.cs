using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using webapi.Dtos;
using webapi.Models; 
using webapi.Repositories.Interfaces; 
using webapi.Services.Interfaces;

namespace webapi.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CommentReadDto>> GetAllCommentsAsync()
        {
            var comments = await _commentRepository.GetAllCommentsAsync();
            return _mapper.Map<IEnumerable<CommentReadDto>>(comments);
        }

        public async Task<CommentReadDto> GetCommentByIdAsync(int id)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id);
            if (comment == null) return null;
            return _mapper.Map<CommentReadDto>(comment);
        }

        public async Task<CommentReadDto> CreateCommentAsync(CommentCreateDto commentCreateDto)
        {
            var comment = _mapper.Map<Comment>(commentCreateDto);
            await _commentRepository.AddCommentAsync(comment);
            return _mapper.Map<CommentReadDto>(comment);
        }

        public async Task<CommentReadDto> UpdateCommentAsync(int id, CommentUpdateDto commentUpdateDto)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id);
            if (comment == null)
            {
                throw new KeyNotFoundException("Comment not found");
            }

            // Map the updated fields from the DTO to the existing entity
            _mapper.Map(commentUpdateDto, comment);
            await _commentRepository.UpdateCommentAsync(comment);

            return _mapper.Map<CommentReadDto>(comment);
        }

        public async Task<bool> DeleteCommentAsync(int id)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return false;
            }

            await _commentRepository.DeleteCommentAsync(comment);
            return true;
        }
    }
}
