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
            user.Id = _context.SaveChanges();

            return user;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public GraphModel CreateGraph(User user, GraphModel graph)
        {
            //GetById(userId).Graphs.Add(graph);
            graph.User = user;
            user.Graphs.Add(graph);
            _context.Graphs.Add(graph);
            graph.Id = _context.SaveChanges();

            return graph;
        }


    }
}
