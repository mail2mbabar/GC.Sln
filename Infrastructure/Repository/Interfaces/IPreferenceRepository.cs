using DBmodels.Models;


namespace InfraStructuree.Repository.Interfaces
{
    public interface IPreferenceRepository
    {
        Task<Preference> GetPreferenceByIdAsync(int preferenceId);
        Task<List<Preference>> GetAllPreferencesAsync();
        Task AddPreferenceAsync(Preference preference);
        Task UpdatePreferenceAsync(Preference preference);
        Task DeletePreferenceAsync(int preferenceId);
    }
}
