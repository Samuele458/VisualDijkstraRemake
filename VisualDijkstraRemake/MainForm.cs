using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using VisualDijkstraRemake.Controllers;
using VisualDijkstraRemake.Models;
using VisualDijkstraRemake.Views;


namespace VisualDijkstraRemake
{
    public partial class MainForm : Form
    {

        Graph _graph;
        GraphView _graphView;
        GraphController _graphController;

        IStatesController _statesController;

        GraphOptions options;



        public MainForm()
        {
            InitializeComponent();

            this.KeyPreview = true;


            options = new GraphOptions();
        }

        private void newGraphButton_Click(object sender, System.EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                bool proceed = false;

                if (!_graphController.IsSaved)
                {
                    DialogResult result = _graphController.AskToSave();

                    if (result == DialogResult.Yes || result == DialogResult.No)
                    {
                        proceed = true;
                    }
                }
                else
                {
                    proceed = true;
                }

                if (proceed)
                {
                    _graph = new Graph();
                    _graphController.Graph = _graph;
                    this.scrollPanel1.setMainControl(_graphView, new System.Drawing.Point(GraphView.SizeLength / 2, GraphView.SizeLength / 2) - scrollPanel1.Size / 2);

                }
            }
        }

        private void addNodeButton_Click(object sender, System.EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                _graphView.requestsNewNode();
            }

        }

        private void addEdgeButton_Click(object sender, System.EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                _graphView.requestsNewEdge();
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Debug.WriteLine(((int)keyData));

            char c = (char)keyData;
            _graphView.fetchInput(c);

            return base.ProcessCmdKey(ref msg, keyData);
        }




        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //creating default graph
            _graph = new Graph();
            _graphView = new Views.GraphView(options);
            _graphController = new GraphController(_graphView, _graph);
            this.scrollPanel1.setMainControl(_graphView, new System.Drawing.Point(GraphView.SizeLength / 2, GraphView.SizeLength / 2) - scrollPanel1.Size / 2);

            _statesController = new StatesController(this.statesView1, new List<GraphState>());
            statesView1.Controller = _statesController;


            _statesController.GraphController = _graphController;
            _graphController.StatesController = _statesController;

            //setting tab defaut page
            this.toolbar.SelectedTab = this.graphTab;
        }

        private void deleteNodeButton_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                _graphView.requestNodeElimination();
            }
        }



        private void saveButton_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                _graphController.save();
            }
        }

        private void solvePathButton_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                _graphView.requestPath();
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                bool proceed = false;

                if (!_graphController.IsSaved)
                {
                    DialogResult result = _graphController.AskToSave();

                    if (result == DialogResult.Yes || result == DialogResult.No)
                    {
                        proceed = true;
                    }
                }
                else
                {
                    proceed = true;
                }

                if (proceed)
                {
                    _graphController.load();
                }
            }
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                _graphController.saveAs();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            bool proceed = false;

            if (!_graphController.IsSaved)
            {
                DialogResult result = _graphController.AskToSave();

                if (result == DialogResult.Yes || result == DialogResult.No)
                {
                    proceed = true;
                }
            }
            else
            {
                proceed = true;
            }

            if (!proceed)
            {
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                Close();
            }

        }

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            try
            {
                zoomTrackbar.Value += 1;
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            try
            {
                zoomTrackbar.Value -= 1;
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void zoomTrackbar_ValueChanged(object sender, EventArgs e)
        {
            options.Zoom = zoomTrackbar.Value;
            _graphView.Options = options;
        }
    }
}
