using DBmodels.Configuration;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;


namespace Infrastructure.Repository.Implementations
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly GcContext _context;

        public ProjectRepository(GcContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Project> GetProjectByIdAsync(Guid projectId)
        {
            return await this.GetById(projectId);
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await this.ToListAsync();
        }

        public async Task AddProjectAsync(Project project)
        {
            await this.Insert(project);
        }

        public async Task UpdateProjectAsync(Project project)
        {
            await this.Update(project);
        }

        public async Task DeleteProjectAsync(Guid projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            if (project != null)
            {
                await this.Delete(project);
            }
        }
    }
}
