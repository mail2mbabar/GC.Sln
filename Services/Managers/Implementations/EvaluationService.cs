using AutoMapper;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Services.Entities;
using Services.Managers.Interfaces;
using System;
namespace Services.Managers.Implementations
{

    public class EvaluationService : IEvaluationService
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly IMapper _mapper;

        public EvaluationService(IEvaluationRepository evaluationRepository, IMapper mapper)
        {
            _evaluationRepository = evaluationRepository;
            _mapper = mapper;
        }

        public async Task<EvaluationEntity> GetEvaluationByIdAsync(long id)
        {
            var dbEvaluation = await _evaluationRepository.GetEvaluationByIdAsync(id);
            return _mapper.Map<EvaluationEntity>(dbEvaluation);
        }

        public async Task<IEnumerable<EvaluationEntity>> GetAllEvaluationsAsync()
        {
            var dbEvaluations = await _evaluationRepository.GetAllEvaluationsAsync();
            return _mapper.Map<IEnumerable<EvaluationEntity>>(dbEvaluations);
        }

        public async Task<EvaluationEntity> AddEvaluationAsync(EvaluationEntity evaluation)
        {
            var dbEvaluation = _mapper.Map<Evaluation>(evaluation);
            await _evaluationRepository.AddEvaluationAsync(dbEvaluation);
            return evaluation;
        }

        public async Task UpdateEvaluationAsync(EvaluationEntity evaluation)
        {
            var dbEvaluation = _mapper.Map<Evaluation>(evaluation);
            await _evaluationRepository.UpdateEvaluationAsync(dbEvaluation);
        }

        public async Task DeleteEvaluationAsync(long id)
        {
            await _evaluationRepository.DeleteEvaluationAsync(id);
        }
    }

}

