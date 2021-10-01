using WebApp.Models;

namespace WebApp.Data
{
    /// <summary>
    ///  User repository interface
    /// </summary>
    public interface IUserRepository
    {

        /// <summary>
        ///  Creates new user
        /// </summary>
        /// <param name="user">User object to be added</param>
        /// <returns>Added user</returns>
        User Create(User user);


        /// <summary>
        ///  Get user by email address
        /// </summary>
        /// <param name="email">Email address</param>
        /// <returns>User object</returns>
        User GetByEmail(string email);


        /// <summary>
        ///  Get user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User object</returns>
        User GetById(int id);


        /// <summary>
        ///  Delete user by id
        /// </summary>
        /// <param name="id">User id</param>
        void DeleteUser(int id);

    }
}
