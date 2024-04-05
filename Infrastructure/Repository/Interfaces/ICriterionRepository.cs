using DBmodels.Models;

namespace InfraStructuree.Repository.Interfaces
{
    public interface ICriterionRepository
    {
        Task<Criterion> GetCriterionByIdAsync(int criterionId);
        Task<List<Criterion>> GetAllCriteriaAsync();
        Task AddCriterionAsync(Criterion criterion);
        Task UpdateCriterionAsync(Criterion criterion);
        Task DeleteCriterionAsync(int criterionId);
    }
}
