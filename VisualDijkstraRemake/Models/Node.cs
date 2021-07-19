﻿using System.Drawing;

namespace VisualDijkstraRemake.Models
{
    class Node
    {
        //Node size
        public const int Size = 100;

        //up-right node angle
        private Point _location;

        //node name
        private string _name;


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

        public Node(string nodeName, Point loc)
        {
            Location = loc;
        }

        public Node(string nodeName, int x, int y) : this(nodeName, new Point(x, y)) { }

    }
}
