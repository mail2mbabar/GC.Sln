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
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IConstraintService, ConstraintService>();
            services.AddTransient<ICriterionService, CriterionService>();
            services.AddTransient<IEvaluationService, EvaluationService>();
            services.AddTransient<IGcAttributeService, GcAttributeService>();
            services.AddTransient<IGoalService, GoalService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IOptionService, OptionService>();
            services.AddTransient<IPreferenceService, PreferenceService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IStageService, StageService>();
            services.AddTransient<IThresholdService, ThresholdService>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
