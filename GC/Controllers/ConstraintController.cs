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
    public class ConstraintController : ControllerBase
    {
        private readonly ILogger<ConstraintController> _logger;
        private readonly IConstraintService _constraintService;

        public ConstraintController(IConstraintService constraintService, ILogger<ConstraintController> logger)
        {
            _constraintService = constraintService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConstraintEntity>> GetConstraint(long id)
        {
            try
            {
                var constraint = await _constraintService.GetConstraintByIdAsync(id);
                if (constraint == null)
                {
                    return NotFound();
                }
                return constraint;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting the Constraint with ID: {id}");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConstraintEntity>>> GetConstraints()
        {
            try
            {
                var constraints = await _constraintService.GetAllConstraintsAsync();
                return Ok(constraints);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all Constraints");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ConstraintEntity>> AddConstraint(ConstraintEntity constraint)
        {
            try
            {
                var addedConstraint = await _constraintService.AddConstraintAsync(constraint);
                return CreatedAtAction(nameof(GetConstraint), new { id = addedConstraint.ConstraintId }, addedConstraint);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a Constraint");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConstraint(long id, ConstraintEntity constraint)
        {
            try
            {
                if (id != constraint.ConstraintId)
                {
                    return BadRequest();
                }
                await _constraintService.UpdateConstraintAsync(constraint);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the Constraint with ID: {id}");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstraint(long id)
        {
            try
            {
                await _constraintService.DeleteConstraintAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting the Constraint with ID: {id}");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }
    }

}
