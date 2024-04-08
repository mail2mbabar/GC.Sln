using DBmodels.Configuration;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;


namespace Infrastructure.Repository.Implementations
{
    public class ConstraintRepository : GenericRepository<Constraint>, IConstraintRepository
    {
        private readonly GcContext _context;

        public ConstraintRepository(GcContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Constraint> GetConstraintByIdAsync(int constraintId)
        {
            return await this.GetById(constraintId);
        }

        public async Task<List<Constraint>> GetAllConstraintsAsync()
        {
            return await this.ToListAsync();
        }

        public async Task AddConstraintAsync(Constraint constraint)
        {
            await this.Insert(constraint);
        }

        public async Task UpdateConstraintAsync(Constraint constraint)
        {
            await this.Update(constraint);
        }

        public async Task DeleteConstraintAsync(int constraintId)
        {
            var constraint = await _context.Constraints.FindAsync(constraintId);
            if (constraint != null)
            {
                await this.Delete(constraint);
            }
        }
    }
}
