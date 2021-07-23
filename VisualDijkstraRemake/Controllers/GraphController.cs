using System.Drawing;
using System.Windows.Forms;
using VisualDijkstraRemake.Models;
using VisualDijkstraRemake.Views;

namespace VisualDijkstraRemake.Controllers
{

    public interface IGraphController
    {
        void newNode(string nodeName, Point location);
    }


    public class GraphController : IGraphController
    {
        private Graph _graph;
        private GraphView _view;

        public Graph Graph
        {
            get { return _graph; }
        }

        public GraphController(GraphView view, Graph graph)
        {
            _graph = graph;
            _view = view;

            view.Controller = this;

        }

        public void newNode(Node node)
        {
            try
            {
                _graph.AddNewNode(node);
            }
            catch (NodeAlreadyExistsException e)
            {
                MessageBox.Show("Node already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            _view.Invalidate();
        }

        public void newNode(string nodeName, Point location)
        {
            newNode(new Node(nodeName, location));
        }

        public void newEdge(Node a, Node b, int weight)
        {
            _graph.CreateNewEdge(a, b, weight);
            _view.Invalidate();
        }

        public void moveNode(Node node, Point location)
        {
            _graph.MoveNode(node, location);
            _view.Invalidate();
        }

        public void deleteNode(Node node)
        {
            _graph.deleteNode(node);
        }


    }
}
