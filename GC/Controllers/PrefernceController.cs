using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Entities;
using Services.Managers.Interfaces;

namespace GC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferenceController : ControllerBase
    {
        private readonly ILogger<PreferenceController> _logger;
        private readonly IPreferenceService _preferenceService;

        public PreferenceController(IPreferenceService preferenceService, ILogger<PreferenceController> logger)
        {
            _preferenceService = preferenceService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PreferenceEntity>> GetPreference(long id)
        {
            try
            {
                var preference = await _preferenceService.GetPreferenceByIdAsync(id);
                if (preference == null)
                {
                    return NotFound();
                }
                return preference;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting the Preference with ID: {id}");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreferenceEntity>>> GetPreferences()
        {
            try
            {
                var preferences = await _preferenceService.GetAllPreferencesAsync();
                return Ok(preferences);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all Preferences");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<PreferenceEntity>> AddPreference(PreferenceEntity preference)
        {
            try
            {
                var addedPreference = await _preferenceService.AddPreferenceAsync(preference);
                return CreatedAtAction(nameof(GetPreference), new { id = addedPreference.PreferenceId }, addedPreference);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a Preference");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePreference(long id, PreferenceEntity preference)
        {
            try
            {
                if (id != preference.PreferenceId)
                {
                    return BadRequest();
                }
                await _preferenceService.UpdatePreferenceAsync(preference);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the Preference with ID: {id}");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreference(long id)
        {
            try
            {
                await _preferenceService.DeletePreferenceAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting the Preference with ID: {id}");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }
    }

}
