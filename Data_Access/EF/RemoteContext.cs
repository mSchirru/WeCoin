using System.Data.Entity;
using Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data_Access.EF
{
    public class RemoteContext : IdentityDbContext<ApplicationUser>
    {
        public virtual IDbSet<User> UsersInfos { get; set; }

        public static RemoteContext Create()
        {
            return new RemoteContext();
        }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Entity<User>()
                .HasMany(e => e.Friendships)
                .WithRequired(e => e.ToUser)
                .HasForeignKey(e => e.ToUserId)
                .WillCascadeOnDelete(false);

            dbModelBuilder.Entity<User>()
                .HasMany(e => e.Friendships1)
                .WithRequired(e => e.FromUser)
                .HasForeignKey(e => e.FromUserId)
                .WillCascadeOnDelete(false);
            
            dbModelBuilder.Entity<ApplicationUser>()
                .HasRequired(au => au.UserInfo);

            dbModelBuilder.Entity<Wallet>()
                .HasRequired(w => w.WalletOwner)
                .WithMany(u => u.Wallets)
                .HasForeignKey(w => w.UserId)
                .WillCascadeOnDelete(false);

            dbModelBuilder.Entity<Wallet>()
                .HasIndex(w => w.WalletAddress)
                .IsUnique();

            dbModelBuilder.Entity<Wallet>()
                .Property(w => w.WalletAddress)
                .HasMaxLength(300);

            dbModelBuilder.Entity<Notification>()
                .HasRequired(n => n.NotifiedUser)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .WillCascadeOnDelete(false);

            dbModelBuilder.Entity<Post>()
                .HasRequired(p => p.Author)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .WillCascadeOnDelete(false);

            dbModelBuilder.Entity<Reaction>()
                .HasRequired(r => r.ReactionOwner)
                .WithMany(u => u.Reactions)
                .HasForeignKey(r => r.UserId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(dbModelBuilder);
        }
    }

}
