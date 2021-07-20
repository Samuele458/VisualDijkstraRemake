using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VisualDijkstraRemake.Models
{
    public class Edge
    {
        Node _nodeA;
        Node _nodeB;

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

        public Edge(Node a, Node b)
        {
            if (a != b)
            {
                NodeA = a;
                NodeB = b;
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

    }

    class DuplicatedEdgeException : Exception
    {
        public DuplicatedEdgeException(string message) : base(message) { }
    }
}
