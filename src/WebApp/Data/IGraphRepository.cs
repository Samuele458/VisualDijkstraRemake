using WebApp.Models;

namespace WebApp.Data
{
    /// <summary>
    ///  Graph repository interface
    /// </summary>
    public interface IGraphRepository
    {
        /// <summary>
        ///  Create new graph
        /// </summary>
        /// <param name="user">User to whom the graph belongs</param>
        /// <param name="graph">Graph to be added</param>
        /// <returns>Added GraphModel</returns>
        GraphModel CreateGraph(User user, GraphModel graph);

        /// <summary>
        ///  Read a specified graph
        /// </summary>
        /// <param name="graphId">Graph id</param>
        /// <param name="user">User to whom the graph belongs</param>
        /// <returns>GraphModel object</returns>
        GraphModel ReadGraph(int graphId, User user);


        /// <summary>
        ///  Updates graph data field
        /// </summary>
        /// <param name="user">User to whom the graph belongs</param>
        /// <param name="graphId">Id of graph to update</param>
        /// <param name="newData">New data field</param>
        /// <returns>Updated graph object</returns>
        GraphModel UpdateGraphData(User user, int graphId, string newData);

        /// <summary>
        ///  Updates graph name field
        /// </summary>
        /// <param name="user">User to whom the graph belongs</param>
        /// <param name="graphId">Id of graph to update</param>
        /// <param name="newName">New name field</param>
        /// <returns>Updated graph object</returns>
        GraphModel UpdateGraphName(User user, int graphId, string newName);


        /// <summary>
        ///  Delete a specified graph
        /// </summary>
        /// <param name="id">Id of graph to be deleted</param>
        /// <param name="user">User to whom the graph belongs</param>
        /// <returns>Deleted graph</returns>
        GraphModel DeleteGraph(int id, User user);
    }
}
