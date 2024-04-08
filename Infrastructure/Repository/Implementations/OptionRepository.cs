using DBmodels.Configuration;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;


namespace Infrastructure.Repository.Implementations
{
    public class OptionRepository : GenericRepository<Option>, IOptionRepository
    {
        private readonly GcContext _context;

        public OptionRepository(GcContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Option> GetOptionByIdAsync(int optionId)
        {
            return await this.GetById(optionId);
        }

        public async Task<List<Option>> GetAllOptionsAsync()
        {
            return await this.ToListAsync();
        }

        public async Task AddOptionAsync(Option option)
        {
            await this.Insert(option);
        }

        public async Task UpdateOptionAsync(Option option)
        {
            await this.Update(option);
        }

        public async Task DeleteOptionAsync(int optionId)
        {
            var option = await _context.Options.FindAsync(optionId);
            if (option != null)
            {
                await this.Delete(option);
            }
        }
    }
}
