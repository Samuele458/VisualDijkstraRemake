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
    }
}
