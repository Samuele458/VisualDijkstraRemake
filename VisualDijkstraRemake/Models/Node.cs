﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace VisualDijkstraRemake.Models
{

    /// <summary>
    ///  Node element used inside Graph
    /// </summary>
    public class Node
    {
        //Node size
        public static int Size = 50;

        //up-right node angle
        private Point _location;

        //node name
        private string _name;


        private List<Edge> _edges;

        [JsonIgnore]
        public bool IsInPath { get; set; }


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


        [JsonIgnore]
        public List<Edge> Edges
        {
            get { return _edges; }
        }

        [JsonConstructor]
        public Node(string name, Point location)
        {
            Location = location;
            _edges = new List<Edge>();
            Name = name;
        }

        /*
        public Node()
        {
            Location = new Point();
            _edges = new List<Edge>();
            Name = "";
        }*/

        /// <summary>
        ///  Constructs a Node object
        /// </summary>
        /// <param name="nodeName">Name given to node.</param>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public Node(string nodeName, int x, int y) : this(nodeName, new Point(x, y)) { }

        /// <summary>
        ///  Check if a given location is inside the node boundaries
        /// </summary>
        /// <param name="location">Location to check</param>
        /// <returns>True is is location if inside boundaries, false otherwise.</returns>
        public bool Contains(Point location)
        {
            return (
                location.X > Location.X &&
                location.Y > Location.Y &&
                location.X < (Location.X + Size) &&
                location.Y < (Location.Y + Size)
            );
        }

        /// <summary>
        ///  Add a new edge to the node
        /// </summary>
        /// <param name="edge"></param>
        public void addEdge(Edge edge)
        {
            if (!Edges.Contains(edge))
            {
                Edges.Add(edge);
            }
        }


        /// <summary>
        ///  Checks if two nodes are equal or not, based on their names
        /// </summary>
        /// <param name="other"></param>
        /// <returns>true if equal, false othwìerwise</returns>
        public bool Equals(Node other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return this.Name.Equals(other.Name);
            }
        }


        public static bool validateName(string nameStr)
        {
            Regex rgx = new Regex(@"^[a-zA-Z0-9]{1,2}$");
            return rgx.IsMatch(nameStr);
        }
    }


    /// <summary>
    ///  Duplicated node exception
    /// </summary>
    class DuplicatedNodeException : Exception
    {
        public DuplicatedNodeException(string message) : base(message) { }
    }
}
