using DBmodels.Configuration;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Implementations
{
        public class EvaluationRepository : IEvaluationRepository
        {
            private readonly GcContext _context;

            public EvaluationRepository(GcContext context)
            {
                _context = context;
            }

            public async Task<Evaluation> GetEvaluationByIdAsync(int evaluationId)
            {
                return await _context.Evaluations.FindAsync(evaluationId);
            }

            public async Task<List<Evaluation>> GetAllEvaluationsAsync()
            {
                return await _context.Evaluations.ToListAsync();
            }

            public async Task AddEvaluationAsync(Evaluation evaluation)
            {
                _context.Evaluations.Add(evaluation);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateEvaluationAsync(Evaluation evaluation)
            {
                _context.Entry(evaluation).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task DeleteEvaluationAsync(int evaluationId)
            {
                var evaluation = await _context.Evaluations.FindAsync(evaluationId);
                if (evaluation != null)
                {
                    _context.Evaluations.Remove(evaluation);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
