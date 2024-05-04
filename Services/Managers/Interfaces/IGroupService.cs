using Services.Entities;

namespace Services.Managers.Interfaces
{
    public interface IGroupService
    {
            Task<GroupEntity> GetGroupByIdAsync(Guid groupId);
            Task<IEnumerable<GroupEntity>> GetAllGroupsAsync();
            Task<GroupEntity> AddGroupAsync(GroupEntity group);
            Task<GroupEntity> UpdateGroupAsync(GroupEntity group);
            Task DeleteGroupAsync(Guid groupId);
    }
}