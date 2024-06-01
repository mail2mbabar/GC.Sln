using Services.Entities;
using Services.Managers.Interfaces;
namespace Services.Managers.Implementations
{

    using AutoMapper;
    using DBmodels.Models;
    using Infrastructure.Repository.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<RoleEntity> GetRoleByIdAsync(long roleId)
        {
            var role = await _roleRepository.GetRoleByIdAsync(roleId);
            return _mapper.Map<RoleEntity>(role);
        }

        public async Task<IEnumerable<RoleEntity>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllRolesAsync();
            return _mapper.Map<IEnumerable<RoleEntity>>(roles);
        }

        public async Task<RoleEntity> AddRoleAsync(RoleEntity role)
        {
            var dbRole = _mapper.Map<Role>(role);
            await _roleRepository.AddRoleAsync(dbRole);
            return role;
        }

        public async Task<RoleEntity> UpdateRoleAsync(RoleEntity role)
        {
            var dbRole = _mapper.Map<Role>(role);
            await _roleRepository.UpdateRoleAsync(dbRole);
            return role;
        }

        public async Task DeleteRoleAsync(long roleId)
        {
            await _roleRepository.DeleteRoleAsync(roleId);
        }
    }
}

