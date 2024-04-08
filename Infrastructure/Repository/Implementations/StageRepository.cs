using DBmodels.Configuration;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;


namespace Infrastructure.Repository.Implementations
{
    public class StageRepository : GenericRepository<Stage>, IStageRepository
    {
        private readonly GcContext _context;

        public StageRepository(GcContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Stage> GetStageByIdAsync(int stageId)
        {
            return await this.GetById(stageId);
        }

        public async Task<List<Stage>> GetAllStagesAsync()
        {
            return await this.ToListAsync();
        }

        public async Task AddStageAsync(Stage stage)
        {
            await this.Insert(stage);
        }

        public async Task UpdateStageAsync(Stage stage)
        {
            await this.Update(stage);
        }

        public async Task DeleteStageAsync(int stageId)
        {
            var stage = await _context.Stages.FindAsync(stageId);
            if (stage != null)
            {
                await this.Delete(stage);
            }
        }
    }
}
