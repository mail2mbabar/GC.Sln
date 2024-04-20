using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
