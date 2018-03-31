using AutoMapper;
using Domain.Entities;
using Presentation.ViewModels;

namespace Presentation.AutoMapper
{
    public class EntityViewModelMappingProfile : Profile
    {
        public EntityViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();
            //CreateMap<ProductViewModel, Product>();
        }

        public override string ProfileName
        {
            get { return "EntityViewModelMappings"; }
        }
    }
}