using DBmodels.Models;


namespace Infrastructure.Repository.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project> GetProjectByIdAsync(int projectId);
        Task<List<Project>> GetAllProjectsAsync();
        Task AddProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int projectId);
    }
}
