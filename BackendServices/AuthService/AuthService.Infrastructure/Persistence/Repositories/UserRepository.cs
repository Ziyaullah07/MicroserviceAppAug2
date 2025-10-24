using AuthService.Application.Repositories;
using AuthService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        AuthServiceDbContext _db;
        public UserRepository(AuthServiceDbContext db)
        {
            _db = db;
        }
        public IEnumerable<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User GetUserByEmail(string email)
        {
            return _db.Users.Include(u=>u.Roles).FirstOrDefault(u => u.Email == email);
        }

        public bool RegisterUser(User user, string role)
        {
            Role existingRole = _db.Roles.FirstOrDefault(r => r.Name ==role);
            if (existingRole == null)
            {
                return false;
            }
            user.Roles.Add(existingRole);
            _db.Users.Add(user);
            _db.SaveChanges();
            return true;

        }
    }
}
