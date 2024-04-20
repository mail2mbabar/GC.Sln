using Microsoft.AspNetCore.Mvc;
using Services.Entities;
using Services.Managers.Interfaces;


[Route("api/[controller]")]
[ApiController]
public class GcAttributeController : ControllerBase
{
    private readonly ILogger<GcAttributeController> _logger;
    private readonly IGcAttributeService _gcAttributeService;

    public GcAttributeController(IGcAttributeService gcAttributeService, ILogger<GcAttributeController> logger)
    {
        _gcAttributeService = gcAttributeService;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GcAttributeEntity>> GetGcAttribute(long id)
    {
        try
        {
            var gcAttribute = await _gcAttributeService.GetGcAttributeByIdAsync(id);
            if (gcAttribute == null)
            {
                return NotFound();
            }
            return gcAttribute;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while getting the GcAttribute with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GcAttributeEntity>>> GetGcAttributes()
    {
        try
        {
            var gcAttributes = await _gcAttributeService.GetAllGcAttributesAsync();
            return Ok(gcAttributes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting all GcAttributes");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<GcAttributeEntity>> AddGcAttribute(GcAttributeEntity gcAttribute)
    {
        try
        {
            var addedGcAttribute = await _gcAttributeService.AddGcAttributeAsync(gcAttribute);
            return CreatedAtAction(nameof(GetGcAttribute), new { id = addedGcAttribute.GcAttributeId }, addedGcAttribute);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while adding a GcAttribute");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGcAttribute(long id, GcAttributeEntity gcAttribute)
    {
        try
        {
            if (id != gcAttribute.GcAttributeId)
            {
                return BadRequest();
            }
            await _gcAttributeService.UpdateGcAttributeAsync(gcAttribute);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while updating the GcAttribute with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGcAttribute(long id)
    {
        try
        {
            await _gcAttributeService.DeleteGcAttributeAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while deleting the GcAttribute with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }
}
