using DBmodels.Configuration;
using DBmodels.Models;
using Infrastructure.Repository.Interfaces;


namespace Infrastructure.Repository.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly GcContext _context;

        public UserRepository(GcContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await this.GetById(userId);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await this.ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await this.Insert(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await this.Update(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                await this.Delete(user);
            }
        }
    }
}
