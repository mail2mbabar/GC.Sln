using DBmodels.Configuration;
using DBmodels.Models;
using InfraStructuree.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructuree.Repository.Implementations
{
        public class ProjectRepository : IProjectRepository
        {
            private readonly GcContext _context;

            public ProjectRepository(GcContext context)
            {
                _context = context;
            }

            public async Task<Project> GetProjectByIdAsync(int projectId)
            {
                return await _context.Projects.FindAsync(projectId);
            }

            public async Task<List<Project>> GetAllProjectsAsync()
            {
                return await _context.Projects.ToListAsync();
            }

            public async Task AddProjectAsync(Project project)
            {
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateProjectAsync(Project project)
            {
                _context.Entry(project).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task DeleteProjectAsync(int projectId)
            {
                var project = await _context.Projects.FindAsync(projectId);
                if (project != null)
                {
                    _context.Projects.Remove(project);
                    await _context.SaveChangesAsync();
                }
            }
        }
}
