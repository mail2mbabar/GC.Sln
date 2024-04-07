using Infrastructure.Repository.Implementations;
using Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DBmodels.Configuration
{
    public class ServiceModule
    {
        public static void Register(IServiceCollection services)
        {
            // services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IConstraintRepository, ConstraintRepository>();
            services.AddTransient<ICriterionRepository, CriterionRepository>();
            services.AddTransient<IEvaluationRepository, EvaluationRepository>();
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IOptionRepository, OptionRepository>();
            services.AddTransient<IPreferenceRepository, PreferenceRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IThresholdRepository, ThresholdRepository>();
        }
    }
}
