using System.Collections.Generic;
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
        void NewNode(string nodeName, Point location);
    }


    public class GraphController : IGraphController
    {
        private Graph _graph;
        private readonly GraphView _view;

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
            set { _graph = value; }
        }

        public GraphController(GraphView view, Graph graph)
        {
            _graph = graph;
            _view = view;

            _saved = true;
            _filenameToSave = "";

            view.Controller = this;

        }

        public void NewNode(Node node)
        {
            try
            {
                _graph.AddNewNode(node);
                Logger.log.Info("New node \"" + node.Name + "\" added.");
            }
            catch (NodeAlreadyExistsException)
            {
                MessageBox.Show("Node already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            _saved = false;
            _view.Invalidate();
        }

        public void NewNode(string nodeName, Point location)
        {
            NewNode(new Node(nodeName, location));
        }

        public void NewEdge(Node a, Node b, int weight)
        {
            try
            {
                _graph.CreateNewEdge(a, b, weight);
                Logger.log.Info("New edge between " + a.Name + " and " + b.Name + " added. Weight: " + weight);
            }
            catch (DuplicatedEdgeException) { }
            catch (DuplicatedNodeException) { }
            _view.Invalidate();
            _saved = false;
        }

        public void MoveNode(Node node, Point location)
        {
            _graph.MoveNode(node, location);
            _saved = false;
            _view.Invalidate();
        }

        public void DeleteNode(Node node)
        {
            _graph.DeleteNode(node);
            Logger.log.Info("\"" + node.Name + "\" node deleted.");
            _saved = false;
        }

        public void EvaluatePath(Node nodeA, Node nodeB)
        {
            IPathFinder solver = new Dijkstra(_graph);
            List<GraphState> states = solver.Solve(nodeA, nodeB);


            StatesController.setStates(states);

        }


        public void ClearStates()
        {
            if (StatesController != null)
            {
                StatesController.clearStates();
            }

            _graph.ClearState();
        }

        public void SetState(GraphState state)
        {
            _graph.SetState(state);
            _view.Refresh();
        }

        public void Save()
        {
            if (_filenameToSave == "")
            {
                SaveAs();
            }
            else
            {
                Regex jsonRegex = new Regex(@"^.*\.json$");
                Regex xmlRegex = new Regex(@"^.*\.xml$");


                if (jsonRegex.Match(_filenameToSave).Success)
                {
                    GraphUtils.saveGraphToJSONFile(_graph, _filenameToSave);
                    _saved = true;
                }
                else if (xmlRegex.Match(_filenameToSave).Success)
                {
                    GraphUtils.saveGraphToXMLFile(_graph, _filenameToSave);
                    _saved = true;
                }
                else
                {
                    SaveAs();
                }
            }
        }

        public void SaveAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json |*.json|XML |*.xml";
            saveFileDialog.Title = "Save graph file";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                string filename = saveFileDialog.FileName;

                Regex jsonRegex = new Regex(@"^.*\.json$");
                Regex xmlRegex = new Regex(@"^.*\.xml$");


                if (jsonRegex.Match(filename).Success)
                {
                    GraphUtils.saveGraphToJSONFile(_graph, filename);
                    _saved = true;
                    _filenameToSave = filename;
                }
                else if (xmlRegex.Match(filename).Success)
                {
                    GraphUtils.saveGraphToXMLFile(_graph, filename);
                    _saved = true;
                    _filenameToSave = filename;
                }
                else
                {
                    MessageBox.Show("Invalid file format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Load()
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
                    _filenameToSave = filename;
                }
                else if (xmlRegex.Match(filename).Success)
                {
                    _graph = GraphUtils.loadGraphFromXMLFile(filename);
                    _filenameToSave = filename;
                }
                else
                {
                    MessageBox.Show("Invalid file format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            _view.Refresh();
        }

        public DialogResult AskToSave()
        {
            DialogResult result = MessageBox.Show("Save your changes before exit?", "Save changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                Save();
            }

            return result;
        }

    }
}
