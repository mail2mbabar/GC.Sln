
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
        Task<Group> GetMemberByIdAsync(int memberId);
        Task<List<Group>> GetAllMembersAsync();
        Task AddMemberAsync(Group member);
        Task UpdateMemberAsync(Group member);
        Task DeleteMemberAsync(int memberId);
    }
}
