using System.Diagnostics;
using System.Drawing;
using VisualDijkstraRemake.Models;
using VisualDijkstraRemake.Views;

namespace VisualDijkstraRemake.Controllers
{

    public interface IGraphController
    {
        void newNode(string nodeName, Point location);
    }


    class GraphController : IGraphController
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

        public void newNode(string nodeName, Point location)
        {
            Debug.WriteLine("Controller:  node created");
            _graph.createNewNode(nodeName, location);
            _view.Refresh();
        }







    }
}
