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
            //list of states to be returned
            List<GraphState> states = new List<GraphState>();


            GraphState state = new GraphState(graph);
            states.Add(state);

            state = state.Copy();
            state.setDistance("Q", 70);
            state.setPrevious("Q", "R");
            states.Add(state);


            foreach (GraphState s in states)
            {
                s.logGraphState();
            }


        }

        public List<GraphState> Solve()
        {
            Debug.WriteLine("Solving dijkstra...");

            return new List<GraphState>();
        }
    }
}
