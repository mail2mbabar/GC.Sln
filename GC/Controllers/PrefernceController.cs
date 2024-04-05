using DBmodels.Models;
using InfraStructuree.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferenceController : ControllerBase
    {
        private readonly IPreferenceRepository _preferenceRepository;

        public PreferenceController(IPreferenceRepository preferenceRepository)
        {
            _preferenceRepository = preferenceRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Preference>> GetPreference(int id)
        {
            var preference = await _preferenceRepository.GetPreferenceByIdAsync(id);

            if (preference == null)
            {
                return NotFound();
            }

            return preference;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Preference>>> GetPreferences()
        {
            var preferences = await _preferenceRepository.GetAllPreferencesAsync();
            return preferences;
        }

        [HttpPost]
        public async Task<ActionResult<Preference>> PostPreference(Preference preference)
        {
            await _preferenceRepository.AddPreferenceAsync(preference);
            return CreatedAtAction(nameof(GetPreference), new { id = preference.PreferenceId }, preference);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreference(int id, Preference preference)
        {
            if (id != preference.PreferenceId)
            {
                return BadRequest();
            }

            await _preferenceRepository.UpdatePreferenceAsync(preference);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreference(int id)
        {
            await _preferenceRepository.DeletePreferenceAsync(id);
            return NoContent();
        }
    }
}