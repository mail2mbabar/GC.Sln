using Services.Entities;


namespace Services.Managers.Interfaces
{
    public interface IEvaluationService
    {
        Task<EvaluationEntity> GetEvaluationByIdAsync(long id);
        Task<IEnumerable<EvaluationEntity>> GetAllEvaluationsAsync();
        Task<EvaluationEntity> AddEvaluationAsync(EvaluationEntity evaluation);
        Task UpdateEvaluationAsync(EvaluationEntity evaluation);
        Task DeleteEvaluationAsync(long id);
    }
}
