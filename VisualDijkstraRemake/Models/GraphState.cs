using System.Collections.Generic;

namespace VisualDijkstraRemake.Models
{
    public class GraphState
    {

        public string Source { get; set; }

        public string Dest { get; set; }

        public string Message { get; set; }

        private List<NodeState> _nodesStates;

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

        public void setNodes(List<Node> nodes)
        {
            _nodesStates = nodes.ConvertAll(
                new System.Converter<Node, NodeState>(
                    (node) => new NodeState(node.Name)
                )
            );
        }

        public void setDistance(string nodeName, int distance)
        {
            NodeState node = _nodesStates.Find(n => n.Name == nodeName);
            if (node != null)
            {
                node.Distance = distance;
            }
        }

        public void setProcessed(string nodeName, bool processed)
        {
            NodeState node = _nodesStates.Find(n => n.Name == nodeName);
            if (node != null)
            {
                node.Processed = processed;
            }
        }

        public void setPrevious(string nodeName, string previous)
        {
            NodeState node = _nodesStates.Find(n => n.Name == nodeName);
            if (node != null)
            {
                node.Previous = previous;
            }
        }

        public GraphState Copy()
        {
            List<NodeState> newNodeStates = new List<NodeState>();

            foreach (NodeState node_state in _nodesStates)
            {
                newNodeStates.Add(new NodeState(node_state.Name, node_state.Distance, node_state.Previous, node_state.Processed));
            }

            GraphState newState = new GraphState();
            newState._nodesStates = newNodeStates;

            return newState;
        }

        public void logGraphState()
        {
            System.Diagnostics.Debug.WriteLine("--- Graph State ---");
            foreach (NodeState state in _nodesStates)
            {
                state.logNodeState();
            }
        }
    }
}
