using WebApp.Models;

namespace WebApp.Data
{
    public interface IGraphRepository
    {

        GraphModel CreateGraph(User user, GraphModel graph);

        GraphModel ReadGraph(int graphId, User user);

        GraphModel UpdateGraphData(User user, int graphId, string newData);

        GraphModel UpdateGraphName(User user, int graphId, string newName);
    }
}
