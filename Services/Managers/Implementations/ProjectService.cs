using AutoMapper;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Services.Entities;
using Services.Managers.Interfaces;

namespace Services.Managers.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<ProjectEntity> GetProjectByIdAsync(Guid id)
        {
            var dbProject = await _projectRepository.GetProjectByIdAsync(id);
            return _mapper.Map<ProjectEntity>(dbProject);
        }

        public async Task<IEnumerable<ProjectEntity>> GetAllProjectsAsync()
        {
            var dbProjects = await _projectRepository.GetAllProjectsAsync();
            return _mapper.Map<IEnumerable<ProjectEntity>>(dbProjects);
        }

        public async Task<ProjectEntity> AddProjectAsync(ProjectEntity project)
        {
            var dbProject = _mapper.Map<Project>(project);
            await _projectRepository.AddProjectAsync(dbProject);
            return project;
        }

        public async Task UpdateProjectAsync(ProjectEntity project)
        {
            var dbProject = _mapper.Map<Project>(project);
            await _projectRepository.UpdateProjectAsync(dbProject);
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            await _projectRepository.DeleteProjectAsync(id);
        }
    }

}

