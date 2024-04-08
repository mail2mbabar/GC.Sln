using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
            private readonly IEvaluationRepository _evaluationRepository;

            public EvaluationController(IEvaluationRepository evaluationRepository)
            {
                _evaluationRepository = evaluationRepository;
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Evaluation>> GetEvaluation(int id)
            {
                var evaluation = await _evaluationRepository.GetEvaluationByIdAsync(id);

                if (evaluation == null)
                {
                    return NotFound();
                }

                return evaluation;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Evaluation>>> GetEvaluations()
            {
                var evaluations = await _evaluationRepository.GetAllEvaluationsAsync();
                return evaluations;
            }

            [HttpPost]
            public async Task<ActionResult<Evaluation>> PostEvaluation(Evaluation evaluation)
            {
                await _evaluationRepository.AddEvaluationAsync(evaluation);
                return CreatedAtAction(nameof(GetEvaluation), new { id = evaluation.EvaluationId }, evaluation);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutEvaluation(int id, Evaluation evaluation)
            {
                if (id != evaluation.EvaluationId)
                {
                    return BadRequest();
                }

                await _evaluationRepository.UpdateEvaluationAsync(evaluation);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteEvaluation(int id)
            {
                await _evaluationRepository.DeleteEvaluationAsync(id);
                return NoContent();
            }
        }
    }
