using System;
using System.Collections.Generic;
using System.Drawing;

namespace VisualDijkstraRemake.Models
{
    public class Graph
    {

        private List<Node> _nodes;

        private List<Edge> _edges;

        public List<Node> Nodes
        {
            get { return _nodes; }
        }

        public List<Edge> Edges
        {
            get { return _edges; }
        }

        public Graph()
        {
            _nodes = new List<Node>();
            _edges = new List<Edge>();
        }

        public void AddNewNode(Node node)
        {
            if (node != null)
            {
                if (_nodes.Exists(n => node.Name.Equals(n.Name)))
                {
                    throw new NodeAlreadyExistsException();
                }
                else
                {
                    _nodes.Add(node);
                }
            }
        }

        public void AddNewNode(string nodeName, Point location)
        {
            this.AddNewNode(new Node(nodeName, location));
        }

        public void MoveNode(Node node, Point location)
        {
            if (_nodes.Contains(node))
            {
                node.Location = new Point(location.X, location.Y);
            }
            else
            {
                throw new NodeNotFoundException("Node \"" + node.Name + "\" not found.");
            }
        }

        public void MoveNode(string nodeName, Point location)
        {
            MoveNode(GetNode(nodeName), location);
        }

        public void CreateNewEdge(Node a, Node b, int weight)
        {
            Edge edge = new Edge(a, b, weight);
            a.addEdge(edge);
            b.addEdge(edge);
            Edges.Add(edge);
        }

        public Node GetNode(string nodeName)
        {
            return Nodes.Find(node => node.Name.Equals(nodeName));
        }
    }

    public class NodeNotFoundException : Exception
    {
        public NodeNotFoundException(string message = "") : base(message) { }
    }


    public class NodeAlreadyExistsException : Exception
    {
        public NodeAlreadyExistsException(string message = "") : base(message) { }
    }

}
