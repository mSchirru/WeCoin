using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Linq;

namespace Repositories.Repositories
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUser GetUserById(string id)
        {
            return Rc.Users.SingleOrDefault(u => u.Id.Equals(id));
        }

        public IEnumerable<ApplicationUser> GetUsersByName(string userName)
        {
            return Rc.Users.Where(u => u.Name.ToLower().Contains(userName.ToLower())).ToList();
        }

        public IEnumerable<Friendship> GetUserFriends(string userId)
        {
            return Rc.Users.SingleOrDefault(u => u.Id.Equals(userId)).Friends.ToList();
        }

        public int RequestUserFriendship(string fromUserId, string toUserId)
        {
            Friendship fp = new Friendship()
            {
                Accepted = false,
                FromApplicationUserId = fromUserId,
                ToApplicationUserId = toUserId
            };

            Friendship fp2 = new Friendship()
            {
                Accepted = false,
                FromApplicationUserId = toUserId,
                ToApplicationUserId = fromUserId
            };

            GetUserById(fromUserId).Friends.Add(fp);
            GetUserById(toUserId).Friends.Add(fp2);

            return Rc.SaveChanges();
        }

        public int AcceptUserFriendship(string fromUserId, string toUserId)
        {
            ApplicationUser appUser = Rc.Users.SingleOrDefault(u => u.Id.Equals(fromUserId));
            ApplicationUser appUser2 = Rc.Users.SingleOrDefault(u => u.Id.Equals(toUserId));

            Friendship friendship = appUser.Friendships.SingleOrDefault(f => f.FromApplicationUserId.Equals(toUserId) &&
                                    f.ToApplicationUserId.Equals(fromUserId));
            friendship.Accepted = true;

            Friendship friendship2 = appUser2.Friendships.SingleOrDefault(f => f.FromApplicationUserId.Equals(fromUserId) &&
                                    f.ToApplicationUserId.Equals(toUserId));
            friendship2.Accepted = true;

            return Rc.SaveChanges();
        }

        public int EditUserWithPhoto(ApplicationUser appUser)
        {
            ApplicationUser applicationUser = GetUserById(appUser.Id);

            applicationUser.Name = appUser.Name;
            applicationUser.Email = appUser.Email;
            applicationUser.BirthDate = appUser.BirthDate;
            applicationUser.WalletAddress = appUser.WalletAddress;
            applicationUser.ImgUrl = appUser.ImgUrl;
            return Rc.SaveChanges();
        }

        public int EditUser(ApplicationUser appUser)
        {
            ApplicationUser applicationUser = GetUserById(appUser.Id);

            applicationUser.Name = appUser.Name;
            applicationUser.Email = appUser.Email;
            applicationUser.BirthDate = appUser.BirthDate;
            applicationUser.WalletAddress = appUser.WalletAddress;
            return Rc.SaveChanges();
        }

        public int CreateUserPost(string userId, Post post)
        {
            Rc.Users.SingleOrDefault(u => u.Id == userId).Posts.Add(post);
            return Rc.SaveChanges();
        }
    }
}