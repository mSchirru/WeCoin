using Domain.Entities;
using System.Collections.Generic;
using Repositories.Repositories;

namespace Services
{
    public class ApplicationUserService
    {
        private readonly ApplicationUserRepository Ur = new ApplicationUserRepository();

        public IEnumerable<ApplicationUser> GetAll()
        {
            return Ur.GetAll();
        }
    }
}
