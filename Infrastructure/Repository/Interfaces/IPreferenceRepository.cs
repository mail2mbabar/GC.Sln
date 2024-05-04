using DBmodels.Models;


namespace Infrastructure.Repository.Interfaces
{
    public interface IPreferenceRepository
    {
        Task<Preference> GetPreferenceByIdAsync(long preferenceId);
        Task<List<Preference>> GetAllPreferencesAsync();
        Task AddPreferenceAsync(Preference preference);
        Task UpdatePreferenceAsync(Preference preference);
        Task DeletePreferenceAsync(long preferenceId);
    }
}
