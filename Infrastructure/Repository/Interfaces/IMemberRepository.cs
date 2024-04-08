
using DBmodels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interfaces
{
    public interface IMemberRepository
    {
        Task<Member> GetMemberByIdAsync(int memberId);
        Task<List<Member>> GetAllMembersAsync();
        Task AddMemberAsync(Member member);
        Task UpdateMemberAsync(Member member);
        Task DeleteMemberAsync(int memberId);
    }
}
