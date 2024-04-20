using Microsoft.AspNetCore.Mvc;
using Services.Entities;
using Services.Managers.Interfaces;


[Route("api/[controller]")]
[ApiController]
public class CriterionController : ControllerBase
{
    private readonly ILogger<CriterionController> _logger;
    private readonly ICriterionService _criterionService;

    public CriterionController(ICriterionService criterionService, ILogger<CriterionController> logger)
    {
        _criterionService = criterionService;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CriterionEntity>> GetCriterion(long id)
    {
        try
        {
            var criterion = await _criterionService.GetCriterionByIdAsync(id);
            if (criterion == null)
            {
                return NotFound();
            }
            return criterion;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while getting the criterion with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CriterionEntity>>> GetCriteria()
    {
        try
        {
            var criteria = await _criterionService.GetAllCriterionAsync();
            return Ok(criteria);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting all criteria");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<CriterionEntity>> AddCriterion(CriterionEntity criterion)
    {
        try
        {
            var addedCriterion = await _criterionService.AddCriterionAsync(criterion);
            return CreatedAtAction(nameof(GetCriterion), new { id = addedCriterion.CriterionId }, addedCriterion);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while adding a criterion");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCriterion(long id, CriterionEntity criterion)
    {
        try
        {
            if (id != criterion.CriterionId)
            {
                return BadRequest();
            }
            await _criterionService.UpdateCriterionAsync(criterion);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while updating the criterion with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCriterion(long id)
    {
        try
        {
            await _criterionService.DeleteCriterionAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while deleting the criterion with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }
}
