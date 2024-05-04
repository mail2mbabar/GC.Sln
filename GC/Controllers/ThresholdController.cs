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
    public class ThresholdController : ControllerBase

    {
        private readonly ILogger<ThresholdController> _logger;
        private readonly IThresholdService _thresholdService;

        public ThresholdController(IThresholdService thresholdService, ILogger<ThresholdController> logger)
        {
            _thresholdService = thresholdService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ThresholdEntity>> GetThreshold(long id)
        {
            try
            {
                var threshold = await _thresholdService.GetThresholdByIdAsync(id);
                if (threshold == null)
                {
                    return NotFound();
                }
                return threshold;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting the Threshold with ID: {id}");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThresholdEntity>>> GetThresholds()
        {
            try
            {
                var thresholds = await _thresholdService.GetAllThresholdsAsync();
                return Ok(thresholds);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all Thresholds");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ThresholdEntity>> AddThreshold(ThresholdEntity threshold)
        {
            try
            {
                await _thresholdService.AddThresholdAsync(threshold);
                return CreatedAtAction(nameof(GetThreshold), new { id = threshold.ThresholdId }, threshold);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a Threshold");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateThreshold(long id, ThresholdEntity threshold)
        {
            try
            {
                if (id != threshold.ThresholdId)
                {
                    return BadRequest();
                }
                await _thresholdService.UpdateThresholdAsync(threshold);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the Threshold with ID: {id}");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThreshold(long id)
        {
            try
            {
                await _thresholdService.DeleteThresholdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting the Threshold with ID: {id}");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }
    }

}
