

using DBmodels.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleByIdAsync(long roleId);
        Task<List<Role>> GetAllRolesAsync();
        Task AddRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(long roleId);
    }
}
