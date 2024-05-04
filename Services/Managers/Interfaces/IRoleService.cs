using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Managers.Interfaces
{
    public interface IRoleService
    {
            Task<RoleEntity> GetRoleByIdAsync(long roleId);
            Task<IEnumerable<RoleEntity>> GetAllRolesAsync();
            Task<RoleEntity> AddRoleAsync(RoleEntity role);
            Task<RoleEntity> UpdateRoleAsync(RoleEntity role);
            Task DeleteRoleAsync(long roleId);
        }
    }