using Microsoft.AspNetCore.Mvc;
using Services.Entities;
using Services.Managers.Implementations;
using Services.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class OptionController : ControllerBase
{
    private readonly ILogger<OptionController> _logger;
    private readonly IOptionService _optionService;

    public OptionController(IOptionService optionService, ILogger<OptionController> logger)
    {
        _optionService = optionService;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OptionEntity>> GetOption(long id)
    {
        try
        {
            var option = await _optionService.GetOptionByIdAsync(id);
            if (option == null)
            {
                return NotFound();
            }
            return option;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while getting the Option with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OptionEntity>>> GetOptions()
    {
        try
        {
            var options = await _optionService.GetAllOptionsAsync();
            return Ok(options);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting all Options");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<OptionEntity>> AddOption(OptionEntity option)
    {
        try
        {
            var addedOption = await _optionService.AddOptionAsync(option);
            return CreatedAtAction(nameof(GetOption), new { id = addedOption.OptionId }, addedOption);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while adding a option");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOption(long id, OptionEntity option)
    {
        try
        {
            if (id != option.OptionId)
            {
                return BadRequest();
            }
            await _optionService.UpdateOptionAsync(option);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while updating the option with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOption(long id)
    {
        try
        {
            await _optionService.DeleteOptionAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while deleting the option with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }
}

