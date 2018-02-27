using AutoMapper;
using Data_Access;
using Data_Access.Domain;
using System.Collections.Generic;
using System.Linq;
using WebTest.ViewModels;

namespace BLL
{
    public class HomeLogic
    {
        private LocalContext lc = new LocalContext();

        public List<FriendViewModel> GetFriends(object session)
        {
            List<FriendViewModel> friendViewModel = (List<FriendViewModel>)Mapper.Map<IEnumerable<Friend>, IEnumerable<FriendViewModel>>(lc.Friends.ToList());
            List<int> BestFriendIds = (List<int>) session;

            foreach (var friend in BestFriendIds)
                friendViewModel.Find(f => f.Id == friend).IsBestFriend = true;

            return friendViewModel;
        }

        public void SetBestFriend(object session, int friendId)
        {
            List<int> BestFriendIds = (List<int>) session;
            BestFriendIds.Add(friendId);

            session = BestFriendIds;
        }

        public void RemoveBestFriend(object session, int friendId)
        {
            List<int> BestFriendIds = (List<int>) session;
            BestFriendIds.Remove(friendId);

            session = BestFriendIds;
        }
    }
}
