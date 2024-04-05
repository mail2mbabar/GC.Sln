using DBmodels.Configuration;
using DBmodels.Models;
using InfraStructuree.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InfraStructuree.Repository.Implementations
{
      public class ConstraintRepository : IConstraintRepository
        {
            private readonly GcContext _context;

            public ConstraintRepository(GcContext context)
            {
                _context = context;
            }

            public async Task<Constraint> GetConstraintByIdAsync(int constraintId)
            {
                return await _context.Constraints.FindAsync(constraintId);
            }

            public async Task<List<Constraint>> GetAllConstraintsAsync()
            {
                return await _context.Constraints.ToListAsync();
            }

            public async Task AddConstraintAsync(Constraint constraint)
            {
                _context.Constraints.Add(constraint);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateConstraintAsync(Constraint constraint)
            {
                _context.Entry(constraint).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task DeleteConstraintAsync(int constraintId)
            {
                var constraint = await _context.Constraints.FindAsync(constraintId);
                if (constraint != null)
                {
                    _context.Constraints.Remove(constraint);
                    await _context.SaveChangesAsync();
                }
            }
      }
}
