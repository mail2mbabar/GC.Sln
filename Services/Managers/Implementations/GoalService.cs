using AutoMapper;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Services.Entities;
using Services.Managers.Interfaces;

namespace Services.Managers.Implementations
{
    public class GoalService : IGoalService
    {
        private readonly IGoalRepository _goalRepository;
        private readonly IMapper _mapper;

        public GoalService(IGoalRepository goalRepository, IMapper mapper)
        {
            _goalRepository = goalRepository;
            _mapper = mapper;
        }

        public async Task<GoalEntity> GetGoalByIdAsync(long id)
        {
            var dbGoal = await _goalRepository.GetGoalByIdAsync(id);
            return _mapper.Map<GoalEntity>(dbGoal);
        }

        public async Task<IEnumerable<GoalEntity>> GetAllGoalsAsync()
        {
            var dbGoals = await _goalRepository.GetAllGoalsAsync();
            return _mapper.Map<IEnumerable<GoalEntity>>(dbGoals);
        }

        public async Task<GoalEntity> AddGoalAsync(GoalEntity goal)
        {
            var dbGoal = _mapper.Map<Goal>(goal);
            await _goalRepository.AddGoalAsync(dbGoal);
            return goal;
        }

        public async Task UpdateGoalAsync(GoalEntity goal)
        {
            var dbGoal = _mapper.Map<Goal>(goal);
            await _goalRepository.UpdateGoalAsync(dbGoal);
        }

        public async Task DeleteGoalAsync(long id)
        {
            await _goalRepository.DeleteGoalAsync(id);
        }
    }
}