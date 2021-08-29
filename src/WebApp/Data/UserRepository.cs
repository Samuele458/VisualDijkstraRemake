using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApp.Models;

namespace WebApp.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            _context.Users.Add(user);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new DuplicatedUserException();
            }

            return user;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return _context
                        .Users
                        .Include(u => u.Graphs)
                        .FirstOrDefault(u => u.Id == id);

        }

        public void DeleteUser(int id)
        {
            User user = GetById(id);

            if (user != default(User))
            {
                _context
                    .Users
                    .Remove(user);
                _context.SaveChanges();
            }
            else
            {
                throw new UserNotFoundException();
            }
        }

    }


    public class DuplicatedUserException : Exception
    {
        public DuplicatedUserException(string message = "") : base(message) { }
    }

    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message = "") : base(message) { }
    }
}
