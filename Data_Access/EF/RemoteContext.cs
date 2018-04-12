using System.Data.Entity;
using Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data_Access.EF
{
    public class RemoteContext : IdentityDbContext<ApplicationUser>
    {
        public static RemoteContext Create()
        {
            return new RemoteContext();
        }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Friendships)
                .WithRequired(e => e.ToApplicationUser)
                .HasForeignKey(e => e.ToApplicationUserId)
                .WillCascadeOnDelete(false);

            dbModelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Friends)
                .WithRequired(e => e.FromApplicationUser)
                .HasForeignKey(e => e.FromApplicationUserId)
                .WillCascadeOnDelete(false);

            dbModelBuilder.Entity<Wallet>()
                .HasRequired(w => w.WalletOwner)
                .WithMany(u => u.Wallets)
                .HasForeignKey(w => w.ApplicationUserId)
                .WillCascadeOnDelete(false);

            dbModelBuilder.Entity<Wallet>()
                .HasIndex(w => w.WalletAddress)
                .IsUnique();

            dbModelBuilder.Entity<Wallet>()
                .Property(w => w.WalletAddress)
                .HasMaxLength(300);

            dbModelBuilder.Entity<Notification>()
                .HasRequired(n => n.NotifiedApplicationUser)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.NotifiedApplicationUserId)
                .WillCascadeOnDelete(false);

            dbModelBuilder.Entity<Post>()
                .HasRequired(p => p.Author)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.ApplicationUserId)
                .WillCascadeOnDelete(false);

            dbModelBuilder.Entity<Reaction>()
                .HasRequired(r => r.ReactionOwner)
                .WithMany(u => u.Reactions)
                .HasForeignKey(r => r.ApplicationUserId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(dbModelBuilder);
        }
    }

}
