using DBmodels.Configuration;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Implementations
{
        public class RoleRepository : IRoleRepository
        {
            private readonly GcContext _context;

            public RoleRepository(GcContext context)
            {
                _context = context;
            }

            public async Task<Role> GetRoleByIdAsync(int roleId)
            {
                return await _context.Roles.FindAsync(roleId);
            }

            public async Task<List<Role>> GetAllRolesAsync()
            {
                return await _context.Roles.ToListAsync();
            }

            public async Task AddRoleAsync(Role role)
            {
                _context.Roles.Add(role);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateRoleAsync(Role role)
            {
                _context.Entry(role).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task DeleteRoleAsync(int roleId)
            {
                var role = await _context.Roles.FindAsync(roleId);
                if (role != null)
                {
                    _context.Roles.Remove(role);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }

