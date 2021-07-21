using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VisualDijkstraRemake.Models
{
    public class Edge
    {
        Node _nodeA;
        Node _nodeB;
        int _weight;

        public Node NodeA
        {
            get { return _nodeA; }
            set { _nodeA = value; }
        }


        public Node NodeB
        {
            get { return _nodeB; }
            set { _nodeB = value; }
        }

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public Edge(Node a, Node b, int weight)
        {
            if (a != b)
            {
                NodeA = a;
                NodeB = b;
                Weight = weight;
            }
            else
            {
                throw new DuplicatedNodeException("Duplicated node");
            }
        }

        public bool Equals(Edge other)
        {
            return (NodeA == other.NodeA && NodeB == other.NodeB) ||
                    (NodeA == other.NodeB && NodeB == other.NodeA);
        }

        public bool Contains(Point loc, int lineWidth)
        {
            Size halfSize = new Size(Node.Size / 2, Node.Size / 2);
            using (var path = new GraphicsPath())
            {
                using (var pen = new Pen(Brushes.Black, lineWidth))
                {
                    path.AddLine(_nodeA.Location + halfSize, _nodeB.Location + halfSize);
                    return path.IsOutlineVisible(loc, pen);
                }
            }
        }

        public double Angle()
        {
            return Math.Atan2(NodeB.Location.X - NodeA.Location.X, NodeB.Location.Y - NodeA.Location.Y);
        }

    }

    class DuplicatedEdgeException : Exception
    {
        public DuplicatedEdgeException(string message) : base(message) { }
    }
}
