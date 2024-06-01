namespace Services.Managers.Implementations
{
    using AutoMapper;
    using DBmodels.Models;
    using global::Services.DTOs;
    using global::Services.Entities;
    using global::Services.Managers.Interfaces;
    using Infrastructure.Repository.Interfaces;
    public class UserService : IUserService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(ITokenService tokenService, IUserRepository userRepository, IMapper mapper)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserResponseDTO> AuthenticateUserAsync(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return new UserResponseDTO();
            }

            var authenticatedUser = await AuthenticatedUser(userId);

            if (authenticatedUser is null || authenticatedUser.UserId == Guid.Empty)
                return new UserResponseDTO();

            return await GetUserResponse(authenticatedUser);
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

        #region private Methods

        private async Task<UserEntity> AuthenticatedUser(Guid userId)
        {
            var dbUser = await _userRepository.GetUserByIdAsync(userId);
            var userEntity = _mapper.Map<UserEntity>(dbUser);

            return userEntity;
        }

        private async Task<UserResponseDTO> GetUserResponse(UserEntity user)
        {
            return new UserResponseDTO()
            {
                FullName = user.FullName,
                Token = await this._tokenService.GetTokenAsync(user)
            };
        }

        #endregion
    }
}
