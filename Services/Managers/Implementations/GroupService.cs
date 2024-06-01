using AutoMapper;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;
using Services.DTOs;
using Services.Entities;
using Services.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<GroupResponseDto> GetGroupByIdAsync(Guid groupId)
        {
            var group = await _groupRepository.GetGroupByIdAsync(groupId);
            if (group == null)
            {
                return null;
            }
            return _mapper.Map<GroupResponseDto>(group);
        }

        public async Task<IEnumerable<GroupResponseDto>> GetAllGroupsAsync()
        {
            var groups = await _groupRepository.GetAllGroupsAsync();
            return _mapper.Map<IEnumerable<GroupResponseDto>>(groups);
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
