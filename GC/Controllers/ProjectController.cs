using DBmodels.Models;
using InfraStructuree.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
            private readonly IProjectRepository _projectRepository;

            public ProjectController(IProjectRepository projectRepository)
            {
                _projectRepository = projectRepository;
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Project>> GetProject(int id)
            {
                var project = await _projectRepository.GetProjectByIdAsync(id);

                if (project == null)
                {
                    return NotFound();
                }

                return project;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
            {
                var projects = await _projectRepository.GetAllProjectsAsync();
                return projects;
            }

            [HttpPost]
            public async Task<ActionResult<Project>> PostProject(Project project)
            {
                await _projectRepository.AddProjectAsync(project);
                return CreatedAtAction(nameof(GetProject), new { id = project.ProjectId }, project);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutProject(int id, Project project)
            {
                if (id != project.ProjectId)
                {
                    return BadRequest();
                }

                await _projectRepository.UpdateProjectAsync(project);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteProject(int id)
            {
                await _projectRepository.DeleteProjectAsync(id);
                return NoContent();
            }
        }
    }

