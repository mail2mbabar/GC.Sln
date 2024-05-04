using Microsoft.AspNetCore.Mvc;
using Services.Entities;
using Services.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly ILogger<RoleController> _logger;
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService, ILogger<RoleController> logger)
    {
        _roleService = roleService;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoleEntity>> GetRole(long id)
    {
        try
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return role;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while getting the role with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleEntity>>> GetRoles()
    {
        try
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting all roles");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<RoleEntity>> AddRole(RoleEntity role)
    {
        try
        {
            var addedRole = await _roleService.AddRoleAsync(role);
            return CreatedAtAction(nameof(GetRole), new { id = addedRole.RoleId }, addedRole);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while adding a role");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRole(long id, RoleEntity role)
    {
        try
        {
            if (id != role.RoleId)
            {
                return BadRequest();
            }
            await _roleService.UpdateRoleAsync(role);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while updating the role with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(long id)
    {
        try
        {
            await _roleService.DeleteRoleAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while deleting the role with ID: {id}");
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }
}
