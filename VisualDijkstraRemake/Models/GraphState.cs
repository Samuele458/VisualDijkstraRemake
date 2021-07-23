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
            setNodes(nodes);
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
    }
}
