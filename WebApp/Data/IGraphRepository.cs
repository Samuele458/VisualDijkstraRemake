using WebApp.Models;

namespace WebApp.Data
{
    public interface IGraphRepository
    {

        GraphModel CreateGraph(User user, GraphModel graph);

        GraphModel ReadGraph(string graphName, User user);

        GraphModel UpdateGraph(User user, string graphName, string newData);
    }
}
