using WebApp.Models;

namespace WebApp.Data
{
    public interface IUserRepository
    {
        User Create(User user);

        User GetByEmail(string email);

        User GetById(int id);

        GraphModel CreateGraph(User user, GraphModel graph);

        GraphModel ReadGraph(string graphName, User user);

        GraphModel UpdateGraph(User user, string graphName, string newData);

    }
}
