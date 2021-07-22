using System;
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
            this.scrollPanel1.setGraphView(_graphView);
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
            this.scrollPanel1.setGraphView(_graphView);

            //setting tab defaut page
            this.toolbar.SelectedTab = this.graphTab;
        }


    }
}
