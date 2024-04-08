using DBmodels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interfaces
{
    public interface IGoalRepository
    {
        Task<Goal> GetGoalByIdAsync(int goalId);
        Task<List<Goal>> GetAllGoalsAsync();
        Task AddGoalAsync(Goal goal);
        Task UpdateGoalAsync(Goal goal);
        Task DeleteGoalAsync(int goalId);
    }
}
