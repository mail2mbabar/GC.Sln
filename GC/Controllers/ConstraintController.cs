using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstraintController : ControllerBase
    {
        private readonly IConstraintRepository _constraintRepository;

        public ConstraintController(IConstraintRepository constraintRepository)
        {
            _constraintRepository = constraintRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Constraint>> GetConstraint(int id)
        {
            var constraint = await _constraintRepository.GetConstraintByIdAsync(id);

            if (constraint == null)
            {
                return NotFound();
            }

            return constraint;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Constraint>>> GetConstraints()
        {
            var constraints = await _constraintRepository.GetAllConstraintsAsync();
            return constraints;
        }

        [HttpPost]
        public async Task<ActionResult<Constraint>> PostConstraint(Constraint constraint)
        {
            await _constraintRepository.AddConstraintAsync(constraint);
            return CreatedAtAction(nameof(GetConstraint), new { id = constraint.ConstraintId }, constraint);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConstraint(int id, Constraint constraint)
        {
            if (id != constraint.ConstraintId)
            {
                return BadRequest();
            }

            await _constraintRepository.UpdateConstraintAsync(constraint);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstraint(int id)
        {
            await _constraintRepository.DeleteConstraintAsync(id);
            return NoContent();
        }
    }
}