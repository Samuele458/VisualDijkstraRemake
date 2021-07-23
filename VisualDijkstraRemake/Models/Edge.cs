using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VisualDijkstraRemake.Models
{

    /// <summary>
    ///  Edge element used inside Graph
    /// </summary>
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

        /// <summary>
        ///  Create an Edge by providing its characteristics
        /// </summary>
        /// <param name="a">Node A</param>
        /// <param name="b">Node B</param>
        /// <param name="weight">Edge weight</param>
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

        /// <summary>
        ///  Checks is two edges are qual or not, based on nodes contained inside edges
        /// </summary>
        /// <param name="other"></param>
        /// <returns>true if the edges are equals, false otherwise</returns>
        public bool Equals(Edge other)
        {
            return (NodeA.Equals(other.NodeA) && NodeB.Equals(other.NodeB)) ||
                   (NodeA.Equals(other.NodeB) && NodeB.Equals(other.NodeA));
        }

        /// <summary>
        ///  Checks if a given location is contained inside Edge boundaries
        /// </summary>
        /// <param name="loc">Location to be checked</param>
        /// <param name="lineWidth">Width of the edge (the higher the width, the larger the boundaries)</param>
        /// <returns>Returns true if location is contained inside boundaries, false otherwise</returns>
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

        /// <summary>
        ///  Evaluate the angle (in radians) between two nodes
        /// </summary>
        /// <returns>Angle value between two nodes</returns>
        public double Angle()
        {
            return Math.Atan2(NodeB.Location.X - NodeA.Location.X, NodeB.Location.Y - NodeA.Location.Y);
        }

        public static bool validateWeight(string weightStr)
        {
            string alphabet = "1234567890";
            bool passed = true;

            if (weightStr.Length == 0)
            {
                return false;
            }

            foreach (char c in weightStr)
            {
                if (!alphabet.Contains(c))
                {
                    return false;
                }
            }

            if (weightStr.Length < 9 && int.Parse(weightStr) < 99999)
            {
                return true;
            }
            else
            {

                return false;
            }

            return passed;
        }

    }


    /// <summary>
    ///  Duplicated edge
    /// </summary>
    class DuplicatedEdgeException : Exception
    {
        public DuplicatedEdgeException(string message) : base(message) { }
    }
}
