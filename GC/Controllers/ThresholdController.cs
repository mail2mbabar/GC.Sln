using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class ThresholdController : ControllerBase
        {
            private readonly IThresholdRepository _thresholdRepository;

            public ThresholdController(IThresholdRepository thresholdRepository)
            {
                _thresholdRepository = thresholdRepository;
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Threshold>> GetThreshold(int id)
            {
                var threshold = await _thresholdRepository.GetThresholdByIdAsync(id);

                if (threshold == null)
                {
                    return NotFound();
                }

                return threshold;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Threshold>>> GetThresholds()
            {
                var thresholds = await _thresholdRepository.GetAllThresholdsAsync();
                return thresholds;
            }

            [HttpPost]
            public async Task<ActionResult<Threshold>> PostThreshold(Threshold threshold)
            {
                await _thresholdRepository.AddThresholdAsync(threshold);
                return CreatedAtAction(nameof(GetThreshold), new { id = threshold.ThresholdId }, threshold);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutThreshold(int id, Threshold threshold)
            {
                if (id != threshold.ThresholdId)
                {
                    return BadRequest();
                }

                await _thresholdRepository.UpdateThresholdAsync(threshold);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteThreshold(int id)
            {
                await _thresholdRepository.DeleteThresholdAsync(id);
                return NoContent();
            }
        }
    }