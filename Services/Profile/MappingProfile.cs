
namespace Services.Profile
{
    using AutoMapper;
    using DBmodels.Models;
    using global::Services.DTOs;
    using global::Services.Entities;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserEntity>().ReverseMap();
      
            CreateMap<Role, RoleEntity>().ReverseMap();
            CreateMap<Goal, GoalEntity>().ReverseMap();
            CreateMap<Option, OptionEntity>().ReverseMap();
            CreateMap<Project, ProjectEntity>().ReverseMap();
            CreateMap<Preference, PreferenceEntity>().ReverseMap();
            CreateMap<Stage, StageEntity>().ReverseMap();
            CreateMap<Comment, CommentEntity>().ReverseMap();
            CreateMap<Constraint, ConstraintEntity>().ReverseMap();
            CreateMap<Criterion, CriterionEntity>().ReverseMap();
            CreateMap<GcAttribute, GcAttributeEntity>().ReverseMap();
            CreateMap<Threshold, ThresholdEntity>().ReverseMap();
            CreateMap<Evaluation, EvaluationEntity>().ReverseMap();

            CreateMap<Group, GroupResponseDto>()
       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Project.Name))
       .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
       .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));
        }
    }
}
  
