using DBmodels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interfaces
{
    public interface IStageRepository
    {
        Task<Stage> GetStageByIdAsync(int stageId);
        Task<List<Stage>> GetAllStagesAsync();
        Task AddStageAsync(Stage stage);
        Task UpdateStageAsync(Stage stage);
        Task DeleteStageAsync(int stageId);
    }
}
