using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VisualDijkstraRemake.Models;
using VisualDijkstraRemake.Utils;
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

        private bool _saved;
        private string _filenameToSave;

        public bool IsSaved
        {
            get { return _saved; }
        }

        public IStatesController StatesController { get; set; }

        public Graph Graph
        {
            get { return _graph; }
        }

        public GraphController(GraphView view, Graph graph)
        {
            _graph = graph;
            _view = view;

            _saved = false;
            _filenameToSave = "";

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

        public void evaluatePath(Node nodeA, Node nodeB)
        {
            Debug.WriteLine("Finding path from " + nodeA.Name + "  ->  " + nodeB.Name);
            IPathFinder solver = new Dijkstra(_graph);
            List<GraphState> states = solver.Solve(nodeA, nodeB);


            Debug.WriteLine("StatesController is not null");
            StatesController.setStates(states);

        }


        public void clearStates()
        {
            if (StatesController != null)
            {
                StatesController.clearStates();
            }

            _graph.ClearState();
        }

        public void setState(GraphState state)
        {
            _graph.setState(state);
            _view.Refresh();
        }

        public void save()
        {
            if (_filenameToSave == "")
            {
                saveAs();
            }
            else
            {

            }
        }

        public void saveAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json |*.json|XML |*.xml";
            saveFileDialog.Title = "Save graph file";
            saveFileDialog.ShowDialog();

            Debug.WriteLine("FIle: \"" + saveFileDialog.FileName + "\"");

            if (saveFileDialog.FileName != "")
            {
                string filename = saveFileDialog.FileName;

                Regex jsonRegex = new Regex(@"^.*\.json$");
                Regex xmlRegex = new Regex(@"^.*\.xml$");


                if (jsonRegex.Match(filename).Success)
                {
                    GraphUtils.saveGraphToJSONFile(_graph, filename);
                }
                else if (xmlRegex.Match(filename).Success)
                {
                    GraphUtils.saveGraphToXMLFile(_graph, filename);
                }
                else
                {
                    MessageBox.Show("Invalid file format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void load()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open graph file";
            openFileDialog.Filter = "Json |*.json|XML |*.xml";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                string filename = openFileDialog.FileName;

                Regex jsonRegex = new Regex(@"^.*\.json$");
                Regex xmlRegex = new Regex(@"^.*\.xml$");

                if (jsonRegex.Match(filename).Success)
                {
                    _graph = GraphUtils.loadGraphFromJSONFile(filename);
                }
                else if (xmlRegex.Match(filename).Success)
                {
                    _graph = GraphUtils.loadGraphFromXMLFile(filename);
                }
                else
                {
                    MessageBox.Show("Invalid file format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            _view.Refresh();
        }

    }
}
