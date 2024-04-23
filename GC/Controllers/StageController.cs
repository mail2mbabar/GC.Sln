using Microsoft.AspNetCore.Mvc;
using Services.Entities;
using Services.Managers.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class StageController : ControllerBase
{
    private readonly ILogger<StageController> _logger;
    private readonly IStageService _stageService;

    public StageController(IStageService stageService, ILogger<StageController> logger)
    {
        _stageService = stageService;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StageEntity>> GetStage(long id)
    {
        try
        {
            var stage = await _stageService.GetStageByIdAsync(id);
            if (stage == null)
            {
                return NotFound();
            }
            return stage;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while getting the Stage with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StageEntity>>> GetStages()
    {
        try
        {
            var stages = await _stageService.GetAllStagesAsync();
            return Ok(stages);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting all Stages");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<StageEntity>> AddStage(StageEntity stage)
    {
        try
        {
            await _stageService.AddStageAsync(stage);
            return CreatedAtAction(nameof(GetStage), new { id = stage.StageId }, stage);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while adding a Stage");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStage(long id, StageEntity stage)
    {
        try
        {
            if (id != stage.StageId)
            {
                return BadRequest();
            }
            await _stageService.UpdateStageAsync(stage);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while updating the Stage with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStage(long id)
    {
        try
        {
            await _stageService.DeleteStageAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while deleting the Stage with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }
}
