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
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService, ILogger<ProjectController> logger)
        {
            _projectService = projectService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectEntity>> GetProject(Guid id)
        {
            try
            {
                var project = await _projectService.GetProjectByIdAsync(id);
                if (project == null)
                {
                    return NotFound();
                }
                return project;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting the Project with ID: {id}");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectEntity>>> GetProjects()
        {
            try
            {
                var projects = await _projectService.GetAllProjectsAsync();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all Projects");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProjectEntity>> AddProject(ProjectEntity project)
        {
            try
            {
                var addedProject = await _projectService.AddProjectAsync(project);
                return CreatedAtAction(nameof(GetProject), new { id = addedProject.ProjectId }, addedProject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a Project");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(Guid id, ProjectEntity project)
        {
            try
            {
                if (id != project.ProjectId)
                {
                    return BadRequest();
                }
                await _projectService.UpdateProjectAsync(project);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the Project with ID: {id}");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            try
            {
                await _projectService.DeleteProjectAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting the Project with ID: {id}");
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }
    }

}
    

