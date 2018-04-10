using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;

namespace Domain.Entities
{
    [JsonObject]
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public override string PasswordHash { get; set; }
        public override string SecurityStamp { get; set; }
        public string ImgUrl { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }


        public virtual bool ShouldSerializeName() => true;
        public virtual bool ShouldSerializeEmail() => true;
        public virtual bool ShouldSerializePhoneNumber() => true;
        public virtual bool ShouldSerializeUserName() => true;
        public virtual bool ShouldSerializeId() => true;
        public virtual bool ShouldSerializePasswordHash() => false;
        public virtual bool ShouldSerializeSecurityStamp() => false;


        public virtual ICollection<Friendship> Friendships { get; set; }
        public virtual ICollection<Friendship> Friends { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Reaction> Reactions { get; set; }
    }
}
