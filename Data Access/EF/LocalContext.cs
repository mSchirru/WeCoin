using Data_Access.Domain;
using System.Data.Entity;

namespace Data_Access
{
    public class LocalContext : DbContext
    {
        public DbSet<Friend> Friends { get; set; }
    }
}
