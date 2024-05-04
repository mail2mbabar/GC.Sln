using AutoMapper;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Services.Entities;
using Services.Managers.Interfaces;

namespace Services.Managers.Implementations
{
        public class GroupService : IGroupService
        {
            private readonly IGroupRepository _groupRepository;
            private readonly IMapper _mapper;

            public GroupService(IGroupRepository groupRepository, IMapper mapper)
            {
                _groupRepository = groupRepository;
                _mapper = mapper;
            }

            public async Task<GroupEntity> GetGroupByIdAsync(Guid groupId)
            {
                var group = await _groupRepository.GetGroupByIdAsync(groupId);
                return _mapper.Map<GroupEntity>(group);
            }

            public async Task<IEnumerable<GroupEntity>> GetAllGroupsAsync()
            {
                var groups = await _groupRepository.GetAllGroupsAsync();
                return _mapper.Map<IEnumerable<GroupEntity>>(groups);
            }

            public async Task<GroupEntity> AddGroupAsync(GroupEntity group)
            {
                var dbGroup = _mapper.Map<Group>(group);
                await _groupRepository.AddGroupAsync(dbGroup);
                return group;
            }

            public async Task<GroupEntity> UpdateGroupAsync(GroupEntity group)
            {
                var dbGroup = _mapper.Map<Group>(group);
                await _groupRepository.UpdateGroupAsync(dbGroup);
                return group;
            }

            public async Task DeleteGroupAsync(Guid groupId)
            {
                await _groupRepository.DeleteGroupAsync(groupId);
            }
        }
    }
