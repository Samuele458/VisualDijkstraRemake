using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using VisualDijkstraRemake.Controllers;
using VisualDijkstraRemake.Models;

namespace VisualDijkstraRemake.Views
{
    class GraphView : PictureBox
    {
        private GraphController _controller;
        private Node nodeToMove;

        public GraphController Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }

        public GraphView()
        {
            this.BackColor = Color.Blue;
            this.Cursor = System.Windows.Forms.Cursors.Default;

            this.Controller = null;
            this.nodeToMove = null;

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



                Debug.WriteLine("View:  double click: creating node");
                //Controller.newNode("A", new Point(mouseEvent.X, mouseEvent.Y));

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
                SolidBrush borderBrush = new SolidBrush(Color.White);
                Font font = new Font("Arial", 20);

                //size of the node boundaries
                Size nodeSize = new Size(Node.Size, Node.Size);


                foreach (Edge edge in Controller.Graph.Edges)
                {
                    e.Graphics.DrawLine(borderPen, edge.NodeA.Location + nodeSize / 2, edge.NodeB.Location + nodeSize / 2);
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
                List<Node> nodes = Controller.Graph.Nodes;
                foreach (Node node in nodes)
                {
                    if (node.Contains(e.Location))
                    {
                        Debug.WriteLine("Clicked node");
                        nodeToMove = node;
                    }
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (Controller != null && nodeToMove != null)
            {
                Controller.moveNode(nodeToMove, e.Location);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            //releasing node under move
            nodeToMove = null;
            Debug.WriteLine("Node released");
        }
    }
}
