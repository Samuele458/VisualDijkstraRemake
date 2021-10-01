using System;
using System.Linq;
using VisualDijkstraLib.Utils;
using WebApp.Models;

namespace WebApp.Data
{
    /// <summary>
    ///  Graph repository class
    /// </summary>
    public class GraphRepository : IGraphRepository
    {

        private readonly UserContext _context;

        public GraphRepository(UserContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public GraphModel CreateGraph(User user, GraphModel graph)
        {
            graph.User = user;

            graph.CreatedOn = DateTime.UtcNow;
            graph.UpdatedOn = DateTime.UtcNow;


            //checking if provided graph is valid or not. If not, exception thrown.
            GraphUtils.decodeGraphFromJSONString(graph.Data);

            user.Graphs.Add(graph);
            _context.Graphs.Add(graph);
            _context.SaveChanges();

            return graph;
        }

        /// <inheritdoc/>
        public GraphModel ReadGraph(int graphId, User user)
        {
            return _context
                        .Graphs
                        .FirstOrDefault(g => g.UserId == user.Id && g.Id == graphId);
        }

        /// <inheritdoc/>
        public GraphModel UpdateGraphData(User user, int graphId, string newData)
        {
            GraphModel graph = _context
                .Graphs
                .FirstOrDefault(g => g.UserId == user.Id && g.Id == graphId);

            if (graph != default(GraphModel))
            {
                //checking if provided graph is valid or not. If not, exception thrown.
                GraphUtils.decodeGraphFromJSONString(graph.Data);

                graph.UpdatedOn = DateTime.UtcNow;
                graph.Data = newData;
                _context.SaveChanges();
            }

            return graph;
        }

        /// <inheritdoc/>
        public GraphModel UpdateGraphName(User user, int graphId, string newName)
        {
            GraphModel graph = _context
                .Graphs
                .FirstOrDefault(g => g.UserId == user.Id && g.Id == graphId);

            if (graph != default(GraphModel))
            {
                graph.UpdatedOn = DateTime.UtcNow;
                graph.Name = newName;
                _context.SaveChanges();
            }

            return graph;
        }

        /// <inheritdoc/>
        public GraphModel DeleteGraph(int id, User user)
        {
            GraphModel graph = ReadGraph(id, user);

            if (graph != default(GraphModel))
            {
                _context
                    .Graphs
                    .Remove(graph);
                _context.SaveChanges();
            }

            return graph;
        }
    }
}
