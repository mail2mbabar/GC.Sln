using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Managers.Interfaces
{
    public interface ICommentService
    {
        Task<CommentEntity> GetCommentByIdAsync(Guid id);
        Task<IEnumerable<CommentEntity>> GetAllCommentsAsync();
        Task<CommentEntity> AddCommentAsync(CommentEntity comment);
        Task UpdateCommentAsync(CommentEntity comment);
        Task DeleteCommentAsync(Guid id);
    }
}
