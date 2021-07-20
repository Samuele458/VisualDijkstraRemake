﻿using System.Drawing;
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

        public void newNode(Node node)
        {
            _graph.addNewNode(node);
            _view.Refresh();
        }

        public void newNode(string nodeName, Point location)
        {
            newNode(new Node(nodeName, location));
        }

        public void newEdge(Node a, Node b, int weight)
        {
            _graph.createNewEdge(a, b, weight);
            _view.Refresh();
        }

        public void moveNode(Node node, Point location)
        {
            _graph.moveNode(node, location);
            _view.Refresh();
        }







    }
}