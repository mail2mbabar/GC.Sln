using DBmodels.Models;

namespace Infrastructure.Repository.Interfaces
{
        public interface ICriterionRepository
        {
            Task<Criterion> GetCriterionByIdAsync(long criterionId);
            Task<List<Criterion>> GetAllCriterionAsync();
            Task AddCriterionAsync(Criterion criterion);
            Task UpdateCriterionAsync(Criterion criterion);
            Task DeleteCriterionAsync(long criterionId);
        }
    }