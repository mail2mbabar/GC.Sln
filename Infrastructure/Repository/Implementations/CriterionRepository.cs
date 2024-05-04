﻿using DBmodels.Configuration;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;


namespace Infrastructure.Repository.Implementations
{
    public class CriterionRepository : GenericRepository<Criterion>, ICriterionRepository
    {
        private readonly GcContext _context;

        public CriterionRepository(GcContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Criterion> GetCriterionByIdAsync(long criterionId)
        {
            return await this.GetById(criterionId);
        }

        public async Task AddCriterionAsync(Criterion criterion)
        {
            await this.Insert(criterion);
        }

        public async Task UpdateCriterionAsync(Criterion criterion)
        {
            await this.Update(criterion);
        }

        public async Task DeleteCriterionAsync(long criterionId)
        {
            var criterion = await _context.Criterions.FindAsync(criterionId);
            if (criterion != null)
            {
                await this.Delete(criterion);
            }
        }

        public async Task<List<Criterion>> GetAllCriterionAsync()
        {
            return await this.ToListAsync();
        }
    }

}

