using System;
using System.Drawing;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace DesktopApp.Models
{
    public interface IPath
    {
        public bool IsInPath { get; set; }

        public bool IsInPartialPath { get; set; }
    }

    /// <summary>
    ///  Node element used inside Graph
    /// </summary>
    public class Node : IPath
    {
        //Node size
        public const int SizeLength = 50;
        public static readonly Size SizeBox = new Size(SizeLength, SizeLength);

        //up-right node angle
        private Point _location;

        //node name
        private string _name;

        [JsonIgnore]
        public bool IsInPath { get; set; }
        public bool IsInPartialPath { get; set; }


        public Point Location
        {
            get { return _location; }
            set { _location = new Point(value.X - SizeLength / 2, value.Y - SizeLength / 2); }
        }



        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        [JsonConstructor]
        public Node(string name, Point location)
        {
            Location = location;
            Name = name;
        }


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
                location.X < (Location.X + SizeLength) &&
                location.Y < (Location.Y + SizeLength)
            );
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

        /// <summary>
        ///  Checks if a given string is a valid node name or not
        /// </summary>
        /// <param name="nameStr">string to check</param>
        /// <returns>true if name is valid, false otherwise</returns>
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
