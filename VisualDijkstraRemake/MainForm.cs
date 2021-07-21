using System.Windows.Forms;
using VisualDijkstraRemake.Controllers;
using VisualDijkstraRemake.Models;
using VisualDijkstraRemake.Views;

namespace VisualDijkstraRemake
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


            this.KeyPreview = true;


            /*
Node a = new Node("A", new System.Drawing.Point(100, 100));
Node b = new Node("B", new System.Drawing.Point(200, 250));
Node c = new Node("C", new System.Drawing.Point(300, 250));

graphController.newNode(a);
graphController.newNode(b);
graphController.newNode(c);

graphController.newEdge(a, b, 6);
graphController.newEdge(c, b, 7);

Utils.GraphUtils.saveGraphToXMLFile(graphModel, @"C:\Users\Yankoo\Desktop\aaaa.xml");
*/

        }

        private void newGraphButton_Click(object sender, System.EventArgs e)
        {
            Graph graphModel = Utils.GraphUtils.loadGraphFromXMLFile(@"C:\Users\Yankoo\Desktop\aaaa.xml");
            GraphView view = new Views.GraphView();
            GraphController graphController = new GraphController(view, graphModel);
            this.scrollPanel1.setGraphView(view);
            view.setScrollBox(this.scrollPanel1);
        }
    }
}
