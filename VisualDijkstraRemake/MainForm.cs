using DesktopApp.Controllers;
using DesktopApp.Models;
using DesktopApp.Utils;
using DesktopApp.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace DesktopApp
{
    public partial class MainForm : Form
    {

        private Graph _graph;
        private GraphView _graphView;
        private GraphController _graphController;

        private IStatesController _statesController;

        private readonly GraphOptions options;



        public MainForm()
        {
            InitializeComponent();

            this.KeyPreview = true;

            options = new GraphOptions();

            Logger.log.Info("Execution started");

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
                    this.scrollPanel1.SetMainControl(_graphView, new System.Drawing.Point(GraphView.SizeLength / 2, GraphView.SizeLength / 2) - scrollPanel1.Size / 2);

                }
            }
        }

        private void addNodeButton_Click(object sender, System.EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                _graphView.RequestsNewNode();
            }

        }

        private void addEdgeButton_Click(object sender, System.EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                _graphView.RequestsNewEdge();
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            char c = (char)keyData;
            _graphView.FetchInput(c);

            return base.ProcessCmdKey(ref msg, keyData);
        }




        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //creating default graph
            _graph = new Graph();
            _graphView = new Views.GraphView(options);
            _graphController = new GraphController(_graphView, _graph);
            this.scrollPanel1.SetMainControl(_graphView, new System.Drawing.Point(GraphView.SizeLength / 2, GraphView.SizeLength / 2) - scrollPanel1.Size / 2);

            _statesController = new StatesController(this.statesView1, new List<GraphState>());
            statesView1.Controller = _statesController;


            _statesController.GraphController = _graphController;
            _graphController.StatesController = _statesController;

            //setting tab defaut page
            this.toolbar.SelectedTab = this.graphTab;


            //loading options
            zoomTrackbar.Value = (int)options.Zoom;

            switch (options.GridType)
            {
                case GridType.None:
                    gridNoneRadioButton.Checked = true;
                    break;
                case GridType.Light:
                    gridLightRadioButton.Checked = true;
                    break;
                case GridType.Dark:
                    gridDarkRadioButton.Checked = true;
                    break;
                case GridType.Slim:
                    gridSlimRadioButton.Checked = true;
                    break;

            }
        }

        private void deleteNodeButton_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                _graphView.RequestNodeElimination();
            }
        }



        private void saveButton_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                _graphController.Save();
            }
        }

        private void solvePathButton_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                _graphView.RequestPath();
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
                    _graphController.Load();
                }
            }
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                _graphController.SaveAs();
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
            else
            {
                Logger.log.Info("Program closed");
                options.Save();
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
            if (e is MouseEventArgs)
            {
                try
                {
                    zoomTrackbar.Value += 1;
                }
                catch (ArgumentOutOfRangeException) { }
            }
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                try
                {
                    zoomTrackbar.Value -= 1;
                }
                catch (ArgumentOutOfRangeException) { }
            }
        }

        private void zoomTrackbar_ValueChanged(object sender, EventArgs e)
        {
            options.Zoom = zoomTrackbar.Value;
            _graphView.Options = options;
        }

        private void gridRadioButtons_MouseClick(object sender, MouseEventArgs e)
        {
            RadioButton radioButtonClicked = (RadioButton)sender;

            options.GridType = (GridType)Enum.Parse(typeof(GridType), radioButtonClicked.Text, true);
            _graphView.Options = options;
        }
    }
}
