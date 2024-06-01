using Services.Entities;

namespace Services.Managers.Interfaces
{
    public interface IGoalService
    {
        Task<GoalEntity> GetGoalByIdAsync(long id);
        Task<IEnumerable<GoalEntity>> GetAllGoalsAsync();
        Task<GoalEntity> AddGoalAsync(GoalEntity goal);
        Task UpdateGoalAsync(GoalEntity goal);
        Task DeleteGoalAsync(long id);
    }
}
