using Services.Entities;
namespace Services.Managers.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectEntity> GetProjectByIdAsync(Guid id);
        Task<IEnumerable<ProjectEntity>> GetAllProjectsAsync();
        Task<ProjectEntity> AddProjectAsync(ProjectEntity project);
        Task UpdateProjectAsync(ProjectEntity project);
        Task DeleteProjectAsync(Guid id);
    }
}
