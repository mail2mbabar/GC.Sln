using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
            private readonly IGoalRepository _goalRepository;

            public GoalController(IGoalRepository goalRepository)
            {
                _goalRepository = goalRepository;
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Goal>> GetGoal(int id)
            {
                var goal = await _goalRepository.GetGoalByIdAsync(id);

                if (goal == null)
                {
                    return NotFound();
                }

                return goal;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Goal>>> GetGoals()
            {
                var goals = await _goalRepository.GetAllGoalsAsync();
                return goals;
            }

            [HttpPost]
            public async Task<ActionResult<Goal>> PostGoal(Goal goal)
            {
                await _goalRepository.AddGoalAsync(goal);
                return CreatedAtAction(nameof(GetGoal), new { id = goal.GoalId }, goal);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutGoal(int id, Goal goal)
            {
                if (id != goal.GoalId)
                {
                    return BadRequest();
                }

                await _goalRepository.UpdateGoalAsync(goal);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteGoal(int id)
            {
                await _goalRepository.DeleteGoalAsync(id);
                return NoContent();
            }
        
    }
}
