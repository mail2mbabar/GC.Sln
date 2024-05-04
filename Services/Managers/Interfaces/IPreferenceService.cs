using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Managers.Interfaces
{
    public interface IPreferenceService
    {
            Task<PreferenceEntity> GetPreferenceByIdAsync(long id);
            Task<IEnumerable<PreferenceEntity>> GetAllPreferencesAsync();
            Task<PreferenceEntity> AddPreferenceAsync(PreferenceEntity preference);
            Task UpdatePreferenceAsync(PreferenceEntity preference);
            Task DeletePreferenceAsync(long id);
    }
}
