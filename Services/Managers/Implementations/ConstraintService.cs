using AutoMapper;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Services.Entities;
using Services.Managers.Interfaces;

namespace Services.Managers.Implementations
{

    public class ConstraintService : IConstraintService
    {
        private readonly IConstraintRepository _constraintRepository;
        private readonly IMapper _mapper;

        public ConstraintService(IConstraintRepository constraintRepository, IMapper mapper)
        {
            _constraintRepository = constraintRepository;
            _mapper = mapper;
        }

        public async Task<ConstraintEntity> GetConstraintByIdAsync(long id)
        {
            var dbConstraint = await _constraintRepository.GetConstraintByIdAsync(id);
            return _mapper.Map<ConstraintEntity>(dbConstraint);
        }

        public async Task<IEnumerable<ConstraintEntity>> GetAllConstraintsAsync()
        {
            var dbConstraints = await _constraintRepository.GetAllConstraintsAsync();
            return _mapper.Map<IEnumerable<ConstraintEntity>>(dbConstraints);
        }

        public async Task<ConstraintEntity> AddConstraintAsync(ConstraintEntity constraint)
        {
            var dbConstraint = _mapper.Map<Constraint>(constraint);
            await _constraintRepository.AddConstraintAsync(dbConstraint);
            return constraint;
        }

        public async Task UpdateConstraintAsync(ConstraintEntity constraint)
        {
            var dbConstraint = _mapper.Map<Constraint>(constraint);
            await _constraintRepository.UpdateConstraintAsync(dbConstraint);
        }

        public async Task DeleteConstraintAsync(long id)
        {
            await _constraintRepository.DeleteConstraintAsync(id);
        }
    }

}

