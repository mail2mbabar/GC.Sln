using Services.Entities;

namespace Services.Managers.Interfaces
{
    public interface IOptionService
    {
        Task<OptionEntity> GetOptionByIdAsync(long optionId);
        Task<IEnumerable<OptionEntity>> GetAllOptionsAsync();
        Task<OptionEntity> AddOptionAsync(OptionEntity option);
        Task<OptionEntity> UpdateOptionAsync(OptionEntity option);
        Task DeleteOptionAsync(long optionId);

    }
}
