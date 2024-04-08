using DBmodels.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface ICriterionRepository
    {
        Task<Criterion> GetCriterionByIdAsync(int criterionId);
        Task<List<Criterion>> GetAllCriterionsAsync();
        Task AddCriterionAsync(Criterion criterion);
        Task UpdateCriterionAsync(Criterion criterion);
        Task DeleteCriterionAsync(int criterionId);
    }
}
