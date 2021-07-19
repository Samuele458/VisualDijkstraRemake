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

        public GraphController Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }

        public GraphView()
        {
            this.BackColor = Color.White;
            Controller = null;
            this.Cursor = System.Windows.Forms.Cursors.Default;

        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);

            if (Controller != null)
            {

                MouseEventArgs mouseEvent = (MouseEventArgs)e;
                Debug.WriteLine("View:  double click: creating node");
                Controller.newNode("A", new Point(mouseEvent.X, mouseEvent.Y));

            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Controller != null && Controller.Graph != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                Debug.WriteLine("Refresh graph view...");
                Graph graph = Controller.Graph;

                List<Node> nodes = graph.Nodes;


                //pen for painting
                Pen pen = new Pen(Color.Black, 10);


                //painting nodes
                foreach (Node node in nodes)
                {
                    e.Graphics.DrawEllipse(pen, new Rectangle(node.Location, new Size(Node.Size, Node.Size)));
                }

            }


            base.OnPaint(e);
        }

    }
}
