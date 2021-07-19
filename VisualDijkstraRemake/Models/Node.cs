using System.Drawing;

namespace VisualDijkstraRemake.Models
{
    class Node
    {
        //Node size
        public const int Size = 50;

        //up-right node angle
        private Point _location;


        public Point Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public Node(Point loc)
        {
            Location = loc;
        }

        public Node(int x, int y) : this(new Point(x, y)) { }

        public Node() : this(new Point(0, 0)) { }
    }
}
