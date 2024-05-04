using DBmodels.Models;


namespace Infrastructure.Repository.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project> GetProjectByIdAsync(Guid projectId);
        Task<List<Project>> GetAllProjectsAsync();
        Task AddProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(Guid projectId);
    }
}
