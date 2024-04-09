using DBmodels.Configuration;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;


namespace Infrastructure.Repository.Implementations
{
    public class MemberRepository : GenericRepository<Group>, IMemberRepository
    {
        private readonly GcContext _context;

        public MemberRepository(GcContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Group> GetMemberByIdAsync(int memberId)
        {
            return await this.GetById(memberId);
        }

        public async Task<List<Group>> GetAllMembersAsync()
        {
            return await this.ToListAsync();
        }

        public async Task AddMemberAsync(Group member)
        {
            await this.Insert(member);
        }

        public async Task UpdateMemberAsync(Group member)
        {
            await this.Update(member);
        }

        public async Task DeleteMemberAsync(int memberId)
        {
            var member = await _context.Members.FindAsync(memberId);
            if (member != null)
            {
                await this.Delete(member);
            }
        }
    }
}
