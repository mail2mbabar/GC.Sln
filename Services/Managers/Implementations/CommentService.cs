using AutoMapper;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Services.Entities;
using Services.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Managers.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CommentEntity> GetCommentByIdAsync(Guid id)
        {
            var dbComment = await _commentRepository.GetCommentByIdAsync(id);
            return _mapper.Map<CommentEntity>(dbComment);
        }

        public async Task<IEnumerable<CommentEntity>> GetAllCommentsAsync()
        {
            var dbComments = await _commentRepository.GetAllCommentsAsync();
            return _mapper.Map<IEnumerable<CommentEntity>>(dbComments);
        }

        public async Task<CommentEntity> AddCommentAsync(CommentEntity comment)
        {
            var dbComment = _mapper.Map<Comment>(comment);
            await _commentRepository.AddCommentAsync(dbComment);
            return comment;
        }

        public async Task UpdateCommentAsync(CommentEntity comment)
        {
            var dbComment = _mapper.Map<Comment>(comment);
            await _commentRepository.UpdateCommentAsync(dbComment);
        }

        public async Task DeleteCommentAsync(Guid id)
        {
            await _commentRepository.DeleteCommentAsync(id);
        }
    }

}

