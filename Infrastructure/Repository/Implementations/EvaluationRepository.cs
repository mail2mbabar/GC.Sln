using DBmodels.Configuration;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;


namespace Infrastructure.Repository.Implementations
{
    public class EvaluationRepository : GenericRepository<Evaluation>, IEvaluationRepository
    {
        private readonly GcContext _context;

        public EvaluationRepository(GcContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Evaluation> GetEvaluationByIdAsync(int evaluationId)
        {
            return await this.GetById(evaluationId);
        }

        public async Task<List<Evaluation>> GetAllEvaluationsAsync()
        {
            return await this.ToListAsync();
        }

        public async Task AddEvaluationAsync(Evaluation evaluation)
        {
            await this.Insert(evaluation);
        }

        public async Task UpdateEvaluationAsync(Evaluation evaluation)
        {
            await this.Update(evaluation);
        }

        public async Task DeleteEvaluationAsync(int evaluationId)
        {
            var evaluation = await _context.Evaluations.FindAsync(evaluationId);
            if (evaluation != null)
            {
                await this.Delete(evaluation);
            }
        }
    }
}
