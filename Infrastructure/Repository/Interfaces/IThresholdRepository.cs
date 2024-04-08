using DBmodels.Models;


namespace Infrastructure.Repository.Interfaces
{
    public interface IThresholdRepository
    {
        Task<Threshold> GetThresholdByIdAsync(int thresholdId);
        Task<List<Threshold>> GetAllThresholdsAsync();
        Task AddThresholdAsync(Threshold threshold);
        Task UpdateThresholdAsync(Threshold threshold);
        Task DeleteThresholdAsync(int thresholdId);
    }
}
