using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Services.Managers.Implementations;
using Services.Managers.Interfaces;
using Services.Profile;

namespace Services.Managers.Configuration
{
    public class ServiceModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
