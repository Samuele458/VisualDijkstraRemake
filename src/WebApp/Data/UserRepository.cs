using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApp.Models;

namespace WebApp.Data
{
    /// <summary>
    ///  User repository class
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public User GetByEmail(string email)
        {
            return _context
                        .Users
                        .Include(u => u.Verification)
                        .FirstOrDefault(u => u.Email == email);
        }

        /// <inheritdoc/>
        public User GetById(int id)
        {
            return _context
                        .Users
                        .Include(u => u.Graphs)
                        .FirstOrDefault(u => u.Id == id);

        }

        /// <inheritdoc/>
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
