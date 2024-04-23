using AutoMapper;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Services.Entities;
using Services.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Managers.Implementations
{
    public class StageService : IStageService
    {
        private readonly IStageRepository _stageRepository;
        private readonly IMapper _mapper;

        public StageService(IStageRepository stageRepository, IMapper mapper)
        {
            _stageRepository = stageRepository;
            _mapper = mapper;
        }

        public async Task<StageEntity> GetStageByIdAsync(long id)
        {
            var dbStage = await _stageRepository.GetStageByIdAsync(id);
            return _mapper.Map<StageEntity>(dbStage);
        }

        public async Task<IEnumerable<StageEntity>> GetAllStagesAsync()
        {
            var dbStages = await _stageRepository.GetAllStagesAsync();
            return _mapper.Map<IEnumerable<StageEntity>>(dbStages);
        }

        public async Task AddStageAsync(StageEntity stage)
        {
            var dbStage = _mapper.Map<Stage>(stage);
            await _stageRepository.AddStageAsync(dbStage);
        }

        public async Task UpdateStageAsync(StageEntity stage)
        {
            var dbStage = _mapper.Map<Stage>(stage);
            await _stageRepository.UpdateStageAsync(dbStage);
        }

        public async Task DeleteStageAsync(long id)
        {
            await _stageRepository.DeleteStageAsync(id);
        }
    }

}

