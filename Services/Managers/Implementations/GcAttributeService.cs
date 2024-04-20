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
        public class GcAttributeService : IGcAttributeService
        {
            private readonly IGcAttributeRepository _gcAttributeRepository;
            private readonly IMapper _mapper;

            public GcAttributeService(IGcAttributeRepository gcAttributeRepository, IMapper mapper)
            {
                _gcAttributeRepository = gcAttributeRepository;
                _mapper = mapper;
            }

            public async Task<GcAttributeEntity> GetGcAttributeByIdAsync(long gcAttributeId)
            {
                var gcAttribute = await _gcAttributeRepository.GetGcAttributeByIdAsync(gcAttributeId);
                return _mapper.Map<GcAttributeEntity>(gcAttribute);
            }

            public async Task<IEnumerable<GcAttributeEntity>> GetAllGcAttributesAsync()
            {
                var gcAttributes = await _gcAttributeRepository.GetAllGcAttributesAsync();
                return _mapper.Map<IEnumerable<GcAttributeEntity>>(gcAttributes);
            }

            public async Task<GcAttributeEntity> AddGcAttributeAsync(GcAttributeEntity gcAttribute)
            {
                var dbGcAttribute = _mapper.Map<GcAttribute>(gcAttribute);
                await _gcAttributeRepository.AddGcAttributeAsync(dbGcAttribute);
                return gcAttribute;
            }

            public async Task<GcAttributeEntity> UpdateGcAttributeAsync(GcAttributeEntity gcAttribute)
            {
                var dbGcAttribute = _mapper.Map<GcAttribute>(gcAttribute);
                await _gcAttributeRepository.UpdateGcAttributeAsync(dbGcAttribute);
                return gcAttribute;
            }

            public async Task DeleteGcAttributeAsync(long gcAttributeId)
            {
                await _gcAttributeRepository.DeleteGcAttributeAsync(gcAttributeId);
            }
        }
}

