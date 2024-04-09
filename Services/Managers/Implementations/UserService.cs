namespace Services.Managers.Implementations
{
    using AutoMapper;
    using DBmodels.Models;
    using Infrastructure.Repository.Interfaces;
    using Services.Entities;
    using Services.Managers.Interfaces;
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserEntity> GetUserByIdAsync(Guid id)
        {
            var dbUser = await _userRepository.GetUserByIdAsync(id);
            var user = _mapper.Map<UserEntity>(dbUser);

            return user;
        }
        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {
            var dbUsers = await _userRepository.GetAllUsersAsync();
            var users = _mapper.Map<IEnumerable<UserEntity>>(dbUsers);

            return users;
        }
        public async Task<UserEntity> AddUserAsync(UserEntity user)
        {
            var dbUser = _mapper.Map<User>(user);
            dbUser.CreatedDate = DateTime.Now;
            dbUser.UpdatedDate = DateTime.Now;
            await _userRepository.AddUserAsync(dbUser);

            return user;
        }
        public async Task<UserEntity> UpdateUserAsync(UserEntity user)
        {
            var dbUser = _mapper.Map<User>(user);
            await _userRepository.UpdateUserAsync(dbUser);

            return user;
        }
        public async Task DeleteUserAsync(Guid id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
