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
    public class ThresholdService : IThresholdService
    
    {
        private readonly IThresholdRepository _thresholdRepository;
        private readonly IMapper _mapper;

        public ThresholdService(IThresholdRepository thresholdRepository, IMapper mapper)
        {
            _thresholdRepository = thresholdRepository;
            _mapper = mapper;
        }

        public async Task<ThresholdEntity> GetThresholdByIdAsync(long id)
        {
            var dbThreshold = await _thresholdRepository.GetThresholdByIdAsync(id);
            return _mapper.Map<ThresholdEntity>(dbThreshold);
        }

        public async Task<IEnumerable<ThresholdEntity>> GetAllThresholdsAsync()
        {
            var dbThresholds = await _thresholdRepository.GetAllThresholdsAsync();
            return _mapper.Map<IEnumerable<ThresholdEntity>>(dbThresholds);
        }

        public async Task AddThresholdAsync(ThresholdEntity threshold)
        {
            var dbThreshold = _mapper.Map<Threshold>(threshold);
            await _thresholdRepository.AddThresholdAsync(dbThreshold);
        }

        public async Task UpdateThresholdAsync(ThresholdEntity threshold)
        {
            var dbThreshold = _mapper.Map<Threshold>(threshold);
            await _thresholdRepository.UpdateThresholdAsync(dbThreshold);
        }

        public async Task DeleteThresholdAsync(long id)
        {
            await _thresholdRepository.DeleteThresholdAsync(id);
        }
    }

}

