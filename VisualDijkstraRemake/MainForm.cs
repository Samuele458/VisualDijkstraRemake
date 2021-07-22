using System;
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
            _graphView.requestsNewNode();
        }

        private void addEdgeButton_Click(object sender, System.EventArgs e)
        {
            _graphView.requestsNewEdge();
        }

        private void mainSplitContainer_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {

        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine((int)e.KeyChar);
            char c = e.KeyChar;
            _graphView.fetchInput(c);

            base.OnKeyPress(e);
        }

        private void newGraphButton_Click_1(object sender, System.EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _graph = Utils.GraphUtils.loadGraphFromXMLFile(@"C:\Users\Yankoo\Desktop\aaaa.xml");
            _graphView = new Views.GraphView();
            _graphController = new GraphController(_graphView, _graph);
            this.scrollPanel1.setGraphView(_graphView);
        }
    }
}
