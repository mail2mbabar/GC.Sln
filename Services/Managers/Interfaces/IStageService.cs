using Services.Entities;

namespace Services.Managers.Interfaces
{
    public interface IStageService
    {
        Task<StageEntity> GetStageByIdAsync(long id);
        Task<IEnumerable<StageEntity>> GetAllStagesAsync();
        Task AddStageAsync(StageEntity stage);
        Task UpdateStageAsync(StageEntity stage);
        Task DeleteStageAsync(long id);
    }
}
