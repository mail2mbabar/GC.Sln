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
        public class OptionService : IOptionService
        {
            private readonly IOptionRepository _optionRepository;
            private readonly IMapper _mapper;

            public OptionService(IOptionRepository optionRepository, IMapper mapper)
            {
                _optionRepository = optionRepository;
                _mapper = mapper;
            }

            public async Task<OptionEntity> GetOptionByIdAsync(long optionId)
            {
                var option = await _optionRepository.GetOptionByIdAsync(optionId);
                return _mapper.Map<OptionEntity>(option);
            }

            public async Task<IEnumerable<OptionEntity>> GetAllOptionsAsync()
            {
                var options = await _optionRepository.GetAllOptionsAsync();
                return _mapper.Map<IEnumerable<OptionEntity>>(options);
            }

            public async Task<OptionEntity> AddOptionAsync(OptionEntity option)
            {
                var dbOption = _mapper.Map<Option>(option);
                await _optionRepository.AddOptionAsync(dbOption);
                return option;
            }

            public async Task<OptionEntity> UpdateOptionAsync(OptionEntity option)
            {
                var dbOption = _mapper.Map<Option>(option);
                await _optionRepository.UpdateOptionAsync(dbOption);
                return option;
            }

            public async Task DeleteOptionAsync(long optionId)
            {
                await _optionRepository.DeleteOptionAsync(optionId);
            }
        }
}