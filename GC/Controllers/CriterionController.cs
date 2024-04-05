using DBmodels.Models;
using InfraStructuree.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriterionController : ControllerBase
        {
            private readonly ICriterionRepository _criterionRepository;

            public CriterionController(ICriterionRepository criterionRepository)
            {
                _criterionRepository = criterionRepository;
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Criterion>> GetCriterion(int id)
            {
                var criterion = await _criterionRepository.GetCriterionByIdAsync(id);

                if (criterion == null)
                {
                    return NotFound();
                }

                return criterion;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Criterion>>> GetCriteria()
            {
                var criteria = await _criterionRepository.GetAllCriteriaAsync();
                return criteria;
            }

            [HttpPost]
            public async Task<ActionResult<Criterion>> PostCriterion(Criterion criterion)
            {
                await _criterionRepository.AddCriterionAsync(criterion);
                return CreatedAtAction(nameof(GetCriterion), new { id = criterion.CriterionId }, criterion);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutCriterion(int id, Criterion criterion)
            {
                if (id != criterion.CriterionId)
                {
                    return BadRequest();
                }

                await _criterionRepository.UpdateCriterionAsync(criterion);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCriterion(int id)
            {
                await _criterionRepository.DeleteCriterionAsync(id);
                return NoContent();
            }
        }
    }
