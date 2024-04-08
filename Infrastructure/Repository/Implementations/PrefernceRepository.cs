using DBmodels.Configuration;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;


namespace Infrastructure.Repository.Implementations
{
    public class PreferenceRepository : GenericRepository<Preference>, IPreferenceRepository
    {
        private readonly GcContext _context;

        public PreferenceRepository(GcContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Preference> GetPreferenceByIdAsync(int preferenceId)
        {
            return await this.GetById(preferenceId);
        }

        public async Task<List<Preference>> GetAllPreferencesAsync()
        {
            return await this.ToListAsync();
        }

        public async Task AddPreferenceAsync(Preference preference)
        {
            await this.Insert(preference);
        }

        public async Task UpdatePreferenceAsync(Preference preference)
        {
            await this.Update(preference);
        }

        public async Task DeletePreferenceAsync(int preferenceId)
        {
            var preference = await _context.Preferences.FindAsync(preferenceId);
            if (preference != null)
            {
                await this.Delete(preference);
            }
        }
    }
}
