using DBmodels.Models;
using Services.DTOs;
using Services.Entities;

namespace Services.Managers.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDTO> AuthenticateUserAsync(Guid userId);
        Task<UserEntity> GetUserByIdAsync(Guid id);
        Task<IEnumerable<UserEntity>> GetAllUsersAsync();
        Task<UserEntity> AddUserAsync(UserEntity user);
        Task<UserEntity> UpdateUserAsync(UserEntity user);
        Task DeleteUserAsync(Guid id);
    }
}
