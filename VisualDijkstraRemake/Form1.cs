using System.Windows.Forms;
using VisualDijkstraRemake.Controllers;
using VisualDijkstraRemake.Models;

namespace VisualDijkstraRemake
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Graph graphModel = new Graph();
            GraphController graphController = new GraphController(this.graphPictureBox, graphModel);

            Node a = new Node("A", new System.Drawing.Point(100, 100));
            Node b = new Node("B", new System.Drawing.Point(200, 250));
            Node c = new Node("C", new System.Drawing.Point(300, 250));

            graphController.newNode(a);
            graphController.newNode(b);
            graphController.newNode(c);

            graphController.newEdge(a, b, 6);
            graphController.newEdge(c, b, 7);


        }




    }
}
