using Services.Entities;
namespace Services.Managers.Interfaces
{
    public interface IThresholdService
    {
        Task<ThresholdEntity> GetThresholdByIdAsync(long id);
        Task<IEnumerable<ThresholdEntity>> GetAllThresholdsAsync();
        Task AddThresholdAsync(ThresholdEntity threshold);
        Task UpdateThresholdAsync(ThresholdEntity threshold);
        Task DeleteThresholdAsync(long id);
    }
}
