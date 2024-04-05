

using DBmodels.Models;

namespace InfraStructuree.Repository.Interfaces
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