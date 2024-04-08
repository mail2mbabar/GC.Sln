using DBmodels.Configuration;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;


namespace Infrastructure.Repository.Implementations
{
    public class GcAttributeRepository : GenericRepository<GcAttribute>, IGcAttributeRepository
    {
        private readonly GcContext _context;

        public GcAttributeRepository(GcContext context) : base(context)
        {
            _context = context;
        }
        public async Task<GcAttribute> GetGcAttributeByIdAsync(int gcAttributeId)
        {
            return await this.GetById(gcAttributeId);
        }

        public async Task<List<GcAttribute>> GetAllGcAttributesAsync()
        {
            return await this.ToListAsync();
        }

        public async Task AddGcAttributeAsync(GcAttribute gcAttribute)
        {
            await this.Insert(gcAttribute);
        }

        public async Task UpdateGcAttributeAsync(GcAttribute gcAttribute)
        {
            await this.Update(gcAttribute);
        }

        public async Task DeleteGcAttributeAsync(int gcAttributeId)
        {
            var gcAttribute = await _context.GcAttributes.FindAsync(gcAttributeId);
            if (gcAttribute != null)
            {
                await this.Delete(gcAttribute);
            }
        }
    }
}
