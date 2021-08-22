using System.Collections.Generic;

namespace VisualDijkstraLib.Models
{
    public interface IPathFinder
    {
        public Graph Graph
        {
            get; set;
        }

        public List<GraphState> Solve(Node source, Node dest);

    }

    public class Dijkstra : IPathFinder
    {

        public Graph Graph
        {
            get; set;
        }

        public Dijkstra(Graph graph)
        {

            Graph = graph;
        }

        public List<GraphState> Solve(string source, string dest)
        {
            //list of states to be returned
            List<GraphState> states = new List<GraphState>();


            //init state
            GraphState state = new GraphState(Graph);
            state.Source = source;
            state.Dest = dest;
            state.setDistance(state.Source, 0);
            states.Add(state);

            state = state.Copy();

            //getting nodes
            List<Node> nodes = Graph.Nodes;

            for (int i = 0; i < nodes.Count; ++i)
            {

                //getting the (non-processed) node with the smallest distance
                Node u = Graph.GetNode(state.minDistance());

                //setting as processed the current node
                state.setProcessed(u.Name, true);

                //getting neighbours
                List<Node> neighbours = Graph.GetNeighbours(u.Name);

                for (int j = 0; j < neighbours.Count; ++j)
                {
                    int alt = state.GetNode(u.Name).Distance +                      //distance between start and current node
                              Graph.GetEdge(u.Name, neighbours[j].Name).Weight;     //weight between current node and neighbour node

                    if (alt < state.GetNode(neighbours[j].Name).Distance)
                    {
                        state.setDistance(neighbours[j].Name, alt);
                        state.setPrevious(neighbours[j].Name, u.Name);
                        state.Message = string.Format("");
                        states.Add(state);
                        state = state.Copy();
                    }
                }
            }

            /*
            foreach (GraphState s in states)
            {
                s.logGraphState();
            }*/

            return states;
        }

        public List<GraphState> Solve(Node source, Node dest)
        {
            return Solve(source.Name, dest.Name);
        }
    }
}
