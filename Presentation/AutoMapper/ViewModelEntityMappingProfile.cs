using AutoMapper;
using Domain.Entities;
using Presentation.ViewModels;

namespace Presentation.AutoMapper
{
    public class ViewModelEntityMappingProfile : Profile
    {
        public ViewModelEntityMappingProfile()
        {
            CreateMap<UserViewModel, User>();
            //CreateMap<ProductViewModel, Product>();
        }
        
        public override string ProfileName
        {
            get { return "ViewModelEntityMappings"; }
        }
    }
}