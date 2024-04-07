using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
        public class RoleController : ControllerBase
        {
            private readonly IRoleRepository _roleRepository;

            public RoleController(IRoleRepository roleRepository)
            {
                _roleRepository = roleRepository;
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Role>> GetRole(int id)
            {
                var role = await _roleRepository.GetRoleByIdAsync(id);

                if (role == null)
                {
                    return NotFound();
                }

                return role;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
            {
                var roles = await _roleRepository.GetAllRolesAsync();
                return roles;
            }

            [HttpPost]
            public async Task<ActionResult<Role>> PostRole(Role role)
            {
                await _roleRepository.AddRoleAsync(role);
                return CreatedAtAction(nameof(GetRole), new { id = role.RoleId }, role);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutRole(int id, Role role)
            {
                if (id != role.RoleId)
                {
                    return BadRequest();
                }

                await _roleRepository.UpdateRoleAsync(role);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteRole(int id)
            {
                await _roleRepository.DeleteRoleAsync(id);
                return NoContent();
            }
        }
    }

