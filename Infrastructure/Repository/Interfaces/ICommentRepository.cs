using DBmodels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task<List<Comment>> GetAllCommentsAsync();
        Task AddCommentAsync(Comment comment);
        Task UpdateCommentAsync(Comment comment);
        Task DeleteCommentAsync(int commentId);
    }
}
