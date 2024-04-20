using AutoMapper;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Services.Entities;
using Services.Managers.Interfaces;

namespace Services.Managers.Implementations
    {
        public class CriterionService : ICriterionService
        {
            private readonly ICriterionRepository _criterionRepository;
            private readonly IMapper _mapper;

            public CriterionService(ICriterionRepository criterionRepository, IMapper mapper)
            {
                _criterionRepository = criterionRepository;
                _mapper = mapper;
            }

            public async Task<CriterionEntity> GetCriterionByIdAsync(long criterionId)
            {
                var criterion = await _criterionRepository.GetCriterionByIdAsync(criterionId);
                return _mapper.Map<CriterionEntity>(criterion);
            }

            public async Task<IEnumerable<CriterionEntity>> GetAllCriterionAsync()
            {
                var criteria = await _criterionRepository.GetAllCriterionAsync();
                return _mapper.Map<IEnumerable<CriterionEntity>>(criteria);
            }

            public async Task<CriterionEntity> AddCriterionAsync(CriterionEntity criterion)
            {
                var dbCriterion = _mapper.Map<Criterion>(criterion);
                await _criterionRepository.AddCriterionAsync(dbCriterion);
                return criterion;
            }

            public async Task<CriterionEntity> UpdateCriterionAsync(CriterionEntity criterion)
            {
                var dbCriterion = _mapper.Map<Criterion>(criterion);
                await _criterionRepository.UpdateCriterionAsync(dbCriterion);
                return criterion;
            }

            public async Task DeleteCriterionAsync(long criterionId)
            {
                await _criterionRepository.DeleteCriterionAsync(criterionId);
            }
        }
    }
