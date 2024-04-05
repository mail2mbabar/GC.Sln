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
        public class PreferenceRepository : IPreferenceRepository
        {
            private readonly GcContext _context;

            public PreferenceRepository(GcContext context)
            {
                _context = context;
            }

            public async Task<Preference> GetPreferenceByIdAsync(int preferenceId)
            {
                return await _context.Preferences.FindAsync(preferenceId);
            }

            public async Task<List<Preference>> GetAllPreferencesAsync()
            {
                return await _context.Preferences.ToListAsync();
            }

            public async Task AddPreferenceAsync(Preference preference)
            {
                _context.Preferences.Add(preference);
                await _context.SaveChangesAsync();
            }

            public async Task UpdatePreferenceAsync(Preference preference)
            {
                _context.Entry(preference).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task DeletePreferenceAsync(int preferenceId)
            {
                var preference = await _context.Preferences.FindAsync(preferenceId);
                if (preference != null)
                {
                    _context.Preferences.Remove(preference);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
