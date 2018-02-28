using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Data_Access.EF;
using Domain.Entities;

namespace BLL
{
    public class HomeLogic
    {
        private LocalContext lc = new LocalContext();
        
        public List<FriendViewModelClone> GetFriends()
        {
            List<FriendViewModelClone> friendViewModel = (List<FriendViewModelClone>) Mapper.Map<IEnumerable<Friend>, IEnumerable<FriendViewModelClone>>(lc.Friends.ToList());
            List<int> bestFriendIds = (List<int>) HttpContext.Current.Session["BestFriendIds"];

            foreach (var friend in bestFriendIds)
                friendViewModel.Find(f => f.Id == friend).IsBestFriend = true;

            return friendViewModel;
        }

        public void SetBestFriend(int friendId)
        {
            List<int> bestFriendIds = (List<int>) HttpContext.Current.Session["BestFriendIds"];
            bestFriendIds.Add(friendId);

            HttpContext.Current.Session["BestFriendIds"] = bestFriendIds;
        }

        public void RemoveBestFriend(int friendId)
        {
            List<int> bestFriendIds = (List<int>) HttpContext.Current.Session["BestFriendIds"];
            bestFriendIds.Remove(friendId);

            HttpContext.Current.Session["BestFriendIds"] = bestFriendIds;
        }
    }
}
