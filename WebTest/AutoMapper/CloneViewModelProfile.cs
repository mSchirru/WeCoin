using AutoMapper;
using BLL;
using WebTest.ViewModels;

namespace WebTest.AutoMapper
{
    public class CloneViewModelProfile : Profile
    {
        public CloneViewModelProfile()
        {
            CreateMap<FriendViewModelClone, FriendViewModel>();
            CreateMap<FriendViewModel, FriendViewModelClone>();
        }

        public override string ProfileName
        {
            get { return "CloneViewModelMappings"; }
        }
    }
}