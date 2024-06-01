using Services.DTOs;
using Services.Entities;

namespace Services.Managers.Interfaces
{
    public interface IGroupService
    {
            Task<GroupResponseDto> GetGroupByIdAsync(Guid groupId);
            Task<IEnumerable<GroupResponseDto>> GetAllGroupsAsync();
            Task<GroupEntity> AddGroupAsync(GroupEntity group);
            Task<GroupEntity> UpdateGroupAsync(GroupEntity group);
            Task DeleteGroupAsync(Guid groupId);
    }
}