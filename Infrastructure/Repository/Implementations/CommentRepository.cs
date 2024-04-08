using DBmodels.Configuration;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Implementations
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly GcContext _context;

        public CommentRepository(GcContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            return await this.GetById(commentId);
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await this.ToListAsync();
        }

        public async Task AddCommentAsync(Comment comment)
        {
            await this.Insert(comment);
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            await this.Update(comment);
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment != null)
            {
                await this.Delete(comment);
            }
        }
    }
}
