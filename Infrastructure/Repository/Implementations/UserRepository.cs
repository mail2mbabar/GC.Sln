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
        public class UserRepository : IUserRepository
        {
            private readonly GcContext _context;

            public UserRepository(GcContext context)
            {
                _context = context;
            }

            public async Task<User> GetUserByIdAsync(int userId)
            {
                return await _context.Users.FindAsync(userId);
            }

            public async Task<List<User>> GetAllUsersAsync()
            {
                return await _context.Users.ToListAsync();
            }

            public async Task AddUserAsync(User user)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateUserAsync(User user)
            {
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task DeleteUserAsync(int userId)
            {
                var user = await _context.Users.FindAsync(userId);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
