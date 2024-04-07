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
    public class CommentRepository : ICommentRepository
    {
        private readonly GcContext _context;

        public CommentRepository(GcContext context)
        {
            _context = context;
        }
        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            return await _context.Comments.FindAsync(commentId);
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task AddCommentAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
