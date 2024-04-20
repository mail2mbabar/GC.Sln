using DBmodels.Configuration;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository.Implementations
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        private readonly GcContext _context;

        public GroupRepository(GcContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Group> GetGroupByIdAsync(Guid groupId)
        {
            return await this.GetById(groupId);
        }

        public async Task<List<Group>> GetAllGroupsAsync()
        {
            return await this.ToListAsync();
        }

        public async Task AddGroupAsync(Group group)
        {
            await this.Insert(group);
        }

        public async Task UpdateGroupAsync(Group group)
        {
            await this.Update(group);
        }

        public async Task DeleteGroupAsync(Guid groupId)
        {
            var group = await _context.Groups.FindAsync(groupId);
            if (group != null)
            {
                await this.Delete(group);
            }
        }

    }
}
