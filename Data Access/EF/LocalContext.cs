using System.Data.Entity;
using Domain.Entities;

namespace Data_Access.EF
{
    public class LocalContext : DbContext
    {
        public DbSet<Friend> Friends { get; set; }
    }
}
