
using DBmodels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interfaces
{
    public interface IGroupRepository
    {
        Task<Group> GetGroupByIdAsync(Guid groupId);
        Task<List<Group>> GetAllGroupsAsync();
        Task AddGroupAsync(Group group);
        Task UpdateGroupAsync(Group group);
        Task DeleteGroupAsync(Guid groupId);
    }
}
