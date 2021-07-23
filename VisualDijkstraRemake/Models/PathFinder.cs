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


            //init state
            GraphState state = new GraphState(graph);
            state.Source = nodeA.Name;
            state.Dest = nodeB.Name;
            state.setDistance(state.Source, 0);
            states.Add(state);

            //getting nodes
            List<Node> nodes = graph.Nodes;

            for (int i = 0; i < nodes.Count; ++i)
            {

                //getting the (non-processed) node with the smallest distance
                Node u = graph.GetNode(state.minDistance());

                //setting as processed the current node
                state.setProcessed(u.Name, true);


            }


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
