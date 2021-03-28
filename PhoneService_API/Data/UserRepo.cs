using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneService_API.Models;

namespace PhoneService_API.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context)
        {
            _context = context;
        }
         
        public User Get(string username, byte[] password)
        {
            if (string.IsNullOrEmpty(username) || password.Length == 0)
                return null;

            var user = _context.User.FirstOrDefault(x => x.Username.ToLower() == username && x.PasswordHash == password);
            return null;
        }

        public void Create(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.User.Add(user);
        }

        public void UpdateUser(User cmd)
        {
            //
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
