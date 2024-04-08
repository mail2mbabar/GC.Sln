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
                return await _context.Criterions.FindAsync(criterionId);
            }

            public async Task<List<Criterion>> GetAllCriterionsAsync()
            {
                return await _context.Criterions.ToListAsync();
            }

            public async Task AddCriterionAsync(Criterion criterion)
            {
                _context.Criterions.Add(criterion);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateCriterionAsync(Criterion criterion)
            {
                _context.Entry(criterion).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task DeleteCriterionAsync(int criterionId)
            {
                var criterion = await _context.Criterions.FindAsync(criterionId);
                if (criterion != null)
                {
                    _context.Criterions.Remove(criterion);
                    await _context.SaveChangesAsync();
                }
            }
        }
    
}
