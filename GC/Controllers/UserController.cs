using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBmodels.Configuration;
using System;
using Infrastructure.Repository.Interfaces;
using DBmodels.Models;
using Services.Managers.Interfaces;
using Services.Entities;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [AllowAnonymous]
    [HttpPost("authenticate/{id}")]
    public async Task<IActionResult> Authenticate(Guid id)
    {
        try
        {
            var userResponse = await this._userService.AuthenticateUserAsync(id);

            if (userResponse is null || (userResponse is not null && string.IsNullOrWhiteSpace(userResponse.Token)))
            {
                this._logger.LogInformation($"User Not Authenticated");
                return Unauthorized();
            }

            this._logger.LogInformation($"User Authenticated SuccessFully with Token : ${userResponse.Token}");

            return Ok(userResponse);
        }
        catch (Exception)
        {
            this._logger.LogInformation($"User Not Authenticated: Exception");
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserEntity>> GetUser(Guid id)
    {
        try
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserEntity>>> GetUsers()
    {
        try
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<UserEntity>> AddUser(UserEntity user)
    {
        try
        {
            var userResponse = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = userResponse.UserId }, user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, UserEntity user)
    {
        try
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            await _userService.UpdateUserAsync(user);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        try
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
        }
    }
}

