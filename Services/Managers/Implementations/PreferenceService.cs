using AutoMapper;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Services.Entities;
using Services.Managers.Interfaces;


namespace Services.Managers.Implementations
{
    public class PreferenceService : IPreferenceService
    {
        private readonly IPreferenceRepository _preferenceRepository;
        private readonly IMapper _mapper;

        public PreferenceService(IPreferenceRepository preferenceRepository, IMapper mapper)
        {
            _preferenceRepository = preferenceRepository;
            _mapper = mapper;
        }

        public async Task<PreferenceEntity> GetPreferenceByIdAsync(long id)
        {
            var dbPreference = await _preferenceRepository.GetPreferenceByIdAsync(id);
            return _mapper.Map<PreferenceEntity>(dbPreference);
        }

        public async Task<IEnumerable<PreferenceEntity>> GetAllPreferencesAsync()
        {
            var dbPreferences = await _preferenceRepository.GetAllPreferencesAsync();
            return _mapper.Map<IEnumerable<PreferenceEntity>>(dbPreferences);
        }

        public async Task<PreferenceEntity> AddPreferenceAsync(PreferenceEntity preference)
        {
            var dbPreference = _mapper.Map<Preference>(preference);
            await _preferenceRepository.AddPreferenceAsync(dbPreference);
            return preference;
        }

        public async Task UpdatePreferenceAsync(PreferenceEntity preference)
        {
            var dbPreference = _mapper.Map<Preference>(preference);
            await _preferenceRepository.UpdatePreferenceAsync(dbPreference);
        }

        public async Task DeletePreferenceAsync(long id)
        {
            await _preferenceRepository.DeletePreferenceAsync(id);
        }
    }
}
