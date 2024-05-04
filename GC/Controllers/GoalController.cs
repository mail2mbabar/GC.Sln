using Microsoft.AspNetCore.Mvc;
using Services.Entities;
using Services.Managers.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class GoalController : ControllerBase
{
    private readonly ILogger<GoalController> _logger;
    private readonly IGoalService _goalService;

    public GoalController(IGoalService goalService, ILogger<GoalController> logger)
    {
        _goalService = goalService;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GoalEntity>> GetGoal(long id)
    {
        try
        {
            var goal = await _goalService.GetGoalByIdAsync(id);
            if (goal == null)
            {
                return NotFound();
            }
            return goal;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while getting the Goal with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GoalEntity>>> GetGoals()
    {
        try
        {
            var goals = await _goalService.GetAllGoalsAsync();
            return Ok(goals);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting all Goals");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<GoalEntity>> AddGoal(GoalEntity goal)
    {
        try
        {
            var addedGoal = await _goalService.AddGoalAsync(goal);
            return CreatedAtAction(nameof(GetGoal), new { id = addedGoal.GoalId }, addedGoal);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while adding a Goal");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGoal(long id, GoalEntity goal)
    {
        try
        {
            if (id != goal.GoalId)
            {
                return BadRequest();
            }
            await _goalService.UpdateGoalAsync(goal);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while updating the Goal with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGoal(long id)
    {
        try
        {
            await _goalService.DeleteGoalAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while deleting the Goal with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }
}
