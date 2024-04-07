using DBmodels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interfaces
{
    public interface IEvaluationRepository
    {
        Task<Evaluation> GetEvaluationByIdAsync(int evaluationId);
        Task<List<Evaluation>> GetAllEvaluationsAsync();
        Task AddEvaluationAsync(Evaluation evaluation);
        Task UpdateEvaluationAsync(Evaluation evaluation);
        Task DeleteEvaluationAsync(int evaluationId);
    }
}
