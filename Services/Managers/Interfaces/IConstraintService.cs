using Services.Entities;

namespace Services.Managers.Interfaces
{
    public interface IConstraintService
    {
        Task<ConstraintEntity> GetConstraintByIdAsync(long id);
        Task<IEnumerable<ConstraintEntity>> GetAllConstraintsAsync();
        Task<ConstraintEntity> AddConstraintAsync(ConstraintEntity constraint);
        Task UpdateConstraintAsync(ConstraintEntity constraint);
        Task DeleteConstraintAsync(long id);
    }
}
