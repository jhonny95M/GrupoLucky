using Lucky.Entities;
using Lucky.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucky.Repositories.EFCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(User user)=>
            await _context.AddAsync(user);

        public Task<IEnumerable<User>> GetAll()
        {
          return Task.FromResult(_context.Users.AsEnumerable());
        }
    }
}
