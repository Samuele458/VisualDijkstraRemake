using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace VisualDijkstraRemake.Models
{
    class Graph
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
            Debug.WriteLine("Graph model created");
            _nodes = new List<Node>();
            _edges = new List<Edge>();
        }

        public void addNewNode(Node node)
        {
            _nodes.Add(node);
        }

        public void addNewNode(string nodeName, Point location)
        {
            this.addNewNode(new Node(nodeName, location));
        }

        public void moveNode(Node node, Point location)
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

        public void createNewEdge(Node a, Node b, int weight)
        {
            Edge edge = new Edge(a, b, weight);
            a.addEdge(edge);
            b.addEdge(edge);
            Edges.Add(edge);
        }

        public Node getNode(string nodeName)
        {
            return Nodes.Find(node => node.Name.Equals(nodeName));
        }
    }

    class NodeNotFoundException : Exception
    {
        public NodeNotFoundException(string message) : base(message) { }
    }
}
