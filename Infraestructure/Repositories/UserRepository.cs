using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Task.FromResult(new List<User>
            {
                new User { Id = 1, Name = "Juan", Email = "juan@bipass.com" },
                new User { Id = 2, Name = "Ana", Email = "ana@bipass.com" }
            });
        }
    }
}
