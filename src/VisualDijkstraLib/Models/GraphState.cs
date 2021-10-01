using System.Collections.Generic;

namespace VisualDijkstraLib.Models
{
    /// <summary>
    ///  Handles a single graph step, used to represents Dijkstra's algorithm step-by-step
    /// </summary>
    public class GraphState
    {

        public string Source { get; set; }

        public string Dest { get; set; }

        public string Message { get; set; }

        private List<NodeState> _nodesStates;

        public List<NodeState> NodesStates
        {
            get { return _nodesStates; }
        }

        /// <summary>
        ///  Constructs GraphState by taking a list of nodes
        /// </summary>
        /// <param name="nodes">List of nodes</param>
        public GraphState(List<Node> nodes)
        {
            _nodesStates = new List<NodeState>();
            setNodes(nodes);
        }

        public GraphState()
        {
            _nodesStates = new List<NodeState>();
        }

        public GraphState(Graph graph) : this(graph.Nodes)
        {

        }

        /// <summary>
        ///  Set nodes to GraphState
        /// </summary>
        /// <param name="nodes">List of nodes</param>
        public void setNodes(List<Node> nodes)
        {
            _nodesStates = nodes.ConvertAll(
                new System.Converter<Node, NodeState>(
                    (node) => new NodeState(node.Name)
                )
            );
        }


        /// <summary>
        ///  Set distance value of a specified node
        /// </summary>
        /// <param name="nodeName">Name of node to edit</param>
        /// <param name="distance">Distance value to set</param>
        public void setDistance(string nodeName, int distance)
        {
            NodeState node = _nodesStates.Find(n => n.Name == nodeName);
            if (node != null)
            {
                node.Distance = distance;
            }
        }

        /// <summary>
        ///  Mark a node as processed (or not processed)
        /// </summary>
        /// <param name="nodeName">Name of node to edit</param>
        /// <param name="processed">State to set (true if processed, false otherwise)</param>
        public void setProcessed(string nodeName, bool processed)
        {
            NodeState node = _nodesStates.Find(n => n.Name == nodeName);
            if (node != null)
            {
                node.Processed = processed;
            }
        }


        /// <summary>
        ///  Set the previous node of a specified node
        /// </summary>
        /// <param name="nodeName">Name of node to edit</param>
        /// <param name="previous">Previous node name</param>
        public void setPrevious(string nodeName, string previous)
        {
            NodeState node = _nodesStates.Find(n => n.Name == nodeName);
            if (node != null)
            {
                node.Previous = previous;
            }
        }

        /// <summary>
        ///  Create a deep clone of current GraphState object
        /// </summary>
        /// <returns>Deep copy of GraphState object</returns>
        public GraphState Copy()
        {
            List<NodeState> newNodeStates = new List<NodeState>();

            foreach (NodeState node_state in _nodesStates)
            {
                newNodeStates.Add(new NodeState(node_state.Name, node_state.Distance, node_state.Previous, node_state.Processed));
            }

            GraphState newState = new GraphState();
            newState._nodesStates = newNodeStates;

            newState.Source = Source;
            newState.Dest = Dest;

            return newState;
        }

        /// <summary>
        ///  Log GraphState to Debug console
        /// </summary>
        public void logGraphState()
        {
            foreach (NodeState state in _nodesStates)
            {
                state.LogNodeState();
            }
        }

        /// <summary>
        ///  Get the name of the not yet processed node with the smallest distance
        /// </summary>
        /// <returns>the name of the not yet processed node with the smallest distance</returns>
        public string minDistance()
        {
            List<NodeState> notProcessed = _nodesStates.FindAll(node => !node.Processed);


            int minIndex = 0;
            for (int i = 0; i < notProcessed.Count; ++i)
            {
                if (notProcessed[i].Distance < notProcessed[minIndex].Distance)
                {
                    minIndex = i;
                }
            }

            return notProcessed[minIndex].Name;
        }

        /// <summary>
        ///  Get NodeState object, based on its name
        /// </summary>
        /// <param name="nodeName">Node name</param>
        /// <returns>NodeState object</returns>
        public NodeState GetNode(string nodeName)
        {
            return _nodesStates.Find(node => node.Name == nodeName);
        }
    }
}
