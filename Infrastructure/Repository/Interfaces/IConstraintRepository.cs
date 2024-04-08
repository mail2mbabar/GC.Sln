

using DBmodels.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IConstraintRepository
    {
        Task<Constraint> GetConstraintByIdAsync(int constraintId);
        Task<List<Constraint>> GetAllConstraintsAsync();
        Task AddConstraintAsync(Constraint constraint);
        Task UpdateConstraintAsync(Constraint constraint);
        Task DeleteConstraintAsync(int constraintId);

    }
}