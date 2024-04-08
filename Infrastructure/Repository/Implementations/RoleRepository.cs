using DBmodels.Configuration;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;


namespace Infrastructure.Repository.Implementations
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly GcContext _context;

        public RoleRepository(GcContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Role> GetRoleByIdAsync(int roleId)
        {
            return await this.GetById(roleId);
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await this.ToListAsync();
        }

        public async Task AddRoleAsync(Role role)
        {
            await this.Insert(role);
        }

        public async Task UpdateRoleAsync(Role role)
        {
            await this.Update(role);
        }

        public async Task DeleteRoleAsync(int roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role != null)
            {
                await this.Delete(role);
            }
        }
    }
}
