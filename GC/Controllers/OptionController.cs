
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
            private readonly IOptionRepository _optionRepository;

            public OptionController(IOptionRepository optionRepository)
            {
                _optionRepository = optionRepository;
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Option>> GetOption(int id)
            {
                var option = await _optionRepository.GetOptionByIdAsync(id);

                if (option == null)
                {
                    return NotFound();
                }

                return option;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Option>>> GetOptions()
            {
                var options = await _optionRepository.GetAllOptionsAsync();
                return options;
            }

            [HttpPost]
            public async Task<ActionResult<Option>> PostOption(Option option)
            {
                await _optionRepository.AddOptionAsync(option);
                return CreatedAtAction(nameof(GetOption), new { id = option.OptionId }, option);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutOption(int id, Option option)
            {
                if (id != option.OptionId)
                {
                    return BadRequest();
                }

                await _optionRepository.UpdateOptionAsync(option);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteOption(int id)
            {
                await _optionRepository.DeleteOptionAsync(id);
                return NoContent();
            }
        }
    }
