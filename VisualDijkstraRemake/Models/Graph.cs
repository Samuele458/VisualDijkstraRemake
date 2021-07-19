using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace VisualDijkstraRemake.Models
{
    class Graph
    {

        private List<Node> _nodes;

        public List<Node> Nodes
        {
            get { return _nodes; }
        }

        public Graph()
        {
            Debug.WriteLine("Graph model created");
            _nodes = new List<Node>();
        }

        public void createNewNode(string nodeName, Point location)
        {
            Debug.WriteLine("model:  node created: " + nodeName + " " + location);
            _nodes.Add(new Node(nodeName, location));
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
    }

    class NodeNotFoundException : Exception
    {
        public NodeNotFoundException(string message) : base(message) { }
    }
}
