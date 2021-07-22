using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VisualDijkstraRemake.Controllers;
using VisualDijkstraRemake.Controls;
using VisualDijkstraRemake.Models;

namespace VisualDijkstraRemake.Views
{
    public class GraphView : PictureBox
    {
        private GraphController _controller;
        private Node nodeToMove;
        private Nullable<Point> dragLocation;

        public GraphController Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }

        public GraphView()
        {
            //general settings
            this.BackColor = Color.White;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.BackgroundImage = global::VisualDijkstraRemake.Properties.Resources.grid100_w4_28o;
            this.Controller = null;
            this.Location = new System.Drawing.Point(3, 3);
            this.Name = "graphPictureBox";
            this.Size = new System.Drawing.Size(10000, 10000);
            this.TabIndex = 0;
            this.TabStop = false;


            //Initializing attributes
            this.Controller = null;
            this.nodeToMove = null;
            this.dragLocation = null;

        }



        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);

            if (Controller != null)
            {

                //mouse event
                MouseEventArgs mouseEvent = (MouseEventArgs)e;

                //getting nodes
                List<Node> nodes = Controller.Graph.Nodes;

                foreach (Node node in nodes)
                {
                    if (node.Contains(mouseEvent.Location))
                    {
                        MessageBox.Show("Clicked node");
                    }
                }

                //getting edges
                List<Edge> edges = Controller.Graph.Edges;
                foreach (Edge edge in edges)
                {
                    if (edge.Contains(mouseEvent.Location, 10))
                    {
                        MessageBox.Show("Clicked edge");
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //if controller and graph exist
            if (Controller != null && Controller.Graph != null)
            {
                //anti alias
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                //getting nodes
                List<Node> nodes = Controller.Graph.Nodes;

                //tools for painting
                Pen borderPen = new Pen(Color.Black, 10);
                Pen edgePen = new Pen(Color.Black, 7);
                SolidBrush borderBrush = new SolidBrush(Color.White);
                Font font = new Font("Arial", 20);

                //size of the node boundaries
                Size nodeSize = new Size(Node.Size, Node.Size);


                foreach (Edge edge in Controller.Graph.Edges)
                {
                    Point center = new Point((edge.NodeA.Location.X + edge.NodeB.Location.X) / 2,
                                                (edge.NodeA.Location.Y + edge.NodeB.Location.Y) / 2);

                    TextRenderer.DrawText(e.Graphics, edge.Weight.ToString(), font, center - new Size((int)(35 * Math.Cos(edge.Angle() + Math.PI)), (int)(35 * Math.Sin(edge.Angle() + Math.PI))), Color.Black);

                    e.Graphics.DrawLine(edgePen, edge.NodeA.Location + nodeSize / 2, edge.NodeB.Location + nodeSize / 2);
                }

                //painting nodes
                foreach (Node node in nodes)
                {
                    e.Graphics.DrawEllipse(borderPen, new Rectangle(node.Location, new Size(Node.Size, Node.Size)));
                    e.Graphics.FillEllipse(borderBrush, new Rectangle(node.Location, new Size(Node.Size, Node.Size)));
                    TextRenderer.DrawText(e.Graphics, node.Name, font, new Rectangle(node.Location + new Size(1, 1), new Size(Node.Size, Node.Size)), Color.Black);
                }


            }

            base.OnPaint(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (Controller != null)
            {

                // trying to find if any node is clicked
                List<Node> nodes = Controller.Graph.Nodes;
                foreach (Node node in nodes)
                {
                    if (node.Contains(e.Location))
                    {
                        nodeToMove = node;
                    }
                }

                // if there is no any clicked node
                if (nodeToMove == null)
                {
                    // Save drag location
                    dragLocation = e.Location;
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (Controller != null)
            {
                if (nodeToMove != null)
                {
                    //moving a node
                    Controller.moveNode(nodeToMove, e.Location);
                }
                else if (this.Parent != null && dragLocation.HasValue)
                {
                    //moving the graph

                    Size delta = new Size(dragLocation.Value.X - e.Location.X, dragLocation.Value.Y - e.Location.Y);
                    ScrollPanel parentScrollBox = (ScrollPanel)this.Parent;

                    parentScrollBox.AutoScrollPosition = new Point(Math.Abs(parentScrollBox.AutoScrollPosition.X),
                                                                   Math.Abs(parentScrollBox.AutoScrollPosition.Y)) + delta;

                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            //releasing node under move
            nodeToMove = null;

            //releasing drag location
            dragLocation = null;
        }
    }
}
