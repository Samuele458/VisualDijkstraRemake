using System;
using System.Collections.Generic;
using System.Drawing;

namespace VisualDijkstraRemake.Models
{
    public class Node
    {
        //Node size
        public const int Size = 50;

        //up-right node angle
        private Point _location;

        //node name
        private string _name;

        List<Edge> _edges;

        public Point Location
        {
            get { return _location; }
            set { _location = new Point(value.X - Size / 2, value.Y - Size / 2); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Edge> Edges
        {
            get { return _edges; }
        }

        public Node(string nodeName, Point loc)
        {
            Location = loc;
            _edges = new List<Edge>();
            Name = nodeName;
        }


        public Node(string nodeName, int x, int y) : this(nodeName, new Point(x, y)) { }


        public bool Contains(Point location)
        {
            return (
                location.X > Location.X &&
                location.Y > Location.Y &&
                location.X < (Location.X + Size) &&
                location.Y < (Location.Y + Size)
            );
        }

        public void addEdge(Edge edge)
        {
            if (!Edges.Contains(edge))
            {
                Edges.Add(edge);
            }
        }

    }

    class DuplicatedNodeException : Exception
    {
        public DuplicatedNodeException(string message) : base(message) { }
    }
}
