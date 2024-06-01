using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Services.Entities;

[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    private readonly ILogger<GroupController> _logger;
    private readonly IGroupService _groupService;

    public GroupController(IGroupService groupService, ILogger<GroupController> logger)
    {
        _groupService = groupService;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GroupResponseDto>> GetGroup(Guid id)
    {
        try
        {
            var group = await _groupService.GetGroupByIdAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while getting the group with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GroupResponseDto>>> GetGroups()
    {
        try
        {
            var groups = await _groupService.GetAllGroupsAsync();
            return Ok(groups);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting all groups");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<GroupEntity>> AddGroup(GroupEntity group)
    {
        try
        {
            var addedGroup = await _groupService.AddGroupAsync(group);
            return CreatedAtAction(nameof(GetGroup), new { id = addedGroup.GroupId }, addedGroup);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while adding a group");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGroup(Guid id, GroupEntity group)
    {
        try
        {
            if (id != group.GroupId)
            {
                return BadRequest();
            }
            await _groupService.UpdateGroupAsync(group);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while updating the group with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGroup(Guid id)
    {
        try
        {
            await _groupService.DeleteGroupAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while deleting the group with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }
}
