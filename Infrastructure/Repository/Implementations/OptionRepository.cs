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
        public class OptionRepository : IOptionRepository
        {
            private readonly GcContext _context;

            public OptionRepository(GcContext context)
            {
                _context = context;
            }

            public async Task<Option> GetOptionByIdAsync(int optionId)
            {
                return await _context.Options.FindAsync(optionId);
            }

            public async Task<List<Option>> GetAllOptionsAsync()
            {
                return await _context.Options.ToListAsync();
            }

            public async Task AddOptionAsync(Option option)
            {
                _context.Options.Add(option);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateOptionAsync(Option option)
            {
                _context.Entry(option).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task DeleteOptionAsync(int optionId)
            {
                var option = await _context.Options.FindAsync(optionId);
                if (option != null)
                {
                    _context.Options.Remove(option);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
