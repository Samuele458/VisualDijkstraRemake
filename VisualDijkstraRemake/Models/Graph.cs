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
    }
}
