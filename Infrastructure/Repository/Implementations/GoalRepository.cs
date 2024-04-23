using DBmodels.Configuration;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;


namespace Infrastructure.Repository.Implementations
{
    public class GoalRepository : GenericRepository<Goal>, IGoalRepository
    {
        private readonly GcContext _context;

        public GoalRepository(GcContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Goal> GetGoalByIdAsync(long goalId)
        {
            return await this.GetById(goalId);
        }

        public async Task<List<Goal>> GetAllGoalsAsync()
        {
            return await this.ToListAsync();
        }

        public async Task AddGoalAsync(Goal goal)
        {
            await this.Insert(goal);
        }

        public async Task UpdateGoalAsync(Goal goal)
        {
            await this.Update(goal);
        }

        public async Task DeleteGoalAsync(long goalId)
        {
            var goal = await _context.Goals.FindAsync(goalId);
            if (goal != null)
            {
                await this.Delete(goal);
            }
        }
    }
}
