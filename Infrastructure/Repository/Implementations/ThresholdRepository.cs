using DBmodels.Configuration;
using DBmodels.Models;
using InfraStructuree.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructuree.Repository.Implementations
{
        public class ThresholdRepository : IThresholdRepository
        {
            private readonly GcContext _context;

            public ThresholdRepository(GcContext context)
            {
                _context = context;
            }

            public async Task<Threshold> GetThresholdByIdAsync(int thresholdId)
            {
                return await _context.Thresholds.FindAsync(thresholdId);
            }

            public async Task<List<Threshold>> GetAllThresholdsAsync()
            {
                return await _context.Thresholds.ToListAsync();
            }

            public async Task AddThresholdAsync(Threshold threshold)
            {
                _context.Thresholds.Add(threshold);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateThresholdAsync(Threshold threshold)
            {
                _context.Entry(threshold).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task DeleteThresholdAsync(int thresholdId)
            {
                var threshold = await _context.Thresholds.FindAsync(thresholdId);
                if (threshold != null)
                {
                    _context.Thresholds.Remove(threshold);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }


