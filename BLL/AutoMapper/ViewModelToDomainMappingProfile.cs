using AutoMapper;
using Data_Access.Domain;
using WebTest.ViewModels;

namespace WebTest.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<FriendViewModel, Friend>();
        }

        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
    }
}