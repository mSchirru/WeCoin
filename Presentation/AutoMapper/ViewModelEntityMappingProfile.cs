using AutoMapper;
using Domain.Entities;
using Presentation.ViewModels;

namespace Presentation.AutoMapper
{
    public class ViewModelEntityMappingProfile : Profile
    {
        public ViewModelEntityMappingProfile()
        {
            CreateMap<ApplicationUserViewModel, ApplicationUser>();
            CreateMap<PostViewModel, Post>();
        }
        
        public override string ProfileName
        {
            get { return "ViewModelEntityMappings"; }
        }
    }
}