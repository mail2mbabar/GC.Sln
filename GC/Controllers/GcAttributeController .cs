using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GcAttributeController : ControllerBase
    {
            private readonly IGcAttributeRepository _gcAttributeRepository;

            public GcAttributeController(IGcAttributeRepository gcAttributeRepository)
            {
                _gcAttributeRepository = gcAttributeRepository;
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<GcAttribute>> GetGcAttribute(int id)
            {
                var gcAttribute = await _gcAttributeRepository.GetGcAttributeByIdAsync(id);

                if (gcAttribute == null)
                {
                    return NotFound();
                }

                return gcAttribute;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<GcAttribute>>> GetGcAttributes()
            {
                var gcAttributes = await _gcAttributeRepository.GetAllGcAttributesAsync();
                return gcAttributes;
            }

            [HttpPost]
            public async Task<ActionResult<GcAttribute>> PostGcAttribute(GcAttribute gcAttribute)
            {
                await _gcAttributeRepository.AddGcAttributeAsync(gcAttribute);
                return CreatedAtAction(nameof(GetGcAttribute), new { id = gcAttribute.GcAttributeId }, gcAttribute);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutGcAttribute(int id, GcAttribute gcAttribute)
            {
                if (id != gcAttribute.GcAttributeId)
                {
                    return BadRequest();
                }

                await _gcAttributeRepository.UpdateGcAttributeAsync(gcAttribute);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteGcAttribute(int id)
            {
                await _gcAttributeRepository.DeleteGcAttributeAsync(id);
                return NoContent();
            }
        
    }
}
