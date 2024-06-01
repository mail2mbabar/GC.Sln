using DBmodels.Models;
using Services.Entities;

namespace Services.Managers.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync(UserEntity user);
    }
}
