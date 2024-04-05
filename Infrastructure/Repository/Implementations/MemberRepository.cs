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
        public class MemberRepository : IMemberRepository
        {
            private readonly GcContext _context;

            public MemberRepository(GcContext context)
            {
                _context = context;
            }

            public async Task<Member> GetMemberByIdAsync(int memberId)
            {
                return await _context.Members.FindAsync(memberId);
            }

            public async Task<List<Member>> GetAllMembersAsync()
            {
                return await _context.Members.ToListAsync();
            }

            public async Task AddMemberAsync(Member member)
            {
                _context.Members.Add(member);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateMemberAsync(Member member)
            {
                _context.Entry(member).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task DeleteMemberAsync(int memberId)
            {
                var member = await _context.Members.FindAsync(memberId);
                if (member != null)
                {
                    _context.Members.Remove(member);
                    await _context.SaveChangesAsync();
                }
            }
        }
}

