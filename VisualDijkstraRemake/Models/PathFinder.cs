using System.Collections.Generic;
using System.Diagnostics;

namespace VisualDijkstraRemake.Models
{
    public interface IPathFinder
    {
        public Node Source
        {
            get; set;
        }

        public Node Dest
        {
            get; set;
        }

        public Graph Graph
        {
            get; set;
        }

        public List<GraphState> Solve();

    }

    public class Dijkstra : IPathFinder
    {
        public Node Source { get; set; }
        public Node Dest { get; set; }

        public Graph Graph
        {
            get; set;
        }

        public Dijkstra(Graph graph, Node nodeA, Node nodeB)
        {

        }

        public List<GraphState> Solve()
        {
            Debug.WriteLine("Solving dijkstra...");

            return new List<GraphState>();
        }
    }
}
