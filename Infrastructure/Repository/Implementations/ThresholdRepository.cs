using DBmodels.Configuration;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;


namespace Infrastructure.Repository.Implementations
{
    public class ThresholdRepository : GenericRepository<Threshold>, IThresholdRepository
    {
        private readonly GcContext _context;

        public ThresholdRepository(GcContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Threshold> GetThresholdByIdAsync(int thresholdId)
        {
            return await this.GetById(thresholdId);
        }

        public async Task<List<Threshold>> GetAllThresholdsAsync()
        {
            return await this.ToListAsync();
        }

        public async Task AddThresholdAsync(Threshold threshold)
        {
            await this.Insert(threshold);
        }

        public async Task UpdateThresholdAsync(Threshold threshold)
        {
            await this.Update(threshold);
        }

        public async Task DeleteThresholdAsync(int thresholdId)
        {
            var threshold = await _context.Thresholds.FindAsync(thresholdId);
            if (threshold != null)
            {
                await this.Delete(threshold);
            }
        }
    }
}
