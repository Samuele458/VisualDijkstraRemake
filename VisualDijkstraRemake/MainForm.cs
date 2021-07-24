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



        public MainForm()
        {
            InitializeComponent();

            this.KeyPreview = true;






        }

        private void newGraphButton_Click(object sender, System.EventArgs e)
        {
            _graph = Utils.GraphUtils.loadGraphFromXMLFile(@"C:\Users\Yankoo\Desktop\aaaa.xml");
            _graphView = new Views.GraphView();
            _graphController = new GraphController(_graphView, _graph);
            this.scrollPanel1.setMainControl(_graphView);
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
            _graphView = new Views.GraphView();
            _graphController = new GraphController(_graphView, _graph);
            this.scrollPanel1.setMainControl(_graphView);


            _statesController = new StatesController(this.statesView1, new List<GraphState>());
            statesView1.Controller = _statesController;


            _statesController.GraphController = _graphController;
            _graphController.StatesController = _statesController;

            //setting tab defaut page
            this.toolbar.SelectedTab = this.graphTab;
        }

        private void deleteNodeButton_Click(object sender, EventArgs e)
        {
            _graphView.requestNodeElimination();
        }



        private void saveButton_Click(object sender, EventArgs e)
        {

            /* for (int j = 0; j < 3; ++j)
             {
                 Button b = new Button();
                 b.Text = (++i).ToString();

                 this.scrollPanel2.Controls.Add(b);
                 b.Location = new System.Drawing.Point(10, 10);
                 b.Size = new System.Drawing.Size(50, 50);
             }*/
        }

        private void solvePathButton_Click(object sender, EventArgs e)
        {

            _graphView.requestPath();
        }
    }
}
