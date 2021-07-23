using System;
using System.Collections.Generic;
using System.Drawing;

namespace VisualDijkstraRemake.Models
{
    /// <summary>
    ///  Model for handling a graph
    /// </summary>
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

        /// <summary>
        ///  Adds a given Node object to graph.
        /// </summary>
        /// <param name="node">Node object to be added.</param>
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

        /// <summary>
        ///  Creates a new node and adds it to graph
        /// </summary>
        /// <param name="nodeName">Node name</param>
        /// <param name="location">Location in which add the node</param>
        public void AddNewNode(string nodeName, Point location)
        {
            this.AddNewNode(new Node(nodeName, location));
        }

        public void deleteNode(Node node)
        {
            if (_nodes.Contains(node))
            {
                _nodes.Remove(node);
                _edges.RemoveAll(edge => (edge.NodeA.Equals(node) || edge.NodeB.Equals(node)));

            }
            else
            {
                throw new NodeNotFoundException("Node \"" + node.Name + "\" not found.");
            }
        }


        /// <summary>
        ///  Move a node to a given location
        /// </summary>
        /// <param name="node">Node object</param>
        /// <param name="location">Location in which move the node</param>
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


        /// <summary>
        ///  Move a node to a given location
        /// </summary>
        /// <param name="node">Node object</param>
        /// <param name="location">Location in which move the node</param>
        public void MoveNode(string nodeName, Point location)
        {
            MoveNode(GetNode(nodeName), location);
        }

        /// <summary>
        ///  Create a new edge between two nodes (the order doesn't matter)
        /// </summary>
        /// <param name="a">Node A</param>
        /// <param name="b">Node B</param>
        /// <param name="weight">Edge weight</param>
        public void CreateNewEdge(Node a, Node b, int weight)
        {
            Edge edge = new Edge(a, b, weight);
            a.addEdge(edge);
            b.addEdge(edge);
            Edges.Add(edge);
        }

        /// <summary>
        ///  Gets a node object, by providing it's name
        /// </summary>
        /// <param name="nodeName">Name of the node to search</param>
        /// <returns>Returns the node object if found, null otherwise</returns>
        public Node GetNode(string nodeName)
        {
            return Nodes.Find(node => node.Name.Equals(nodeName));
        }


        public List<Node> GetNeighbours(string nodeName)
        {
            Node node = GetNode(nodeName);

            return _edges
                        .FindAll(edge => (edge.NodeA.Equals(node) || edge.NodeB.Equals(node)))
                        .ConvertAll<Node>(new Converter<Edge, Node>(edge => edge.NodeA.Equals(node) ? edge.NodeB : edge.NodeA));
        }

        public Edge getEdge(string nodeA, string nodeB)
        {
            return _edges.Find(edge => (edge.NodeA.Name == nodeA && edge.NodeB.Name == nodeB) || (edge.NodeA.Name == nodeB && edge.NodeB.Name == nodeA));
        }
    }


    /// <summary>
    ///  Node not found
    /// </summary>
    public class NodeNotFoundException : Exception
    {
        public NodeNotFoundException(string message = "") : base(message) { }
    }


    public class NodeAlreadyExistsException : Exception
    {
        public NodeAlreadyExistsException(string message = "") : base(message) { }
    }

}
