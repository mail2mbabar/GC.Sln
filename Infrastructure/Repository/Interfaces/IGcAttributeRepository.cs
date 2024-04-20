using DBmodels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interfaces
{
    public interface IGcAttributeRepository
    {
        Task<GcAttribute> GetGcAttributeByIdAsync(long gcAttributeId);
        Task<List<GcAttribute>> GetAllGcAttributesAsync();
        Task AddGcAttributeAsync(GcAttribute gcAttribute);
        Task UpdateGcAttributeAsync(GcAttribute gcAttribute);
        Task DeleteGcAttributeAsync(long gcAttributeId);
    }
}
