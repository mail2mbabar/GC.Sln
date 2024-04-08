using DBmodels.Configuration;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;


namespace Infrastructure.Repository.Implementations
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        private readonly GcContext _context;

        public MemberRepository(GcContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Member> GetMemberByIdAsync(int memberId)
        {
            return await this.GetById(memberId);
        }

        public async Task<List<Member>> GetAllMembersAsync()
        {
            return await this.ToListAsync();
        }

        public async Task AddMemberAsync(Member member)
        {
            await this.Insert(member);
        }

        public async Task UpdateMemberAsync(Member member)
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
