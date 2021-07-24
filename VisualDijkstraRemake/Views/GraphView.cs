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

        private Node _nodeToMove;
        private Nullable<Point> _dragLocation;
        private bool _nodeCreationRequested;
        private bool _edgeCreationRequested;
        private Node _firstNode;
        private bool _nodeEliminationRequested;

        private string _inputString;
        private Node _nodeOnEdit;

        private Edge _edgeOnEdit;

        private bool _solvePathRequested;
        private Node _solvePath;

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
            this._nodeToMove = null;
            this._dragLocation = null;
            this._nodeCreationRequested = false;
            this._edgeCreationRequested = false;
            this._firstNode = null;
            this._nodeEliminationRequested = false;
            this._inputString = "";
            this._nodeOnEdit = null;
            this._solvePath = null;
            this._solvePathRequested = false;

            System.Windows.Forms.ContextMenuStrip cm = new ContextMenuStrip();
            cm.Items.Add("Item 1");
            cm.Items.Add("sd");
            cm.ItemClicked += new ToolStripItemClickedEventHandler(contexMenu_ItemClicked);


            this.ContextMenuStrip = cm;



        }

        private void CheckNodeOnEdit()
        {
            if (!_controller.Graph.Nodes.Contains(_nodeOnEdit))
            {
                if (_controller.Graph.GetNode(_inputString) == null)
                {
                    _nodeOnEdit.Name = _inputString;
                    _controller.newNode(_nodeOnEdit);
                }
                else
                {
                    MessageBox.Show("Node already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (_controller.Graph.GetNode(_inputString) == null)
                {
                    _nodeOnEdit.Name = _inputString;
                }
                else
                {
                    MessageBox.Show("Node already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void fetchInput(char c)
        {

            if (_nodeOnEdit != null)
            {
                if ((int)c == 13)
                {
                    CheckNodeOnEdit();

                    _nodeOnEdit = null;
                    _inputString = "";
                }
                else if ((int)c == 8)
                {
                    if (_inputString.Length > 0)
                    {
                        _inputString = _inputString.Remove(_inputString.Length - 1);
                    }
                }
                else if (Node.validateName(_inputString + c))
                {
                    _inputString += c;

                }
            }

            if (_edgeOnEdit != null)
            {
                if ((int)c == 13)
                {

                    if (Edge.validateWeight(_inputString))
                    {
                        _edgeOnEdit.Weight = int.Parse(_inputString);
                    }

                    _edgeOnEdit = null;
                    _inputString = "";
                }
                else if ((int)c == 8)
                {
                    if (_inputString.Length > 0)
                    {
                        _inputString = _inputString.Remove(_inputString.Length - 1);
                    }
                }
                else if (Edge.validateWeight(_inputString + c))
                {
                    _inputString += c;
                }
            }

            this.Invalidate();
        }


        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            clearRequests();

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
                        _inputString = node.Name;
                        _nodeOnEdit = node;
                        //_nodeOnChangingName = node;
                        this.Invalidate();
                        return;
                    }
                }

                //getting edges
                List<Edge> edges = Controller.Graph.Edges;
                foreach (Edge edge in edges)
                {
                    if (edge.Contains(mouseEvent.Location, 10))
                    {
                        _edgeOnEdit = edge;
                        _inputString = edge.Weight.ToString();
                        this.Invalidate();
                        return;
                    }
                }

                //nothing clicked, creating new node
                _nodeOnEdit = new Node("", mouseEvent.Location);
                this.Invalidate();

            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {


            //if controller and graph exist
            if (Controller != null && Controller.Graph != null)
            {
                //anti alias
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                //e.Graphics.ScaleTransform(2f, 2f);

                //getting nodes
                List<Node> nodes = Controller.Graph.Nodes;

                //tools for painting
                Pen borderPen = new Pen(Color.Black, 6);
                Pen borderPenPath = new Pen(Color.Red, 6);
                SolidBrush nodeFillBrush = new SolidBrush(Color.White);
                Font font = new Font("Segoe UI", 20);

                //size of the node boundaries
                Size nodeSize = new Size(Node.Size, Node.Size);


                foreach (Edge edge in Controller.Graph.Edges)
                {
                    Point center = new Point((edge.NodeA.Location.X + edge.NodeB.Location.X) / 2,
                                                (edge.NodeA.Location.Y + edge.NodeB.Location.Y) / 2);

                    if (edge.IsInPath)
                    {
                        e.Graphics.DrawLine(borderPenPath, edge.NodeA.Location + nodeSize / 2, edge.NodeB.Location + nodeSize / 2);
                    }
                    else
                    {
                        e.Graphics.DrawLine(borderPen, edge.NodeA.Location + nodeSize / 2, edge.NodeB.Location + nodeSize / 2);
                    }

                    if (_edgeOnEdit != edge)
                    {
                        TextRenderer.DrawText(e.Graphics, edge.Weight.ToString(), font, center - new Size((int)(35 * Math.Cos((2 * Math.PI) - edge.Angle())), (int)(35 * Math.Sin((2 * Math.PI) - edge.Angle()))), Color.Black);
                    }
                }

                if (_edgeOnEdit != null)
                {
                    Point center = new Point((_edgeOnEdit.NodeA.Location.X + _edgeOnEdit.NodeB.Location.X) / 2,
                                                (_edgeOnEdit.NodeA.Location.Y + _edgeOnEdit.NodeB.Location.Y) / 2);
                    TextRenderer.DrawText(e.Graphics, _inputString, font, center - new Size((int)(35 * Math.Cos((2 * Math.PI) - _edgeOnEdit.Angle())), (int)(35 * Math.Sin((2 * Math.PI) - _edgeOnEdit.Angle()))), Color.White, Color.FromArgb(0, 120, 215));

                }

                //painting nodes
                foreach (Node node in nodes)
                {
                    e.Graphics.FillEllipse(nodeFillBrush, new Rectangle(node.Location, new Size(Node.Size, Node.Size)));

                    if (node.IsInPath)
                    {
                        e.Graphics.DrawEllipse(borderPenPath, new Rectangle(node.Location, new Size(Node.Size, Node.Size)));
                    }
                    else
                    {
                        e.Graphics.DrawEllipse(borderPen, new Rectangle(node.Location, new Size(Node.Size, Node.Size)));
                    }




                    if (_nodeOnEdit != node)
                    {

                        TextRenderer.DrawText(e.Graphics, node.Name, font, new Rectangle(node.Location + new Size(1, 1), new Size(Node.Size, Node.Size)), Color.Black);
                    }
                }

                if (_nodeOnEdit != null)
                {
                    e.Graphics.DrawEllipse(borderPen, new Rectangle(_nodeOnEdit.Location, new Size(Node.Size, Node.Size)));
                    e.Graphics.FillEllipse(nodeFillBrush, new Rectangle(_nodeOnEdit.Location, new Size(Node.Size, Node.Size)));
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 3), new Rectangle(_nodeOnEdit.Location + new Size((int)(Node.Size * 0.2), (int)(Node.Size * 0.2)), new Size((int)(Node.Size * 0.6), (int)(Node.Size * 0.6))));
                    TextRenderer.DrawText(e.Graphics, _inputString, font, new Rectangle(_nodeOnEdit.Location + new Size(1, 1), new Size(Node.Size, Node.Size)), Color.White, Color.FromArgb(0, 120, 215));
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 3), new Rectangle(_nodeOnEdit.Location + new Size(45, 45), new Size(110, 30)));
                    e.Graphics.FillRectangle(nodeFillBrush, new Rectangle(_nodeOnEdit.Location + new Size(45, 45), new Size(110, 30)));
                    TextRenderer.DrawText(e.Graphics, "Enter node name", new Font("Segoe UI", 10), new Rectangle(_nodeOnEdit.Location + new Size(45, 45), new Size(110, 30)), Color.Black);

                }


            }

            base.OnPaint(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);


        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (Controller != null)
            {

                Node node = null;

                // trying to find if any node is clicked
                List<Node> nodes = Controller.Graph.Nodes;
                for (int i = 0; i < nodes.Count; ++i)
                {

                    if (nodes[i].Contains(e.Location))
                    {
                        //a node was clicked
                        node = nodes[i];

                        break;
                    }
                }

                if (node != null)
                {
                    //checking if edge creation was requested
                    if (_edgeCreationRequested && _firstNode == null)
                    {
                        //edge creation has already been requested, but first node has not been picked yes
                        _firstNode = node;
                    }
                    else if (_edgeCreationRequested && _firstNode != null)
                    {
                        //first node also exists, so new edge can be created
                        _controller.newEdge(_firstNode, node, 3);
                        _edgeCreationRequested = false;
                        _firstNode = null;

                    }
                    else if (_solvePathRequested && _solvePath == null)
                    {
                        _solvePath = node;
                    }
                    else if (_solvePathRequested && _solvePath != null)
                    {
                        _controller.evaluatePath(_solvePath, node);
                        _solvePathRequested = false;
                        _solvePath = null;
                    }
                    else if (_nodeEliminationRequested)
                    {
                        _controller.deleteNode(node);
                        _nodeEliminationRequested = false;
                    }
                    else
                    {
                        //saving node to be moved
                        _nodeToMove = node;
                    }
                }
                else if (_nodeCreationRequested)
                {
                    //string nodeName = Microsoft.VisualBasic.Interaction.InputBox("Enter node name:", "New node");
                    _nodeOnEdit = new Node("", e.Location);
                    //_controller.newNode(_nodeOnChangingName);

                    _nodeCreationRequested = false;


                }
                else if (_nodeToMove == null)
                {
                    // Save drag location
                    _dragLocation = e.Location;
                }
                else
                {
                    clearRequests();
                }

            }

            this.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (Controller != null)
            {
                if (_nodeToMove != null)
                {
                    //moving a node
                    Controller.moveNode(_nodeToMove, e.Location);
                }
                else if (this.Parent != null && _dragLocation.HasValue)
                {
                    //moving the graph

                    Size delta = new Size(_dragLocation.Value.X - e.Location.X, _dragLocation.Value.Y - e.Location.Y);
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
            _nodeToMove = null;

            //releasing drag location
            _dragLocation = null;
        }


        /// <summary>
        ///  Requests new node creation
        /// </summary>
        public void requestsNewNode()
        {
            clearRequests();
            this._nodeCreationRequested = true;
        }


        /// <summary>
        ///  Requests new edge creation
        /// </summary>
        public void requestsNewEdge()
        {
            clearRequests();
            this._edgeCreationRequested = true;
        }


        public void requestNodeElimination()
        {
            clearRequests();
            this._nodeEliminationRequested = true;
        }

        public void requestPath()
        {
            clearRequests();
            this._solvePathRequested = true;
        }

        /// <summary>
        ///  Clear any pending request.
        /// </summary>
        public void clearRequests()
        {
            Controller.clearStates();

            //clearing node creation request
            this._nodeCreationRequested = false;


            //clearing edge creation request
            this._edgeCreationRequested = false;
            this._firstNode = null;

            //clearing node elimination request
            this._nodeEliminationRequested = false;

            //clearing path request
            _solvePath = null;
            _solvePathRequested = false;


            _edgeOnEdit = null;
            _nodeOnEdit = null;
            _inputString = "";
        }

        void contexMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            // your code here
        }

    }
}
