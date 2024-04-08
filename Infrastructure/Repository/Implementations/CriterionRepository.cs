using DBmodels.Configuration;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;


namespace Infrastructure.Repository.Implementations
{
    public class CriterionRepository : ICriterionRepository
        {
            private readonly GcContext _context;

            public CriterionRepository(GcContext context)
            {
                _context = context;
            }

            public async Task<Criterion> GetCriterionByIdAsync(int criterionId)
            {
                return await _context.Criteria.FindAsync(criterionId);
            }

            public async Task<List<Criterion>> GetAllCriteriaAsync()
            {
                return await _context.Criteria.ToListAsync();
            }

            public async Task AddCriterionAsync(Criterion criterion)
            {
                _context.Criteria.Add(criterion);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateCriterionAsync(Criterion criterion)
            {
                _context.Entry(criterion).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task DeleteCriterionAsync(int criterionId)
            {
                var criterion = await _context.Criteria.FindAsync(criterionId);
                if (criterion != null)
                {
                    _context.Criteria.Remove(criterion);
                    await _context.SaveChangesAsync();
                }
            }
        }
    
}
