using AutoMapper;
using Domain.Entities;
using Presentation.ViewModels;

namespace Presentation.AutoMapper
{
    public class EntityViewModelMappingProfile : Profile
    {
        public EntityViewModelMappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserViewModel>();
            CreateMap<Post, PostViewModel>();
        }

        public override string ProfileName
        {
            get { return "EntityViewModelMappings"; }
        }
    }
}