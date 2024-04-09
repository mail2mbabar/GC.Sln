using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Managers.Interfaces
{
    public interface IUserService
    {
        Task<UserEntity> GetUserByIdAsync(Guid id);
        Task<IEnumerable<UserEntity>> GetAllUsersAsync();
        Task<UserEntity> AddUserAsync(UserEntity user);
        Task<UserEntity> UpdateUserAsync(UserEntity user);
        Task DeleteUserAsync(Guid id);
    }
}
