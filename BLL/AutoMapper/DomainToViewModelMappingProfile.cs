using AutoMapper;
using Data_Access.Domain;
using WebTest.ViewModels;

namespace WebTest.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Friend, FriendViewModel>();
        }

        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
    }
}