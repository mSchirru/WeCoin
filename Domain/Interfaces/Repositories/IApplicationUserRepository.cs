using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IApplicationUserRepository : IBaseRepository<ApplicationUser>
    {
        IEnumerable<ApplicationUser> GetUsersByName(string userName);
    }
}
