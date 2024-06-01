﻿using Services.Entities;

namespace Services.Managers.Interfaces
{
    public interface ICriterionService
    {
        Task<CriterionEntity> GetCriterionByIdAsync(long criterionId);
        Task<IEnumerable<CriterionEntity>> GetAllCriterionAsync();
        Task<CriterionEntity> AddCriterionAsync(CriterionEntity criterion);
        Task<CriterionEntity> UpdateCriterionAsync(CriterionEntity criterion);
        Task DeleteCriterionAsync(long criterionId);
    }
}
