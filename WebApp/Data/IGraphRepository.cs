using WebApp.Models;

namespace WebApp.Data
{
    public interface IGraphRepository
    {

        GraphModel CreateGraph(User user, GraphModel graph);

        GraphModel ReadGraph(int graphId, User user);

        GraphModel UpdateGraph(User user, int graphId, string newData);
    }
}
