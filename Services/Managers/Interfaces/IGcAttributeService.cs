using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Managers.Interfaces
{
    public interface IGcAttributeService
    {
        Task<GcAttributeEntity> GetGcAttributeByIdAsync(long gcAttributeId);
        Task<IEnumerable<GcAttributeEntity>> GetAllGcAttributesAsync();
        Task<GcAttributeEntity> AddGcAttributeAsync(GcAttributeEntity gcAttribute);
        Task<GcAttributeEntity> UpdateGcAttributeAsync(GcAttributeEntity gcAttribute);
        Task DeleteGcAttributeAsync(long gcAttributeId);
    }
}
